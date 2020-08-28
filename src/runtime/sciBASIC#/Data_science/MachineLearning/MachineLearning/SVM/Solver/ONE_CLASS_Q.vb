﻿
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Text
Imports stdNum = System.Math

Namespace SVM

    Friend Class ONE_CLASS_Q
        Inherits Kernel

        Private ReadOnly cache As Cache
        Private ReadOnly QD As Double()

        Public Sub New(ByVal prob As Problem, ByVal param As Parameter)
            MyBase.New(prob.Count, prob.X, param)
            cache = New Cache(prob.Count, CLng(param.CacheSize) * (1 << 20))
            QD = New Double(prob.Count - 1) {}

            For i = 0 To prob.Count - 1
                QD(i) = KernelFunction(i, i)
            Next
        End Sub

        Public Overrides Function GetQ(ByVal i As Integer, ByVal len As Integer) As Single()
            Dim data As Single() = Nothing
            Dim start As i32 = 0
            Dim j As Integer

            If (start = cache.GetData(i, data, len)) < len Then
                For j = start To len - 1
                    data(j) = CSng(KernelFunction(i, j))
                Next
            End If

            Return data
        End Function

        Public Overrides Function GetQD() As Double()
            Return QD
        End Function

        Public Overrides Sub SwapIndex(ByVal i As Integer, ByVal j As Integer)
            cache.SwapIndex(i, j)
            MyBase.SwapIndex(i, j)

            Do
                Dim __ = QD(i)
                QD(i) = QD(j)
                QD(j) = __
            Loop While False
        End Sub
    End Class

End Namespace