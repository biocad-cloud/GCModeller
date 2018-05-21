REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:09


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `conformation_effector_link`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `conformation_effector_link` (
'''   `effector_id` char(12) NOT NULL,
'''   `conformation_id` char(12) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("conformation_effector_link", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `conformation_effector_link` (
  `effector_id` char(12) NOT NULL,
  `conformation_id` char(12) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class conformation_effector_link: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("effector_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="effector_id")> Public Property effector_id As String
    <DatabaseField("conformation_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="conformation_id")> Public Property conformation_id As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `conformation_effector_link` (`effector_id`, `conformation_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `conformation_effector_link` (`effector_id`, `conformation_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `conformation_effector_link` (`effector_id`, `conformation_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `conformation_effector_link` (`effector_id`, `conformation_id`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `conformation_effector_link` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `conformation_effector_link` SET `effector_id`='{0}', `conformation_id`='{1}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `conformation_effector_link` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `conformation_effector_link` (`effector_id`, `conformation_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, effector_id, conformation_id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `conformation_effector_link` (`effector_id`, `conformation_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, effector_id, conformation_id)
        Else
        Return String.Format(INSERT_SQL, effector_id, conformation_id)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{effector_id}', '{conformation_id}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `conformation_effector_link` (`effector_id`, `conformation_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, effector_id, conformation_id)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `conformation_effector_link` (`effector_id`, `conformation_id`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, effector_id, conformation_id)
        Else
        Return String.Format(REPLACE_SQL, effector_id, conformation_id)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `conformation_effector_link` SET `effector_id`='{0}', `conformation_id`='{1}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As conformation_effector_link
                         Return DirectCast(MyClass.MemberwiseClone, conformation_effector_link)
                     End Function
End Class


End Namespace
