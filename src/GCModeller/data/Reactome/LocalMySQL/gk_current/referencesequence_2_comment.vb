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
''' DROP TABLE IF EXISTS `referencesequence_2_comment`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `referencesequence_2_comment` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `comment_rank` int(10) unsigned DEFAULT NULL,
'''   `comment` text,
'''   KEY `DB_ID` (`DB_ID`),
'''   FULLTEXT KEY `comment` (`comment`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("referencesequence_2_comment", Database:="gk_current", SchemaSQL:="
CREATE TABLE `referencesequence_2_comment` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `comment_rank` int(10) unsigned DEFAULT NULL,
  `comment` text,
  KEY `DB_ID` (`DB_ID`),
  FULLTEXT KEY `comment` (`comment`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class referencesequence_2_comment: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("comment_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="comment_rank")> Public Property comment_rank As Long
    <DatabaseField("comment"), DataType(MySqlDbType.Text), Column(Name:="comment")> Public Property comment As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `referencesequence_2_comment` (`DB_ID`, `comment_rank`, `comment`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `referencesequence_2_comment` (`DB_ID`, `comment_rank`, `comment`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `referencesequence_2_comment` (`DB_ID`, `comment_rank`, `comment`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `referencesequence_2_comment` (`DB_ID`, `comment_rank`, `comment`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `referencesequence_2_comment` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `referencesequence_2_comment` SET `DB_ID`='{0}', `comment_rank`='{1}', `comment`='{2}' WHERE `DB_ID` = '{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `referencesequence_2_comment` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `referencesequence_2_comment` (`DB_ID`, `comment_rank`, `comment`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, comment_rank, comment)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `referencesequence_2_comment` (`DB_ID`, `comment_rank`, `comment`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, comment_rank, comment)
        Else
        Return String.Format(INSERT_SQL, DB_ID, comment_rank, comment)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{comment_rank}', '{comment}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `referencesequence_2_comment` (`DB_ID`, `comment_rank`, `comment`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, comment_rank, comment)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `referencesequence_2_comment` (`DB_ID`, `comment_rank`, `comment`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, comment_rank, comment)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, comment_rank, comment)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `referencesequence_2_comment` SET `DB_ID`='{0}', `comment_rank`='{1}', `comment`='{2}' WHERE `DB_ID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, comment_rank, comment, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As referencesequence_2_comment
                         Return DirectCast(MyClass.MemberwiseClone, referencesequence_2_comment)
                     End Function
End Class


End Namespace
