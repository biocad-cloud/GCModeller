﻿Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Scripting
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.NCBI.Extensions.LocalBLAST.BLASTOutput.BlastPlus
Imports SMRUCC.genomics.NCBI.Extensions.LocalBLAST.BLASTOutput.BlastPlus.v228
Imports SMRUCC.genomics.SequenceModel.NucleotideModels

Namespace LocalBLAST.Application

    ''' <summary>
    ''' Blastn Mapping for fastaq
    ''' </summary>
    Public Class BlastnMapping : Inherits Contig

        ''' <summary>
        ''' The name of the reads query
        ''' </summary>
        ''' <returns></returns>
        <Column("Reads.Query")> Public Property ReadQuery As String
        ''' <summary>
        ''' The name of the reference genome sequence.
        ''' </summary>
        ''' <returns></returns>
        Public Property Reference As String
        ''' <summary>
        ''' Length of <see cref="ReadQuery"/>
        ''' </summary>
        ''' <returns></returns>
        Public Property QueryLength As Integer
        <Column("Score(bits)")> Public Property Score As Integer
        <Column("Score(Raw)")> Public Property RawScore As Integer
        <Column("E-value")> Public Property Evalue As Double
        ''' <summary>
        ''' Identities(%)
        ''' </summary>
        ''' <returns></returns>
        <Column("Identities(%)")> Public Property Identities As Double
        <Column("Identities")> Public Property IdentitiesFraction As String
            Get
                Return _identitiesFraction
            End Get
            Set(value As String)
                _identitiesFraction = value
                If Not String.IsNullOrEmpty(value) Then
                    Dim Tokens As String() = value.Replace("\", "/").Split("/"c)
                    If Tokens.Count > 1 Then
                        __identitiesFraction = Math.Abs(Val(Tokens(Scan0) - Val(Tokens(1))))
                    Else
                        __identitiesFraction = Integer.MaxValue
                    End If
                Else
                    __identitiesFraction = Integer.MaxValue
                End If
            End Set
        End Property

        Dim _identitiesFraction As String
        Dim __identitiesFraction As Integer

        ''' <summary>
        ''' Gaps(%)
        ''' </summary>
        ''' <returns></returns>
        <Column("Gaps(%)")> Public Property Gaps As String
        <Column("Gaps")> Public Property GapsFraction As String

#Region "Public Property Strand As String"

        <Ignored> Public ReadOnly Property QueryStrand As Strands
        ''' <summary>
        ''' 在进行装配的时候是以基因组上面的链方向以及位置为基准的
        ''' </summary>
        ''' <returns></returns>
        <Ignored> Public ReadOnly Property ReferenceStrand As Strands

        Dim _strand As String

        Public Property Strand As String
            Get
                Return _strand
            End Get
            Set(value As String)
                _strand = value

                If String.IsNullOrEmpty(value) Then
                    Me._QueryStrand = Strands.Unknown
                    Me._ReferenceStrand = Strands.Unknown
                    Return
                End If

                Dim Tokens As String() = value.Split("/"c)
                Me._QueryStrand = GetStrand(Tokens(Scan0))
                Me._ReferenceStrand = GetStrand(Tokens(1))
            End Set
        End Property
#End Region

        <Column("Left(Query)")> Public Property QueryLeft As Integer
        <Column("Right(Query)")> Public Property QueryRight As Integer
        <Column("Left(Reference)")> Public Property ReferenceLeft As Integer
        <Column("Right(Reference)")> Public Property ReferenceRight As Integer

        'Public Property Lambda As Double
        'Public Property K As Double
        'Public Property H As Double

        '<Column("Lambda(Gapped)")> Public Property Lambda_Gapped As Double
        '<Column("K(Gapped)")> Public Property K_Gapped As Double
        '<Column("H(Gapped)")> Public Property H_Gapped As Double

        '<Column("Effective Search Space")> Public Property EffectiveSearchSpaceUsed As String

        ''' <summary>
        ''' Unique?(这个属性值应该从blastn日志之中导出mapping数据的时候就执行了的)
        ''' </summary>
        ''' <returns></returns>
        <Column("Unique?")> Public Property Unique As Boolean
        <Column("FullLength?")> Public ReadOnly Property AlignmentFullLength As Boolean
            Get
                Return QueryLeft = 1 AndAlso QueryLength = QueryRight
            End Get
        End Property

        ''' <summary>
        ''' Perfect?
        ''' </summary>
        ''' <returns></returns>
        <Column("Perfect?")> Public ReadOnly Property PerfectAlignment As Boolean
            Get
                ' Explicit conditions
                Return (Identities = 100.0R AndAlso __identitiesFraction <= 3) AndAlso Val(Gaps) = 0R
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return $"{Me.ReadQuery} //{MappingLocation.ToString}"
        End Function

        Protected Overrides Function __getMappingLoci() As NucleotideLocation
            Return New NucleotideLocation(ReferenceLeft, ReferenceRight, ReferenceStrand)
        End Function
    End Class
End Namespace