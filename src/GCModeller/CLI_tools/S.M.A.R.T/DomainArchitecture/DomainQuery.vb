﻿#Region "Microsoft.VisualBasic::1589cfd490bf0d9976592abb4e91a194, ..\GCModeller\CLI_tools\S.M.A.R.T\DomainArchitecture\DomainQuery.vb"

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

Imports SMRUCC.genomics.ProteinModel

Public Class DomainQuery

    Dim ListData As protein()

    Sub New(SMARTDB As SMARTDB)
        ListData = SMARTDB.Proteins
    End Sub

    Public Function Query(DomainId As String) As SequenceModel.FASTA.FastaFile
        Dim LQuery = From Protein In ListData Where Protein.ContainsDomain(DomainId) Select Protein.EXPORT '
        Dim File = CType(LQuery.ToArray, SequenceModel.FASTA.FastaFile)
        Call File.Save(Settings.TEMP & "/" & DomainId & ".fsa")
        Return File
    End Function
End Class

