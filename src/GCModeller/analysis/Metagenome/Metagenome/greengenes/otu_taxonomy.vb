﻿#Region "Microsoft.VisualBasic::5ee42a22956bfee578c9d9a46c8dc4cc, ..\GCModeller\analysis\Metagenome\Metagenome\greengenes\otu_taxonomy.vb"

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

Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository
Imports SMRUCC.genomics.Metagenomics

Namespace greengenes

    Public Class otu_taxonomy : Implements INamedValue

        Public Property ID As String Implements IKeyedEntity(Of String).Key
        Public Property Taxonomy As Taxonomy

        Public Overrides Function ToString() As String
            Return Taxonomy.CreateTable.Value.TaxonomyString
        End Function

        Public Shared Function Load(path As String) As IEnumerable(Of otu_taxonomy)
            Return path _
                .IterateAllLines _
                .AsParallel _
                .Select(AddressOf Parser)
        End Function

        Private Shared Function Parser(line As String) As otu_taxonomy
            Dim data = line.GetTagValue(vbTab, trim:=True)
            Dim table = BIOMTaxonomy.TaxonomyParser(data.Value)
            Dim taxonomy As New Taxonomy(table)

            Return New otu_taxonomy With {
                .ID = data.Name,
                .Taxonomy = taxonomy
            }
        End Function
    End Class
End Namespace
