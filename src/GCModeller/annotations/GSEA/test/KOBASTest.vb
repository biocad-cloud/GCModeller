﻿Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports SMRUCC.genomics.Analysis.HTS.GSEA

Module KOBASTest

    Sub Main()

        Dim genelist = {"A", "B", "C", "D", "E", "F", "G"}
        Dim background As Index(Of String) = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N"}

        Dim name = {"test"}

        ' (labels,phnameA,phnameB,sample_num,sample0,sample1) =gsea.read_cls_file(cls=opt.cls)

        Dim cls As phenotype = phenotype.FromClsFile("D:\GCModeller\src\GCModeller\annotations\GSEA\test_cls.txt")


        Dim m = KOBAS_GSEA.get_hit_matrix(genelist, genelist.Length, name, name.ToArray, {background}, 3, 1000)
        Dim rank As (sort_r As Object, sort_gene_index As Object) = KOBAS_GSEA.rank_pro(labels, md:="ttest", expr_data:=expr_data, sample0:=sample0, sample1:=sample1)


        Pause()
    End Sub
End Module
