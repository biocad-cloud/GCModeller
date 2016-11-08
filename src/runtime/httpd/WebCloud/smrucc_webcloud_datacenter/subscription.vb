REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @2016/11/8 15:11:37


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace mysql

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `subscription`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `subscription` (
'''   `uid` int(11) NOT NULL AUTO_INCREMENT,
'''   `email` varchar(128) NOT NULL,
'''   `hash` varchar(64) NOT NULL,
'''   `app` int(11) NOT NULL,
'''   `active` int(11) NOT NULL DEFAULT '0' COMMENT '1 OR 0',
'''   PRIMARY KEY (`uid`,`email`),
'''   UNIQUE KEY `uid_UNIQUE` (`uid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("subscription", Database:="smrucc_webcloud", SchemaSQL:="
CREATE TABLE `subscription` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(128) NOT NULL,
  `hash` varchar(64) NOT NULL,
  `app` int(11) NOT NULL,
  `active` int(11) NOT NULL DEFAULT '0' COMMENT '1 OR 0',
  PRIMARY KEY (`uid`,`email`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class subscription: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uid"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property uid As Long
    <DatabaseField("email"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "128")> Public Property email As String
    <DatabaseField("hash"), NotNull, DataType(MySqlDbType.VarChar, "64")> Public Property hash As String
    <DatabaseField("app"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property app As Long
''' <summary>
''' 1 OR 0
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("active"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property active As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `subscription` (`email`, `hash`, `app`, `active`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `subscription` (`email`, `hash`, `app`, `active`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `subscription` WHERE `uid`='{0}' and `email`='{1}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `subscription` SET `uid`='{0}', `email`='{1}', `hash`='{2}', `app`='{3}', `active`='{4}' WHERE `uid`='{5}' and `email`='{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `subscription` WHERE `uid`='{0}' and `email`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uid, email)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `subscription` (`email`, `hash`, `app`, `active`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, email, hash, app, active)
    End Function
''' <summary>
''' ```SQL
''' REPLACE INTO `subscription` (`email`, `hash`, `app`, `active`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, email, hash, app, active)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `subscription` SET `uid`='{0}', `email`='{1}', `hash`='{2}', `app`='{3}', `active`='{4}' WHERE `uid`='{5}' and `email`='{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uid, email, hash, app, active, uid, email)
    End Function
#End Region
End Class


End Namespace
