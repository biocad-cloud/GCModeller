﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Math.Statistics.Hypothesis
Imports Microsoft.VisualBasic.Terminal.STDIO
Imports SMRUCC.genomics.Analysis.PFSNet.DataStructure
Imports SMRUCC.genomics.Analysis.PFSNet.R

<HideModuleName> Module estimatetdistFunction

    Public Function estimatetdist(d1 As DataFrameRow(),
                                  d2 As DataFrameRow(),
                                  ggi As GraphEdge(),
                                  b As Double,
                                  t1 As Double,
                                  t2 As Double,
                                  n As Integer) As Double()
        ' total<-cbind(d1,d2)
        Dim total As DataFrameRow() = cbind(d1, d2).ToArray
        ' tdistribution<-c()
        Dim tdistribution As New List(Of Double)

        For i As Integer = 0 To n - 1
            cat(".")
            tdistribution += total.estimatetdistLoop(ggi, d1, d2, t1, t2, b)

            If tdistribution > 1000 Then
                Exit For
            End If
        Next

        Return tdistribution.ToArray
    End Function

    <Extension>
    Private Function estimatetdistLoop(total As DataFrameRow(), ggi As GraphEdge(), d1 As DataFrameRow(), d2 As DataFrameRow(), t1#, t2#, b#) As Double()
        Dim samplevector = Sample(total.First.samples - 1, d1.First.samples - 1)
        Dim expr1o = DataFrameRow.TakeSamples(total, samplevector, False)
        Dim expr2o = DataFrameRow.TakeSamples(total, samplevector, True)
        Dim w1matrix1 = computew1(expr1o, theta1:=t1, theta2:=t2)
        Dim w1matrix2 = computew1(expr2o, theta1:=t1, theta2:=t2)

        Dim genelist1 As Index(Of String) = computegenelist(w1matrix1, beta:=b)
        Dim genelist2 As Index(Of String) = computegenelist(w1matrix2, beta:=b)

        'ggi_mask <- apply(ggi, 1, func <- function(i){
        ' 	if ((i[2] %in% genelist1$gl) && (i[3] %in% genelist1$gl))
        ' 		TRUE
        ' 	else FALSE
        '})
        Dim ggi_mask = ggi.ggi_mask(genelist1)
        Dim masked_ggi As GraphEdge() = ggi.getMasked_ggi(ggi_mask)
        Dim ccs = masked_ggi.ccs(w1matrix1, w1matrix2).ToArray

        '	ccs <- unlist(ccs, recursive=FALSE)

        Dim pscore = sapply_pscore(ccs, w1matrix1)
        Dim nscore = sapply_nscore(ccs, w1matrix1)

        Dim statistics As Double() = rep(False, ccs.Length)

        For p As Integer = 0 To ccs.Length - 1
            Dim x = pscore(p), y = nscore(p)
            Dim ttest = t.Test(x, y)

            statistics(p) = ttest.TestValue
        Next

        Return statistics
    End Function
End Module