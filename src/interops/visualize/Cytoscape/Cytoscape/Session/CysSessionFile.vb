﻿Imports Microsoft.VisualBasic.ApplicationServices.Zip

Namespace Session

    ''' <summary>
    ''' ``*.cys`` cytoscape session file reader model
    ''' </summary>
    Public Class CysSessionFile

        ''' <summary>
        ''' the original *.cys session file location.
        ''' </summary>
        Public ReadOnly source As String

        ReadOnly tempDir As String

        Private Sub New(tempDir As String, cys As String)
            Me.tempDir = tempDir
            Me.source = cys
        End Sub

        Public Shared Function Open(cys As String) As CysSessionFile
            Dim temp As String = App.GetAppSysTempFile(".zip", App.PID, "cytoscape_")

            Call UnZip.ImprovedExtractToDirectory(cys, temp, Overwrite.Always, extractToFlat:=False)

            Return New CysSessionFile(temp, cys)
        End Function
    End Class
End Namespace