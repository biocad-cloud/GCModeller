﻿#Region "Microsoft.VisualBasic::0b191b9ac322c3bf2a7b7b816ba148a0, Microsoft.VisualBasic.Core\Serialization\BinaryDumping\BinaryWriter.vb"

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

'     Module BinaryWriter
' 
'         Function: __serialize, GetReadProperty, (+2 Overloads) Serialization
' 
' 
' /********************************************************************************/

#End Region

Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Text

Namespace Serialization.BinaryDumping

    Public Module BinaryWriter

        ReadOnly utf8 As Encoding = Encodings.UTF8WithoutBOM.CodePage

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        <Extension>
        Public Function Serialization(Of T)(obj As T) As Byte()
            Return Serialization(obj, GetType(T)).ToArray
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function Serialization(obj As Object, type As Type) As List(Of Byte)
            ' 为了解决对象之间的循环引用的问题
            Return serializeInternal(obj, type, New Index(Of Object))
        End Function

        Private Function serializeInternal(obj As Object, type As Type, ByRef visited As Index(Of Object)) As List(Of Byte)
            Dim readProps As Dictionary(Of String, PropertyInfo) = DataFramework.Schema(type, PropertyAccess.Readable,, nonIndex:=True)
            Dim buffer As New List(Of Byte)
            Dim value As Object

            For Each prop As KeyValuePair(Of String, PropertyInfo) In readProps
                type = prop.Value.PropertyType
                value = prop.Value.GetValue(obj, Nothing)

                If DataFramework.IsPrimitive(type) Then
                    ' 基础类型,直接写入数据
                    Select Case type
                        Case GetType(Date)
                            buffer += BitConverter.GetBytes(DirectCast(value, Date).ToBinary)
                        Case GetType(String)
                            buffer += utf8.GetBytes(DirectCast(value, String))
                        Case GetType(Integer)
                            buffer += BitConverter.GetBytes(DirectCast(value, Integer))
                        Case GetType(Long)
                        Case GetType(Double)

                    End Select
                End If
            Next

            Return buffer
        End Function
    End Module
End Namespace
