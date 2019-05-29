﻿#Region "Microsoft.VisualBasic::7cdcee0f9c1010fd3239abb95a42fd09, v1.0\namesOf.vb"

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

'     Class namesOf
' 
' 
' 
' 
' /********************************************************************************/

#End Region

Namespace v10

    ''' <summary>
    ''' ``&lt;string>`` Table type (a controlled vocabulary) acceptable values
    ''' </summary>
    Public NotInheritable Class namesOf

        Public Const OTU_table As String = "OTU table"
        Public Const Pathway_table As String = "Pathway table"
        Public Const Function_table As String = "Function table"
        Public Const Ortholog_table As String = "Ortholog table"
        Public Const Gene_table As String = "Gene table"
        Public Const Metabolite_table As String = "Metabolite table"
        Public Const Taxon_table As String = "Taxon table"

        Private Sub New()
        End Sub
    End Class

    Public NotInheritable Class matrix_element_type

        Public Const int As String = "int"
        Public Const float As String = "float"
        Public Const unicode As String = "unicode"

        Private Sub New()
        End Sub
    End Class

    ''' <summary>
    ''' ###### 2019-05-27
    ''' 
    ''' 因为自带的JSON序列化函数会将枚举类型转换为对应的值，而非枚举成员的名称字符串
    ''' 所以在这里就直接使用字符串常数来表示枚举了
    ''' </summary>
    Public NotInheritable Class matrix_type

        Public Const dense As String = "dense"
        Public Const sparse As String = "sparse"

        Private Sub New()
        End Sub
    End Class
End Namespace
