﻿#Region "Microsoft.VisualBasic::d2f20568e51bc93a216cdb1f5ac4f6fe, ..\sciBASIC#\gr\Microsoft.VisualBasic.Imaging\Drawing2D\Text\Text.vb"

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

Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Imaging.BitmapImage
Imports Microsoft.VisualBasic.MIME.Markup.HTML.Render
Imports Microsoft.VisualBasic.Scripting.Expressions

Namespace Drawing2D.Text

    ''' <summary>
    ''' 基于HTML语法的字符串的绘制描述信息的解析
    ''' </summary>
    Public Module TextRender

        ReadOnly HTMLtemplate$ = (
            <html>
                <head>
                    <style type="text/css">
                    body {
                        $font
                    }
                    </style>
                </head>
                <body>
                    $text
                </body>
            </html>).ToString

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="g"></param>
        ''' <param name="text$"></param>
        ''' <param name="CSS_style$"></param>
        ''' <param name="location">默认是 ``(0, 0)``</param>
        ''' <param name="maxWidth%"></param>
        <Extension>
        Public Sub RenderHTML(ByRef g As Graphics, text$, CSS_style$, Optional location As PointF = Nothing, Optional maxWidth% = 1024)
            Dim table As New Dictionary(Of String, String) From {
                {"font", CSS_style},
                {"text", text}
            }
            Dim html$ = HTMLtemplate _
                .Interpolate(table, nullAsEmpty:=True)

            Call HtmlRenderer.Render(
                g, html,
                location, maxWidth)
        End Sub

        ''' <summary>
        ''' Rendering the html text as gdi+ image
        ''' </summary>
        ''' <param name="label$">HTML</param>
        ''' <param name="cssFont$">For html ``&lt;p>...&lt;/p>`` css style</param>
        ''' <param name="maxSize$"></param>
        ''' <returns></returns>
        Public Function DrawHtmlText(label$, cssFont$, Optional maxSize$ = "1600,600") As Image
            Using g As Graphics2D = New Size(1600, 600).CreateGDIDevice(Color.Transparent)
                Dim out As Image

                TextRender.RenderHTML(g.Graphics, label, cssFont,, maxWidth:=g.Width)
                out = g.ImageResource
                out = out.CorpBlank(blankColor:=Color.Transparent)

                Return out
            End Using
        End Function
    End Module
End Namespace
