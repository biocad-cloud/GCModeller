﻿#Region "Microsoft.VisualBasic::a845ca3ba72a21d88c1c8a9ac050e333, Bio.Assembly\Assembly\NCBI\SeqDump\nt.vb"

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

    '     Class Nucleotide
    ' 
    '         Properties: CommonName, Location, LocusTag
    ' 
    '         Constructor: (+1 Overloads) Sub New
    '         Function: Load, NtAccessionMatches
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.Text.RegularExpressions
Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Scripting
Imports SMRUCC.genomics.ComponentModel.Loci
Imports SMRUCC.genomics.SequenceModel
Imports SMRUCC.genomics.SequenceModel.FASTA

Namespace Assembly.NCBI.SequenceDump

    ''' <summary>
    ''' NCBI genbank title format fasta parser
    ''' </summary>
    Public Class Nucleotide : Inherits FASTA.FastaSeq

#Region "ReadOnly properties"

        <XmlAttribute>
        Public ReadOnly Property CommonName As String
        <XmlAttribute>
        Public ReadOnly Property LocusTag As String
        Public ReadOnly Property Location As NucleotideLocation
#End Region

        Sub New(FastaObj As FASTA.FastaSeq)
            Dim strTitle As String = FastaObj.Title
            Dim LocusTag As String = Regex.Match(strTitle, "locus_tag=[^]]+").Value
            Dim Location As String = Regex.Match(strTitle, "location=[^]]+").Value
            Dim CommonName As String = Regex.Match(strTitle, "gene=[^]]+").Value

            Me._LocusTag = LocusTag.Split(CChar("=")).Last
            Me._CommonName = CommonName.Split(CChar("=")).Last
            Me._Location = LocusExtensions.TryParse(Location)
            Me.Headers = FastaObj.Headers
            Me.SequenceData = FastaObj.SequenceData
        End Sub

        Public Overloads Shared Function Load(path As String) As Nucleotide()
            Dim FASTA As FastaFile = FastaFile.Read(path)
            Dim LQuery As Nucleotide() = LinqAPI.Exec(Of Nucleotide) <=
 _
                From fa As FastaSeq
                In FASTA
                Select New Nucleotide(fa)

            Return LQuery
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nt">The nt fasta sequence database.</param>
        ''' <returns></returns>
        Public Shared Iterator Function NtAccessionMatches(nt As IEnumerable(Of FastaSeq), accessionList As IEnumerable(Of String), accid As TextGrepMethod) As IEnumerable(Of FastaSeq)
            Dim idlist As Index(Of String) = accessionList _
                .Select(AddressOf HeaderFormats.TrimAccessionVersion) _
                .Select(AddressOf Strings.LCase) _
                .Indexing

            For Each fa As FastaSeq In nt
                Dim acc As String = accid(fa.Title).ToLower

                If acc Like idlist Then
                    Call fa.Title.__INFO_ECHO
                    Call idlist.Delete(acc)

                    Yield fa

                    If idlist.Count = 0 Then
                        Exit For
                    End If
                End If
            Next
        End Function
    End Class
End Namespace
