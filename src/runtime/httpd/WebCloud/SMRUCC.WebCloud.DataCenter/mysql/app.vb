REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:59:32


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace mysql

''' <summary>
''' ```SQL
''' The analysis application that running the task
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `app`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `app` (
'''   `uid` int(11) NOT NULL,
'''   `name` varchar(128) NOT NULL,
'''   `description` longtext COMMENT '功能的详细描述',
'''   `catagory` varchar(45) DEFAULT NULL COMMENT '功能分类',
'''   PRIMARY KEY (`uid`),
'''   UNIQUE KEY `uid_UNIQUE` (`uid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='The analysis application that running the task';
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("app", Database:="smrucc-cloud", SchemaSQL:="
CREATE TABLE `app` (
  `uid` int(11) NOT NULL,
  `name` varchar(128) NOT NULL,
  `description` longtext COMMENT '功能的详细描述',
  `catagory` varchar(45) DEFAULT NULL COMMENT '功能分类',
  PRIMARY KEY (`uid`),
  UNIQUE KEY `uid_UNIQUE` (`uid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='The analysis application that running the task';")>
Public Class app: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("uid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11"), Column(Name:="uid"), XmlAttribute> Public Property uid As Long
    <DatabaseField("name"), NotNull, DataType(MySqlDbType.VarChar, "128"), Column(Name:="name")> Public Property name As String
''' <summary>
''' 功能的详细描述
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("description"), DataType(MySqlDbType.Text), Column(Name:="description")> Public Property description As String
''' <summary>
''' 功能分类
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("catagory"), DataType(MySqlDbType.VarChar, "45"), Column(Name:="catagory")> Public Property catagory As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `app` (`uid`, `name`, `description`, `catagory`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `app` (`uid`, `name`, `description`, `catagory`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `app` (`uid`, `name`, `description`, `catagory`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `app` (`uid`, `name`, `description`, `catagory`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `app` WHERE `uid` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `app` SET `uid`='{0}', `name`='{1}', `description`='{2}', `catagory`='{3}' WHERE `uid` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `app` WHERE `uid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, uid)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `app` (`uid`, `name`, `description`, `catagory`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, uid, name, description, catagory)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `app` (`uid`, `name`, `description`, `catagory`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, uid, name, description, catagory)
        Else
        Return String.Format(INSERT_SQL, uid, name, description, catagory)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{uid}', '{name}', '{description}', '{catagory}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `app` (`uid`, `name`, `description`, `catagory`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, uid, name, description, catagory)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `app` (`uid`, `name`, `description`, `catagory`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, uid, name, description, catagory)
        Else
        Return String.Format(REPLACE_SQL, uid, name, description, catagory)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `app` SET `uid`='{0}', `name`='{1}', `description`='{2}', `catagory`='{3}' WHERE `uid` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, uid, name, description, catagory, uid)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As app
                         Return DirectCast(MyClass.MemberwiseClone, app)
                     End Function
End Class


End Namespace
