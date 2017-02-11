﻿#Region "Microsoft.VisualBasic::41f87eae5e96ed1541f96b115bd119c7, ..\interops\localblast\CLI_tools\CLI\COGTools.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
'       xie (genetics@smrucc.org)
' 
' Copyright (c) 2016 GPL3 Licensed
' 
' 
' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports System.IO
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.UnixBash.FileSystem
Imports Microsoft.VisualBasic.Linq
Imports SMRUCC.genomics.Assembly.DOOR
Imports SMRUCC.genomics.Assembly.NCBI
Imports SMRUCC.genomics.Assembly.NCBI.COG
Imports SMRUCC.genomics.Assembly.NCBI.COG.COGs
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.RpsBLAST
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Programs
Imports SMRUCC.genomics.SequenceModel.FASTA

Partial Module CLI

    <ExportAPI("/COG.Statics",
               Usage:="/COG.Statics /in <myva_cogs.csv> [/locus <locus.txt/csv> /locuMap <Gene> /out <out.csv>]")>
    <Group(CLIGrouping.COGTools)>
    Public Function COGStatics(args As CommandLine) As Integer
        Dim inFile As String = args("/in")
        Dim locus As String = args("/locus")
        Dim out As String
        Dim myvaCogs = inFile.LoadCsv(Of MyvaCOG)

        If Not locus.FileExists Then
            out = args.GetValue("/out", inFile.TrimSuffix & ".COG.Stat.Csv")
        Else
            out = args.GetValue("/out", inFile.TrimSuffix & "." & locus.BaseName & ".COG.Stat.Csv")
        End If

        If locus.FileExists Then
            Dim ext As String = Path.GetExtension(locus)
            Dim locusTag As String()

            If String.Equals(ext, ".csv", StringComparison.OrdinalIgnoreCase) Then
                Dim temp = EntityObject.LoadDataSet(locus, args.GetValue("/locusMap", "Gene"))
                locusTag = temp.ToArray(Function(x) x.ID)
            Else
                locusTag = locus.ReadAllLines
            End If

            myvaCogs = LinqAPI.MakeList(Of MyvaCOG) <=
                From x As MyvaCOG
                In myvaCogs
                Where Array.IndexOf(locusTag, x.QueryName) > -1
                Select x
        End If

        Dim func As COG.Function = COG.Function.Default
        Dim stst As COGFunction() = COGFunction.GetClass(myvaCogs, func)

        Return stst.SaveTo(out).CLICode
    End Function

    <ExportAPI("/EXPORT.COGs.from.DOOR",
               Usage:="/EXPORT.COGs.from.DOOR /in <DOOR.opr> [/out <out.csv>]")>
    <Group(CLIGrouping.COGTools)>
    Public Function ExportDOORCogs(args As CommandLine) As Integer
        Dim opr As String = args("/in")
        Dim out As String = args.GetValue("/out", opr.TrimSuffix & ".COGs.csv")
        Dim DOOR As DOOR = DOOR_API.Load(opr)

        Return (LinqAPI.MakeList(Of MyvaCOG) <=
 _
            From x As GeneBrief
            In DOOR.Genes
            Select New MyvaCOG With {
                .COG = x.COG_number,
                .MyvaCOG = x.COG_number,
                .QueryName = x.Synonym,
                .Description = x.Product,
                .Category = x.COG_number
 _
            }) >> OpenHandle(out)
    End Function

    <ExportAPI("/install.cog2003-2014",
               Info:="Config the ``prot2003-2014.fasta`` database for GCModeller localblast tools. This database will be using for the COG annotation. 
               This command required of the blast+ install first.",
               Usage:="/install.cog2003-2014 /db <prot2003-2014.fasta>",
               Example:="/install.cog2003-2014 /db /data/fasta/prot2003-2014.fasta")>
    <Group(CLIGrouping.COGTools)>
    <Argument("/db", False, CLITypes.File,
              AcceptTypes:={GetType(FastaFile)},
              Description:="The fasta database using for COG annotation, which can be download from NCBI ftp: 
              > ftp://ftp.ncbi.nlm.nih.gov/pub/COG/COG2014/data/prot2003-2014.fa.gz")>
    Public Function InstallCOGDatabase(args As CommandLine) As Integer
        Dim localblast As New BLASTPlus(
            bin:=GCModeller.FileSystem.GetLocalblast)
        Dim db$ = args("/db")

        ' 保存并格式化数据库，则后面的分析就可以直接使用了
        Settings.SettingsFile.COG2003_2014 = db.GetFullPath
        Settings.Save()

        Return localblast _
            .FormatDb(db, localblast.MolTypeProtein) _
            .Run()
    End Function

    <ExportAPI("/query.cog2003-2014", Info:="Protein COG annotation by using NCBI cog2003-2014.fasta database.",
               Usage:="/query.cog2003-2014 /query <query.fasta> [/evalue 1e-5 /coverage 0.65 /identities 0.85 /all /out <out.DIR> /db <cog2003-2014.fasta> /blast+ <blast+/bin>]")>
    <Group(CLIGrouping.COGTools)>
    <Argument("/db", True, CLITypes.File,
              AcceptTypes:={GetType(FastaFile)},
              Description:="The file path to the database fasta file.
              If you have config the cog2003-2014 database previously, then this argument can be omitted.")>
    <Argument("/blast+", True, CLITypes.File,
              AcceptTypes:={GetType(String)},
              Description:="The directory to the NCBI blast+ suite ``bin`` directory. If you have config this path before, then this argument can be omitted.")>
    <Argument("/all", True, CLITypes.Boolean,
              AcceptTypes:={GetType(Boolean)},
              Description:="For export the bbh result, export all match or only the top best? default is only top best.")>
    <Argument("/evalue", True, CLITypes.Double,
              AcceptTypes:={GetType(Double)},
              Description:="blastp e-value cutoff.")>
    <Argument("/out", True, CLITypes.File,
              AcceptTypes:={GetType(String)},
              Description:="The output directory for the work files.")>
    Public Function COG2003_2014(args As CommandLine) As Integer
        Dim query$ = args("/query")
        Dim evalue$ = args.GetValue("/evalue", "1e-5")
        Dim coverage# = args.GetValue("/coverage", 0.65)
        Dim identities# = args.GetValue("/identities", 0.85)
        Dim isAll As Boolean = args.GetBoolean("/all")
        Dim out As String = args.GetValue("/out", query.TrimSuffix & "_cog2003-2014/")
        Dim db$ = args.GetValue("/db", Settings.SettingsFile.COG2003_2014)
        Dim bin$ = args.GetValue("/blast+", GCModeller.FileSystem.GetLocalblast)
        Dim localblast As New BLASTPlus(bin$) With {
            .NumThreads = App.CPUCoreNumbers / 2
        }

        ' running tasks
        Dim qvs$ = out & "/" & query.BaseName & "_vs__cog2003-2014.txt"
        Dim svq$ = out & "/cog2003-2014_vs__" & query.BaseName & ".txt"
        Dim qvsTask As Func(Of Integer) =
            AddressOf localblast.Blastp(query, db, qvs, evalue).Run
        Dim svqTask = localblast.Blastp(db, query, svq, evalue)
        Dim runTask = qvsTask.BeginInvoke(Nothing, Nothing)

        Call localblast.FormatDb(query, localblast.MolTypeProtein).Run()
        Call svqTask.Run()
        Call qvsTask.EndInvoke(runTask)

        ' 导出bbh结果
        Dim sbh_qvs = BLASTOutput.BlastPlus.Parser.TryParseUltraLarge(qvs).ExportAllBestHist(coverage, identities)
        Dim sbh_svq = BLASTOutput.BlastPlus.Parser.TryParseUltraLarge(svq).ExportAllBestHist(coverage, identities)

        Call sbh_qvs.SaveTo(qvs.TrimSuffix & ".sbh.csv")
        Call sbh_svq.SaveTo(svq.TrimSuffix & ".sbh.csv")

        Dim bbh As BiDirectionalBesthit() = If(isAll,
            BBHParser.GetDirreBhAll2(sbh_qvs, sbh_svq),
            BBHParser.GetBBHTop(sbh_qvs, sbh_svq))

        Call bbh.SaveTo(qvs.TrimSuffix & ".bbh.csv")

        ' 从bbh结果之中匹配得到COG信息

    End Function

    <ExportAPI("/COG2014.result",
               Usage:="/COG2014.result /sbh <query-vs-COG2003-2014.fasta> /cog <cog2003-2014.csv> [/cog.names <cognames2003-2014.tab> /out <out.myva_cog.csv>]")>
    Public Function COG2014_result(args As CommandLine) As Integer
        Dim [in] As String = args("/sbh")
        Dim cog As String = args("/cog")
        Dim out As String = args.GetValue("/out", [in].TrimSuffix & ".myva.csv")
        Dim names$ = args.GetValue("/cog.name", GCModeller.FileSystem.FileSystem.COGs & "/cognames2003-2014.tab")
        Dim cogs As COGTable() = COGTable.LoadCsv(cog)
        Dim sbh As IEnumerable(Of BestHit) = [in].LoadCsv(Of BestHit)
        Dim result As MyvaCOG() = sbh.COG2014_result(COGs)

        If names.FileExists(True) Then
            Dim cogNames As COGName() = COGName.LoadTable(names)
            result = result.COGCatalog(cogNames)
        End If

        Return result.SaveTo(out).CLICode
    End Function
End Module
