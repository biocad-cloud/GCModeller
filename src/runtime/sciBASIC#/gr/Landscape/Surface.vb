﻿#Region "Microsoft.VisualBasic::644bd23f8da243f8a93afc4eae43b20b, ..\sciBASIC#\gr\Landscape\Surface.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
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

Imports System.Drawing
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Imaging.Drawing2D
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON

''' <summary>
''' 方便将3D模型保存与XML文件之中的数据模型对象
''' </summary>
''' <remarks>
''' 2017.1.30
''' 由于受到XML序列化的限制，这里就不再实现这个枚举接口了
''' </remarks>
Public Class Surface ': Implements IEnumerable(Of Point3D)

    ''' <summary>
    ''' 请注意，在这里面的点都是有先后顺序分别的，为了模型文件的XML文档结构的可读性，
    ''' 在这里并不是直接使用<see cref="Point3D"/>来保存的，而是使用一个向量来保存
    ''' ``xyz``的坐标数据
    ''' </summary>
    <XmlElement>
    Public Property vertices As Vector()
    ''' <summary>
    ''' 这个是本``表面``对象所喷涂的纹理的定义，可以是颜色的名称或者表达式，也可以是图片的相对路径的引用
    ''' </summary>
    ''' <returns></returns>
    <XmlAttribute>
    Public Property paint As String

    ''' <summary>
    ''' 将<see cref="paint"/>资源字符串转换为相对应的<see cref="Brush"/>画刷对象.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Brush As Brush
        Get
            Return paint.GetBrush
        End Get
    End Property

    Public Function CreateObject() As Drawing3D.Surface
        Return New Drawing3D.Surface With {
            .vertices = vertices.ToArray(Function(pt) pt.PointData),
            .brush = Brush
        }
    End Function

    Public Overrides Function ToString() As String
        Return paint
    End Function

    'Public Iterator Function GetEnumerator() As IEnumerator(Of Point3D) Implements IEnumerable(Of Point3D).GetEnumerator
    '    For Each x As Point3D In vertices
    '        Yield x
    '    Next
    'End Function

    'Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
    '    Yield GetEnumerator()
    'End Function
End Class

Public Structure Vector

    ''' <summary>
    ''' 2017-1-30
    ''' 因为在进行XML存储的时候，可能会由于需要调整格式对齐数字，所以在这里使用字符串来存储数据，
    ''' 否则直接使用数组会因为格式的变化而无法被读取
    ''' </summary>
    ''' <returns></returns>
    <XmlAttribute>
    Public Property Point3D As String

    Public ReadOnly Property PointData As Point3D
        Get
            Dim v As Single() = Me.Point3D _
                .Split() _
                .Where(Function(t) Not t.IsBlank) _
                .ToArray(Function(s) CSng(s))
            Return New Point3D(v(Scan0), v(1), v(2))
        End Get
    End Property

    Sub New(pt As Point3D)
        With pt
            Point3D = { .X, .Y, .Z}.JoinBy(" ")
        End With
    End Sub

    Public Overrides Function ToString() As String
        Return PointData.GetJson
    End Function
End Structure
