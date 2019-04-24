﻿Imports System.Runtime.CompilerServices
Imports SMRUCC.genomics.Assembly.KEGG.DBGET.bGetObject
Imports SMRUCC.genomics.Assembly.KEGG.WebServices.InternalWebFormParsers
Imports SMRUCC.genomics.ComponentModel

Namespace Assembly.KEGG.DBGET.WebQuery.Compounds

    Public Class DbGetWebQuery : Inherits WebQuery(Of String)

        Public Sub New(<CallerMemberName> Optional cache As String = Nothing)
            MyBase.New(AddressOf dbgetApi, AddressOf Scripting.ToString, AddressOf doParse, cache)
        End Sub

        Public Shared Function doParse(data$, schema As Type) As Object
            Dim form As New WebForm(data)

            Select Case schema
                Case GetType(Compound)
                    Return WebParser.ParseCompound(form)
                Case GetType(Glycan)
                    Return GlycanParser.ParseGlycan(form)
                Case Else
                    Throw New NotImplementedException(schema.FullName)
            End Select
        End Function

        Public Shared Function dbgetApi(id As String) As String
            If id.StartsWith("C") Then
                Return $"http://www.kegg.jp/dbget-bin/www_bget?cpd:{id}"
            ElseIf id.StartsWith("G") Then
                Return $"http://www.kegg.jp/dbget-bin/www_bget?gl:{id}"
            ElseIf id.StartsWith("D") Then
                Return $"http://www.kegg.jp/dbget-bin/www_bget?dr:{id}"
            Else
                Throw New NotImplementedException
            End If
        End Function
    End Class
End Namespace