REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:10


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `mv_tax_entry_count`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `mv_tax_entry_count` (
'''   `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `tax_id` decimal(22,0) NOT NULL,
'''   `count` decimal(22,0) NOT NULL,
'''   PRIMARY KEY (`entry_ac`,`tax_id`,`count`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("mv_tax_entry_count", Database:="interpro", SchemaSQL:="
CREATE TABLE `mv_tax_entry_count` (
  `entry_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `tax_id` decimal(22,0) NOT NULL,
  `count` decimal(22,0) NOT NULL,
  PRIMARY KEY (`entry_ac`,`tax_id`,`count`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class mv_tax_entry_count: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9"), Column(Name:="entry_ac"), XmlAttribute> Public Property entry_ac As String
    <DatabaseField("tax_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Decimal), Column(Name:="tax_id"), XmlAttribute> Public Property tax_id As Decimal
    <DatabaseField("count"), PrimaryKey, NotNull, DataType(MySqlDbType.Decimal), Column(Name:="count"), XmlAttribute> Public Property count As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `mv_tax_entry_count` WHERE `entry_ac`='{0}' and `tax_id`='{1}' and `count`='{2}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `mv_tax_entry_count` SET `entry_ac`='{0}', `tax_id`='{1}', `count`='{2}' WHERE `entry_ac`='{3}' and `tax_id`='{4}' and `count`='{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `mv_tax_entry_count` WHERE `entry_ac`='{0}' and `tax_id`='{1}' and `count`='{2}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry_ac, tax_id, count)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry_ac, tax_id, count)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, entry_ac, tax_id, count)
        Else
        Return String.Format(INSERT_SQL, entry_ac, tax_id, count)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry_ac}', '{tax_id}', '{count}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry_ac, tax_id, count)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `mv_tax_entry_count` (`entry_ac`, `tax_id`, `count`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, entry_ac, tax_id, count)
        Else
        Return String.Format(REPLACE_SQL, entry_ac, tax_id, count)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `mv_tax_entry_count` SET `entry_ac`='{0}', `tax_id`='{1}', `count`='{2}' WHERE `entry_ac`='{3}' and `tax_id`='{4}' and `count`='{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry_ac, tax_id, count, entry_ac, tax_id, count)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As mv_tax_entry_count
                         Return DirectCast(MyClass.MemberwiseClone, mv_tax_entry_count)
                     End Function
End Class


End Namespace
