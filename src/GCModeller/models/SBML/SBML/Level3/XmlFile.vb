﻿#Region "Microsoft.VisualBasic::622d737b6d2c3a6a3b48a5b939809e57, SBML\SBML\Level3\XmlFile.vb"

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

    '     Class XmlFile
    ' 
    '         Properties: level, model, version
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Function: LoadDocument, ToString
    ' 
    '     Class Model
    ' 
    '         Properties: listOfCompartments, listOfFunctionDefinitions, listOfReactions, listOfSpecies, listOfUnitDefinitions
    '                     notes
    ' 
    '     Class functionDefinition
    ' 
    '         Properties: math
    ' 
    '     Class Compartment
    ' 
    '         Properties: Constant, Size
    ' 
    '     Class Species
    ' 
    '         Properties: annotation, constant, hasOnlySubstanceUnits, initialConcentration, metaid
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.MIME.application.rdf_xml
Imports SMRUCC.genomics.Model.SBML.Components

Namespace Level3

    <XmlRoot("sbml", Namespace:="http://www.sbml.org/sbml/level3/version1/core")>
    Public Class XmlFile(Of T As Reaction)

        <XmlAttribute("level")> Public Property level As Integer
        <XmlAttribute("version")> Public Property version As Integer
        <XmlElement("model")> Public Property model As Model(Of T)

        <XmlNamespaceDeclarations()>
        Public xmlns As New XmlSerializerNamespaces

        Sub New()
            xmlns.Add("rdf", RDFEntity.XmlnsNamespace)
        End Sub

        Public Overrides Function ToString() As String
            Return model.ToString
        End Function

        Public Shared Function LoadDocument(xml As String) As XmlFile(Of T)
            Return xml.LoadXml(Of XmlFile(Of T))
        End Function
    End Class

    <XmlType("model", Namespace:=sbmlXmlns)>
    Public Class Model(Of T As Reaction) : Inherits ModelBase

        <XmlElement("notes")> Public Property notes As Notes

        Public Property listOfCompartments As Compartment()
        Public Property listOfSpecies As Species()
        Public Property listOfReactions As T()
        Public Property listOfUnitDefinitions As unitDefinition()
        Public Property listOfFunctionDefinitions As functionDefinition()
    End Class

    Public Class functionDefinition : Inherits IPartsBase

        <XmlElement("math", [Namespace]:="http://www.w3.org/1998/Math/MathML")>
        Public Property math As Math
    End Class

    <XmlType("compartment", Namespace:="http://www.sbml.org/sbml/level3/version1/core")>
    Public Class Compartment : Inherits Components.Compartment
        <XmlAttribute("size")> Public Property Size As Integer
        <XmlAttribute("constant")> Public Property Constant As Boolean
    End Class

    <XmlType("species", Namespace:=sbmlXmlns)>
    Public Class Species : Inherits Components.Specie
        <XmlAttribute> Public Property hasOnlySubstanceUnits As Boolean
        <XmlAttribute> Public Property constant As Boolean
        <XmlAttribute> Public Property metaid As String
        <XmlAttribute> Public Property initialConcentration As Double

        Public Property annotation As annotation
    End Class
End Namespace
