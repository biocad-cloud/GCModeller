﻿#Region "Microsoft.VisualBasic::93780abbb8a78200356e4068a3ca3e1d, Microsoft.VisualBasic.Core\Language\Value\DefaultValue\DefaultString.vb"

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

    '     Structure DefaultString
    ' 
    '         Properties: DefaultValue, IsEmpty
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Function: assertIsNothing, LoadJson, LoadXml, ToString
    '         Operators: (+2 Overloads) IsFalse, (+2 Overloads) IsTrue, (+6 Overloads) Or
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Serialization.JSON
Imports CLI = Microsoft.VisualBasic.CommandLine.CommandLine

Namespace Language.Default

    ''' <summary>
    ''' <see cref="CLI"/> optional value helper data model
    ''' </summary>
    Public Structure DefaultString : Implements IDefaultValue(Of String)
        Implements IsEmpty

        ''' <summary>
        ''' The optional argument value that read from <see cref="CLI"/> 
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property DefaultValue As String Implements IDefaultValue(Of String).DefaultValue

        ''' <summary>
        ''' <see cref="DefaultValue"/> is empty?
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property IsEmpty As Boolean Implements IsEmpty.IsEmpty
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return DefaultValue.StringEmpty
            End Get
        End Property

        Sub New([string] As String)
            DefaultValue = [string]
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function LoadXml(Of T)() As T
            Return DefaultValue.LoadXml(Of T)
        End Function

        ''' <summary>
        ''' 如果文件不存在或者文本内容为空，则函数返回空值
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <returns></returns>
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Function LoadJson(Of T)() As T
            If DefaultValue.FileExists Then
                Return DefaultValue.ReadAllText.LoadJSON(Of T)
            ElseIf DefaultValue.StringEmpty Then
                Return Nothing
            Else
                Return DefaultValue.LoadJSON(Of T)
            End If
        End Function

        Public Overrides Function ToString() As String
            Return DefaultValue
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Private Shared Function assertIsNothing(s As String) As Boolean
            Return s Is Nothing OrElse String.IsNullOrEmpty(s)
        End Function

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Narrowing Operator CType(str As DefaultString) As Boolean
            Return str.DefaultValue.ParseBoolean
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Narrowing Operator CType(str As DefaultString) As Integer
            Return str.DefaultValue.ParseDouble
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Narrowing Operator CType(str As DefaultString) As Double
            Return str.DefaultValue.ParseDouble
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Narrowing Operator CType(str As DefaultString) As Long
            Return str.DefaultValue.ParseDouble
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Narrowing Operator CType(str As DefaultString) As Single
            Return str.DefaultValue.ParseDouble
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Narrowing Operator CType(str As DefaultString) As Short
            Return str.DefaultValue.ParseDouble
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Widening Operator CType(str As String) As DefaultString
            Return New DefaultString(str)
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Operator IsTrue(str As DefaultString) As Boolean
            Return CType(str, Boolean)
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Operator IsFalse(str As DefaultString) As Boolean
            Return False = CType(str, Boolean)
        End Operator

        ''' <summary>
        ''' If <paramref name="value"/> is empty then returns <paramref name="default"/>, 
        ''' else returns <paramref name="value"/> itself.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <param name="default$"></param>
        ''' <returns></returns>
        Public Shared Operator Or(value As DefaultString, default$) As String
            If assertIsNothing(value.DefaultValue) Then
                Return [default]
            Else
                Return value.DefaultValue
            End If
        End Operator

        ''' <summary>
        ''' Get a <see cref="Integer"/> value or using default <see cref="Integer"/> value.
        ''' </summary>
        ''' <param name="value"></param>
        ''' <param name="x%"></param>
        ''' <returns></returns>
        Public Shared Operator Or(value As DefaultString, x%) As Integer
            Return CInt(value Or CDbl(x))
        End Operator

        Public Shared Operator Or(value As DefaultString, x#) As Double
            If assertIsNothing(value.DefaultValue) Then
                Return x
            Else
                Return Val(value.DefaultValue)
            End If
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Narrowing Operator CType(value As DefaultString) As String
            Return value.DefaultValue
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Operator &(s1 As DefaultString, s2$) As String
            Return s1.DefaultValue & s2
        End Operator

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Shared Operator &(s1$, s2 As DefaultString) As String
            Return s1 & s2.DefaultValue
        End Operator
    End Structure
End Namespace
