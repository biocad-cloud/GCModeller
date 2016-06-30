﻿Imports System.Xml.Serialization
Imports LANS.SystemsBiology.AnalysisTools.SequenceTools.SequencePatterns
Imports LANS.SystemsBiology.AnalysisTools.SequenceTools.SequencePatterns.SequenceLogo
Imports LANS.SystemsBiology.SequenceModel.NucleotideModels
Imports LANS.SystemsBiology.SequenceModel.NucleotideModels.NucleicAcid
Imports LANS.SystemsBiology.SequenceModel.Patterns
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.Scripting.MetaData

Namespace ComponentModel

    ''' <summary>
    ''' Motif序列之中的一个位点
    ''' </summary>
    ''' <remarks></remarks>
    Public Class MotifPM : Implements ILogoResidue

        Dim _innerTable As Dictionary(Of DNA, Double)

        ''' <summary>
        ''' <see cref="DNA.dAMP"></see>碱基在这个位点之上出现的概率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property A As Double
            Get
                Return _innerTable(DNA.dAMP)
            End Get
            Set(value As Double)
                Call __setValue(DNA.dAMP, value)
            End Set
        End Property

        Private Sub __setValue(nt As DNA, value As Double)
            If _innerTable.ContainsKey(nt) Then
                Call _innerTable.Remove(nt)
            End If
            Call _innerTable.Add(nt, value)

            MostPossible = (From item In _innerTable Where item.Value > 0 Select item Order By item.Value Descending).First
        End Sub

        ''' <summary>
        ''' <see cref="DNA.dTMP"></see>碱基在这个位点之上出现的概率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property T As Double
            Get
                Return _innerTable(DNA.dTMP)
            End Get
            Set(value As Double)
                Call __setValue(DNA.dTMP, value)
            End Set
        End Property

        ''' <summary>
        ''' <see cref="DNA.dGMP"></see>碱基在这个位点之上出现的概率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property G As Double
            Get
                Return _innerTable(DNA.dGMP)
            End Get
            Set(value As Double)
                Call __setValue(DNA.dGMP, value)
            End Set
        End Property

        ''' <summary>
        ''' <see cref="DNA.dCMP"></see>碱基在这个位点之上出现的概率
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property C As Double
            Get
                Return _innerTable(DNA.dCMP)
            End Get
            Set(value As Double)
                Call __setValue(DNA.dCMP, value)
            End Set
        End Property

        Dim MostPossible As KeyValuePair(Of DNA, Double)

        <XmlAttribute> Public Property Bits As Double Implements ILogoResidue.Bits

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="s">MEME文本文件结果数据之中的概率表之中的一行文本</param>
        ''' <remarks></remarks>
        Friend Sub New(s As String)
            Dim Tokens As String() = (From tt As String In s.Split Where Not String.IsNullOrEmpty(tt) Select tt).ToArray
            Dim A = Val(Tokens(0))
            Dim T = Val(Tokens(3))
            Dim G = Val(Tokens(2))
            Dim C = Val(Tokens(1))

            _innerTable = New Dictionary(Of DNA, Double) From {
 _
                {DNA.dAMP, A},
                {DNA.dCMP, C},
                {DNA.dGMP, G},
                {DNA.dTMP, T}
            }

            MostPossible = (From item In _innerTable Where item.Value > 0 Select item Order By item.Value Descending).First
        End Sub

        Sub New()
            _innerTable = New Dictionary(Of DNA, Double)
        End Sub

        Public Sub New(A As Double, T As Double, G As Double, C As Double)
            _innerTable = New Dictionary(Of DNA, Double) From {
 _
                {DNA.dAMP, A},
                {DNA.dCMP, C},
                {DNA.dGMP, G},
                {DNA.dTMP, T}
            }

            MostPossible = (From item In _innerTable Where item.Value > 0 Select item Order By item.Value Descending).First
        End Sub

        ''' <summary>
        ''' 当前的位点之上最有可能出现的碱基及其概率，即可能出现的概率最高的碱基
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property MostProperly As KeyValuePair(Of DNA, Double)
            Get
                Return MostPossible
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{NucleicAcid.ToString(MostProperly.Key)}   bits:={Bits}"
        End Function

        Public Delegate Function GetValue(PM As MotifPM) As Double

        Public Shared ReadOnly Property GetValueMethods As Dictionary(Of DNA, GetValue) =
            New Dictionary(Of DNA, GetValue) From {
 _
            {DNA.dAMP, Function(pm As MotifPM) pm.A},
            {DNA.dTMP, Function(pm As MotifPM) pm.T},
            {DNA.dGMP, Function(pm As MotifPM) pm.G},
            {DNA.dCMP, Function(pm As MotifPM) pm.C}
        }

        Default Public ReadOnly Property Probability(c As Char) As Double Implements ILogoResidue.Probability
            Get
                Select Case c
                    Case "A"c, "a"c
                        Return A
                    Case "T"c, "t"c
                        Return T
                    Case "G"c, "g"c
                        Return G
                    Case "C"c, "c"c
                        Return Me.C
                    Case Else
                        Throw New Exception(c & " is not a valid residue!")
                End Select
            End Get
        End Property

        Public Property Address As Integer Implements IAddressHandle.Address

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="MAT">长度必须要相等</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CreateObject(MAT As MotifPM()()) As MotifPM()
            If MAT.Length = 1 Then
                Return MAT.First
            End If

            MAT = MAT.MatrixTransposeIgnoredDimensionAgreement

            Dim LQuery = (From nn In MAT Select __createObject(nn)).ToArray  '因为元素对象之间有先后顺序，所以这里不会使用并行化拓展
            Return LQuery
        End Function

        Private Shared Function __createObject(nn As MotifPM()) As MotifPM
            Dim A = (From item As MotifPM In nn Select item._innerTable(DNA.dAMP)).ToArray.Average
            Dim T = (From item As MotifPM In nn Select item._innerTable(DNA.dTMP)).ToArray.Average
            Dim G = (From item As MotifPM In nn Select item._innerTable(DNA.dGMP)).ToArray.Average
            Dim C = (From item As MotifPM In nn Select item._innerTable(DNA.dCMP)).ToArray.Average

            Return New MotifPM(A, T, G, C)
        End Function

        Public Overloads Shared Function ToString(Motifs As MotifPM()) As String
            Return NucleicAcid.ToString((From n As MotifPM In Motifs Select n.MostProperly.Key).ToArray)
        End Function

        Public Shared Function CreateFromNtBase(nt As DNA) As MotifPM
            Select Case nt
                Case DNA.dAMP
                    Return New MotifPM(A:=1, C:=0, G:=0, T:=0)
                Case DNA.dCMP
                    Return New MotifPM(C:=1, T:=0, G:=0, A:=0)
                Case DNA.dGMP
                    Return New MotifPM(G:=1, A:=0, T:=0, C:=0)
                Case DNA.dTMP
                    Return New MotifPM(T:=1, C:=0, A:=0, G:=0)
                Case Else
                    Return New MotifPM(0.25, 0.25, 0.25, 0.25)
            End Select
        End Function

        Public Function EnumerateKeys() As IEnumerable(Of Char) Implements IPatternSite.EnumerateKeys
            Return SequenceLogo.NT
        End Function

        Public Function EnumerateValues() As IEnumerable(Of Double) Implements IPatternSite.EnumerateValues
            Return Me._innerTable.Values
        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects).
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

        ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
        'Protected Overrides Sub Finalize()
        '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(True)
            ' TODO: uncomment the following line if Finalize() is overridden above.
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Namespace