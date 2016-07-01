﻿Imports SMRUCC.genomics.Toolkits.RNA_Seq.dataExprMAT
Imports SMRUCC.genomics.Toolkits.RNA_Seq.RTools.DESeq2
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq

Partial Module CLI

    <ExportAPI("/Stat.Changes", Usage:="/Stat.Changes /deseq <deseq.result.csv> /sample <sampletable.csv> [/out <out.csv> /levels <1000> /diff <0.5>]")>
    Public Function StatChanges(args As CommandLine.CommandLine) As Integer
        Dim inFile As String = args("/deseq")
        Dim sample As String = args("/sample")
        Dim out As String = args.GetValue("/out", inFile.TrimFileExt & ".stat_changes.Csv")
        Dim levels As Integer = args.GetValue("/levels", 1000)
        Dim diff As Double = args.GetValue("/diff", 0.5)
        Dim result = SleepIdentified.IdentifyChanges(inFile.LoadCsv(Of ResultData), sample.LoadCsv(Of SampleTable), diff, levels)
        Return result.SaveTo(out).CLICode
    End Function

    <ExportAPI("/RPKM.Log2",
               Usage:="/RPKM.Log2 /in <RPKM.csv> /cond <conditions> [/out <out.csv>]")>
    <ParameterInfo("/cond", False,
                   Description:="Syntax format as:  <experiment1>/<experiment2>|<experiment3>/<experiment4>|.....",
                   Example:="colR1/xcb1|colR2/xcb2")>
    Public Function Log2(args As CommandLine.CommandLine) As Integer
        Dim inRPKM As String = args("/in")
        Dim out As String = args.GetValue("/out", inRPKM.TrimFileExt & ".log2.csv")
        Dim samples As Experiment() = Experiment.GetSamples(args("/cond"))
        Dim MAT As MatrixFrame = MatrixFrame.Load(DocumentStream.File.Load(inRPKM))
        Dim log2s As DocumentStream.File = MAT.Log2(samples)
        Return log2s.Save(out, Encodings.ASCII).CLICode
    End Function

    <ExportAPI("/log2.selects", Usage:="/log2.selects /log2 <rpkm.log2.csv> /data <dataset.csv> [/locus_map <locus> /factor 1 /out <out.dataset.csv>]")>
    Public Function Log2Selects(args As CommandLine.CommandLine) As Integer
        Dim inFile As String = args("/log2")
        Dim data As String = args("/data")
        Dim locus_map As String = args.GetValue("/locus_map", "locus")
        Dim out As Int = args.OpenHandle("/out", inFile.TrimFileExt & $".selects-{data.BaseName}.out.csv")
        Dim log2 = DocumentStream.DataSet.LoadDataSet(inFile, "LocusId")
        Dim factor As Double = args.GetValue("/factor", 1.0R)
        Dim dataSets = (From x As DocumentStream.EntityObject
                        In DocumentStream.EntityObject.LoadDataSet(data, locus_map)
                        Select x
                        Group x By x.Identifier Into Group) _
                             .ToDictionary(Function(x) x.Identifier,
                                           Function(x) x.Group.ToArray)
        Dim LQuery = (From x In log2
                      Where dataSets.ContainsKey(x.Identifier) AndAlso
                          (From p As Double
                           In x.Properties.Values
                           Where Math.Abs(p) >= factor
                           Select p).FirstOrDefault > 0
                      Select dataSets(x.Identifier)).MatrixAsIterator
        Return LQuery > out
    End Function

    <ExportAPI("/DataFrame.RPKMs", Info:="Merges the RPKM csv data files.",
               Usage:="/DataFrame.RPKMs /in <in.DIR> [/trim /out <out.csv>]")>
    Public Function MergeRPKMs(args As CommandLine.CommandLine) As Integer
        Dim [in] As String = args - "/in"
        Dim trim As Boolean = args.GetBoolean("/trim")
        Dim out As String = args.GetValue("/out", [in].ParentPath & "/" & [in].BaseName & $".RPKMs{If(trim, "-TRIM", "")}.Csv")
        Dim dataExpr0 As DocumentStream.File = MergeDataMatrix([in], trim)
        Return dataExpr0.Save(out, Encodings.ASCII)
    End Function
End Module