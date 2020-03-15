﻿Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Visualize.CatalogProfiling
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Interop

<Package("visualkit.plots")>
Module visualPlot

    ''' <summary>
    ''' Do plot of the given kegg pathway profiles data
    ''' </summary>
    ''' <param name="profiles"></param>
    ''' <param name="title"></param>
    ''' <param name="axisTitle"></param>
    ''' <param name="size"></param>
    ''' <param name="tick"></param>
    ''' <param name="colors"></param>
    ''' <param name="displays"></param>
    ''' <returns></returns>
    <ExportAPI("kegg.category_profiles.plot")>
    <RApiReturn(GetType(GraphicsData))>
    Public Function KEGGCategoryProfilePlots(profiles As Object,
                                             Optional title$ = "KEGG Orthology Profiling",
                                             Optional axisTitle$ = "Number Of Proteins",
                                             <RRawVectorArgument>
                                             Optional size As Object = "2300,2000",
                                             Optional tick# = -1,
                                             <RRawVectorArgument>
                                             Optional colors As Object = "#E41A1C,#377EB8,#4DAF4A,#984EA3,#FF7F00,#CECE00",
                                             Optional displays% = 10,
                                             Optional env As Environment = Nothing) As Object

        Dim profile As Dictionary(Of String, NamedValue(Of Double)())

        If TypeOf profiles Is Dictionary(Of String, Integer) Then
            profile = profiles _
                .KEGGCategoryProfiles _
                .ToDictionary(Function(p) p.Key,
                              Function(group)
                                  Return group.Value _
                                     .OrderByDescending(Function(t) t.Value) _
                                     .Take(displays) _
                                     .ToArray
                              End Function)
        ElseIf TypeOf profiles Is Dictionary(Of String, NamedValue(Of Double)()) Then
            profile = DirectCast(profiles, Dictionary(Of String, NamedValue(Of Double)()))
        Else
            Return Internal.debug.stop("invalid data type for plot kegg category profile plot!", env)
        End If

        Return profile.ProfilesPlot(title,
            size:=size,
            tick:=tick,
            axisTitle:=axisTitle,
            labelRightAlignment:=False,
            valueFormat:="F0",
            colorSchema:=colors
        )
    End Function


End Module
