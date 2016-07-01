﻿#Region "Microsoft.VisualBasic::e4da91f0c0b1c76838167b54cd824793, ..\GCModeller\sub-system\FBA_DP\FBA\Models\gcFBA\PhenoOUT.vb"

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

Imports SMRUCC.genomics.GCModeller.AnalysisTools.ModelSolvers.FBA.FBA_OUTPUT
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.DocumentFormat.Csv.StorageProvider.Reflection

Namespace Models.rFBA

    Public Class PhenoModel : Inherits Simpheny.RXN
        Implements IDynamicMeta(Of Double)

        Dim _props As Dictionary(Of String, Double)

        Sub New()
        End Sub

        Sub New(base As Simpheny.RXN)
            Me.Abbreviation = base.Abbreviation
            Me.Enzyme = base.Enzyme
            Me.Objective = base.Objective
            Me.OfficialName = base.OfficialName
            Me.ReactionId = base.ReactionId
            Me.Reversible = base.Reversible
        End Sub

        <Meta(GetType(Double))>
        Public Property Properties As Dictionary(Of String, Double) Implements IDynamicMeta(Of Double).Properties
            Get
                If _props Is Nothing Then
                    _props = New Dictionary(Of String, Double)
                End If
                Return _props
            End Get
            Set(value As Dictionary(Of String, Double))
                _props = value
            End Set
        End Property

        Public Const tag_UPPER_BOUND As String = "[UPPER_BOUND]"
        Public Const tag_LOWER_BOUND As String = "[LOWER_BOUND]"

        Public Sub AddLowerBound(sample As String, value As Double)
            Call Properties.Add(tag_LOWER_BOUND & sample, value)
        End Sub

        Public Sub AddUpperBound(sample As String, value As Double)
            Call Properties.Add(tag_UPPER_BOUND & sample, value)
        End Sub
    End Class

    Public Class RPKMStat : Inherits DynamicPropertyBase(Of Double)
        Implements sIdEnumerable
        Implements IPhenoOUT

        Public Property Locus As String Implements sIdEnumerable.Identifier
        <Meta(GetType(Double))> Public Overrides Property Properties As Dictionary(Of String, Double)
            Get
                Return MyBase.Properties
            End Get
            Set(value As Dictionary(Of String, Double))
                MyBase.Properties = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Locus
        End Function
    End Class
End Namespace
