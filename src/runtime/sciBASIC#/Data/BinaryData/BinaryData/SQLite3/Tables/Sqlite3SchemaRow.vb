﻿#Region "Microsoft.VisualBasic::59626a901b27b36a0499b7cd00bc1aad, Data\BinaryData\BinaryData\SQLite3\Tables\Sqlite3SchemaRow.vb"

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

    '     Class Sqlite3SchemaRow
    ' 
    '         Properties: name, rootPage, Sql, tableName, type
    ' 
    '         Function: ParseSchema, ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Namespace ManagedSqlite.Core.Tables

    Public Class Sqlite3SchemaRow

        Public Property type As String
        Public Property name As String
        Public Property tableName As String
        Public Property rootPage As UInteger
        Public Property Sql As String

        Public Overrides Function ToString() As String
            If type.TextEquals("table") Then
                Return Sql
            Else
                Return $"[{type}] {tableName}|{name}"
            End If
        End Function

        Public Function ParseSchema(Optional removeNameEscape As Boolean = False) As Schema
            Dim columns As String() = Sql _
                .GetStackValue("(", ")") _
                .StringReplace("UNIQUE\s*\(.+?\)", "") _
                .StringSplit("\s*,\s*")

            ' 有一些字段的名称可能是包含有空格或者小数点之类的,
            ' 则这些字段名称会被[]转义
            ' 在下面的构造函数调用过程之中会根据参数值来自动处理这些转义
            Return New Schema(columns, removeNameEscape)
        End Function

    End Class
End Namespace
