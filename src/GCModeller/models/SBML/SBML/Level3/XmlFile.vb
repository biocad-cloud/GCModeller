﻿#Region "Microsoft.VisualBasic::b567f8088cf6f9e970891b0ccd1f64b2, models\SBML\SBML\Level3\XmlFile.vb"

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
'         Properties: Level, ModelData, Version
' 
'         Function: ToString
' 
'     Class Model
' 
'         Properties: ListOfCompartment, ListOfReactions, ListOfSpecies
' 
'     Class Compartment
' 
'         Properties: Constant, Size
' 
'     Class Species
' 
'         Properties: constant, hasOnlySubstanceUnits
' 
'     Class Reaction
' 
'         Properties: id, listOfModifiers, listOfProducts, listOfReactants, name
'                     Notes, reversible
' 
'         Function: ToString
' 
'     Class modifierSpeciesReference
' 
'         Properties: species
' 
'         Function: ToString
' 
'     Class SpeciesReference
' 
'         Properties: Constant
' 
'     Class kineticLaw
' 
'         Properties: AnnotationData, listOfLocalParameters, Math, metaid, sboTerm
'         Class annotation
' 
'             Properties: _sbrk, bqbiol, rdf, RDFData, sabiorkValue
'             Class sabiork
' 
'                 Properties: ExperimentConditionsValue, kineticLawID
'                 Class experimentalConditions
' 
'                     Properties: buffer, pHValue, TempratureValue
' 
'                 Class temperature
' 
'                     Properties: startValueTemperature, temperatureUnit
' 
'                 Class pH
' 
'                     Properties: startValuepH
' 
' 
' 
' 
' 
' 
' 
'     Class RDF
' 
'         Properties: bqbiol, bqmodel, DescriptionValue, rdf
'         Class Description
' 
'             Properties: about, isDescribedBy
' 
'         Class isDescribedBy
' 
'             Properties: Bag
' 
'         Class Bag
' 
'             Properties: li
' 
'         Class li
' 
'             Properties: resource
' 
' 
' 
'     Class Math
' 
'         Properties: applyValue
'         Class Apply
' 
'             Properties: VaslueCollection
' 
' 
' 
'     Class localParameter
' 
'         Properties: id, name, sboTerm, units, value
' 
' 
' /********************************************************************************/

#End Region

Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.MIME.application.rdf_xml
Imports SMRUCC.genomics.Model.SBML.Components

Namespace Level3

    <XmlRoot("sbml", Namespace:="http://www.sbml.org/sbml/level3/version1/core")>
    Public Class XmlFile

        Public Const XmlNamespace As String = "http://www.sbml.org/sbml/level3/version1/core"

        <XmlAttribute("level")> Public Property level As Integer
        <XmlAttribute("version")> Public Property version As Integer
        <XmlElement("model")> Public Property model As Model

        <XmlNamespaceDeclarations()>
        Public xmlns As New XmlSerializerNamespaces

        Sub New()
            xmlns.Add("rdf", RDFEntity.XmlnsNamespace)
        End Sub

        Public Overrides Function ToString() As String
            Return model.ToString
        End Function

        Public Shared Function LoadDocument(xml As String) As XmlFile
            Return xml.LoadXml(Of XmlFile)
        End Function
    End Class

    <XmlType("model", Namespace:=XmlFile.XmlNamespace)>
    Public Class Model : Inherits ModelBase

        <XmlElement("notes")> Public Property notes As Notes

        Public Property listOfCompartments As Compartment()
        Public Property listOfSpecies As Species()
        Public Property listOfReactions As Reaction()
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

    <XmlType("species", Namespace:=XmlFile.XmlNamespace)>
    Public Class Species : Inherits Components.Specie
        <XmlAttribute> Public Property hasOnlySubstanceUnits As Boolean
        <XmlAttribute> Public Property constant As Boolean
        <XmlAttribute> Public Property metaid As String
        <XmlAttribute> Public Property initialConcentration As Double

        Public Property annotation As annotation
    End Class
End Namespace
