﻿#Region "Microsoft.VisualBasic::e02290cbcd79db5ea05e0466b68c14a4, ..\GCModeller\data\RegulonDatabase\Regprecise\WebServices\WebParser\Regulator.vb"

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

Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq.Extensions
Imports Microsoft.VisualBasic.Text.HtmlParser
Imports Microsoft.VisualBasic.Text.Xml.Models
Imports SMRUCC.genomics.SequenceModel
Imports r = System.Text.RegularExpressions.Regex

Namespace Regprecise

    Public Class Regulator : Implements IReadOnlyId

        Public Enum Types
            NotSpecific = -1
            ''' <summary>
            '''
            ''' </summary>
            ''' <remarks></remarks>
            TF
            ''' <summary>
            ''' RNA regulatory element
            ''' </summary>
            ''' <remarks></remarks>
            RNA
        End Enum

        <XmlAttribute> Public Property Type As Types
        <XmlElement> Public Property Regulator As KeyValuePair
        <XmlElement> Public Property Effector As String
        <XmlElement> Public Property Pathway As String
        <XmlElement> Public Property LocusTag As KeyValuePair
        <XmlAttribute> Public Property Family As String
        <XmlAttribute> Public Property RegulationMode As String
        <XmlElement> Public Property BiologicalProcess As String
        <XmlElement> Public Property Regulog As KeyValuePair
        <XmlArray> Public Property RegulatorySites As Regtransbase.WebServices.FastaObject()
        ''' <summary>
        ''' 被这个调控因子所调控的基因，按照操纵子进行分组，这个适用于推断Regulon的
        ''' </summary>
        ''' <returns></returns>
        <XmlArray> Public Property operons As Operon()
        <XmlElement> Public Property Regulates As RegulatedGene()
        Public Property SiteMore As String

        ''' <summary>
        ''' 该Regprecise调控因子的基因号
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property LocusId As String Implements IReadOnlyId.Identity
            <MethodImpl(MethodImplOptions.AggressiveInlining)>
            Get
                Return LocusTag.Key
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("[{0}] {1}", Type.ToString, Regulator.ToString)
        End Function

        Public Function GetMotifSite(GeneId As String, MotifPosition As Integer) As Regtransbase.WebServices.FastaObject
            Dim LQuery = (From fa As Regtransbase.WebServices.FastaObject In RegulatorySites
                          Where String.Equals(GeneId, fa.locus_tag) AndAlso
                              fa.position = MotifPosition
                          Select fa).FirstOrDefault
            Return LQuery
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="trace">locus_tag:position</param>
        ''' <returns></returns>
        Public Function GetMotifSite(trace As String) As Regtransbase.WebServices.FastaObject
            Dim Tokens As String() = trace.Split(":"c)
            Return GetMotifSite(Tokens(Scan0), CInt(Val(Tokens(1))))
        End Function

        ''' <summary>
        ''' 这个函数会自动移除一些表示NNNN的特殊符号
        ''' </summary>
        ''' <returns></returns>
        Public Function ExportMotifs() As FASTA.FastaToken()
            Dim LQuery As FASTA.FastaToken() =
                LinqAPI.Exec(Of FASTA.FastaToken) <=
                    From FastaObject As Regtransbase.WebServices.FastaObject
                    In RegulatorySites
                    Let t As String = $"[gene={FastaObject.locus_tag}:{FastaObject.position}] [family={Family}] [regulog={Regulog.Key}]"
                    Let attrs = New String() {t}
                    Let seq As String = Regtransbase.WebServices.Regulator.SequenceTrimming(FastaObject)
                    Let fa As FASTA.FastaToken =
                        New FASTA.FastaToken With {
                            .SequenceData = seq,
                            .Attributes = attrs
                        }
                    Select fa
            Return LQuery
        End Function

        Public Shared Function CreateObject(str As String) As Regulator
            Dim list$() = r.Matches(str, "<td.+?</td>").ToArray
            Dim i As int = Scan0
            Dim regulator As New Regulator With {
                .Type = If(InStr(list(++i), " RNA "), Regulator.Types.RNA, Regulator.Types.TF)
            }
            Dim entry As String = Regex.Match(list(++i), "href="".+?"">.+?</a>").Value
            Dim url As String = "http://regprecise.lbl.gov/RegPrecise/" & entry.href
            regulator.Regulator = KeyValuePair.CreateObject(WebAPI.GetsId(entry), url)
            regulator.Effector = __getTagValue(list(++i))
            regulator.Pathway = __getTagValue(list(++i))

            Return More(regulator)
        End Function

        Private Shared Function More(regulator As Regulator) As Regulator
            Dim html$ = regulator.Regulator.Value.GET
            Dim infoTable$ = html.Match("<table class=""proptbl"">.+?</table>", RegexOptions.Singleline)
            Dim properties$() = r.Matches(infoTable, "<tr>.+?</tr>", RegexICSng).ToArray
            Dim i As int = 1

            regulator.SiteMore = r.Match(html, "\[<a href="".+?"">see more</a>\]", RegexOptions.IgnoreCase).Value
            regulator.SiteMore = "http://regprecise.lbl.gov/RegPrecise/" & regulator.SiteMore.href

            If regulator.Type = Types.TF Then
                Dim LocusTag As String = r.Match(properties(++i), "href="".+?"">.+?</a>", RegexOptions.Singleline).Value
                regulator.LocusTag = KeyValuePair.CreateObject(WebAPI.GetsId(LocusTag), LocusTag.href)
                regulator.Family = __getTagValue_td(properties(++i).Replace("<td>Regulator family:</td>", ""))
            Else
                Dim Name As String = r.Matches(properties(++i), "<td>.+?</td>", RegexICSng).ToArray.Last
                Name = Mid(Name, 5)
                Name = Mid(Name, 1, Len(Name) - 5)
                regulator.LocusTag = KeyValuePair.CreateObject(Name, "")
                regulator.Family = r.Match(infoTable, "<td class=""[^""]+?"">RFAM:</td>[^<]+?<td>.+?</td>", RegexOptions.Singleline).Value
                regulator.Family = __getTagValue_td(regulator.Family)
            End If

            regulator.RegulationMode = __getTagValue_td(properties(++i))
            regulator.BiologicalProcess = __getTagValue_td(properties(++i))

            Dim RegulogEntry As String = Regex.Match(properties(i + 1), "href="".+?"">.+?</a>", RegexOptions.Singleline).Value
            Dim url As String = "http://regprecise.lbl.gov/RegPrecise/" & RegulogEntry.href
            regulator.Regulog = KeyValuePair.CreateObject(WebAPI.GetsId(RegulogEntry).TrimNewLine("").Replace(vbTab, "").Trim, url)

            Dim exportServletLnks$() = __exportServlet(html)
            regulator.operons = Operon.OperonParser(html)
            regulator.RegulatorySites = Regtransbase.WebServices.FastaObject.Parse(url:=exportServletLnks.ElementAtOrDefault(1))

            Return regulator
        End Function

        Private Shared Function __getTagValue_td(strData As String) As String
            strData = r.Match(strData, "<td>.+?</td>", RegexOptions.Singleline).Value
            If String.IsNullOrEmpty(Trim(strData)) Then
                Return ""
            End If
            strData = Mid(strData, 5)
            strData = Mid(strData, 1, Len(strData) - 5)
            Return strData
        End Function

        Private Shared Function __exportServlet(pageContent As String) As String()
            Dim url As String = Regex.Match(pageContent, "<table class=""tblexport"">.+?</table>", RegexOptions.Singleline).Value
            Dim links$() = r.Matches(url, "<tr>.+?</tr>", RegexOptions.Singleline + RegexOptions.IgnoreCase).ToArray
            links = links _
                .Select(Function(s) Regex.Match(s, "href="".+?""><b>DOWNLOAD</b>").Value) _
                .Select(Function(s) "http://regprecise.lbl.gov/RegPrecise/" & s.href) _
                .ToArray
            Return links
        End Function

        Private Shared Function __getTagValue(s As String) As String
            s = Regex.Match(s, """>.+?</td>").Value
            s = Mid(s, 3)
            s = Mid(s, 1, Len(s) - 5)
            Return Trim(s)
        End Function
    End Class
End Namespace
