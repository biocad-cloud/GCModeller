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
''' DROP TABLE IF EXISTS `cv_evidence`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `cv_evidence` (
'''   `code` char(3) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `abbrev` varchar(10) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `description` mediumtext CHARACTER SET latin1 COLLATE latin1_bin,
'''   PRIMARY KEY (`code`),
'''   UNIQUE KEY `uq_evidence$abbrev` (`abbrev`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("cv_evidence", Database:="interpro", SchemaSQL:="
CREATE TABLE `cv_evidence` (
  `code` char(3) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `abbrev` varchar(10) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `description` mediumtext CHARACTER SET latin1 COLLATE latin1_bin,
  PRIMARY KEY (`code`),
  UNIQUE KEY `uq_evidence$abbrev` (`abbrev`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class cv_evidence: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("code"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "3"), Column(Name:="code"), XmlAttribute> Public Property code As String
    <DatabaseField("abbrev"), NotNull, DataType(MySqlDbType.VarChar, "10"), Column(Name:="abbrev")> Public Property abbrev As String
    <DatabaseField("description"), DataType(MySqlDbType.Text), Column(Name:="description")> Public Property description As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `cv_evidence` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `cv_evidence` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `cv_evidence` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `cv_evidence` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `cv_evidence` WHERE `code` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `cv_evidence` SET `code`='{0}', `abbrev`='{1}', `description`='{2}' WHERE `code` = '{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `cv_evidence` WHERE `code` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, code)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `cv_evidence` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, code, abbrev, description)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `cv_evidence` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, code, abbrev, description)
        Else
        Return String.Format(INSERT_SQL, code, abbrev, description)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{code}', '{abbrev}', '{description}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `cv_evidence` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, code, abbrev, description)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `cv_evidence` (`code`, `abbrev`, `description`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, code, abbrev, description)
        Else
        Return String.Format(REPLACE_SQL, code, abbrev, description)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `cv_evidence` SET `code`='{0}', `abbrev`='{1}', `description`='{2}' WHERE `code` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, code, abbrev, description, code)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As cv_evidence
                         Return DirectCast(MyClass.MemberwiseClone, cv_evidence)
                     End Function
End Class


End Namespace
