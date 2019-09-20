﻿#Region "Microsoft.VisualBasic::f1692826a1fa57ef3ba35fd608e6394f, shared\RNA-Seq.Doc\SampleTable.vb"

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

    '     Class SampleTable
    ' 
    '         Properties: condition, fileName, sampleName
    ' 
    '         Function: ToString
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports Microsoft.VisualBasic.Serialization
Imports Microsoft.VisualBasic.Serialization.JSON

Namespace DESeq2

    ''' <summary>
    ''' for htseq-count: a data.frame with three or more columns.                               
    ''' Each row describes one sample. The first column Is the sample name, the second column the file name of the count file generated by htseq-count,                               
    ''' And the remaining columns are sample metadata which will be stored in colData
    ''' </summary>
    Public Class SampleTable
        Public Property sampleName As String
        Public Property fileName As String
        Public Property condition As String

        Public Overrides Function ToString() As String
            Return Me.GetJson
        End Function
    End Class
End Namespace
