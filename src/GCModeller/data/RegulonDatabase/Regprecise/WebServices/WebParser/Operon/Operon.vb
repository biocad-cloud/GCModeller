﻿#Region "Microsoft.VisualBasic::f802b624648675c019f2af695f383742, data\RegulonDatabase\Regprecise\WebServices\WebParser\Operon.vb"

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

'     Class Operon
' 
'         Properties: ID, members
' 
'         Function: __geneParser, __locusParser, __operonParser, OperonParser, PageParser
'                   ToString
' 
' 
' /********************************************************************************/

#End Region

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Serialization.JSON
Imports Microsoft.VisualBasic.Text.Xml.Models

Namespace Regprecise

    ''' <summary>
    ''' Operon that regulated in a regulon
    ''' </summary>
    ''' 
    <XmlType("operon")> Public Class Operon : Inherits ListOf(Of RegulatedGene)

        <XmlAttribute("id")>
        Public Property ID As String

        <XmlElement("member")>
        Public Property members As RegulatedGene()

        Public Overrides Function ToString() As String
            With members _
                .Where(Function(g)
                           Return Not g.name.StringEmpty
                       End Function) _
                .Select(Function(g) g.name) _
                .ToArray

                If Not .IsNullOrEmpty Then
                    Return .GetJson
                Else
                    Return members _
                        .Select(Function(g) g.locusId) _
                        .ToArray _
                        .GetJson
                End If
            End With
        End Function

        Public Shared Function PageParser(url As String, Optional cache$ = "./.regprecise/operons/") As Operon()
            Static query As New Dictionary(Of String, OperonQuery)

            Dim webApi As OperonQuery = query.ComputeIfAbsent(
                key:=cache,
                lazyValue:=Function()
                               Return New OperonQuery(cache,,)
                           End Function)

            Return webApi.Query(Of Operon())(url, ".html")
        End Function

        Protected Overrides Function getSize() As Integer
            Return members.Length
        End Function

        Protected Overrides Function getCollection() As IEnumerable(Of RegulatedGene)
            Return members
        End Function
    End Class
End Namespace