﻿#Region "Microsoft.VisualBasic::78acc9fbdafc907d13c18cb7ef2ec06f, Compiler\Extensions.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xie (genetics@smrucc.org)
'       xieguigang (xie.guigang@live.com)
' 
' Copyright (c) 2018 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
' 
' 
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
' 
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
' 
' You should have received a copy of the GNU General Public License
' along with this program. If not, see <http://www.gnu.org/licenses/>.



' /********************************************************************************/

' Summaries:

' Module Extensions
' 
'     Function: ToMarkup, ToTabular
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Text.Xml.Models
Imports SMRUCC.genomics.Assembly.NCBI.GenBank
Imports SMRUCC.genomics.Assembly.NCBI.GenBank.TabularFormat.ComponentModels
Imports SMRUCC.genomics.ComponentModel.EquaionModel.DefaultTypes
Imports SMRUCC.genomics.Data
Imports SMRUCC.genomics.Data.Regprecise
Imports SMRUCC.genomics.GCModeller.Assembly.GCMarkupLanguage.v2
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Model
Imports Excel = Microsoft.VisualBasic.MIME.Office.Excel.File
Imports XmlReaction = SMRUCC.genomics.GCModeller.Assembly.GCMarkupLanguage.v2.Reaction

Public Module Extensions

    <Extension> Public Function ToMarkup(model As CellularModule, genome As GBFF.File, KEGG As RepositoryArguments, regulations As RegulationFootprint()) As VirtualCell
        Dim KOgenes As Dictionary(Of String, CentralDogma) = model _
            .Genotype _
            .CentralDogmas _
            .Where(Function(process)
                       Return Not process.IsRNAGene AndAlso Not process.orthology.StringEmpty
                   End Function) _
            .ToDictionary(Function(term) term.geneID)
        Dim enzymes As Enzyme() = model _
            .Regulations _
            .Where(Function(process)
                       Return process.type = Processes.MetabolicProcess
                   End Function) _
            .createEnzymes(KOgenes) _
            .ToArray
        Dim KOfunc As Dictionary(Of String, CentralDogma()) = KOgenes _
            .Values _
            .GroupBy(Function(proc) proc.orthology) _
            .ToDictionary(Function(KO) KO.Key,
                          Function(g) g.ToArray)

        Return New VirtualCell With {
            .Taxonomy = model.Taxonomy,
            .Genome = New Genome With {
                .genes = genome.getGenes.ToArray,
                .regulations = regulations _
                    .getTFregulations _
                    .ToArray
            },
            .MetabolismStructure = New MetabolismStructure With {
                .Reactions = model _
                    .Phenotype _
                    .fluxes _
                    .Select(Function(r)
                                Return New XmlReaction With {
                                    .ID = r.ID,
                                    .name = r.name,
                                    .Equation = r.GetEquationString
                                }
                            End Function) _
                    .ToArray,
                .Enzymes = enzymes,
                .Compounds = .Reactions _
                             .getCompounds(KEGG.GetCompounds) _
                             .ToArray,
                .Pathways = KEGG.GetPathways _
                    .PathwayMaps _
                    .Select(Function(map)
                                Dim enzymeUnits = map.KEGGOrthology _
                                    .Terms _
                                    .SafeQuery _
                                    .Where(Function(term)
                                               Return KOfunc.ContainsKey(term.name)
                                           End Function) _
                                    .Select(Function(term)
                                                Dim enzymeUnit = KOfunc(term.name) _
                                                    .Select(Function(protein)
                                                                Return New [Property] With {
                                                                    .name = protein.polypeptide,
                                                                    .Comment = protein.geneID,
                                                                    .value = term.name
                                                                }
                                                            End Function) _
                                                    .ToArray
                                                Return enzymeUnit
                                            End Function) _
                                    .IteratesALL _
                                    .ToArray

                                Return New Pathway With {
                                    .ID = map.KOpathway,
                                    .name = map.name,
                                    .enzymes = enzymeUnits
                                }
                            End Function) _
                    .Where(Function(map) Not map.enzymes.IsNullOrEmpty) _
                    .ToArray
            }
        }
    End Function

    <Extension>
    Private Iterator Function getGenes(genome As GBFF.File) As IEnumerable(Of Gene)
        For Each gene As GeneBrief In genome.GbffToPTT(ORF:=False).GeneObjects
            Yield New Gene With {
                .left = gene.Location.Left,
                .right = gene.Location.Right,
                .locus_tag = gene.Synonym,
                .product = gene.Product,
                .protein_id = gene.PID,
                .strand = gene.Location.Strand.GetBriefCode
            }
        Next
    End Function

    <Extension>
    Private Iterator Function getTFregulations(regulations As RegulationFootprint()) As IEnumerable(Of TranscriptionRegulation)
        For Each reg As RegulationFootprint In regulations
            Yield New TranscriptionRegulation With {
                .biological_process = reg.biological_process,
                .distance = reg.distance,
                .effector = reg.effector,
                .mode = reg.mode,
                .regulator = reg.regulator,
                .target = reg.regulated,
                .motif = New Motif With {
                    .family = reg.family,
                    .left = reg.motif.Left,
                    .right = reg.motif.Right,
                    .strand = reg.motif.Strand.GetBriefCode,
                    .sequence = reg.sequenceData
                }
            }
        Next
    End Function

    <Extension>
    Private Iterator Function getCompounds(reactions As IEnumerable(Of XmlReaction), compounds As CompoundRepository) As IEnumerable(Of Compound)
        Dim allCompoundId$() = reactions _
            .Select(Function(r)
                        Return Equation.TryParse(r.Equation) _
                                       .GetMetabolites _
                                       .Select(Function(compound) compound.ID)
                    End Function) _
            .IteratesALL _
            .Distinct _
            .ToArray

        For Each id As String In allCompoundId.Where(Function(cid) compounds.Exists(cid))
            Dim keggModel = compounds.GetByKey(id).Entity

            Yield New Compound With {
                .ID = id,
                .name = keggModel _
                    .CommonNames _
                    .ElementAtOrDefault(0, keggModel.Formula),
                .otherNames = keggModel _
                    .CommonNames _
                    .SafeQuery _
                    .Skip(1) _
                    .ToArray
            }
        Next
    End Function

    <Extension>
    Private Iterator Function createEnzymes(metabolicProcess As IEnumerable(Of Regulation), KOgenes As Dictionary(Of String, CentralDogma)) As IEnumerable(Of Enzyme)
        For Each catalysis As IGrouping(Of String, Regulation) In metabolicProcess.GroupBy(Function(c) c.regulator)
            Yield New Enzyme With {
                .geneID = catalysis.Key,
                .catalysis = catalysis _
                    .Select(Function(reg)
                                Return New Catalysis With {
                                    .coefficient = reg.effects,
                                    .reaction = reg.process,
                                    .comment = reg.name
                                }
                            End Function) _
                    .ToArray,
                .KO = KOgenes.TryGetValue(.geneID).orthology
            }
        Next
    End Function

    <Extension> Public Function ToTabular(model As CellularModule) As Excel

    End Function
End Module

