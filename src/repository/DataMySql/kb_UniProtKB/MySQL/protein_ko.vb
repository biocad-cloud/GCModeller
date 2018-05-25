REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:51


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace kb_UniProtKB.mysql

''' <summary>
''' ```SQL
''' 蛋白质的KEGG直系同源的注释信息表，uniprotKB库通过这个表连接kegg知识库
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_ko`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_ko` (
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) DEFAULT NULL,
'''   `KO` int(10) unsigned NOT NULL,
'''   PRIMARY KEY (`hash_code`,`KO`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='蛋白质的KEGG直系同源的注释信息表，uniprotKB库通过这个表连接kegg知识库';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_ko", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_ko` (
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) DEFAULT NULL,
  `KO` int(10) unsigned NOT NULL,
  PRIMARY KEY (`hash_code`,`KO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='蛋白质的KEGG直系同源的注释信息表，uniprotKB库通过这个表连接kegg知识库';")>
Public Class protein_ko: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("hash_code"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code"), XmlAttribute> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("KO"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="KO"), XmlAttribute> Public Property KO As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `protein_ko` (`hash_code`, `uniprot_id`, `KO`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `protein_ko` (`hash_code`, `uniprot_id`, `KO`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `protein_ko` (`hash_code`, `uniprot_id`, `KO`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `protein_ko` (`hash_code`, `uniprot_id`, `KO`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `protein_ko` WHERE `hash_code`='{0}' and `KO`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `protein_ko` SET `hash_code`='{0}', `uniprot_id`='{1}', `KO`='{2}' WHERE `hash_code`='{3}' and `KO`='{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `protein_ko` WHERE `hash_code`='{0}' and `KO`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, hash_code, KO)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `protein_ko` (`hash_code`, `uniprot_id`, `KO`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, KO)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `protein_ko` (`hash_code`, `uniprot_id`, `KO`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, hash_code, uniprot_id, KO)
        Else
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, KO)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{hash_code}', '{uniprot_id}', '{KO}')"
        Else
            Return $"('{hash_code}', '{uniprot_id}', '{KO}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_ko` (`hash_code`, `uniprot_id`, `KO`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, KO)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `protein_ko` (`hash_code`, `uniprot_id`, `KO`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, hash_code, uniprot_id, KO)
        Else
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, KO)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `protein_ko` SET `hash_code`='{0}', `uniprot_id`='{1}', `KO`='{2}' WHERE `hash_code`='{3}' and `KO`='{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, KO, hash_code, KO)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As protein_ko
                         Return DirectCast(MyClass.MemberwiseClone, protein_ko)
                     End Function
End Class


End Namespace
