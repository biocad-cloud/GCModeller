﻿#Region "Microsoft.VisualBasic::8643764bf668da8120f96aad46edd156, ..\GCModeller\data\RegulonDatabase\Regprecise\WebServices\WebParser\TranscriptionFactors.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Xml.Serialization
Imports SMRUCC.genomics.SequenceModel
Imports SMRUCC.genomics.DatabaseServices.Regprecise.WebServices
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Linq

Namespace Regprecise

    ''' <summary>
    ''' [Regprecise database] [Collections of regulogs classified by transcription factors]
    ''' Each transcription factor collection organizes all reconstructed regulogs for a given set of orthologous
    ''' regulators across different taxonomic groups of microorganisms. These collections represent regulons for
    ''' a selected subset of transcription factors. The collections include both widespread transcription factors
    ''' such as NrdR, LexA, and Zur, that are present in more than 25 diverse taxonomic groups of Bacteria, and
    ''' narrowly distributed transcription factors such as Irr and PurR. The TF regulon collections are valuable
    ''' for comparative and evolutionary analysis of TF binding site motifs and regulon content for orthologous
    ''' transcription factors.
    ''' </summary>
    ''' <remarks></remarks>
    '''
    <XmlRoot("TranscriptionFactors", Namespace:="http://regprecise.lbl.gov/RegPrecise/")>
    Public Class TranscriptionFactors : Inherits ITextFile

        <XmlElement> Public Property BacteriaGenomes As BacteriaGenome()
        <XmlAttribute("Database.UpdateTime")>
        Public Property DownloadTime As String

        Public Overrides Function Save(Optional FilePath As String = "", Optional Encoding As Encoding = Nothing) As Boolean
            Return Me.GetXml.SaveTo(getPath(FilePath), Encoding)
        End Function

        Public Function InsertRegulog(Family As String,
                                      Bacteria As String,
                                      RegulatorSites As FASTA.FastaFile,
                                      RegulatorId As String) As Boolean
            Dim BacteriaGenome As BacteriaGenome = GetBacteriaGenomeProfile(Bacteria)

            If BacteriaGenome Is Nothing Then '不存在这条记录，则插入新的记录
                Dim Regulog = New Regulon With {
                    .Regulators = {CreateRegulator(Family, Bacteria, RegulatorSites, RegulatorId)}
                }
                BacteriaGenome = New BacteriaGenome With {
                    .BacteriaGenome = New JSONLDM.genome With {
                        .name = Bacteria
                    }
                }
                BacteriaGenome.Regulons = Regulog
                BacteriaGenomes.Add(BacteriaGenome)

                Return True
            End If

            Dim Regulator = (From tf As Regulator In BacteriaGenome.Regulons.Regulators
                             Where String.Equals(tf.LocusTag.Key, RegulatorId, StringComparison.OrdinalIgnoreCase)
                             Select tf).FirstOrDefault
            If Regulator Is Nothing Then
                Regulator = CreateRegulator(Family, Bacteria, RegulatorSites, RegulatorId)
                BacteriaGenome.Regulons.Regulators = Regulator.Join(BacteriaGenome.Regulons.Regulators).ToArray
            Else
                Dim RegulatorySites = (From FastaObject As FastaReaders.Site
                                       In FastaReaders.Site.CreateObject(RegulatorSites)
                                       Select FastaObject.ToFastaObject).ToArray
                Regulator.RegulatorySites = {RegulatorySites, Regulator.RegulatorySites}.MatrixToVector
            End If

            Return True
        End Function

        Public Function GetBacteriaGenomeProfile(SpeciesName As String, Optional FuzzyMatch As Boolean = False) As BacteriaGenome
            Dim LQuery = (From Bacteria As BacteriaGenome
                          In Me.BacteriaGenomes.AsParallel
                          Where String.Equals(SpeciesName, Bacteria.BacteriaGenome.name, StringComparison.OrdinalIgnoreCase)
                          Select Bacteria).FirstOrDefault

            If Not LQuery Is Nothing Then Return LQuery

            If FuzzyMatch Then
                LQuery = (From Bacteria As BacteriaGenome
                          In BacteriaGenomes.AsParallel
                          Where SpeciesName.FuzzyMatching(Bacteria.BacteriaGenome.name)
                          Select Bacteria).FirstOrDefault
                Return LQuery
            Else
                Return Nothing
            End If
        End Function

        Public Function GetRegulatorId(locus_tag As String, MotifPosition As Integer) As String
            For Each Genome As BacteriaGenome In BacteriaGenomes
                Dim LQuery = (From Regulator As Regulator In Genome.Regulons.Regulators
                              Where Not Regulator.GetMotifSite(locus_tag, MotifPosition) Is Nothing
                              Select Regulator).FirstOrDefault
                If Not LQuery Is Nothing Then
                    Return LQuery.LocusTag.Key
                End If
            Next

            Return ""
        End Function

        ''' <summary>
        ''' 相较于<see cref="GetRegulatorId"/>方法，其只是获取得到的第一个调控因子的编号，推荐使用这个方法来获取完整的调控因子的信息
        ''' </summary>
        ''' <param name="trace">locus_tag:position</param>
        ''' <returns></returns>
        Public Function GetRegulators(trace As String) As Regulator()
            For Each genome As BacteriaGenome In BacteriaGenomes
                Dim LQuery As Regulator() = (From Regulator As Regulator In genome.Regulons.Regulators
                                             Where Not Regulator.GetMotifSite(trace) Is Nothing
                                             Select Regulator).ToArray
                If Not LQuery.IsNullOrEmpty Then
                    Return LQuery
                End If
            Next

            Return Nothing
        End Function

        Public Shared Function Load(File As String) As TranscriptionFactors
            Dim XmlFile = File.LoadXml(Of TranscriptionFactors)()
            XmlFile.FilePath = File
            Return XmlFile
        End Function

        Public Overloads Shared Widening Operator CType(FilePath As String) As TranscriptionFactors
            Return TranscriptionFactors.Load(FilePath)
        End Operator

        Public Function Export_TFBSInfo() As FASTA.FastaFile
            Dim TFBS_sites = (From Regulator As Regulator In Me.ListAllRegulators()
                              Where Regulator.Type = Regulator.Types.TF
                              Select (From site In Regulator.RegulatorySites
                                      Select RegulatorId = Regulator.LocusTag.Key,
                                          Regulator.Family,
                                          Species = Strings.Split(Regulator.Regulog.Key, " - ").Last,
                                          Tfbs_siteInfo = site).ToArray).ToArray.MatrixToVector
            Dim LQuery = (From Tfbs As Integer
                          In TFBS_sites.Sequence.AsParallel
                          Let SiteInfo = TFBS_sites(Tfbs)
                          Select GenerateFastaData(SiteInfo.Tfbs_siteInfo,
                                                   SiteInfo.Family,
                                                   SiteInfo.Species,
                                                   lcl:=Tfbs,
                                                   Regulator:=SiteInfo.RegulatorId)).ToArray
            Return New FASTA.FastaFile(LQuery)
        End Function

        Public Function ListAllRegulators() As Regulator()
            Dim LQuery = (From BacteriaGenome As BacteriaGenome
                          In Me.BacteriaGenomes.AsParallel
                          Select BacteriaGenome.Regulons.Regulators).ToArray
            Return LQuery.MatrixToVector
        End Function

        ''' <summary>
        ''' 选择所有的调控因子请使用<see cref="Get_Regulators"></see>
        ''' </summary>
        ''' <param name="Type"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Get_Regulators(Type As Regulator.Types) As Regulator()
            Dim LQuery = (From genome As BacteriaGenome
                          In Me.BacteriaGenomes.AsParallel
                          Select genome.Regulons.Regulators).ToArray
            Return (From reg As Regulator
                    In LQuery.MatrixAsIterator.AsParallel
                    Where reg.Type = Type
                    Select reg).ToArray
        End Function

        ''' <summary>
        ''' 生成映射{site, TF()}
        ''' </summary>
        ''' <returns></returns>
        Public Function BuildRegulatesHash() As Dictionary(Of String, String())
            Dim LQuery = (From g As BacteriaGenome
                          In Me.BacteriaGenomes
                          Where Not g.Regulons Is Nothing
                          Select g.Regulons.Regulators.ToArray(Function(x) (From site As Regtransbase.WebServices.FastaObject
                                                                            In x.RegulatorySites
                                                                            Select uid = $"{site.LocusTag}:{site.Position}",
                                                                                x.LocusId)).MatrixAsIterator).MatrixAsIterator
            Dim Groups = (From x In LQuery
                          Select x
                          Group x By x.uid Into Group) _
                               .ToDictionary(Function(x) x.uid,
                                             Function(x) x.Group.ToArray(Function(s) s.LocusId))
            Return Groups
        End Function
    End Class
End Namespace
