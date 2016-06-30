﻿Imports LANS.SystemsBiology.AnalysisTools.ComparativeGenomics
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.Analysis
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.Analysis.MotifScans
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat
Imports LANS.SystemsBiology.AnalysisTools.NBCR.Extensions.MEME_Suite.DocumentFormat.MAST.HTML
Imports LANS.SystemsBiology.DatabaseServices.Regprecise.WebServices
Imports LANS.SystemsBiology.SequenceModel
Imports LANS.SystemsBiology.SequenceModel.NucleotideModels
Imports LANS.SystemsBiology.SequenceModel.NucleotideModels.NucleicAcid
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ComponentModel.DataStructures
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Linq.Extensions

Namespace Analysis.MotifScans

    ''' <summary>
    ''' MEME操作实际上是将motif位点的序列进行分组，则某一个符合条件的位点应该不仅仅和PWM可以匹配，和生成那些位点的序列也应该匹配
    ''' </summary>
    Public Class MotifScans

        Dim MotifSite As AnnotationModel
        Dim Delta, Delta2 As Double
        Dim Sites As NucleotideModels.NucleicAcid()
        Dim OffSet As Integer

        Sub New(Motif As AnnotationModel, Regulations As Regulations,
                Optional delta As Double = 80,
                Optional delta2 As Double = 70,
                Optional offSet As Integer = 5)

            Dim setValue = New SetValue(Of NucleotideModels.NucleicAcid)() <=
                NameOf(NucleotideModels.NucleicAcid.UserTag)

            MotifSite = Motif

            Me.Delta = delta / 1000
            Me.Sites = MotifSite.Sites.ToArray(
                Function(site) setValue(New NucleotideModels.NucleicAcid(site.Site), site.Name))
            Me.OffSet = offSet
            Me.Delta2 = delta2
        End Sub

        ''' <summary>
        ''' 函数返回可能的匹配上的位点的位置以及序列片段，链的方向
        ''' </summary>
        ''' <param name="Nt"></param>
        ''' <returns></returns>
        Public Function Mast(Nt As FASTA.FastaToken) As MAST.HTML.MatchedSite()
            Dim SlideWindows = New NucleotideModels.NucleicAcid(Nt).ToArray _
                .CreateSlideWindows(MotifSite.PspMatrix.Length + OffSet * 2)
            Dim NtLen As Long = Nt.Length
            Dim Seeds = (From site In SlideWindows.AsParallel
                         Let delta As Double = Similarity.Sigma(MotifSite.PspMatrix, Similarity.PWM(site.Elements))
                         Where delta <= Me.Delta
                         Select delta, site, complements = False).ToList
            Dim revNT As New NucleotideModels.NucleicAcid(New String(NucleotideModels.NucleicAcid.Complement(Nt.SequenceData).Reverse.ToArray))
            SlideWindows = revNT.ToArray.CreateSlideWindows(MotifSite.PspMatrix.Length + OffSet * 2)
            Call Seeds.AddRange((From site In SlideWindows.AsParallel
                                 Let delta As Double = Similarity.Sigma(MotifSite.PspMatrix, Similarity.PWM(site.Elements))
                                 Where delta <= Me.Delta
                                 Select delta, site, complements = True).ToArray)
            Dim LQuery = (From site In Seeds.AsParallel
                          Let matchedSite = Match(
                              sequence:=site.site,
                              PWMDelta:=site.delta,
                              complement:=site.complements,
                              NtLen:=NtLen)
                          Where Not matchedSite Is Nothing
                          Select matchedSite).ToArray
            Return LQuery
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sequence">基因组上面的滑窗位点片段</param>
        ''' <param name="PWMDelta"></param>
        ''' <param name="complement"></param>
        ''' <returns></returns>
        Private Function Match(sequence As SlideWindowHandle(Of DNA),
                               PWMDelta As Double,
                               complement As Boolean,
                               NtLen As Long) As MatchedSite
            Dim NT As List(Of DNA) = sequence.ToList

            For i As Integer = 0 To OffSet - 1
                Call NT.RemoveAt(Scan0)

                Dim NtSequence = New NucleotideModels.NucleicAcid(NT)
                Dim delta = (From site As SequenceModel.NucleotideModels.NucleicAcid
                             In Me.Sites
                             Let deltaValue = DifferenceMeasurement.Sigma(NtSequence, site)
                             Where deltaValue <= Me.Delta2
                             Select deltaValue, site).ToArray

                If delta.Length > Sites.Length * 0.6 Then
                    Dim Left, Right As Integer

                    If complement Then
                        Left = NtLen - sequence.Left - i
                        Right = Left - NT.Count
                    Else
                        Left = sequence.Left + i
                        Right = sequence.Left + i + NT.Count
                    End If

                    Return New MatchedSite With {
                        .Strand = If(complement, "-", "+"),
                        .SequenceData = NtSequence.SequenceData,
                        .Starts = Left,
                        .Ends = Right
                    }
                End If

                Call NT.RemoveAt(NT.Count - 1)
            Next

            Return Nothing
        End Function
    End Class
End Namespace