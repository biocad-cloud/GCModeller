﻿#Region "Microsoft.VisualBasic::022cd9bba427395d2feb1688945173b8, R#\cytoscape_toolkit\xgmml.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
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



    ' /********************************************************************************/

    ' Summaries:

    ' Module xgmmlToolkit
    ' 
    '     Function: createGraph, loadXgmml, XgmmlRender
    ' 
    ' /********************************************************************************/

#End Region


Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Imaging.Driver
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Model.Network.KEGG.PathwayMaps
Imports SMRUCC.genomics.Model.Network.KEGG.PathwayMaps.RenderStyles
Imports SMRUCC.genomics.Visualize.Cytoscape.CytoscapeGraphView
Imports SMRUCC.genomics.Visualize.Cytoscape.CytoscapeGraphView.XGMML.File
Imports SMRUCC.Rsharp.Runtime.Interop

<Package("xgmml")>
Module xgmmlToolkit

    <ExportAPI("read.xgmml")>
    Public Function loadXgmml(file As String) As XGMMLgraph
        Return XGMML.RDFXml.Load(path:=file)
    End Function

    <ExportAPI("xgmml.graph")>
    Public Function createGraph(xgmml As XGMMLgraph, <RRawVectorArgument(GetType(String))> Optional propertyNames As Object = "label|class|group.category|group.category.color") As NetworkGraph
        Return xgmml.ToNetworkGraph(DirectCast(propertyNames, String()))
    End Function

    <ExportAPI("xgmml.render")>
    Public Function XgmmlRender(model As Object,
                                Optional size$ = "10(A0)",
                                Optional convexHull$() = Nothing,
                                Optional edgeBends As Boolean = False,
                                Optional altStyle As Boolean = False,
                                Optional rewriteGroupCategoryColors$ = "TSF",
                                Optional enzymeColorSchema$ = "Set1:c8",
                                Optional compoundColorSchema$ = "Clusters",
                                Optional reactionKOMapping As Dictionary(Of String, String()) = Nothing,
                                Optional compoundNames As Dictionary(Of String, String) = Nothing) As GraphicsData

        Dim style As RenderStyle = Nothing
        Dim graph As NetworkGraph

        If model Is Nothing Then
            Return Nothing
        ElseIf model.GetType Is GetType(NetworkGraph) Then
            graph = model
        ElseIf model.GetType Is GetType(XGMMLgraph) Then
            graph = DirectCast(model, XGMMLgraph).ToNetworkGraph("label", "class", "group.category", "group.category.color")
        Else
            Return Nothing
        End If

        If altStyle Then
            Dim convexHullCategoryStyle As Dictionary(Of String, String) = graph _
                .getCategoryColors(convexHull, rewriteGroupCategoryColors) _
                .TupleTable

            style = New PlainStyle(
                graph:=graph,
                convexHullCategoryStyle:=convexHullCategoryStyle,
                enzymeColorSchema:=enzymeColorSchema,
                compoundColorSchema:=compoundColorSchema
            )
        End If

        Return ReferenceMapRender.Render(
            graph:=graph,
            canvasSize:=size,
            convexHull:=convexHull.Indexing,
            compoundNames:=compoundNames,
            edgeBends:=edgeBends,
            renderStyle:=style,
            reactionKOMapping:=reactionKOMapping
        )
    End Function
End Module

