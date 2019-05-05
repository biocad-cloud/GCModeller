﻿Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports SMRUCC.genomics.Assembly.EBI.ChEBI.XML

Namespace Assembly.EBI.ChEBI

    ''' <summary>
    ''' 物质注释信息摘要表格
    ''' </summary>
    Public Class EntitySummary

        Public Property chebiId As String
        Public Property chebiAsciiName As String
        Public Property smiles As String
        Public Property charge As Integer
        Public Property mass As Double
        Public Property formulae As String
        Public Property secondaryChebiIds As String()
        Public Property kegg_Ids As String()
        Public Property wikipedia As String
        Public Property inchi As String
        Public Property inchiKey As String
        Public Property cas As String()
        Public Property hmdb As String
        Public Property biosamples As String()

        Public Shared Function FromEntity(entity As ChEBIEntity) As EntitySummary
            Dim xref As Dictionary(Of String, NamedValue(Of String)()) = entity.RegistryNumbersSearchModel

            Return New EntitySummary With {
                .chebiAsciiName = entity.chebiAsciiName,
                .chebiId = entity.chebiId,
                .charge = entity.charge,
                .formulae = entity.Formulae?.data,
                .inchi = entity.inchi,
                .inchiKey = entity.inchiKey,
                .mass = entity.mass,
                .secondaryChebiIds = entity.SecondaryChEBIIds,
                .smiles = entity.smiles,
                .cas = xref.TryGetValue("CAS Registry Number").Values,
                .hmdb = xref.TryGetValue("HMDB accession").FirstOrDefault.Value,
                .kegg_Ids = xref.TryGetValue("KEGG COMPOUND accession").Values,
                .wikipedia = xref.TryGetValue("Wikipedia accession").FirstOrDefault.Value,
                .biosamples = entity.CompoundOrigins _
                    .Select(Function(co) co.componentText) _
                    .Where(Function(s) Not s.StringEmpty) _
                    .ToArray
            }
        End Function
    End Class
End Namespace