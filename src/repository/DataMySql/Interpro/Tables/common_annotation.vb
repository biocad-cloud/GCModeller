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
''' DROP TABLE IF EXISTS `common_annotation`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `common_annotation` (
'''   `ann_id` varchar(7) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `name` varchar(50) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   `text` mediumtext CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `comments` varchar(100) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
'''   PRIMARY KEY (`ann_id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("common_annotation", Database:="interpro", SchemaSQL:="
CREATE TABLE `common_annotation` (
  `ann_id` varchar(7) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `name` varchar(50) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  `text` mediumtext CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `comments` varchar(100) CHARACTER SET latin1 COLLATE latin1_bin DEFAULT NULL,
  PRIMARY KEY (`ann_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class common_annotation: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ann_id"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7"), Column(Name:="ann_id"), XmlAttribute> Public Property ann_id As String
    <DatabaseField("name"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="name")> Public Property name As String
    <DatabaseField("text"), NotNull, DataType(MySqlDbType.Text), Column(Name:="text")> Public Property text As String
    <DatabaseField("comments"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="comments")> Public Property comments As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `common_annotation` (`ann_id`, `name`, `text`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `common_annotation` (`ann_id`, `name`, `text`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `common_annotation` (`ann_id`, `name`, `text`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `common_annotation` (`ann_id`, `name`, `text`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `common_annotation` WHERE `ann_id` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `common_annotation` SET `ann_id`='{0}', `name`='{1}', `text`='{2}', `comments`='{3}' WHERE `ann_id` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `common_annotation` WHERE `ann_id` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ann_id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `common_annotation` (`ann_id`, `name`, `text`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ann_id, name, text, comments)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `common_annotation` (`ann_id`, `name`, `text`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, ann_id, name, text, comments)
        Else
        Return String.Format(INSERT_SQL, ann_id, name, text, comments)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ann_id}', '{name}', '{text}', '{comments}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `common_annotation` (`ann_id`, `name`, `text`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ann_id, name, text, comments)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `common_annotation` (`ann_id`, `name`, `text`, `comments`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, ann_id, name, text, comments)
        Else
        Return String.Format(REPLACE_SQL, ann_id, name, text, comments)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `common_annotation` SET `ann_id`='{0}', `name`='{1}', `text`='{2}', `comments`='{3}' WHERE `ann_id` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ann_id, name, text, comments, ann_id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As common_annotation
                         Return DirectCast(MyClass.MemberwiseClone, common_annotation)
                     End Function
End Class


End Namespace
