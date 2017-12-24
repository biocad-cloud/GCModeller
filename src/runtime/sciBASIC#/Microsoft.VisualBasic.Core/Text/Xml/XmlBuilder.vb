﻿#Region "Microsoft.VisualBasic::9a400696d779fb1627c44851b354c3e5, ..\sciBASIC#\Microsoft.VisualBasic.Core\Text\Xml\XmlBuilder.vb"

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

Imports Microsoft.VisualBasic.Scripting.SymbolBuilder

Namespace Text.Xml.Models

    ''' <summary>
    ''' Builder for XML and html
    ''' </summary>
    Public Class XmlBuilder : Inherits ScriptBuilder

        Sub New()
            Call MyBase.New(1024)
        End Sub

        Public Overloads Shared Operator +(xb As XmlBuilder, node As XElement) As XmlBuilder
            Call xb.Script.AppendLine(node.ToString)
            Return xb
        End Operator
    End Class
End Namespace
