﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.MachineLearning.NeuralNetwork.Activations
Imports Microsoft.VisualBasic.Math.LinearAlgebra
Imports Microsoft.VisualBasic.Serialization.JSON

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

        Sub New(size%, active As IActivationFunction, Optional input As Layer = Nothing)
            Neurons = New Neuron(size - 1) {}

            If input Is Nothing Then
                For i As Integer = 0 To size - 1
                    Neurons(i) = New Neuron(active)
                Next
            Else
                For i As Integer = 0 To size - 1
                    Neurons(i) = New Neuron(input.Neurons)
                Next
            End If
        End Sub

        Public Sub Input(data As Double())
            For i As Integer = 0 To Neurons.Length - 1
                Neurons(i).Value = data(i)
            Next
        End Sub

        Public Sub UpdateWeights(learnRate#, momentum#)
            For Each neuron As Neuron In Neurons
                Call neuron.UpdateWeights(learnRate, momentum)
            Next
        End Sub

        Public Sub CalculateValue()
            For Each neuron As Neuron In Neurons
                Call neuron.CalculateValue()
            Next
        End Sub

        Public Sub CalculateGradient(targets As Double())
            For i As Integer = 0 To targets.Length - 1
                Neurons(i).CalculateGradient(targets(i))
            Next
        End Sub

        Public Sub CalculateGradient()
            For Each neuron As Neuron In Neurons
                Call neuron.CalculateGradient()
            Next
        End Sub

        Public Overrides Function ToString() As String
            Return $"{Neurons.Length} neurons => {Output.AsVector.ToString}"
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

    ''' <summary>
    ''' 隐藏层,由多个神经元层所构成的
    ''' 
    ''' ##### 20181212
    ''' 
    ''' 请注意,这个隐藏层的大小虽然可以是任意规模的,但是并不是越大越好的
    ''' 当隐藏层越大的话,会导致训练的效率降低,并且预测能力也会下降
    ''' 如果问题比较简单的话,三层隐藏层已经足够了
    ''' 
    ''' 一般来说,隐藏层之中每一层的神经元的数量应该要大于输入和输出的节点数的最大值.
    ''' </summary>
    Public Class HiddenLayers : Implements IEnumerable(Of Layer)

        Public ReadOnly Property Layers As Layer()
        Public ReadOnly Property Size As Integer

        ''' <summary>
        ''' 使用最后一层作为输出层
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Output As Layer
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return Layers(Size - 1)
            End Get
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="input">s神经网络的输入层会作为隐藏层的输入</param>
        ''' <param name="size%"></param>
        ''' <param name="active"></param>
        Sub New(input As Layer, size%(), active As IActivationFunction)
            Dim hiddenPortal As New Layer(size(Scan0), active, input)

            Layers = New Layer(size.Length - 1) {}
            Layers(Scan0) = hiddenPortal

            ' 在隐藏层之中,前一层神经网络会作为后面的输出
            For i As Integer = 1 To size.Length - 1
                Layers(i) = New Layer(size(i), active, input:=hiddenPortal)
                hiddenPortal = Layers(i)
            Next

            Me.Size = size.Length
        End Sub

        Public Sub ForwardPropagate()
            For Each layer As Layer In Layers
                Call layer.CalculateValue()
            Next
        End Sub

        Public Sub BackPropagate(learnRate#, momentum#)
            Dim reverse = Layers.Reverse.ToArray

            ' 因为在调用函数计算之后,值变了
            ' 所以在这里会需要使用两个for each
            ' 不然计算会出bug
            For Each revLayer As Layer In reverse
                Call revLayer.CalculateGradient()
            Next
            For Each revLayer As Layer In reverse
                Call revLayer.UpdateWeights(learnRate, momentum)
            Next
        End Sub

        Public Overrides Function ToString() As String
            Return $"{Size} hidden layers => {Layers.Select(Function(l) l.Neurons.Length).ToArray.GetJson }"
        End Function

        Public Iterator Function GetEnumerator() As IEnumerator(Of Layer) Implements IEnumerable(Of Layer).GetEnumerator
            For Each layer As Layer In Layers
                Yield layer
            Next
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function
    End Class
End Namespace