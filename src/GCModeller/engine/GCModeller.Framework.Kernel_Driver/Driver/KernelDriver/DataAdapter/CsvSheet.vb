﻿#Region "Microsoft.VisualBasic::f9b935fa94a1fa11d48a63a4417cda4c, ..\GCModeller\engine\GCModeller.Framework.Kernel_Driver\Driver\KernelDriver\DataAdapter\CsvSheet.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
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


''' <summary>
''' 泛型仅能够包含有有限的几种基本的值类型
''' </summary>
''' <typeparam name="T"></typeparam>
''' <remarks></remarks>
Public Class MsCsvChunkBuffer(Of T) : Inherits DataStorage(Of T, DataStorage.FileModel.DataSerials(Of T))

    Dim _kernelDriver As IKernelDriver

    Public Function AttachKernel(driver As IKernelDriver) As MsCsvChunkBuffer(Of T)
        _kernelDriver = driver
        Return Me
    End Function

    Public Overrides Function WriteData(chunkbuffer As IEnumerable(Of DataStorage.FileModel.DataSerials(Of T)), url As String) As Boolean
        Dim File As DocumentFormat.Csv.DocumentStream.File = get_Result(chunkbuffer)
        Return File.Save(url, False)
    End Function

    Public Shared Function Generate_CsvRow(Line As DataStorage.FileModel.DataSerials(Of T)) As Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream.RowObject
        Dim Row As Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream.RowObject =
            New DocumentFormat.Csv.DocumentStream.RowObject From {Line.UniqueId}
        Dim array As String() = (From n As T In Line.Samples Let strValue As String = n.ToString Select strValue).ToArray
        Call Row.AddRange(array)
        Return Row
    End Function

    Public Const TIMETicksTAG As String = "#Time/Ticks"

    Public Function get_Result(ChunkBuffer As IEnumerable(Of DataStorage.FileModel.DataSerials(Of T))) As Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream.File
        Dim LQuery = (From item In ChunkBuffer.AsParallel Select Generate_CsvRow(item)).ToArray
        Dim File As Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream.File = New DocumentFormat.Csv.DocumentStream.File
        Call File.AppendLine(New String() {TIMETicksTAG})
        Call File.Last.AddRange((From i In ChunkBuffer.First.Samples.Sequence Select CStr(i)).ToArray)
        Call File.AppendRange(LQuery)

        Return File
    End Function

    Public Function get_Result(driver As IDriver_DataSource_Adapter(Of T)) As Microsoft.VisualBasic.DocumentFormat.Csv.DocumentStream.File
        Dim chunkbuffer = driver.get_DataSerials
        Dim File = get_Result(chunkbuffer)
        Return File
    End Function

    Public Overloads Overrides Function WriteData(url As String) As Boolean
        Dim package = get_Result(DirectCast(_kernelDriver, IDriver_DataSource_Adapter(Of T)))
        Return package.Save(url, False)
    End Function
End Class


