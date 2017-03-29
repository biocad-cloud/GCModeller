REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @2017/3/29 17:22:14


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace mysql

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `orthology_references`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `orthology_references` (
'''   `entry_id` varchar(45) NOT NULL,
'''   `pmid` varchar(45) NOT NULL,
'''   `id` int(11) NOT NULL AUTO_INCREMENT,
'''   PRIMARY KEY (`pmid`,`entry_id`),
'''   UNIQUE KEY `id_UNIQUE` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("orthology_references", Database:="jp_kegg2", SchemaSQL:="
CREATE TABLE `orthology_references` (
  `entry_id` varchar(45) NOT NULL,
  `pmid` varchar(45) NOT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`pmid`,`entry_id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class orthology_references: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry_id"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "45")> Public Property entry_id As String
    <DatabaseField("pmid"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "45")> Public Property pmid As String
    <DatabaseField("id"), AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `orthology_references` (`entry_id`, `pmid`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `orthology_references` (`entry_id`, `pmid`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `orthology_references` WHERE `pmid`='{0}' and `entry_id`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `orthology_references` SET `entry_id`='{0}', `pmid`='{1}', `id`='{2}' WHERE `pmid`='{3}' and `entry_id`='{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `orthology_references` WHERE `pmid`='{0}' and `entry_id`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, pmid, entry_id)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `orthology_references` (`entry_id`, `pmid`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry_id, pmid)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry_id}', '{pmid}', '{2}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `orthology_references` (`entry_id`, `pmid`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry_id, pmid)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `orthology_references` SET `entry_id`='{0}', `pmid`='{1}', `id`='{2}' WHERE `pmid`='{3}' and `entry_id`='{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry_id, pmid, id, pmid, entry_id)
    End Function
#End Region
End Class


End Namespace
