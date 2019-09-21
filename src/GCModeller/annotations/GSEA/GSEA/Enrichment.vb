﻿#Region "Microsoft.VisualBasic::fd7f7ad41316496f7047ae4dd300a5a4, GSEA\GSEA\Enrichment.vb"

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

    ' Module Enrichment
    ' 
    '     Function: calcResult, Enrichment, FDRCorrection
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math
Imports Microsoft.VisualBasic.Terminal.ProgressBar
Imports F = Microsoft.VisualBasic.Math.Statistics.Hypothesis.FishersExact.FishersExactTest

''' <summary>
''' 基于Fisher Extract test算法的富集分析
''' </summary>
Public Module Enrichment

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="genome"></param>
    ''' <param name="list">需要进行富集计算分析的目标基因列表</param>
    ''' <param name="outputAll"></param>
    ''' <param name="showProgress"></param>
    ''' <returns></returns>
    <Extension>
    Public Iterator Function Enrichment(genome As Background,
                                        list As IEnumerable(Of String),
                                        Optional outputAll As Boolean = False,
                                        Optional isLocustag As Boolean = False,
                                        Optional showProgress As Boolean = True) As IEnumerable(Of EnrichmentResult)

        Dim doProgress As Action(Of String)
        Dim progress As ProgressBar = Nothing
        Dim tick As New ProgressProvider(genome.clusters.Length)
        Dim ETA$
        Dim termResult As New Value(Of EnrichmentResult)
        Dim genes As Integer

        If showProgress Then
            progress = New ProgressBar("Do enrichment...")
            doProgress = Sub(id)
                             ETA = $"{id}.... ETA: {tick.ETA(progress.ElapsedMilliseconds)}"
                             progress.SetProgress(tick.StepProgress, ETA)
                         End Sub
        Else
            doProgress = Sub()
                             ' Do Nothing
                         End Sub
        End If

        If genome.size <= 0 Then
            genes = genome.clusters _
                .Select(Function(c) c.members) _
                .IteratesALL _
                .Distinct _
                .Count
        Else
            genes = genome.size
        End If

        With list.ToArray
            For Each cluster As Cluster In genome.clusters
                Dim enriched$() = cluster.Intersect(.ByRef, isLocustag).ToArray

                Call doProgress(cluster.ID)

                If Not (termResult = cluster.calcResult(enriched, .Length, genes, outputAll)) Is Nothing Then
                    Yield termResult
                End If
            Next
        End With

        If Not progress Is Nothing Then
            progress.Dispose()
        End If
    End Function

    ''' <summary>
    ''' 计算基因集合的功能富集结果
    ''' </summary>
    ''' <param name="cluster">根据我们的先验知识所创建的一个基因集合，一般为KEGG代谢途径或者GO词条</param>
    ''' <param name="enriched">在当前的基因集合中与我们所给定的基因列表所产生交集的基因id的列表，即我们的差异基因列表中属于当前的代谢途径的基因的列表</param>
    ''' <param name="inputSize">输入的原始的通过实验所获取得到的基因列表的大小，即我们的差异基因的id的数量</param>
    ''' <param name="genes">背景基因组中的总的基因数量</param>
    ''' <param name="outputAll"></param>
    ''' <returns></returns>
    <Extension>
    Private Function calcResult(cluster As Cluster, enriched$(), inputSize%, genes%, outputAll As Boolean) As EnrichmentResult
        ' 我们的差异基因列表中，属于目标代谢途径的基因的数量
        Dim a% = enriched.Length
        ' 在目标基因组中，属于当前的代谢途径中的基因的数量
        Dim b% = cluster.members.Length
        ' 在我们的差异基因列表中，不属于当前的代谢途径的基因的数量
        Dim c% = inputSize - a
        ' 在目标基因组中，不属于当前的代谢途径中的基因的数量
        Dim d% = genes - b
        ' 最后将得到的个数变量，进行F双尾检验
        Dim pvalue# = F.FishersExact(a, b, c, d).two_tail_pvalue
        Dim score# = a / b

        If (pvalue.IsNaNImaginary OrElse enriched.Length = 0) AndAlso Not outputAll Then
            Return Nothing
        End If

        Return New EnrichmentResult With {
            .term = cluster.ID,
            .name = cluster.names,
            .description = cluster.description,
            .geneIDs = enriched,
            .pvalue = pvalue,
            .score = score,
            .cluster = b,
            .enriched = $"{a}/{c}"
        }
    End Function

    ''' <summary>
    ''' 进行计算结果的假阳性FDR控制计算
    ''' </summary>
    ''' <param name="enrichments">根据我们所提供的基因列表，对每一个代谢途径的富集计算结果的集合</param>
    ''' <returns></returns>
    <Extension>
    Public Function FDRCorrection(enrichments As IEnumerable(Of EnrichmentResult)) As EnrichmentResult()
        With enrichments.Shadows
            !FDR = !Pvalue.FDR
            Return .ToArray
        End With
    End Function
End Module
