﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Language
Imports SMRUCC.genomics.Analysis.SequenceTools.SequencePatterns.Abstract
Imports SMRUCC.genomics.SequenceModel.FASTA
Imports Microsoft.VisualBasic.DataMining.KMeans
Imports SMRUCC.genomics.Analysis.SequenceTools.MSA

Public Module Protocol

    <Extension>
    Public Iterator Function PopulateMotifs(inputs As IEnumerable(Of FastaSeq)) As IEnumerable(Of Probability)
        Dim regions As FastaSeq() = inputs.ToArray
        Dim seeds As New List(Of HSP)

        ' 先进行两两局部最优比对，得到最基本的种子
        For Each q As FastaSeq In regions
            For Each s As FastaSeq In regions.Where(Function(seq) Not seq Is q)
                seeds += pairwiseSeeding(q, s)
            Next
        Next

        ' 之后对得到的种子序列进行两两全局比对，得到距离矩阵
        Dim matrix As New List(Of DataSet)
        Dim i As int = 1
        Dim repSeq As New Dictionary(Of String, String)

        For Each q As HSP In seeds
            Dim row As New DataSet With {
                .ID = ++i,
                .Properties = New Dictionary(Of String, Double)
            }
            Dim j As int = 1

            repSeq(row.ID) = q.Consensus

            For Each s As HSP In seeds
                ' 因为在这里需要构建一个矩阵，所以自己比对自己这个情况也需要放进去了
                Dim score = RunNeedlemanWunsch.RunAlign(
                    New FastaSeq With {.SequenceData = q.Query},
                    New FastaSeq With {.SequenceData = s.Query},
                    [single]:=True,
                    echo:=False
                )

                row(++j) = score
            Next

            matrix += row
        Next

        ' 进行聚类分簇
        Dim clusters = matrix.ToKMeansModels.Kmeans(10)
        Dim motifs = clusters.GroupBy(Function(c) c.Cluster).ToArray

        ' 对聚类簇进行多重序列比对得到概率矩阵
        For Each group As IGrouping(Of String, EntityClusterModel) In motifs
            Dim MSA = group _
                .Select(Function(seq)
                            Return New FastaSeq With {
                                .SequenceData = repSeq(seq.ID)
                            }
                        End Function) _
                .MultipleAlignment

        Next
    End Function

    <Extension>
    Private Function PWM(MSA$()()) As Probability

    End Function

    Public Function pairwiseSeeding(q As FastaSeq, s As FastaSeq) As IEnumerable(Of HSP)
        Dim smithWaterman As New SmithWaterman(q.SequenceData, s.SequenceData)
        Dim result = smithWaterman.GetOutput(0.3, 6)
        Return result.HSP
    End Function

    <Extension>
    Public Function Consensus(pairwise As HSP) As String

    End Function
End Module
