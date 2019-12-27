﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Net.Http
Imports Microsoft.VisualBasic.Text.Parser.HtmlParser
Imports Microsoft.VisualBasic.Text.Xml.Models
Imports r = System.Text.RegularExpressions.Regex

Namespace Assembly.KEGG.DBGET.bGetObject.Organism

    Friend Class ShowOrganism : Inherits WebQuery(Of String)

        Public Sub New(<CallerMemberName>
                       Optional cache As String = Nothing,
                       Optional interval As Integer = -1,
                       Optional offline As Boolean = False
                   )

            MyBase.New(url:=AddressOf ShowOrganism.url,
                       contextGuid:=Function(code) code,
                       parser:=AddressOf ParseShowOrganism,
                       prefix:=Nothing,
                       cache:=cache,
                       interval:=interval,
                       offline:=offline
                   )
        End Sub

        Private Shared Function url(code As String) As String
            Return $"http://www.kegg.jp/kegg-bin/show_organism?org={code}"
        End Function

        Public Shared Function ParseShowOrganism(html$, schema As Type) As OrganismInfo
            html = Strings.Split(html, "</form>").Last
            html = TableParser.GetTablesHTML(html,) _
                              .First _
                              .Replace("&nbsp;", " ") _
                              .Trim

            Dim infoTable = html _
                .GetRowsHTML _
                .Select(Function(r)
                            Dim cols = r.GetColumnsHTML
                            Dim name$ = cols(0).StripHTMLTags(True)
                            Dim value = cols(1)

                            Return New NamedValue(Of String) With {
                                .Name = name,
                                .Value = value
                            }
                        End Function) _
                .ToArray

            Dim rows As New Dictionary(Of String, String)

            For Each r As NamedValue(Of String) In infoTable
                ' 因为如果基因组存在质粒的话，则会出现多个sequence字段重复
                ' 所以不可以直接使用linq生成字典
                ' 在这里只添加第一个出现的字段就行了
                ' 因为基因组序列总是先于质粒序列出现的
                If Not rows.ContainsKey(r.Name) Then
                    rows.Add(r.Name, r.Value)
                End If
            Next

            Dim comment$ = rows _
                .TryGetValue("Comment") _
                .StripHTMLTags _
                .StringReplace("\s{2,}", " ") _
                .Trim
            Dim keywords$() = rows _
                .TryGetValue("Keywords") _
               ?.Split(","c)

            Return New OrganismInfo With {
                .Aliases = rows?!Aliases,
                .code = rows("Org code"),
                .Comment = comment,
                .Created = rows!Created,
                .FullName = rows("Full name"),
                .Definition = rows!Definition,
                .Keywords = keywords,
                .Sequence = rows.TryGetValue("Sequence").href,
                .Lineage = rows!Lineage,
                .Taxonomy = rows!Taxonomy.StripHTMLTags,
                .TID = rows("T number").StripHTMLTags,
                .DataSource = links(rows("Data source")),
                .Reference = infoTable.DoCall(AddressOf referenceParser).ToArray
            }
        End Function

        Private Shared Function links(html$) As NamedValue()
            Dim a = r.Matches(html, "<a.+?</a>", RegexICSng) _
                .EachValue(Function(s)
                               Return New NamedValue With {
                                   .name = s.StripHTMLTags,
                                   .Text = s.href
                               }
                           End Function) _
                .ToArray
            Return a
        End Function

        Private Shared Iterator Function referenceParser(source As NamedValue(Of String)()) As IEnumerable(Of Reference)
            For Each block As NamedValue(Of String)() In source _
                .Split(delimiter:=Function(r)
                                      Return r.Name = "Reference"
                                  End Function,
                       deliPosition:=DelimiterLocation.NextFirst
                ) _
                .Skip(1)

                Dim rows As Dictionary(Of String, String) = block _
                    .ToDictionary(replaceOnDuplicate:=True) _
                    .FlatTable
                Dim ref As Reference = rows.DoCall(AddressOf referenceParser)

                Yield ref
            Next
        End Function

        Private Shared Function referenceParser(rows As Dictionary(Of String, String)) As Reference
            Dim J$ = rows.TryGetValue("Journal")
            Dim title$ = rows.TryGetValue("Title")
            Dim DOI$

            If J.StringEmpty AndAlso title.StringEmpty Then
                Return Nothing
            End If

            If J.StringEmpty Then
                J = ""
                DOI = ""
            Else
                DOI = r.Match(J, "DOI[:].+", RegexICSng).Value

                If Not DOI.StringEmpty Then
                    J = J.Replace(DOI, "").StripHTMLTags.Trim
                    DOI = DOI.StripHTMLTags
                End If
            End If

            Dim authors = rows.TryGetValue("Authors")?.Split(";"c)
            Dim ref$ = rows.TryGetValue("Reference").StripHTMLTags

            Return New Reference With {
                .Title = title,
                .Authors = authors,
                .Reference = ref,
                .Journal = J,
                .DOI = DOI
            }
        End Function
    End Class
End Namespace