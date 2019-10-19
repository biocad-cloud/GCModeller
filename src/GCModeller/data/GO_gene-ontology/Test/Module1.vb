﻿#Region "Microsoft.VisualBasic::f06b50cb6121aaa6d1a5562d5f4f4410, GO_gene-ontology\Test\Module1.vb"

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

' Module Module1
' 
'     Sub: Main
' 
' /********************************************************************************/

#End Region

Imports SMRUCC.genomics.Data.GeneOntology.OBO

Module Module1

    Sub Main()

        Dim test = GO_OBO.LoadDocument("P:\go.obo")

        Pause()

        Call loadertest()
    End Sub

    Sub loadertest()
        Dim tree = SMRUCC.genomics.Data.GeneOntology.DAG.BuildTree("H:\GO_DB\go-basic.obo")

        Dim file = GO_OBO.LoadDocument("G:\GCModeller\src\GCModeller\data\GO_gene-ontology\obographs\resources\basic.obo")
        file = GO_OBO.LoadDocument("G:\GCModeller\src\GCModeller\data\GO_gene-ontology\obographs\resources\equivNodeSetTest.obo")

        Pause()
    End Sub
End Module
