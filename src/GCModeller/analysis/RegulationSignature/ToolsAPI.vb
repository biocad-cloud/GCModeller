﻿#Region "Microsoft.VisualBasic::f4c1e6b03d1dc260b69be37914006425, ..\GCModeller\analysis\RegulationSignature\ToolsAPI.vb"

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

Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports Microsoft.VisualBasic.DocumentFormat.Csv.Extensions
Imports System.Text
Imports SMRUCC.genomics.ComponentModel
Imports SMRUCC.genomics.Assembly.NCBI
Imports SMRUCC.genomics.AnalysisTools.NBCR.Extensions.MEME_Suite.Analysis.GenomeMotifFootPrints
Imports SMRUCC.genomics.SequenceModel

Namespace RegulationSignature

    <[Namespace]("Regulation.Signatures")>
    Public Module ToolsAPI

        <ExportAPI("Signature.Create")>
        Public Function GenerateSignature(VirtualFootprints As IEnumerable(Of PredictedRegulationFootprint),
                PTT As GenBank.TabularFormat.PTT,
                <Parameter("KEGG.Pathways")> KEGG_Pathways As IEnumerable(Of SMRUCC.genomics.Assembly.KEGG.DBGET.bGetObject.Pathway),
                COG As IEnumerable(Of ICOGDigest)) As SignatureBuilder

            Return New SignatureBuilder(VirtualFootprints, PTT, KEGG_Pathways, COG)
        End Function

        <ExportAPI("Read.Csv.VirtualFootprints")>
        Public Function ReadOfVirtualFootprints(Path As String) As PredictedRegulationFootprint()
            Return Path.LoadCsv(Of PredictedRegulationFootprint)(False).ToArray
        End Function

        <ExportAPI("ToFasta")>
        Public Function GenerateSignatureFasta(SignatureBuilder As SignatureBuilder) As SMRUCC.genomics.SequenceModel.FASTA.FastaToken
            Dim Sequence As String = SignatureBuilder.ToString
            Dim Fasta As SMRUCC.genomics.SequenceModel.FASTA.FastaToken =
                New FASTA.FastaToken With
                {
                    .SequenceData = Sequence,
                    .Attributes = New String() {SignatureBuilder.Title}
                }
            Return Fasta
        End Function

        ''' <summary>
        ''' 将包含有一定意义的字符串转换为碱基核酸序列
        ''' </summary>
        ''' <param name="str"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        <ExportAPI("GenerateCode")>
        Public Function GenerateCode(str As String) As String
            Dim Bytes As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(str.ToLower) '转换为字节码 0-256，这里为了保持比对之间的一致性，字符串全部转换为小写
            Dim sBuilder As StringBuilder = New StringBuilder

            For Each byt As Byte In Bytes
                sBuilder = ByteToATGC(byt, sBuilder)
            Next

            Return sBuilder.ToString
        End Function

        Private ReadOnly BinHash As Dictionary(Of String, Char) = New Dictionary(Of String, Char) From {{"00", "A"c}, {"01", "T"c}, {"10", "G"c}, {"11", "C"c}}

        <ExportAPI("Bytes2NT")>
        Public Function ByteToATGC(Byt As Byte, ByRef sBuilder As StringBuilder) As StringBuilder
            Dim bin As String = Convert.ToString(Byt, toBase:=2)

            For i As Integer = 1 To Len(bin)
                Dim Tokens As String = Mid(bin, i, 2)
                If Len(Tokens) = 1 Then Tokens = "0" & Tokens
                Call sBuilder.Append(BinHash(Tokens))
            Next

            Return sBuilder
        End Function

    End Module
End Namespace
