﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Data.visualize.Network.Analysis.SimilarityImpl
Imports Microsoft.VisualBasic.Data.visualize.Network.FileStream.Generic
Imports Microsoft.VisualBasic.Data.visualize.Network.Graph
Imports Microsoft.VisualBasic.Data.visualize.Network.Layouts
Imports Microsoft.VisualBasic.Math.LinearAlgebra

Namespace Analysis.SimilarityImpl

    Module GraphTopology

        ''' <summary>
        ''' Calculate topology similarity
        ''' </summary>
        ''' <param name="a"></param>
        ''' <param name="b"></param>
        ''' <returns></returns>
        Public Function TopologyCos(a As Node, b As Node) As Double
            ' enumerate all connected node adjacencies
            ' evaluate angle for each pair
            Dim aTopo = a.nodeClassTopology
            Dim bTopo = b.nodeClassTopology
            Dim allGroups As Index(Of String) = aTopo.Keys.AsList + bTopo.Keys
            Dim av As New Vector(allGroups.EnumerateMapKeys.Select(AddressOf aTopo.TryGetValue))
            Dim bv As New Vector(allGroups.EnumerateMapKeys.Select(AddressOf bTopo.TryGetValue))
            Dim cos As Double = Math.SSM(av, bv)

            Return cos
        End Function

        <Extension>
        Private Function nodeClassTopology(v As Node) As Dictionary(Of String, Double)
            Return (From type In v.allNodeTopology Group By type.Item1 Into Group) _
                .ToDictionary(Function(group) group.Item1,
                              Function(group)
                                  Return group.Group.Average(Function(n) n.Item2)
                              End Function)
        End Function

        <Extension>
        Private Iterator Function allNodeTopology(v As Node) As IEnumerable(Of (String, Double))
            Dim adjacencies As Node() = v.EnumerateAdjacencies.ToArray
            Dim key$
            Dim cos$
            Dim a, b As AbstractVector

            For Each x As Node In adjacencies
                For Each y As Node In adjacencies
                    a = x.data.initialPostion
                    b = y.data.initialPostion
                    key = $"{If(x.data(NamesOf.REFLECTION_ID_MAPPING_NODETYPE), "n/a")}-{If(x.data(NamesOf.REFLECTION_ID_MAPPING_NODETYPE), "n/a")}"
                    cos = Imaging.Math2D.angleBetween2Lines(a.x, a.y, a.z, b.x, b.y, b.z)

                    Yield (key, cos)
                Next
            Next
        End Function

        Public Function VertexDistanceCos(a As Node, b As Node) As Double
            Dim aDist As Dictionary(Of String, Double) = a.nodeGroupDistance
            Dim bDist As Dictionary(Of String, Double) = b.nodeGroupDistance
            Dim allGroups As Index(Of String) = aDist.Keys.AsList + bDist.Keys
            Dim av As New Vector(allGroups.EnumerateMapKeys.Select(AddressOf aDist.TryGetValue))
            Dim bv As New Vector(allGroups.EnumerateMapKeys.Select(AddressOf bDist.TryGetValue))
            Dim cos As Double = Math.SSM(av, bv)

            Return cos
        End Function

        <Extension>
        Private Function nodeGroupDistance(v As Node) As Dictionary(Of String, Double)
            Return (From type As (String, Double) In v.AllNodeDistance Group By type.Item1 Into Group) _
                 .ToDictionary(Function(group) group.Item1,
                               Function(group)
                                   Return group.Group.Average(Function(n) n.Item2)
                               End Function)
        End Function

        <Extension>
        Private Function AllNodeDistance(v As Node) As IEnumerable(Of (String, Double))
            If v.adjacencies Is Nothing Then
                ' 孤立节点
                Return {}
            End If

            Dim a As AbstractVector = v.data.initialPostion

            Return v.adjacencies _
                .EnumerateAllEdges _
                .Select(Function(e)
                            Return v.calcVertexDistance(a, e)
                        End Function)
        End Function

        <Extension>
        Private Function calcVertexDistance(v As Node, a As AbstractVector, e As Edge) As (String, Double)
            Dim partner As Node

            If e.U Is v Then
                partner = e.V
            Else
                partner = e.U
            End If

            Dim type$ = partner.data(NamesOf.REFLECTION_ID_MAPPING_NODETYPE)
            Dim b As AbstractVector = partner.data.initialPostion
            Dim dist = (a.x - b.x) ^ 2 + (a.y - b.y) ^ 2 + (a.z - b.z) ^ 2

            Return (If(type, "n/a"), dist)
        End Function
    End Module
End Namespace