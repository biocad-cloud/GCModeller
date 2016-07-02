﻿#Region "Microsoft.VisualBasic::3f0c1b8a144f09fc709d488bc1fa75a5, ..\GCModeller\CLI_tools\MEME\Cli\Views + Stats\ModuleRegulons.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
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

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports SMRUCC.genomics.Analysis.AnnotationTools
Imports SMRUCC.genomics.Analysis.RNA_Seq
Imports SMRUCC.genomics.Assembly.DOOR
Imports SMRUCC.genomics.Data.Regprecise
Imports SMRUCC.genomics.Interops.NBCR.MEME_Suite
Imports SMRUCC.genomics.Interops.NBCR.MEME_Suite.Analysis.FootprintTraceAPI
Imports SMRUCC.genomics.Interops.NBCR.MEME_Suite.Analysis.MotifScans

Partial Module CLI

    <ExportAPI("/Motif.BuildRegulons",
               Usage:="/Motif.BuildRegulons /meme <meme.txt.DIR> /model <FootprintTrace.xml> /DOOR <DOOR.opr> /maps <bbhmappings.csv> /corrs <name/DIR> [/cut <0.65> /out <outDIR>]")>
    Public Function BuildRegulons(args As CommandLine.CommandLine) As Integer
        Dim meme As String = args("/meme")
        Dim model As String = args("/model")
        Dim DOOR As String = args("/DOOR")
        Dim maps As String = args("/maps")
        Dim out As String = args.GetValue("/out", model.TrimFileExt & ".ModuleRegulons/")  ' 主要是需要存放TOMTOM全局比对的图片数据
        Dim LDM = AnnotationModel.LoadMEMEOUT(meme)
        Dim footprints = model.LoadXml(Of FootprintTrace)
        Dim opr = DOOR_API.Load(DOOR)
        Dim mapsTF = maps.LoadCsv(Of bbhMappings)
        Dim corrs = Correlation2.LoadAuto(args("/corrs"))
        Dim cut As Double = args.GetValue("/cut", 0.65)
        Dim istrue As IsTrue = corrs.IsTrueFunc(cut)
        Dim regulons As ModuleMotif() = ToRegulons(LDM, footprints, opr, mapsTF, istrue, out)
        Return regulons.SaveTo(out & "/ModuleRegulons.Csv").CLICode
    End Function
End Module

