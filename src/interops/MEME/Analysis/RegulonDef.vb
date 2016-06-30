﻿Imports System.Runtime.CompilerServices
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.Linq.Extensions
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.Analysis.MotifScans

Namespace Analysis

    ''' <summary>
    ''' 基因能够被比对得上，并且motif位点也能够恰好被比对上，就认为是一个成功预测的Regulon？？
    ''' </summary>
    ''' 
    <PackageNamespace("MEME.Regulon.Def", Category:=APICategories.ResearchTools)>
    Public Module RegulonDef

        Public ReadOnly Property MAST_LDM As Dictionary(Of String, AnnotationModel)

        Sub New()
            Call Settings.Session.Initialize()

            Dim source = GCModeller.FileSystem.FileSystem.GetMotifLDM.LoadSourceEntryList("*.xml")
            MAST_LDM = source.ToDictionary(Function(x) x.Key, Function(x) x.Value.LoadXml(Of AnnotationModel))
        End Sub

        Public Function IsRegulonCorrect(regulon As DatabaseServices.Regprecise.Regulator) As Boolean

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="regulonBBH">ref.regulon.bbh.xml</param>
        ''' <param name="tomOUT">tom_out.csv.DIR</param>
        ''' <returns></returns>
        ''' 
        <ExportAPI("Export")>
        Public Function Export(regulonBBH As String, tomOUT As String) As Regulon()

            VBDebugger.Mute = True

            Dim regulons = FileIO.FileSystem.GetFiles(regulonBBH, FileIO.SearchOption.SearchTopLevelOnly, "*.xml") _
                .ToArray(Function(x) x.LoadXml(Of DatabaseServices.Regprecise.BacteriaGenome))
            Dim tomOUTs = FileIO.FileSystem.GetFiles(tomOUT, FileIO.SearchOption.SearchAllSubDirectories, "*.csv") _
                .ToArray(Function(x) x.LoadCsv(Of Analysis.Similarity.TOMQuery.CompareResult)).MatrixToVector
            Dim tomHash = (From x As Similarity.TOMQuery.CompareResult
                           In tomOUTs
                           Select uid = IO.Path.GetFileNameWithoutExtension(x.QueryName),
                               x
                           Group By uid Into Group) _
                                .ToDictionary(Function(x) x.uid,
                                              Function(x) x.Group.ToArray(Function(xx) xx.x))
            Dim regulonHash = (From x In regulons
                               Where Not x.Regulons Is Nothing
                               Select x.Regulons.Regulators.ToArray(Function(xx) New With {.uid = uid(xx), .regulon = xx})).MatrixToVector
            Dim regulonResults = (From x In regulonHash Where tomHash.ContainsKey(x.uid) Select x.regulon.__creates(tomHash(x.uid))).MatrixToVector
            Return regulonResults
        End Function

        Private Function uid(regulon As DatabaseServices.Regprecise.Regulator) As String
            Return $"{regulon.LocusTag.Key}.{regulon.LocusTag.Value}".Replace(":", "_")
        End Function

        <Extension> Private Function __creates(regulon As DatabaseServices.Regprecise.Regulator, query As Similarity.TOMQuery.CompareResult()) As Regulon()
            Return query.ToArray(Function(x) regulon.__creates(x))
        End Function

        <Extension> Private Function __creates(regulonRef As DatabaseServices.Regprecise.Regulator, query As Similarity.TOMQuery.CompareResult) As Regulon
            Dim regulon As New Regulon With {
                .BiologicalProcess = regulonRef.BiologicalProcess,
                .Family = regulonRef.Family,
                .Hit = query.HitName,
                .HitMotif = query.HitMotif,
                .Mode = regulonRef.RegulationMode,
                .Motif = query.QueryMotif,
                .Pathway = regulonRef.Pathway,
                .refLocus = regulonRef.LocusTag.Value,
                .Regulates = regulonRef.Regulates.ToArray(Function(x) x.LocusId),
                .Regulator = regulonRef.LocusTag.Key,
                .Similarity = query.Similarity,
                .Consensus = query.Consensus,
                .Distance = query.Distance,
                .Edits = query.Edits,
                .Gaps = query.Gaps,
                .ref = regulonRef.Regulog.Key,
                .Score = query.Score,
                .Trace = "",
                .Effector = regulonRef.Effector
            }
            Return regulon
        End Function
    End Module

    Public Class Regulon
        Public Property ref As String
        <Column("ref.Locus_tag")> Public Property refLocus As String
        Public Property Regulator As String
        Public Property Regulates As String()
        Public Property Family As String
        Public Property Hit As String
        Public Property Motif As String
        <Column("hit.Motif")> Public Property HitMotif As String
        <XmlAttribute> Public Property Score As Double
        <XmlAttribute> Public Property Distance As Double
        <XmlAttribute> Public Property Similarity As Double
        <XmlElement> Public Property Edits As String
        <XmlElement> Public Property Consensus As String
        <XmlAttribute> Public Property Gaps As Integer
        Public Property Trace As String
        Public Property Mode As String
        Public Property Pathway As String
        Public Property BiologicalProcess As String
        Public Property Effector As String

    End Class
End Namespace