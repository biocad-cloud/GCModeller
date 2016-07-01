﻿Imports System.Text.RegularExpressions
Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports SMRUCC.genomics.ComponentModel.EquaionModel.DefaultTypes
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic

Namespace SabiorkKineticLaws.SBMLParser

    Public Class CompoundSpecie : Implements sIdEnumerable

        Public Property Id As String Implements sIdEnumerable.Identifier
        Public Property Name As String
        Public Property Identifiers As String()
        Public Property modifierType As String

        Public Overrides Function ToString() As String
            Return Name
        End Function

        Friend Shared Function TryParse(strData As String) As CompoundSpecie
            Dim ItemObject As CompoundSpecie = New CompoundSpecie
            ItemObject.Id = kineticLawModel.GetStringValue(Regex.Match(strData, "id="".+?""").Value)
            ItemObject.Name = kineticLawModel.GetStringValue(Regex.Match(strData, "name="".+?""").Value)
            ItemObject.Identifiers = (From m As Match In Regex.Matches(strData, "rdf:resource="".+?""") Select kineticLawModel.GetStringValue(m.Value)).ToArray
            ItemObject.modifierType = kineticLawModel.GetNodeValue(Regex.Match(strData, "<sbrk:modifierType>.+?</sbrk:modifierType>").Value)

            Return ItemObject
        End Function
    End Class

    Public Class kineticLawModel : Inherits Equation

        Public Property Identifiers As String()
        Public Property Modifiers As String()
        Public Property Fast As Boolean
        Public Property LocalParameters As TripleKeyValuesPair()

        Friend Shared Function TryParse(strData As String) As kineticLawModel
            Dim KineticRecord As kineticLawModel = New kineticLawModel
            KineticRecord.Identifiers = (From m As Match In Regex.Matches(strData, "rdf:resource="".+?""") Select GetStringValue(m.Value)).ToArray
            Dim strTemp As String = Regex.Match(strData, "<listOfReactants>.+?</listOfReactants>", RegexOptions.Singleline).Value
            Dim TempChunk As String() = (From m As Match In Regex.Matches(strTemp, "<speciesReference.+?/>") Select m.Value).ToArray
            KineticRecord.Reactants = (From strItem As String In TempChunk Select TryParseSpeciesReference(strItem)).ToArray
            strTemp = Regex.Match(strData, "<listOfProducts>.+?</listOfProducts>", RegexOptions.Singleline).Value
            TempChunk = (From m As Match In Regex.Matches(strTemp, "<speciesReference.+?/>") Select m.Value).ToArray
            KineticRecord.Products = (From strItem As String In TempChunk Select TryParseSpeciesReference(strItem)).ToArray
            KineticRecord.Reversible = GetStringValue(Regex.Match(strData, "reversible="".+?""").Value)
            KineticRecord.Fast = GetStringValue(Regex.Match(strData, "fast="".+?""").Value)
            KineticRecord.LocalParameters = TryParseLocalParameters(Regex.Match(strData, "<listOfLocalParameters>.+?</listOfLocalParameters>", RegexOptions.Singleline).Value)

            Return KineticRecord
        End Function

        Private Shared Function TryParseLocalParameters(strData As String) As Microsoft.VisualBasic.ComponentModel.TripleKeyValuesPair()
            Dim TempChunk As String() = (From m As Match In Regex.Matches(strData, "<localParameter.+?/>", RegexOptions.Multiline) Select m.Value).ToArray
            Dim LQuery = (From strItem As String In TempChunk
                          Let strId As String = GetStringValue(Regex.Match(strItem, "id="".+?""").Value)
                          Let strName As String = GetStringValue(Regex.Match(strItem, "name="".+?""").Value)
                          Let strValue As String = GetStringValue(Regex.Match(strItem, "value="".+?""").Value)
                          Select New TripleKeyValuesPair With {.Key = strId, .Value1 = strName, .Value2 = strValue}).ToArray
            Return LQuery
        End Function

        Private Shared Function TryParseSpeciesReference(strData As String) As CompoundSpecieReference
            Dim Reference As CompoundSpecieReference = New CompoundSpecieReference
            Reference.Identifier = GetStringValue(Regex.Match(strData, "species="".+?""").Value)
            Reference.StoiChiometry = Val(GetStringValue(Regex.Match(strData, "stoichiometry="".+?""").Value))

            Return Reference
        End Function

        Public Shared Function LoadDocument(FilePath As String) As SABIORK
            Dim strData As String = FileIO.FileSystem.ReadAllText(FilePath)
            Dim kineticLawID As Long = Val(GetNodeValue(Regex.Match(strData, "<sbrk:kineticLawID>.+?</sbrk:kineticLawID>").Value))
            Dim CompoundSpecies = TryParseListOfSpecies(strData:=Regex.Match(strData, "<listOfSpecies>.+</listOfSpecies>", RegexOptions.Singleline).Value)
            Dim kineticLawModel = TryParseListOfReactions(strData:=Regex.Match(strData, "<listOfReactions>.+?</listOfReactions>", RegexOptions.Singleline).Value)
            Dim startValuepH As Double = Val(GetNodeValue(Regex.Match(strData, "<sbrk:startValuepH>.+?</sbrk:startValuepH>").Value))
            Dim startValueTemperature As Double = Val(GetNodeValue(Regex.Match(strData, "<sbrk:startValueTemperature>.+?</sbrk:startValueTemperature>").Value))
            Dim Buffer As String = GetNodeValue(Regex.Match(strData, "<sbrk:buffer>.+?</sbrk:buffer>").Value).Trim

            Dim KineticLaw As New SABIORK With {
                .Buffer = Buffer,
                .Identifiers = kineticLawModel.Identifiers,
                .kineticLawID = kineticLawID,
                .Reactants = kineticLawModel.Reactants,
                .Products = kineticLawModel.Products,
                .startValuepH = startValuepH,
                .startValueTemperature = startValueTemperature,
                .CompoundSpecies = CompoundSpecies,
                .Fast = kineticLawModel.Fast,
                .Reversible = kineticLawModel.Reversible,
                .LocalParameters = kineticLawModel.LocalParameters
            }
            Return KineticLaw
        End Function

        Private Shared Function TryParseListOfSpecies(strData As String) As CompoundSpecie()
            Dim sBuilder = New StringBuilder(strData)
            Dim TempChunk As List(Of String) = (From m As Match In Regex.Matches(strData, "<species .+?/>", RegexOptions.Multiline) Select m.Value).ToList
            For Each strItem As String In TempChunk
                Call sBuilder.Replace(strItem, "")
            Next
            Call TempChunk.AddRange((From m As Match In Regex.Matches(sBuilder.ToString, "<species .+?</species>", RegexOptions.Singleline) Select m.Value).ToArray)
            Dim LQuery = (From strItem As String In TempChunk Select CompoundSpecie.TryParse(strItem)).ToArray
            Return LQuery
        End Function

        Private Shared Function TryParseListOfReactions(strData As String) As kineticLawModel
            Dim TempChunk As String() = (From m As Match In Regex.Matches(strData, "<reaction.+?</reaction>", RegexOptions.Singleline) Select m.Value).ToArray
            Return kineticLawModel.TryParse(TempChunk.First)
        End Function

        Protected Friend Shared Function GetStringValue(strData As String) As String
            strData = Regex.Match(strData, """.+?""").Value

            If String.IsNullOrEmpty(strData) Then
                Return ""
            Else
                strData = Mid(strData, 2)
                strData = Mid(strData, 1, Len(strData) - 1)
                Return strData
            End If
        End Function

        Protected Friend Shared Function GetNodeValue(strData As String) As String
            strData = Regex.Match(strData, ">.+?<").Value

            If String.IsNullOrEmpty(strData) Then
                Return ""
            Else
                strData = Mid(strData, 2)
                strData = Mid(strData, 1, Len(strData) - 1)
                Return strData
            End If
        End Function
    End Class
End Namespace
