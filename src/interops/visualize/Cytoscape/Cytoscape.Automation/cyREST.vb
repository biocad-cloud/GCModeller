﻿Imports SMRUCC.genomics.Visualize.Cytoscape.CytoscapeGraphView.Cyjs
Imports Flute.Http.FileSystem
Imports Flute.Http.Core
Imports System.Net.Sockets
Imports Microsoft.VisualBasic.Text
Imports Microsoft.VisualBasic.Net.Protocols.ContentTypes
Imports Microsoft.VisualBasic.Language
Imports SMRUCC.genomics.Visualize.Cytoscape.Tables

Public MustInherit Class cyREST

    Protected virtualFilesystem As New FileHost(8887)

    Public Function addUploadFile(file As String) As String
        Return virtualFilesystem.addUploadFile(file)
    End Function

    Public MustOverride Function layouts() As String()

    ''' <summary>
    ''' Returns a list of all networks as names and their corresponding SUIDs.
    ''' </summary>
    ''' <returns></returns>
    Public MustOverride Function networksNames() As String()

    ''' <summary>
    ''' Creates a new network in the current session from a file or URL source.
    ''' </summary>
    ''' <returns></returns>
    Public MustOverride Function putNetwork(network As [Variant](Of Cyjs, SIF()), Optional collection$ = Nothing, Optional title$ = Nothing) As Object

End Class

''' <summary>
''' local file reference for cytoscape automation
''' </summary>
Public Class FileReference
    Public Property source_location As String
    Public Property source_method As String = "GET"
    Public Property ndex_uuid As String = "12345"
End Class

Public Class FileHost : Inherits HttpServer

    ReadOnly virtual As New FileSystem(App.CurrentDirectory)

    Public Sub New(port As Integer, Optional threads As Integer = -1)
        MyBase.New(port, threads)
    End Sub

    Public Function addUploadFile(file As String) As String
        Dim res As String = "/" & file.GetFullPath.Replace(":/", "/").Split("/"c).Select(AddressOf UrlEncode).JoinBy("/")
        Call virtual.AddMapping(res, file)
        Return $"http://localhost:{localPort}/{res}".Replace("//", "/")
    End Function

    Public Function addUploadData(data As String, ext$) As String
        Dim res As String = App.NextTempName & $"/upload.{ext}"
        Dim type As ContentType

        Select Case ext.ToLower
            Case "json"
                type = New ContentType With {.Details = MIME.Json, .MIMEType = MIME.Json}
            Case "txt", "sif"
                type = New ContentType With {.Details = "plain/text", .MIMEType = "plain/text"}
            Case Else
                Throw New NotImplementedException(ext)
        End Select

        Call virtual.AddCache(res, Encodings.UTF8WithoutBOM.CodePage.GetBytes(data), type)
        Return $"http://localhost:{localPort}/{res}".Replace("//", "/")
    End Function

    Public Overrides Sub handleGETRequest(p As HttpProcessor)
        Dim path As String = p.http_url
        Dim handler = p.openResponseStream

        If virtual.FileExists(path) Then
            Call handler.WriteHeader(virtual.GetContentType(path).MIMEType, virtual.GetFileSize(path))
            Call p.openResponseStream.Write(virtual.GetByteBuffer(path))
        Else
            Call p.openResponseStream.WriteError(404, "invalid file")
        End If
    End Sub

    Public Overrides Sub handlePOSTRequest(p As HttpProcessor, inputData As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub handleOtherMethod(p As HttpProcessor)
        Throw New NotImplementedException()
    End Sub

    Protected Overrides Function getHttpProcessor(client As TcpClient, bufferSize As Integer) As HttpProcessor
        Return New HttpProcessor(client, Me, bufferSize)
    End Function
End Class

Public Enum formats
    ''' <summary>
    ''' SIF format
    ''' </summary>
    egdeList
    ''' <summary>
    ''' cx format
    ''' </summary>
    cx
    ''' <summary>
    ''' cytoscape.js format
    ''' </summary>
    json
End Enum