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
''' DROP TABLE IF EXISTS `reactionvertex`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reactionvertex` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `pointCoordinates` text,
'''   PRIMARY KEY (`DB_ID`),
'''   FULLTEXT KEY `pointCoordinates` (`pointCoordinates`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reactionvertex", Database:="gk_current", SchemaSQL:="
CREATE TABLE `reactionvertex` (
  `DB_ID` int(10) unsigned NOT NULL,
  `pointCoordinates` text,
  PRIMARY KEY (`DB_ID`),
  FULLTEXT KEY `pointCoordinates` (`pointCoordinates`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class reactionvertex: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("pointCoordinates"), DataType(MySqlDbType.Text), Column(Name:="pointCoordinates")> Public Property pointCoordinates As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `reactionvertex` (`DB_ID`, `pointCoordinates`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `reactionvertex` (`DB_ID`, `pointCoordinates`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `reactionvertex` (`DB_ID`, `pointCoordinates`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `reactionvertex` (`DB_ID`, `pointCoordinates`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `reactionvertex` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `reactionvertex` SET `DB_ID`='{0}', `pointCoordinates`='{1}' WHERE `DB_ID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `reactionvertex` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `reactionvertex` (`DB_ID`, `pointCoordinates`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, pointCoordinates)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `reactionvertex` (`DB_ID`, `pointCoordinates`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, pointCoordinates)
        Else
        Return String.Format(INSERT_SQL, DB_ID, pointCoordinates)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{pointCoordinates}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `reactionvertex` (`DB_ID`, `pointCoordinates`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, pointCoordinates)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `reactionvertex` (`DB_ID`, `pointCoordinates`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, pointCoordinates)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, pointCoordinates)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `reactionvertex` SET `DB_ID`='{0}', `pointCoordinates`='{1}' WHERE `DB_ID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, pointCoordinates, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As reactionvertex
                         Return DirectCast(MyClass.MemberwiseClone, reactionvertex)
                     End Function
End Class


End Namespace
