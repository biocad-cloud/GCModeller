﻿#Region "Microsoft.VisualBasic::b14448a5b78e7b9bb7c9c6d62ca43ab1, ..\GCModeller\core\Bio.Assembly\Assembly\NCBI\Database\COG\Categories.vb"

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

Imports System.ComponentModel

Namespace Assembly.NCBI.COG

    Public Enum COGCategories As Integer

        ''' <summary>
        ''' No function category assigned to this gene
        ''' </summary>
        <Description("NOT ASSIGNED")> NotAssigned = -100
        ''' <summary>
        ''' INFORMATION STORAGE AND PROCESSING
        ''' </summary>
        <Description("INFORMATION STORAGE AND PROCESSING")> Genetics = 2
        ''' <summary>
        ''' CELLULAR PROCESSES AND SIGNALING
        ''' </summary>
        <Description("CELLULAR PROCESSES AND SIGNALING")> Signaling = 4
        ''' <summary>
        ''' METABOLISM
        ''' </summary>
        <Description("METABOLISM")> Metabolism = 8
        ''' <summary>
        ''' POORLY CHARACTERIZED
        ''' </summary>
        <Description("POORLY CHARACTERIZED")> Unclassified = 16
    End Enum

End Namespace
