﻿#Region "Microsoft.VisualBasic::485a9aea42db2663b3e965ac92891544, Data_science\MachineLearning\MachineLearning\NeuralNetwork\Models\Layer.vb"

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

'     Class Layer
' 
'         Properties: Neurons, Output
' 
'         Constructor: (+2 Overloads) Sub New
' 
'         Function: GetEnumerator, IEnumerable_GetEnumerator, ToString
' 
'         Sub: (+2 Overloads) CalculateGradient, CalculateValue, Input, UpdateWeights
' 
'     Class HiddenLayers
' 
'         Properties: Layers, Output, Size
' 
'         Constructor: (+2 Overloads) Sub New
' 
'         Function: GetAllNeurons, GetEnumerator, IEnumerable_GetEnumerator, ToString
' 
'         Sub: BackPropagate, ForwardPropagate
' 
' 
' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.MachineLearning.NeuralNetwork.Activations
Imports Microsoft.VisualBasic.Math.LinearAlgebra

Namespace NeuralNetwork

    ''' <summary>
    ''' 输入层和输出层对象,神经元节点的数量应该和实际的问题保持一致
    ''' </summary>
    Public Class Layer : Implements IEnumerable(Of Neuron)

        Public ReadOnly Property Neurons As Neuron()

        Public ReadOnly Property Output As Double()
            Get
                Return Neurons _
                    .Select(Function(n) n.Value) _
                    .ToArray
            End Get
        End Property

        ''' <summary>
        ''' 将当前层之中的所有的神经元的值都归一化为[0,1]这个区间内
        ''' </summary>
        ''' <returns></returns>
        Public Property doNormalize As Boolean

        ''' <summary>
        ''' 用于XML模型的加载操作
        ''' </summary>
        Friend Sub New(neurons As Neuron())
            Me.Neurons = neurons
        End Sub

        Sub New(size%, active As IActivationFunction, Optional input As Layer = Nothing, Optional guid As VBInteger = Nothing)
            Neurons = New Neuron(size - 1) {}

            If input Is Nothing Then
                For i As Integer = 0 To size - 1
                    Neurons(i) = New Neuron(active, guid)
                Next
            Else
                For i As Integer = 0 To size - 1
                    Neurons(i) = New Neuron(input.Neurons, active, guid)
                Next
            End If
        End Sub

        ''' <summary>
        ''' 将外界的测试数据赋值到每一个神经元的<see cref="Neuron.Value"/>之上,在这里只是进行简单的属性赋值操作
        ''' </summary>
        ''' <param name="data"></param>
        ''' <remarks>
        ''' 没有并行的必要
        ''' </remarks>
        Public Sub Input(data As Double())
            For i As Integer = 0 To _Neurons.Length - 1
                _Neurons(i).Value = data(i)
            Next
        End Sub

        ''' <summary>
        ''' 调用这个函数将会修改突触链接的权重值，这个函数只会在训练的时候被调用
        ''' </summary>
        ''' <param name="learnRate#"></param>
        ''' <param name="momentum#"></param>
        ''' <param name="parallel"></param>
        Public Sub UpdateWeights(learnRate#, momentum#, Optional parallel As Boolean = False)
            If Not parallel Then
                For Each neuron As Neuron In Neurons
                    Call neuron.UpdateWeights(learnRate, momentum)
                Next
            Else
                With Aggregate neuron As Neuron
                     In Neurons.AsParallel
                     Into Sum(neuron.UpdateWeights(learnRate, momentum))
                End With
            End If
        End Sub

        ''' <summary>
        ''' 计算输出层的结果值,即通过这个函数的调用计算出分类的结果值,结果值为``[0,1]``之间的小数
        ''' </summary>
        ''' <remarks>
        ''' 因为输出层的节点数量比较少,所以这里应该也没有并行的必要?
        ''' </remarks>
        Public Sub CalculateValue(Optional parallel As Boolean = False)
            If Not parallel Then
                For Each neuron As Neuron In Neurons
                    Call neuron.CalculateValue()
                Next
            Else
                ' 在这里将结果值赋值到一个临时的匿名变量中
                ' 来触发这个并行调用表达式
                '
                ' 2019-1-14 因为在计算的时候，取的neuron.value是上一层网络的值
                ' 只是修改当前网络的节点值
                ' 并没有修改上一层网络的任何参数
                ' 所以在这里的并行是没有问题的
                With Aggregate neuron As Neuron
                     In Neurons.AsParallel
                     Into Sum(neuron.CalculateValue)
                End With
            End If

            If doNormalize Then
                ' 将当前层之中的所有的神经元的值都归一化为[0,1]这个区间内
                Dim max = Neurons.Max(Function(n) n.Value)

                For Each neuron As Neuron In Neurons
                    neuron.Value /= max
                Next
            End If
        End Sub

        Public Sub CalculateGradient(targets As Double(), truncate As Double)
            For i As Integer = 0 To targets.Length - 1
                _Neurons(i).CalculateGradient(targets(i), truncate)
            Next
        End Sub

        Public Sub CalculateGradient(Optional parallel As Boolean = False, Optional truncate# = -1)
            If Not parallel Then
                For Each neuron As Neuron In Neurons
                    Call neuron.CalculateGradient(truncate)
                Next
            Else
                With Aggregate neuron As Neuron
                     In Neurons.AsParallel
                     Into Sum(neuron.CalculateGradient(truncate))
                End With
            End If
        End Sub

        Public Overrides Function ToString() As String
            Dim n = Output
            Dim summary$

            If n.Length > 20 Then
                summary = n.Split(15).Select(Function(l) "   " & l.Select(Function(x) x.ToString("G3")).JoinBy(vbTab)).JoinBy(vbCrLf)
                summary = $"[{vbCrLf}{summary}{vbCrLf}]"
            Else
                summary = n.AsVector.ToString
            End If

            Return $"{Neurons.Length} neurons => {summary}"
        End Function

        Public Iterator Function GetEnumerator() As IEnumerator(Of Neuron) Implements IEnumerable(Of Neuron).GetEnumerator
            For Each neuron As Neuron In Neurons
                Yield neuron
            Next
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function
    End Class
End Namespace
