﻿#Region "Microsoft.VisualBasic::d1f9749f36915c1efd6d8102f9c04177, data\SABIO-RK\SBML\SbmlDocument.vb"

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

    '     Class SbmlDocument
    ' 
    '         Properties: mathML, sbml
    ' 
    '         Function: LoadDocument
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.MIME.application.xml.MathML
Imports Microsoft.VisualBasic.Text
Imports SMRUCC.genomics.Model.SBML.Level3

Namespace SBML

    Public Class SbmlDocument

        Public Property sbml As XmlFile(Of SBMLReaction)
        Public Property mathML As NamedValue(Of LambdaExpression)()

        Public Shared Function LoadDocument(path As String) As SbmlDocument
            Dim text As String = path.SolveStream

            If text.Trim(" "c, ASCII.TAB, ASCII.CR, ASCII.LF) = "No results found for query" Then
                Return Nothing
            End If

            Dim sbml As XmlFile(Of SBMLReaction) = text.LoadFromXml(Of XmlFile(Of SBMLReaction))
            Dim math = MathMLParser.ParseMathML(sbmlText:=text).ToArray
            Dim formulas As NamedValue(Of LambdaExpression)() = math _
                .Select(Function(a)
                            Return New NamedValue(Of LambdaExpression) With {
                                .Name = a.Name,
                                .Description = a.Description,
                                .Value = LambdaExpression.FromMathML(a.Value)
                            }
                        End Function) _
                .ToArray

            Return New SbmlDocument With {
                .sbml = sbml,
                .mathML = formulas
            }
        End Function
    End Class
End Namespace
