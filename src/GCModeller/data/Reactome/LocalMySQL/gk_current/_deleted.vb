REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:14


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `_deleted`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `_deleted` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `curatorComment` text,
'''   `reason` int(10) unsigned DEFAULT NULL,
'''   `reason_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `reason` (`reason`),
'''   FULLTEXT KEY `curatorComment` (`curatorComment`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("_deleted", Database:="gk_current", SchemaSQL:="
CREATE TABLE `_deleted` (
  `DB_ID` int(10) unsigned NOT NULL,
  `curatorComment` text,
  `reason` int(10) unsigned DEFAULT NULL,
  `reason_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `reason` (`reason`),
  FULLTEXT KEY `curatorComment` (`curatorComment`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class _deleted: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("curatorComment"), DataType(MySqlDbType.Text), Column(Name:="curatorComment")> Public Property curatorComment As String
    <DatabaseField("reason"), DataType(MySqlDbType.Int64, "10"), Column(Name:="reason")> Public Property reason As Long
    <DatabaseField("reason_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="reason_class")> Public Property reason_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `_deleted` (`DB_ID`, `curatorComment`, `reason`, `reason_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `_deleted` (`DB_ID`, `curatorComment`, `reason`, `reason_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `_deleted` (`DB_ID`, `curatorComment`, `reason`, `reason_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `_deleted` (`DB_ID`, `curatorComment`, `reason`, `reason_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `_deleted` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `_deleted` SET `DB_ID`='{0}', `curatorComment`='{1}', `reason`='{2}', `reason_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `_deleted` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `_deleted` (`DB_ID`, `curatorComment`, `reason`, `reason_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, curatorComment, reason, reason_class)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `_deleted` (`DB_ID`, `curatorComment`, `reason`, `reason_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, curatorComment, reason, reason_class)
        Else
        Return String.Format(INSERT_SQL, DB_ID, curatorComment, reason, reason_class)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{curatorComment}', '{reason}', '{reason_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `_deleted` (`DB_ID`, `curatorComment`, `reason`, `reason_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, curatorComment, reason, reason_class)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `_deleted` (`DB_ID`, `curatorComment`, `reason`, `reason_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, curatorComment, reason, reason_class)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, curatorComment, reason, reason_class)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `_deleted` SET `DB_ID`='{0}', `curatorComment`='{1}', `reason`='{2}', `reason_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, curatorComment, reason, reason_class, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As _deleted
                         Return DirectCast(MyClass.MemberwiseClone, _deleted)
                     End Function
End Class


End Namespace
