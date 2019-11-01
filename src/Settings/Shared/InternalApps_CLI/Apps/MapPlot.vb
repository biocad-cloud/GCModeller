Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.InteropService
Imports Microsoft.VisualBasic.ApplicationServices

' Microsoft VisualBasic CommandLine Code AutoGenerator
' assembly: ..\bin\MapPlot.exe

' 
'  // 
'  // SMRUCC genomics GCModeller Programs Profiles Manager
'  // 
'  // VERSION:   3.3277.7244.17825
'  // ASSEMBLY:  Settings, Version=3.3277.7244.17825, Culture=neutral, PublicKeyToken=null
'  // COPYRIGHT: Copyright © SMRUCC genomics. 2014
'  // GUID:      a554d5f5-a2aa-46d6-8bbb-f7df46dbbe27
'  // BUILT:     2019/11/1 9:54:10
'  // 
' 
' 
'  < Map.CLI >
' 
' 
' SYNOPSIS
' Settings command [/argument argument-value...] [/@set environment-variable=value...]
' 
' All of the command that available in this program has been list below:
' 
'  /Config.Template:                 
'  /draw.map.region:                 
'  /Plot.GC:                         
'  /Visual.BBH:                      Visualize the blastp result.
'  /visual.orthology.profiles:       
'  /Visualize.blastn.alignment:      Blastn result alignment visualization from the NCBI web blast.
'                                    This tools is only works for a plasmid blastn search result or
'                                    a small gene cluster region in a large genome.
'  --Draw.ChromosomeMap:             Drawing the chromosomes map from the PTT object as the basically
'                                    genome information source.
'  --Draw.ChromosomeMap.genbank:     Draw bacterial genome map from genbank annotation dataset.
' 
' 
' ----------------------------------------------------------------------------------------------------
' 
'    1. You can using "Settings ??<commandName>" for getting more details command help.
'    2. Using command "Settings /CLI.dev [---echo]" for CLI pipeline development.
'    3. Using command "Settings /i" for enter interactive console mode.

Namespace GCModellerApps


''' <summary>
''' Map.CLI
''' </summary>
'''
Public Class MapPlot : Inherits InteropService

    Public Const App$ = "MapPlot.exe"

    Sub New(App$)
        MyBase._executableAssembly = App$
    End Sub

     <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Public Shared Function FromEnvironment(directory As String) As MapPlot
          Return New MapPlot(App:=directory & "/" & MapPlot.App)
     End Function

