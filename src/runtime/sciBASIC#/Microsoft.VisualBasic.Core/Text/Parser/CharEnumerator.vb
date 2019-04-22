﻿#Region "Microsoft.VisualBasic::32540340e40f011eb25715d86b4d03fe, Microsoft.VisualBasic.Core\Text\Parser\CharEnumerator.vb"

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

    '     Class CharPtr
    ' 
    '         Properties: Remaining
    ' 
    '         Constructor: (+1 Overloads) Sub New
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Emit.Marshal

Namespace Text.Parser

    Public Class CharPtr : Inherits Pointer(Of Char)

        ''' <summary>
        ''' 查看还有多少字符没有被处理完
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Remaining As String
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return buffer.Skip(index).CharString
            End Get
        End Property

        Sub New(data As String)
            Call MyBase.New(data)
        End Sub

        ''' <summary>
        ''' 这个调试试图函数会将当前的读取位置给标记出来
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String
            Dim previous$ = buffer.Take(index).CharString
            Dim current As Char = Me.Current
            Dim remaining$ = Me.Remaining

            Return $"{previous} ->[{current}]<- {remaining}"
        End Function
    End Class
End Namespace
