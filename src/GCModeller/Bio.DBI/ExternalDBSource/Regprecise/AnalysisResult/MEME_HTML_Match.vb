﻿Imports Microsoft.VisualBasic.DataVisualization.DocumentFormat.Csv.Reflection
Imports Microsoft.VisualBasic.DataVisualization.DocumentFormat.Extensions

Public Class Matched

    <Column("MatchedRegulator")> Public Property RegpreciseRegulator As String
    Public Property ObjectId As String
    Public Property Strand As String
    Public Property MatchedMotif As String
    Public Property DoorId As String
    <Column("MAST.E-value", ColumnAttribute.Type.Double)> Public Property MAST_Evalue As Double
    <Column("MAST.P-value", ColumnAttribute.Type.Double)> Public Property MAST_Pvalue As Double
    <ArrayColumn("SequenceId", "; ")> Public Property OperonGeneIds As String()
    <Column("MEME.P-value", ColumnAttribute.Type.Double)> Public Property MEME_Pvalue As Double
    Public Property Starts As Long
    Public Property Ends As Long
    Public Property MotifId As String
    <Column("MEME.E-value", ColumnAttribute.Type.Double)> Public Property MEME_Evalue As Double
    Public Property Width As Integer
    Public Property Log_Likelihood_Ratio As Double
    Public Property Information_Content As Double
    Public Property Relative_Entropy As Double
    Public Property Signature As String

    ''' <summary>
    ''' 目标基因组内被匹配到的调控因子
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TF As String
    Public Property OperonPromoter As String

    <Column("BiologiclaProcess")> Public Property BiologicalProcess As String
    <ArrayColumn("Effectors")> Public Property Effectors As String()

    <ArrayColumn("WGCNA-weights", "; ", ColumnAttribute.Type.Double)> Public Property WGCNAWeight As Double()
    ''' <summary>
    ''' <see cref="TF"></see>和<see cref="OperonPromoter"></see>
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Column("Pcc.TF->Operon", ColumnAttribute.Type.Double)> Public Property TFPcc As Double
    <ArrayColumn("Pcc-array", "; ", ColumnAttribute.Type.Double)> Public Property PccArray As Double()

    Public Function Clone() As Matched
        Return DirectCast(Me.MemberwiseClone, Matched)
    End Function
End Class