﻿#Region "Microsoft.VisualBasic::8e39e9a57943e3592c2bedce44990937, ..\interops\visualize\Cytoscape\Cytoscape.App\PathwayModuleFilter.vb"

' Author:
' 
'       asuka (amethyst.asuka@gcmodeller.org)
'       xieguigang (xie.guigang@live.com)
'       xie (genetics@smrucc.org)
' 
' Copyright (c) 2018 GPL3 Licensed
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

Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Text.Xml.Models

Namespace NetworkModel

    ''' <summary>
    ''' 统计出每一个Module之中有多少个代谢途径
    ''' </summary>
    ''' <remarks></remarks>
    Public Class PathwayModuleFilter

        Public Shared Function ImportsModules(path As String) As KeyValuePair()
            Dim strLines = path.ReadAllLines.Skip(1)
            Dim LQuery = (From strLine As String In strLines
                          Let Tokens As String() = Strings.Split(strLine, " ")
                          Select KeyValuePair.CreateObject(Tokens(0), Tokens(2))).ToArray
            Return LQuery
        End Function

        ''' <summary>
        ''' {ModuleId, Module_GeneId()}
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function BuildModules(importedModules As KeyValuePair()) As NamedVector(Of String)()
            Dim GetAllModules = (From item In importedModules Select item.Value Distinct Order By Value Ascending).ToArray
            Dim LQuery = (From [Module] As String
                      In GetAllModules
                          Select NamedVector(Of String).CreateObject([Module], (
                          From item As KeyValuePair
                          In importedModules
                          Where String.Equals([Module], item.Value)
                          Select item.Key
                          Distinct
                          Order By Key Ascending).ToArray)).ToArray
            Return LQuery
        End Function

        Public Shared Function ImportsPathways(pathwayOverview As IO.File) As NamedVector(Of String)()
            Dim LQuery = (From row As IO.RowObject In pathwayOverview.Skip(1)
                          Where Not String.Equals(row(2), "True")
                          Let item = NamedVector(Of String).CreateObject(row.First,
                     (
                         From strToken As String
                         In Strings.Split(row(4), "; ")
                         Where Not String.IsNullOrEmpty(strToken)
                         Select strToken
                         Order By strToken Ascending).ToArray)
                          Select item).ToArray
            Return LQuery
        End Function

        Public Shared Function Match(pathwayOverview As IO.File, Modules As String, COGProfile As IO.File) As IO.File
            Dim pathwayGenes = ImportsPathways(pathwayOverview)
            Dim ImportedModule = ImportsModules(Modules)
            Dim modulesGenes = BuildModules(ImportedModule)
            Dim itemList = (From [module] As NamedVector(Of String)
                            In modulesGenes
                            Let lstName As String() = (From pathway As NamedVector(Of String)
                                                       In pathwayGenes
                                                       Where Not pathway.vector.Union([module].vector).IsNullOrEmpty
                                                       Select pathway.name).ToArray
                            Select NamedVector(Of String).CreateObject([module].name, lstName)).ToArray
            Dim rows = (From i As Integer In itemList.Count.Sequence
                        Let [module] = itemList(i)
                        Select New IO.RowObject From {
                        [module].Key,
                        CInt(modulesGenes(i).vector.Count / ImportedModule.Count * 100),
                        CInt([module].Value.Count / pathwayGenes.Count * 100)}).ToArray

            Dim COGs = ModuleMatchCOG(ImportedModule, COGProfile)
            Dim COGFunction = SMRUCC.genomics.Assembly.NCBI.COG.Function.Default
            For i As Integer = 0 To rows.Count - 1
                Dim row = rows(i)
                Dim [module] As String = row(0)
                Dim LQuery = (From item In COGs Where String.Equals([module], item.Key) Select item.Value).ToArray
                Call row.AddRange((From n In COGFunction.Statistics(LQuery) Select CInt(n / ImportedModule.Count * 100)).ToArray.ToStringArray)
            Next

            Dim newFile As IO.File = New IO.File
            Call newFile.AppendLine(New String() {"module", "gene_counts", "associated_pathways", "INFORMATION STORAGE AND PROCESSING", "CELLULAR PROCESSES AND SIGNALING", "METABOLISM", "POORLY CHARACTERIZED"})
            Call newFile.AppendRange(rows)

            Return newFile
        End Function

        Public Shared Function ModuleMatchCOG(importedModules As KeyValuePair(), COGProfile As IO.File) As KeyValuePair()
            Dim LQuery = (From item In importedModules
                          Let cog = COGProfile.FindAtColumn(item.Key, 0)
                          Where Not cog.IsNullOrEmpty
                          Let category = cog.First()(3)
                          Select KeyValuePair.CreateObject(item.Value, category)).ToArray
            Return LQuery
        End Function
    End Class
End Namespace
