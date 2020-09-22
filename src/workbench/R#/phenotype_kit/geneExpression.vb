﻿#Region "Microsoft.VisualBasic::a07661e38be11be09ef8a5a9b3f7ec42, phenotype_kit\geneExpression.vb"

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

' Module geneExpression
' 
'     Constructor: (+1 Overloads) Sub New
'     Function: average, loadExpression, relative
' 
' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.genomics.Analysis.HTS.DataFrame
Imports SMRUCC.genomics.GCModeller.Workbench.ExperimentDesigner
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Components
Imports SMRUCC.Rsharp.Runtime.Interop
Imports Rdataframe = SMRUCC.Rsharp.Runtime.Internal.Object.dataframe
Imports Vec = Microsoft.VisualBasic.Math.LinearAlgebra.Vector

<Package("geneExpression")>
Module geneExpression

    Sub New()

    End Sub

    ''' <summary>
    ''' load an expressin matrix data
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="exclude_samples"></param>
    ''' <returns></returns>
    <ExportAPI("load.expr")>
    <RApiReturn(GetType(Matrix))>
    Public Function loadExpression(file As Object, Optional exclude_samples As String() = Nothing, Optional env As Environment = Nothing) As Object
        Dim ignores As Index(Of String) = If(exclude_samples, {})

        If TypeOf file Is String Then
            Return Matrix.LoadData(DirectCast(file, String), ignores)
        ElseIf TypeOf file Is Rdataframe Then
            Dim table As Rdataframe = DirectCast(file, Rdataframe)
            Dim sampleNames As String() = table.columns.Keys.Where(Function(c) Not c Like ignores).ToArray
            Dim genes As DataFrameRow() = table _
                .forEachRow(colKeys:=sampleNames) _
                .Select(Function(v)
                            Return New DataFrameRow With {
                                .geneID = v.name,
                                .experiments = v.value _
                                    .Select(Function(obj) CDbl(obj)) _
                                    .ToArray
                            }
                        End Function) _
                .ToArray

            Return New Matrix With {
                .expression = genes,
                .sampleID = sampleNames
            }
        Else
            Return Message.InCompatibleType(GetType(Rdataframe), file.GetType, env)
        End If
    End Function

    <ExportAPI("average")>
    Public Function average(matrix As Matrix, sampleinfo As SampleInfo()) As Matrix
        Return Matrix.MatrixAverage(matrix, sampleinfo)
    End Function

    <ExportAPI("relative")>
    Public Function relative(matrix As Matrix) As Matrix
        Return New Matrix With {
            .sampleID = matrix.sampleID,
            .expression = matrix.expression _
                .Select(Function(gene)
                            Return New DataFrameRow With {
                                .geneID = gene.geneID,
                                .experiments = New Vec(gene.experiments) / gene.experiments.Max
                            }
                        End Function) _
                .ToArray
        }
    End Function
End Module
