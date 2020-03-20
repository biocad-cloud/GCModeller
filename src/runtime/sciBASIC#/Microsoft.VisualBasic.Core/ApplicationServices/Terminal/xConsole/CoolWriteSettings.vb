﻿#Region "Microsoft.VisualBasic::08920a87692c09624918fe290bdd11a1, Microsoft.VisualBasic.Core\ApplicationServices\Terminal\xConsole\CoolWriteSettings.vb"

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

'     Class CoolWriteSettings
' 
'         Properties: CoolWriting, CoolWritingDelay, CWRDDelay
' 
'         Constructor: (+1 Overloads) Sub New
' 
' 
' /********************************************************************************/

#End Region

Namespace ApplicationServices.Terminal.xConsole

    Public NotInheritable Class CoolWriteSettings

        ''' <summary>
        ''' Gradual typing the output into console
        ''' </summary>
        Public Shared Property CoolWriting As Boolean = False

        ''' <summary>
        ''' Write speed
        ''' </summary>
        Public Shared Property CoolWritingDelay As Integer = 8

        ''' <summary>
        ''' Set the delay when write a new line or dots. (Default = 200).
        ''' </summary>
        Public Shared Property CWRDDelay As Integer = 280

        Private Sub New()
        End Sub
    End Class

End Namespace
