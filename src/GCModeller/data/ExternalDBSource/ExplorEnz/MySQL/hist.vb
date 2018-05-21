REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:10


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace ExplorEnz.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `hist`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `hist` (
'''   `ec_num` varchar(12) NOT NULL DEFAULT '',
'''   `action` varchar(11) NOT NULL DEFAULT '',
'''   `note` text,
'''   `history` text,
'''   `class` int(1) DEFAULT NULL,
'''   `subclass` int(1) DEFAULT NULL,
'''   `subsubclass` int(1) DEFAULT NULL,
'''   `serial` int(1) DEFAULT NULL,
'''   `status` char(3) DEFAULT NULL,
'''   `last_change` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
'''   PRIMARY KEY (`ec_num`),
'''   UNIQUE KEY `ec_num` (`ec_num`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("hist", Database:="enzymed", SchemaSQL:="
CREATE TABLE `hist` (
  `ec_num` varchar(12) NOT NULL DEFAULT '',
  `action` varchar(11) NOT NULL DEFAULT '',
  `note` text,
  `history` text,
  `class` int(1) DEFAULT NULL,
  `subclass` int(1) DEFAULT NULL,
  `subsubclass` int(1) DEFAULT NULL,
  `serial` int(1) DEFAULT NULL,
  `status` char(3) DEFAULT NULL,
  `last_change` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ec_num`),
  UNIQUE KEY `ec_num` (`ec_num`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class hist: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ec_num"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="ec_num"), XmlAttribute> Public Property ec_num As String
    <DatabaseField("action"), NotNull, DataType(MySqlDbType.VarChar, "11"), Column(Name:="action")> Public Property action As String
    <DatabaseField("note"), DataType(MySqlDbType.Text), Column(Name:="note")> Public Property note As String
    <DatabaseField("history"), DataType(MySqlDbType.Text), Column(Name:="history")> Public Property history As String
    <DatabaseField("class"), DataType(MySqlDbType.Int64, "1"), Column(Name:="class")> Public Property [class] As Long
    <DatabaseField("subclass"), DataType(MySqlDbType.Int64, "1"), Column(Name:="subclass")> Public Property subclass As Long
    <DatabaseField("subsubclass"), DataType(MySqlDbType.Int64, "1"), Column(Name:="subsubclass")> Public Property subsubclass As Long
    <DatabaseField("serial"), DataType(MySqlDbType.Int64, "1"), Column(Name:="serial")> Public Property serial As Long
    <DatabaseField("status"), DataType(MySqlDbType.VarChar, "3"), Column(Name:="status")> Public Property status As String
    <DatabaseField("last_change"), NotNull, DataType(MySqlDbType.DateTime), Column(Name:="last_change")> Public Property last_change As Date
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `hist` WHERE `ec_num` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `hist` SET `ec_num`='{0}', `action`='{1}', `note`='{2}', `history`='{3}', `class`='{4}', `subclass`='{5}', `subsubclass`='{6}', `serial`='{7}', `status`='{8}', `last_change`='{9}' WHERE `ec_num` = '{10}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `hist` WHERE `ec_num` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ec_num)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, MySqlScript.ToMySqlDateTimeString(last_change))
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, MySqlScript.ToMySqlDateTimeString(last_change))
        Else
        Return String.Format(INSERT_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, MySqlScript.ToMySqlDateTimeString(last_change))
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ec_num}', '{action}', '{note}', '{history}', '{[class]}', '{subclass}', '{subsubclass}', '{serial}', '{status}', '{last_change}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, MySqlScript.ToMySqlDateTimeString(last_change))
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `hist` (`ec_num`, `action`, `note`, `history`, `class`, `subclass`, `subsubclass`, `serial`, `status`, `last_change`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, MySqlScript.ToMySqlDateTimeString(last_change))
        Else
        Return String.Format(REPLACE_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, MySqlScript.ToMySqlDateTimeString(last_change))
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `hist` SET `ec_num`='{0}', `action`='{1}', `note`='{2}', `history`='{3}', `class`='{4}', `subclass`='{5}', `subsubclass`='{6}', `serial`='{7}', `status`='{8}', `last_change`='{9}' WHERE `ec_num` = '{10}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ec_num, action, note, history, [class], subclass, subsubclass, serial, status, MySqlScript.ToMySqlDateTimeString(last_change), ec_num)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As hist
                         Return DirectCast(MyClass.MemberwiseClone, hist)
                     End Function
End Class


End Namespace
