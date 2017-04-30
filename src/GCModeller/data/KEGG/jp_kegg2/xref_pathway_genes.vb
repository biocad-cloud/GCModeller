REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @4/30/2017 10:10:49 PM


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace mysql

''' <summary>
''' ```SQL
''' 代谢途径和所属于该代谢途径对象的基因之间的关系表
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `xref_pathway_genes`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `xref_pathway_genes` (
'''   `pathway` int(11) NOT NULL,
'''   `gene` int(11) NOT NULL,
'''   `gene_KO` varchar(45) DEFAULT NULL COMMENT '目标基因的KO分类编号',
'''   `locus_tag` varchar(45) DEFAULT NULL COMMENT '基因号',
'''   `gene_name` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`pathway`,`gene`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代谢途径和所属于该代谢途径对象的基因之间的关系表';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("xref_pathway_genes", Database:="jp_kegg2", SchemaSQL:="
CREATE TABLE `xref_pathway_genes` (
  `pathway` int(11) NOT NULL,
  `gene` int(11) NOT NULL,
  `gene_KO` varchar(45) DEFAULT NULL COMMENT '目标基因的KO分类编号',
  `locus_tag` varchar(45) DEFAULT NULL COMMENT '基因号',
  `gene_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`pathway`,`gene`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='代谢途径和所属于该代谢途径对象的基因之间的关系表';")>
Public Class xref_pathway_genes: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("pathway"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="pathway")> Public Property pathway As Long
    <DatabaseField("gene"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="gene")> Public Property gene As Long
''' <summary>
''' 目标基因的KO分类编号
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("gene_KO"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="gene_KO")> Public Property gene_KO As String
''' <summary>
''' 基因号
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("locus_tag"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="locus_tag")> Public Property locus_tag As String
    <DatabaseField("gene_name"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="gene_name")> Public Property gene_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `xref_pathway_genes` (`pathway`, `gene`, `gene_KO`, `locus_tag`, `gene_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `xref_pathway_genes` (`pathway`, `gene`, `gene_KO`, `locus_tag`, `gene_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `xref_pathway_genes` WHERE `pathway`='{0}' and `gene`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `xref_pathway_genes` SET `pathway`='{0}', `gene`='{1}', `gene_KO`='{2}', `locus_tag`='{3}', `gene_name`='{4}' WHERE `pathway`='{5}' and `gene`='{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `xref_pathway_genes` WHERE `pathway`='{0}' and `gene`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, pathway, gene)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `xref_pathway_genes` (`pathway`, `gene`, `gene_KO`, `locus_tag`, `gene_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, pathway, gene, gene_KO, locus_tag, gene_name)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{pathway}', '{gene}', '{gene_KO}', '{locus_tag}', '{gene_name}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `xref_pathway_genes` (`pathway`, `gene`, `gene_KO`, `locus_tag`, `gene_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, pathway, gene, gene_KO, locus_tag, gene_name)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `xref_pathway_genes` SET `pathway`='{0}', `gene`='{1}', `gene_KO`='{2}', `locus_tag`='{3}', `gene_name`='{4}' WHERE `pathway`='{5}' and `gene`='{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, pathway, gene, gene_KO, locus_tag, gene_name, pathway, gene)
    End Function
#End Region
Public Function Clone() As xref_pathway_genes
                  Return DirectCast(MyClass.MemberwiseClone, xref_pathway_genes)
              End Function
End Class


End Namespace
