﻿Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Dynamics.Core
Imports SMRUCC.genomics.GCModeller.ModellingEngine.Model

Namespace Engine.ModelLoader

    ''' <summary>
    ''' 先构建一般性的中心法则过程
    ''' 在这里面包含所有类型的RNA转录
    ''' 以及蛋白序列的翻译
    ''' </summary>
    Public Class CentralDogmaFluxLoader : Inherits FluxLoader

        Public Sub New(loader As Loader)
            Call MyBase.New(loader)
        End Sub

        Public Overrides Iterator Function CreateFlux(cell As CellularModule) As IEnumerable(Of Channel)
            Dim templateDNA As Variable()
            Dim productsRNA As Variable()
            Dim templateRNA As Variable()
            Dim productsPro As Variable()
            Dim rnaMatrix = cell.Genotype.RNAMatrix.ToDictionary(Function(r) r.geneID)
            Dim proteinMatrix = cell.Genotype.ProteinMatrix.ToDictionary(Function(r) r.proteinID)

            For Each cd As CentralDogma In cell.Genotype.centralDogmas
                ' if the gene template mass value is set to ZERO
                ' that means no transcription activity that it will be
                ' A deletion mutation was created
                Call MassTable.AddNew(cd.geneID)
                Call MassTable.AddNew(cd.RNA.Name)

                If Not cd.polypeptide Is Nothing Then
                    Call MassTable.AddNew(cd.polypeptide)
                End If

                templateDNA = transcriptionTemplate(cd.geneID, rnaMatrix)
                productsRNA = {
                    MassTable.variable(cd.RNA.Name)
                }

                ' 转录和翻译的反应过程都是不可逆的

                ' 翻译模板过程只针对CDS基因
                If Not cd.polypeptide Is Nothing Then
                    templateRNA = translationTemplate(cd.RNA.Name, proteinMatrix)
                    productsPro = {
                        MassTable.variable(cd.polypeptide)
                    }

                    Yield New Channel(templateRNA, productsPro) With {
                        .ID = cd.DoCall(AddressOf Loader.GetTranslationId),
                        .forward = New Controls With {.baseline = 10},
                        .reverse = New Controls With {.baseline = 0},
                        .bounds = New Boundary With {.forward = 100, .reverse = 0}
                    }
                End If

                Yield New Channel(templateDNA, productsRNA) With {
                    .ID = cd.DoCall(AddressOf Loader.GetTranscriptionId),
                    .forward = New Controls With {.baseline = 10},
                    .reverse = New Controls With {.baseline = 0},
                    .bounds = New Boundary With {.forward = 100, .reverse = 0}
                }
            Next
        End Function

        ''' <summary>
        ''' DNA模板加上碱基消耗
        ''' </summary>
        ''' <param name="geneID$"></param>
        ''' <param name="matrix"></param>
        ''' <returns></returns>
        Private Function transcriptionTemplate(geneID$, matrix As Dictionary(Of String, RNAComposition)) As Variable()
            Return matrix(geneID) _
                .Where(Function(i) i.Value > 0) _
                .Select(Function(base)
                            Dim baseName = loader.define.NucleicAcid(base.Name)
                            Return MassTable.variable(baseName, base.Value)
                        End Function) _
                .AsList + MassTable.template(geneID)
        End Function

        ''' <summary>
        ''' mRNA模板加上氨基酸消耗
        ''' </summary>
        ''' <param name="mRNA$"></param>
        ''' <param name="matrix"></param>
        ''' <returns></returns>
        Private Function translationTemplate(mRNA$, matrix As Dictionary(Of String, ProteinComposition)) As Variable()
            Return matrix(mRNA) _
                .Where(Function(i) i.Value > 0) _
                .Select(Function(aa)
                            Dim aaName = loader.define.AminoAcid(aa.Name)
                            Return MassTable.variable(aaName, aa.Value)
                        End Function) _
                .AsList + MassTable.template(mRNA)
        End Function
    End Class
End Namespace