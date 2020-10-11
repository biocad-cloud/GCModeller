﻿''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'
'	PdfFileWriter
'	PDF File Write C# Class Library.
'
'	PdfAnnotation
'	PDF Annotation class. 
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

Imports System.Collections.Generic


    ''' <summary>
    ''' PDF Annotation class
    ''' </summary>
    Public Class PdfAnnotation
        Inherits PdfObject
        ''' <summary>
        ''' Layer control
        ''' </summary>
        Public LayerControl As PdfLayer = Nothing
        Friend AnnotPage As PdfPage
        Friend AnnotRect As PdfRectangle
        Friend AnnotAction As AnnotAction

        ''' <summary>
        ''' PdfAnnotation constructor
        ''' </summary>
        ''' <param name="AnnotPage">Page object</param>
        ''' <param name="AnnotRect">Annotation rectangle</param>
        ''' <param name="AnnotAction">Annotation action</param>
        Friend Sub New(ByVal AnnotPage As PdfPage, ByVal AnnotRect As PdfRectangle, ByVal AnnotAction As AnnotAction)
            MyBase.New(AnnotPage.Document)
            ' save arguments
            Me.AnnotPage = AnnotPage
            Me.AnnotRect = AnnotRect
            Me.AnnotAction = AnnotAction

            ' annotation subtype
            Dictionary.Add("/Subtype", AnnotAction.Subtype)

            ' area rectangle on the page
            Dictionary.AddRectangle("/Rect", AnnotRect)

            ' annotation flags. value of 4 = Bit position 3 print
            Dictionary.Add("/F", "4")

            ' border style dictionary. If /BS with /W 0 is not specified, the annotation will have a thin border
            Dictionary.Add("/BS", "<</W 0>>")

            ' web link
            If AnnotAction.GetType() Is GetType(AnnotWebLink) Then
                Dictionary.AddIndirectReference("/A", PdfWebLink.AddWebLink(Document, CType(AnnotAction, AnnotWebLink).WebLinkStr))

                ' jump to destination
            ElseIf AnnotAction.GetType() Is GetType(AnnotLinkAction) Then
                If Document.LinkAnnotArray Is Nothing Then Document.LinkAnnotArray = New List(Of PdfAnnotation)()
                Document.LinkAnnotArray.Add(Me)

                ' display video or play sound
            ElseIf AnnotAction.GetType() Is GetType(AnnotDisplayMedia) Then
                Dim DisplayMedia = CType(AnnotAction, AnnotDisplayMedia).DisplayMedia

                ' action reference dictionary
                Dictionary.AddIndirectReference("/A", DisplayMedia)

                ' add page reference
                Dictionary.AddIndirectReference("/P", AnnotPage)

                ' add annotation reference
                DisplayMedia.Dictionary.AddIndirectReference("/AN", Me)

                ' file attachment
            ElseIf AnnotAction.GetType() Is GetType(AnnotFileAttachment) Then
                ' add file attachment reference
                Dim File = CType(AnnotAction, AnnotFileAttachment)
                Dictionary.AddIndirectReference("/FS", File.EmbeddedFile)

                If File.Icon <> FileAttachIcon.NoIcon Then
                    ' icon
                    Dictionary.AddName("/Name", File.Icon.ToString())
                Else
                    ' no icon
                    Dim XObject As PdfXObject = New PdfXObject(Document, AnnotRect.Right, AnnotRect.Top)
                    Dictionary.AddFormat("/AP", "<</N {0} 0 R>>", XObject.ObjectNumber)
                End If

                ' sticky notes
            ElseIf AnnotAction.GetType() Is GetType(AnnotStickyNote) Then
                ' short cut
                Dim StickyNote = CType(AnnotAction, AnnotStickyNote)

                ' icon
                Dictionary.AddName("/Name", StickyNote.Icon.ToString())

                ' action reference dictionary
                Dictionary.AddPdfString("/Contents", StickyNote.Note)
            End If

            ' add annotation object to page dictionary
            Dim KeyValue = AnnotPage.Dictionary.GetValue("/Annots")

            If KeyValue Is Nothing Then
                AnnotPage.Dictionary.AddFormat("/Annots", "[{0} 0 R]", ObjectNumber)
            Else
                AnnotPage.Dictionary.Add("/Annots", CStr(KeyValue.Value).Replace("]", String.Format(" {0} 0 R]", ObjectNumber)))
            End If

            ' exit
            Return
        End Sub

        ''' <summary>
        ''' Gets a copy of the annotation rectangle
        ''' </summary>
        Public ReadOnly Property AnnotationRect As PdfRectangle
            Get
                Return New PdfRectangle(AnnotRect)
            End Get
        End Property

        ''' <summary>
        ''' Activate annotation when page becomes visible.
        ''' </summary>
        ''' <param name="Activate">Activate or not-activate annotation.</param>
        Public Sub ActivateActionWhenPageIsVisible(ByVal Activate As Boolean)
            ' applicable to screen action
            If AnnotAction.GetType() Is GetType(AnnotDisplayMedia) Then
                ' play video when page becomes visible
                If Activate Then
                    Dictionary.AddFormat("/AA", "<</PV {0} 0 R>>", CType(AnnotAction, AnnotDisplayMedia).DisplayMedia.ObjectNumber)
                Else
                    Dictionary.Remove("/AA")
                End If
            End If

            Return
        End Sub

        ''' <summary>
        ''' Display border around annotation rectangle.
        ''' </summary>
        ''' <param name="BorderWidth">Border width</param>
        Public Sub DisplayBorder(ByVal BorderWidth As Double)
            ' see page 611 section 8.4
            Dictionary.AddFormat("/BS", "<</W {0}>>", ToPt(BorderWidth))
            Return
        End Sub

        ''' <summary>
        ''' Annotation rectangle appearance
        ''' </summary>
        ''' <param name="AppearanceDixtionary">PDF X Object</param>
        Public Sub Appearance(ByVal AppearanceDixtionary As PdfXObject)
            Dictionary.AddFormat("/AP", "<</N {0} 0 R>>", AppearanceDixtionary.ObjectNumber)
            Return
        End Sub

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Write object to PDF file
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Friend Overrides Sub WriteObjectToPdfFile()
            ' layer control
            If LayerControl IsNot Nothing Then Dictionary.AddIndirectReference("/OC", LayerControl)

            ' call PdfObject routine
            MyBase.WriteObjectToPdfFile()

            ' exit
            Return
        End Sub
    End Class

