REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:36


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
''' DROP TABLE IF EXISTS `objects`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `objects` (
'''   `object_id` decimal(10,0) DEFAULT NULL,
'''   `object_description` varchar(4000) DEFAULT NULL,
'''   `object_table_name` varchar(50) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("objects", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `objects` (
  `object_id` decimal(10,0) DEFAULT NULL,
  `object_description` varchar(4000) DEFAULT NULL,
  `object_table_name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class objects: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("object_id"), DataType(MySqlDbType.Decimal), Column(Name:="object_id")> Public Property object_id As Decimal
    <DatabaseField("object_description"), DataType(MySqlDbType.VarChar, "4000"), Column(Name:="object_description")> Public Property object_description As String
    <DatabaseField("object_table_name"), DataType(MySqlDbType.VarChar, "50"), Column(Name:="object_table_name")> Public Property object_table_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `objects` (`object_id`, `object_description`, `object_table_name`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `objects` (`object_id`, `object_description`, `object_table_name`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `objects` (`object_id`, `object_description`, `object_table_name`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `objects` (`object_id`, `object_description`, `object_table_name`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `objects` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `objects` SET `object_id`='{0}', `object_description`='{1}', `object_table_name`='{2}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `objects` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `objects` (`object_id`, `object_description`, `object_table_name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, object_id, object_description, object_table_name)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `objects` (`object_id`, `object_description`, `object_table_name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, object_id, object_description, object_table_name)
        Else
        Return String.Format(INSERT_SQL, object_id, object_description, object_table_name)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{object_id}', '{object_description}', '{object_table_name}')"
        Else
            Return $"('{object_id}', '{object_description}', '{object_table_name}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `objects` (`object_id`, `object_description`, `object_table_name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, object_id, object_description, object_table_name)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `objects` (`object_id`, `object_description`, `object_table_name`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, object_id, object_description, object_table_name)
        Else
        Return String.Format(REPLACE_SQL, object_id, object_description, object_table_name)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `objects` SET `object_id`='{0}', `object_description`='{1}', `object_table_name`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As objects
                         Return DirectCast(MyClass.MemberwiseClone, objects)
                     End Function
End Class


End Namespace