''' <summary>
''' ```bash
''' /Config.Template [/out &lt;./config.inf&gt;]
''' ```
''' </summary>
'''
Public Function WriteConfigTemplate(Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Config.Template")
    Call CLI.Append(" ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /draw.map.region /gb &lt;genome.gbk&gt; [/COG &lt;cog.csv&gt; /draw.shape.stroke /size &lt;default=10240,2048&gt; /default.color &lt;default=brown&gt; /gene.draw.height &lt;default=85&gt; /disable.level.skip /out &lt;map.png&gt;]
''' ```
''' </summary>
'''
Public Function DrawMapRegion(gb As String, Optional cog As String = "", Optional size As String = "10240,2048", Optional default_color As String = "brown", Optional gene_draw_height As String = "85", Optional out As String = "", Optional draw_shape_stroke As Boolean = False, Optional disable_level_skip As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/draw.map.region")
    Call CLI.Append(" ")
    Call CLI.Append("/gb " & """" & gb & """ ")
    If Not cog.StringEmpty Then
            Call CLI.Append("/cog " & """" & cog & """ ")
    End If
    If Not size.StringEmpty Then
            Call CLI.Append("/size " & """" & size & """ ")
    End If
    If Not default_color.StringEmpty Then
            Call CLI.Append("/default.color " & """" & default_color & """ ")
    End If
    If Not gene_draw_height.StringEmpty Then
            Call CLI.Append("/gene.draw.height " & """" & gene_draw_height & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If draw_shape_stroke Then
        Call CLI.Append("/draw.shape.stroke ")
    End If
    If disable_level_skip Then
        Call CLI.Append("/disable.level.skip ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Plot.GC /in &lt;mal.fasta&gt; [/plot &lt;gcskew/gccontent&gt; /colors &lt;Jet&gt; /out &lt;out.png&gt;]
''' ```
''' </summary>
'''
Public Function PlotGC([in] As String, Optional plot As String = "", Optional colors As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Plot.GC")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not plot.StringEmpty Then
            Call CLI.Append("/plot " & """" & plot & """ ")
    End If
    If Not colors.StringEmpty Then
            Call CLI.Append("/colors " & """" & colors & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Visual.BBH /in &lt;bbh.Xml&gt; /PTT &lt;genome.PTT&gt; /density &lt;genomes.density.DIR&gt; [/limits &lt;sp-list.txt&gt; /out &lt;image.png&gt;]
''' ```
''' Visualize the blastp result.
''' </summary>
'''
Public Function BBHVisual([in] As String, PTT As String, density As String, Optional limits As String = "", Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/Visual.BBH")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/PTT " & """" & PTT & """ ")
    Call CLI.Append("/density " & """" & density & """ ")
    If Not limits.StringEmpty Then
            Call CLI.Append("/limits " & """" & limits & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /visual.orthology.profiles /in &lt;bbh.csv&gt; [/out &lt;plot.png&gt;]
''' ```
''' </summary>
'''
Public Function VisualOrthologyProfiles([in] As String, Optional out As String = "") As Integer
    Dim CLI As New StringBuilder("/visual.orthology.profiles")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' /Visualize.blastn.alignment /in &lt;alignmentTable.txt&gt; /genbank &lt;genome.gb&gt; [/ORF.catagory &lt;catagory.tsv&gt; /region &lt;left,right&gt; /local /out &lt;image.png&gt;]
''' ```
''' Blastn result alignment visualization from the NCBI web blast. This tools is only works for a plasmid blastn search result or a small gene cluster region in a large genome.
''' </summary>
'''
Public Function BlastnVisualizeWebResult([in] As String, genbank As String, Optional orf_catagory As String = "", Optional region As String = "", Optional out As String = "", Optional local As Boolean = False) As Integer
    Dim CLI As New StringBuilder("/Visualize.blastn.alignment")
    Call CLI.Append(" ")
    Call CLI.Append("/in " & """" & [in] & """ ")
    Call CLI.Append("/genbank " & """" & genbank & """ ")
    If Not orf_catagory.StringEmpty Then
            Call CLI.Append("/orf.catagory " & """" & orf_catagory & """ ")
    End If
    If Not region.StringEmpty Then
            Call CLI.Append("/region " & """" & region & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If local Then
        Call CLI.Append("/local ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Draw.ChromosomeMap /ptt &lt;genome.ptt&gt; [/conf &lt;config.inf&gt; /out &lt;dir.export&gt; /COG &lt;cog.csv&gt;]
''' ```
''' Drawing the chromosomes map from the PTT object as the basically genome information source.
''' </summary>
'''
Public Function DrawingChrMap(ptt As String, Optional conf As String = "", Optional out As String = "", Optional cog As String = "") As Integer
    Dim CLI As New StringBuilder("--Draw.ChromosomeMap")
    Call CLI.Append(" ")
    Call CLI.Append("/ptt " & """" & ptt & """ ")
    If Not conf.StringEmpty Then
            Call CLI.Append("/conf " & """" & conf & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not cog.StringEmpty Then
            Call CLI.Append("/cog " & """" & cog & """ ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function

''' <summary>
''' ```bash
''' --Draw.ChromosomeMap.genbank /gb &lt;genome.gbk&gt; [/motifs &lt;motifs.csv&gt; /hide.mics /conf &lt;config.inf&gt; /out &lt;dir.export&gt; /COG &lt;cog.csv&gt;]
''' ```
''' Draw bacterial genome map from genbank annotation dataset.
''' </summary>
'''
Public Function DrawGenbank(gb As String, Optional motifs As String = "", Optional conf As String = "", Optional out As String = "", Optional cog As String = "", Optional hide_mics As Boolean = False) As Integer
    Dim CLI As New StringBuilder("--Draw.ChromosomeMap.genbank")
    Call CLI.Append(" ")
    Call CLI.Append("/gb " & """" & gb & """ ")
    If Not motifs.StringEmpty Then
            Call CLI.Append("/motifs " & """" & motifs & """ ")
    End If
    If Not conf.StringEmpty Then
            Call CLI.Append("/conf " & """" & conf & """ ")
    End If
    If Not out.StringEmpty Then
            Call CLI.Append("/out " & """" & out & """ ")
    End If
    If Not cog.StringEmpty Then
            Call CLI.Append("/cog " & """" & cog & """ ")
    End If
    If hide_mics Then
        Call CLI.Append("/hide.mics ")
    End If
     Call CLI.Append("/@set --internal_pipeline=TRUE ")


    Dim proc As IIORedirectAbstract = RunDotNetApp(CLI.ToString())
    Return proc.Run()
End Function
End Class
End Namespace
