﻿#Region "Microsoft.VisualBasic::a3d7106df6f48710a9f10d729d0b0e99, ..\GCModeller\engine\GCModeller\EngineSystem\ObjectModels\Entity\Peptide.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
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

Imports SMRUCC.genomics.GCModeller.ModellingEngine.Assembly.DocumentFormat.GCMarkupLanguage
Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.Services.DataAcquisition.Services

Namespace EngineSystem.ObjectModels.Entity

    Public Class Peptide : Inherits IDisposableCompound

        <DumpNode> Protected Friend ProteinModelBase As GCML_Documents.XmlElements.Metabolism.Polypeptide

        Public Overrides ReadOnly Property DataSource As DataSource
            Get
                Return New DataSource(Handle, EntityBaseType.DataSource.value)
            End Get
        End Property

        Public Overrides Property Quantity As Double
            Get
                Return EntityBaseType.Quantity
            End Get
            Set(value As Double)
                EntityBaseType.Quantity = value
            End Set
        End Property

        Public ReadOnly Property ProteinType As GCML_Documents.XmlElements.Metabolism.Polypeptide.ProteinTypes
            Get
                Return ProteinModelBase.ProteinType
            End Get
        End Property
    End Class
End Namespace
