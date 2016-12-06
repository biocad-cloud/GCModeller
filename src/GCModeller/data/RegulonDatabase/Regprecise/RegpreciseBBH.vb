﻿#Region "Microsoft.VisualBasic::92144bc18981f31ceb0e2cd79eacebfc, ..\GCModeller\data\RegulonDatabase\Regprecise\RegpreciseBBH.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
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

Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.Data.csv.Extensions
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports SMRUCC.genomics.Data.Xfam.Pfam
Imports SMRUCC.genomics.Data.Xfam.Pfam.ProteinDomainArchitecture.MPAlignment.BiDirectionalBesthit
Imports SMRUCC.genomics.Interops.NCBI.Extensions
Imports SMRUCC.genomics.Interops.NCBI.Extensions.LocalBLAST.Application.BBH

Namespace Regprecise

    Public Class RegpreciseBBH : Inherits BiDirectionalBesthit

        Implements INamedValue
        Implements IRegulatorMatched

        ''' <summary>
        ''' 和Regprecise数据库之中的调控因子所比对上的目标菌株的基因组之中的蛋白质
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Column("LocusId")> Public Overrides Property QueryName As String Implements INamedValue.Identifier,
            IRegulatorMatched.locusId
            Get
                Return MyBase.QueryName
            End Get
            Set(value As String)
                MyBase.QueryName = value
            End Set
        End Property

        ''' <summary>
        ''' Regprecise_regulator
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Column("Regprecise_Matched")> Public Overrides Property HitName As String Implements IRegulatorMatched.Address
            Get
                Return MyBase.HitName
            End Get
            Set(value As String)
                MyBase.HitName = value
            End Set
        End Property

        <Column("Family.Regprecise")> Public Property Family As String Implements IRegulatorMatched.Family

        Public Property RegulationEffects As String
        Public Property RegprecisePhenotypeAssociation As String

        <Collection("Possible.Effectors")> Public Property Effectors As String()
        <Collection("Possible.Regprecise_TfbsId")> Public Property RegpreciseTfbsIds As String()
    End Class
    ''' <summary>
    ''' Bidirectional best hit regulator with the regprecise database.(调控因子与Regprecise数据库的双向最佳比对结果)
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Class RegpreciseMPBBH : Inherits RegpreciseBBH

        Implements IMPAlignmentResult
        Implements INamedValue
        Implements IRegulatorMatched

#Region "Public Property"

        <Column("Pfam-String")> Public Property PfamString As String
        <Column("subject.pfam-string")> Public Property SubjectPfamString As String

        Public Property Similarity As Double Implements IMPAlignmentResult.Similarity
        Public Property MPScore As Double Implements IMPAlignmentResult.MPScore

#End Region

        Public Function GetLocusTag() As String
            Return Me.HitName.Split(CChar(":")).Last
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("{0}({1})", QueryName, HitName)
        End Function
    End Class
End Namespace
