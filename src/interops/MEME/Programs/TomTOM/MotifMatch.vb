﻿Imports System.Xml.Serialization
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat.MEME
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat.TomTOM
Imports LANS.SystemsBiology.SequenceModel
Imports LANS.SystemsBiology.SequenceModel.FASTA
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Language.UnixBash

Namespace Programs

    Public Class MotifMatch : Inherits TOMText
        Implements I_FastaProvider

        ''' <summary>
        ''' This motif match him self???
        ''' </summary>
        ''' <returns></returns>
        <Column("match.self?")> Public ReadOnly Property MatchSelf As Boolean
            Get
                Return String.Equals($"{[Module]}.{Query}", $"{Family}.{Target}", StringComparison.OrdinalIgnoreCase)
            End Get
        End Property

        ''' <summary>
        ''' 用于映射用的
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property uid As String
            Get
                Dim query As String = $"{Family}.{Target}"
                Dim hit As String = $"{[Module]}.{Me.Query}"
                Dim ar As String() = {query, hit}
                Dim sort As String() = ar.OrderBy(Function(s) s).ToArray
                Return String.Join("@", sort)
            End Get
        End Property

        Public Property [Module] As String
        Public Property Family As String
        <Column("MEME.Evalue")> Public Property MEMEEvalue As Double
        <XmlAttribute> Public Property Width As Integer
        ''' <summary>
        ''' Site name，该目标序列的Fasta文件的文件头，一般是基因号
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Property LocusId As String
        ''' <summary>
        ''' 位点的序列
        ''' </summary>
        ''' <returns></returns>
        <XmlAttribute> Public Property Site As String Implements I_PolymerSequenceModel.SequenceData
        <Column("MEME.pvalue")> Public Overridable Property MEMEPvalue As Double
        ''' <summary>
        ''' 在整条序列之中的起始位置
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <XmlAttribute> Public Overridable Property Start As Long
        <XmlAttribute> Public Property Right As Long

#Region "Implements SequenceModel.FASTA.I_FastaProvider"
        <Ignored> Public ReadOnly Property Title As String Implements I_FastaProvider.Title
            Get
                Return $"{uid}::{LocusId}"
            End Get
        End Property
        <Ignored> Public ReadOnly Property Attributes As String() Implements I_FastaProvider.Attributes
            Get
                Return {Title}
            End Get
        End Property
#End Region

        Public Overrides Function ToString() As String
            Return uid
        End Function
    End Class
End Namespace