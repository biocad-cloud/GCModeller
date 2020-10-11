﻿''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'
'	PdfFileWriter
'	PDF File Write C# Class Library.
'
'	AnnotAction
'	Annotation action classes 
'
'	Uzi Granot
'	Version: 1.0
'	Date: April 1, 2013
'	Copyright (C) 2013-2019 Uzi Granot. All Rights Reserved
'
'	PdfFileWriter C# class library and TestPdfFileWriter test/demo
'  application are free software.
'	They is distributed under the Code Project Open License (CPOL).
'	The document PdfFileWriterReadmeAndLicense.pdf contained within
'	the distribution specify the license agreement and other
'	conditions and notes. You must read this document and agree
'	with the conditions specified in order to use this software.
'
'	For version history please refer to PdfDocument.cs
'
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Imports System


''' <summary>
''' File attachement icon
''' </summary>
Public Enum FileAttachIcon
        ''' <summary>
        ''' Graph
        ''' </summary>
        Graph

        ''' <summary>
        ''' Paperclip
        ''' </summary>
        Paperclip

        ''' <summary>
        ''' PushPin (default)
        ''' </summary>
        PushPin

        ''' <summary>
        ''' Tag
        ''' </summary>
        Tag

        ''' <summary>
        ''' no icon 
        ''' </summary>
        NoIcon
    End Enum

    ''' <summary>
    ''' Sticky note icon
    ''' </summary>
    Public Enum StickyNoteIcon
        ''' <summary>
        ''' Comment (note: no icon)
        ''' </summary>
        Comment
        ''' <summary>
        ''' Key
        ''' </summary>
        Key
        ''' <summary>
        ''' Note (default)
        ''' </summary>
        Note
        ''' <summary>
        ''' Help
        ''' </summary>
        Help
        ''' <summary>
        ''' New paragraph
        ''' </summary>
        NewParagraph
        ''' <summary>
        ''' Paragraph
        ''' </summary>
        Paragraph
        ''' <summary>
        ''' Insert
        ''' </summary>
        Insert
    End Enum

    ''' <summary>
    ''' Annotation action base class
    ''' </summary>
    Public Class AnnotAction
        ''' <summary>
        ''' Gets the PDF PdfAnnotation object subtype
        ''' </summary>
        Private _Subtype As String

        Public Property Subtype As String
            Get
                Return _Subtype
            End Get
            Friend Set(ByVal value As String)
                _Subtype = value
            End Set
        End Property

        Friend Sub New(ByVal Subtype As String)
            Me.Subtype = Subtype
            Return
        End Sub

        Friend Overridable Function IsEqual(ByVal Other As AnnotAction) As Boolean
            Throw New ApplicationException("AnnotAction IsEqual not implemented")
        End Function

        Friend Shared Function IsEqual(ByVal One As AnnotAction, ByVal Two As AnnotAction) As Boolean
            If One Is Nothing AndAlso Two Is Nothing Then Return True
            If One Is Nothing AndAlso Two IsNot Nothing OrElse One IsNot Nothing AndAlso Two Is Nothing OrElse One.GetType() IsNot Two.GetType() Then Return False
            Return One.IsEqual(Two)
        End Function
    End Class

    ''' <summary>
    ''' Web link annotation action
    ''' </summary>
    Public Class AnnotWebLink
        Inherits AnnotAction
        ''' <summary>
        ''' Gets or sets web link string
        ''' </summary>
        Public Property WebLinkStr As String

        ''' <summary>
        ''' Web link constructor
        ''' </summary>
        ''' <param name="WebLinkStr">Web link string</param>
        Public Sub New(ByVal WebLinkStr As String)
            MyBase.New("/Link")
            Me.WebLinkStr = WebLinkStr
            Return
        End Sub

        Friend Overrides Function IsEqual(ByVal Other As AnnotAction) As Boolean
            Return Equals(WebLinkStr, CType(Other, AnnotWebLink).WebLinkStr)
        End Function
    End Class

    ''' <summary>
    ''' Link to location marker within the document
    ''' </summary>
    Public Class AnnotLinkAction
        Inherits AnnotAction
        ''' <summary>
        ''' Gets or sets the location marker name
        ''' </summary>
        Public Property LocMarkerName As String

        ''' <summary>
        ''' Go to annotation action constructor
        ''' </summary>
        ''' <param name="LocMarkerName">Location marker name</param>
        Public Sub New(ByVal LocMarkerName As String)
            MyBase.New("/Link")
            Me.LocMarkerName = LocMarkerName
            Return
        End Sub

        Friend Overrides Function IsEqual(ByVal Other As AnnotAction) As Boolean
            Return Equals(LocMarkerName, CType(Other, AnnotLinkAction).LocMarkerName)
        End Function
    End Class

    ''' <summary>
    ''' Display video or play sound class
    ''' </summary>
    Public Class AnnotDisplayMedia
        Inherits AnnotAction
        ''' <summary>
        ''' Gets or sets PdfDisplayMedia object
        ''' </summary>
        Public Property DisplayMedia As PdfDisplayMedia

        ''' <summary>
        ''' Display media annotation action constructor
        ''' </summary>
        ''' <param name="DisplayMedia">PdfDisplayMedia</param>
        Public Sub New(ByVal DisplayMedia As PdfDisplayMedia)
            MyBase.New("/Screen")
            Me.DisplayMedia = DisplayMedia
            Return
        End Sub

        Friend Overrides Function IsEqual(ByVal Other As AnnotAction) As Boolean
            Return Equals(DisplayMedia.MediaFile.FileName, CType(Other, AnnotDisplayMedia).DisplayMedia.MediaFile.FileName)
        End Function
    End Class

    ''' <summary>
    ''' Save or view embedded file
    ''' </summary>
    Public Class AnnotFileAttachment
        Inherits AnnotAction
        ''' <summary>
        ''' Gets or sets embedded file
        ''' </summary>
        Public Property EmbeddedFile As PdfEmbeddedFile

        ''' <summary>
        ''' Gets or sets associated icon
        ''' </summary>
        Public Icon As FileAttachIcon

        ''' <summary>
        ''' File attachement constructor
        ''' </summary>
        ''' <param name="EmbeddedFile">Embedded file</param>
        ''' <param name="Icon">Icon enumeration</param>
        Public Sub New(ByVal EmbeddedFile As PdfEmbeddedFile, ByVal Icon As FileAttachIcon)
            MyBase.New("/FileAttachment")
            Me.EmbeddedFile = EmbeddedFile
            Me.Icon = Icon
            Return
        End Sub

        ''' <summary>
        ''' File attachement constructor (no icon)
        ''' </summary>
        ''' <param name="EmbeddedFile">Embedded file</param>
        Public Sub New(ByVal EmbeddedFile As PdfEmbeddedFile)
            MyBase.New("/FileAttachment")
            Me.EmbeddedFile = EmbeddedFile
            Icon = FileAttachIcon.NoIcon
            Return
        End Sub

        Friend Overrides Function IsEqual(ByVal Other As AnnotAction) As Boolean
            Dim FileAttach = CType(Other, AnnotFileAttachment)
            Return Equals(EmbeddedFile.FileName, FileAttach.EmbeddedFile.FileName) AndAlso Icon = FileAttach.Icon
        End Function
    End Class

    ''' <summary>
    ''' Display sticky note
    ''' </summary>
    Public Class AnnotStickyNote
        Inherits AnnotAction

        Friend Note As String
        Friend Icon As StickyNoteIcon

        ''' <summary>
        ''' Sticky note annotation action constructor
        ''' </summary>
        ''' <param name="Note">Sticky note text</param>
        ''' <param name="Icon">Sticky note icon</param>
        Public Sub New(ByVal Note As String, ByVal Icon As StickyNoteIcon)
            MyBase.New("/Text")
            Me.Note = Note
            Me.Icon = Icon
            Return
        End Sub

        Friend Overrides Function IsEqual(ByVal Other As AnnotAction) As Boolean
            Dim StickyNote = CType(Other, AnnotStickyNote)
            Return Equals(Note, StickyNote.Note) AndAlso Icon = StickyNote.Icon
        End Function
    End Class

