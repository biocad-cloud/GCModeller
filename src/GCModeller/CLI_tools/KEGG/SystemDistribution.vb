﻿Imports SMRUCC.genomics.Assembly.KEGG.DBGET
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.SchemaMaps
Imports Microsoft.VisualBasic.DocumentFormat.Csv
Imports Microsoft.VisualBasic.Imaging
Imports Microsoft.VisualBasic.Scripting.MetaData

<[PackageNamespace]("Pathway.System.Distribution", Publisher:="xie.guigang@gmail.com")>
Public Module SystemDistribution

    <DataFrameColumn("Margin")> Dim Margin As Integer

    <ExportAPI("Invoke.Drawing")>
    Public Function InvokeDrawing(MAT As DocumentStream.File) As Image
        Dim Organism = bGetObject.Organism.GetOrganismListFromResource
        Dim LQuery = (From row In MAT.Skip(1).AsParallel
                      Let sp As String = row.First
                      Let system As Integer() = (From s As String In row.Skip(1) Select CInt(Val(s))).ToArray
                      Select sp, system, org = Organism(sp)
                      Group By org.Phylum Into Group).ToArray

        Dim Device = New Size(MAT.Width * 100 + 2 * Margin, MAT.Count * 2 + 2 * Margin).CreateGDIDevice
        Dim X As Integer, Y As Integer
        Dim DrawingFont As New Font(FontFace.MicrosoftYaHei, 8)
        Dim Size As SizeF = LQuery.First.Group.First.sp.MeasureString(DrawingFont)

        For Each row In LQuery
            Dim Rect As Rectangle = New Rectangle(X, Y, Device.Width, Size.Height * row.Group.Count)
            Call Device.Graphics.DrawRectangle(Pens.Black, Rect)

            X = Margin
            Y += 2

            For Each sp In row.Group
                Size = Device.Graphics.MeasureString(sp.sp, DrawingFont)
                Call Device.Graphics.DrawString(sp.sp, DrawingFont, Brushes.Black, New Point(X, Y))

                X += Size.Width

                For Each sys In sp.system
                    Dim Color As Color = If(sys = 0, Color.White, Color.Red)
                    Call Device.Graphics.FillRectangle(New SolidBrush(Color), New Rectangle(New Point(X, Y), New Size(80, 2)))
                    X += 90
                Next

                Y += Size.Height
                X = Margin
            Next
        Next

        Return Device.ImageResource
    End Function
End Module
