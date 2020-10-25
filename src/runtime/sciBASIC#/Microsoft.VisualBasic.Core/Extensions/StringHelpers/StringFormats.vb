﻿#Region "Microsoft.VisualBasic::b0cb08a2031318c848dffaf376a0884f, Microsoft.VisualBasic.Core\Extensions\StringHelpers\StringFormats.vb"

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

' Module StringFormats
' 
'     Function: Lanudry
' 
' /********************************************************************************/

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ApplicationServices.Terminal
Imports Microsoft.VisualBasic.Language.C
Imports stdNum = System.Math

Public Module StringFormats

    ''' <summary>
    ''' 对bytes数值进行格式自动优化显示
    ''' </summary>
    ''' <param name="bytes"></param>
    ''' <returns>经过自动格式优化过后的大小显示字符串</returns>
    Public Function Lanudry(bytes As Double) As String
        If bytes <= 0 Then
            Return "0 B"
        End If

        Dim symbols = {"B", "KB", "MB", "GB", "TB"}
        Dim exp = stdNum.Floor(stdNum.Log(bytes) / stdNum.Log(1000))
        Dim symbol = symbols(exp)
        Dim val = (bytes / (1000 ^ stdNum.Floor(exp)))

        Return sprintf($"%.2f %s", val, symbol)
    End Function

    ''' <summary>
    ''' ``days, hh:mm:ss.ms``
    ''' </summary>
    ''' <param name="t"></param>
    ''' <returns></returns>
    ''' 
    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    <Extension>
    Public Function FormatTime(t As TimeSpan) As String
        With t
            Return $"{ZeroFill(.Days, 2)}, {ZeroFill(.Hours, 2)}:{ZeroFill(.Minutes, 2)}:{ZeroFill(.Seconds, 2)}.{ ZeroFill(.Milliseconds, 3)}"
        End With
    End Function

    <Extension>
    Public Function Lanudry(timespan As TimeSpan) As String
        If timespan < TimeSpan.FromMinutes(1) Then
            Return $"{timespan.TotalSeconds} seconds"
        ElseIf timespan < TimeSpan.FromHours(1) Then
            Return $"{timespan.TotalMinutes} min"
        ElseIf timespan < TimeSpan.FromDays(1) Then
            Return $"{timespan.TotalHours} hours"
        Else
            Return timespan.FormatTime
        End If
    End Function
End Module
