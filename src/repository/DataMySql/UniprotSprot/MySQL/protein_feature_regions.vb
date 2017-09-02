REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2017/9/3 2:55:59


Imports System.Data.Linq.Mapping
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports System.Xml.Serialization

Namespace kb_UniProtKB

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `protein_feature_regions`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protein_feature_regions` (
'''   `hash_code` int(10) unsigned NOT NULL,
'''   `uniprot_id` varchar(45) DEFAULT NULL,
'''   `type_id` int(10) unsigned NOT NULL,
'''   `type` varchar(45) DEFAULT NULL,
'''   `description` varchar(45) DEFAULT NULL,
'''   `begin` varchar(45) DEFAULT NULL,
'''   `end` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`hash_code`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protein_feature_regions", Database:="kb_uniprotkb", SchemaSQL:="
CREATE TABLE `protein_feature_regions` (
  `hash_code` int(10) unsigned NOT NULL,
  `uniprot_id` varchar(45) DEFAULT NULL,
  `type_id` int(10) unsigned NOT NULL,
  `type` varchar(45) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  `begin` varchar(45) DEFAULT NULL,
  `end` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`hash_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class protein_feature_regions: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("hash_code"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="hash_code"), XmlAttribute> Public Property hash_code As Long
    <DatabaseField("uniprot_id"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="uniprot_id")> Public Property uniprot_id As String
    <DatabaseField("type_id"), NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="type_id")> Public Property type_id As Long
    <DatabaseField("type"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="type")> Public Property type As String
    <DatabaseField("description"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="description")> Public Property description As String
    <DatabaseField("begin"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="begin")> Public Property begin As String
    <DatabaseField("end"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="end")> Public Property [end] As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protein_feature_regions` (`hash_code`, `uniprot_id`, `type_id`, `type`, `description`, `begin`, `end`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protein_feature_regions` (`hash_code`, `uniprot_id`, `type_id`, `type`, `description`, `begin`, `end`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protein_feature_regions` WHERE `hash_code` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protein_feature_regions` SET `hash_code`='{0}', `uniprot_id`='{1}', `type_id`='{2}', `type`='{3}', `description`='{4}', `begin`='{5}', `end`='{6}' WHERE `hash_code` = '{7}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `protein_feature_regions` WHERE `hash_code` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, hash_code)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `protein_feature_regions` (`hash_code`, `uniprot_id`, `type_id`, `type`, `description`, `begin`, `end`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, hash_code, uniprot_id, type_id, type, description, begin, [end])
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{hash_code}', '{uniprot_id}', '{type_id}', '{type}', '{description}', '{begin}', '{[end]}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `protein_feature_regions` (`hash_code`, `uniprot_id`, `type_id`, `type`, `description`, `begin`, `end`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, hash_code, uniprot_id, type_id, type, description, begin, [end])
    End Function
''' <summary>
''' ```SQL
''' UPDATE `protein_feature_regions` SET `hash_code`='{0}', `uniprot_id`='{1}', `type_id`='{2}', `type`='{3}', `description`='{4}', `begin`='{5}', `end`='{6}' WHERE `hash_code` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, hash_code, uniprot_id, type_id, type, description, begin, [end], hash_code)
    End Function
#End Region
Public Function Clone() As protein_feature_regions
                  Return DirectCast(MyClass.MemberwiseClone, protein_feature_regions)
              End Function
End Class


End Namespace
