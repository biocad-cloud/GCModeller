REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:13


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `description`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `description` (
'''   `OtherWID` bigint(20) NOT NULL,
'''   `TableName` varchar(30) NOT NULL,
'''   `Comm` text
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("description", Database:="warehouse", SchemaSQL:="
CREATE TABLE `description` (
  `OtherWID` bigint(20) NOT NULL,
  `TableName` varchar(30) NOT NULL,
  `Comm` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class description: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("OtherWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="OtherWID")> Public Property OtherWID As Long
    <DatabaseField("TableName"), NotNull, DataType(MySqlDbType.VarChar, "30"), Column(Name:="TableName")> Public Property TableName As String
    <DatabaseField("Comm"), DataType(MySqlDbType.Text), Column(Name:="Comm")> Public Property Comm As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `description` (`OtherWID`, `TableName`, `Comm`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `description` (`OtherWID`, `TableName`, `Comm`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `description` (`OtherWID`, `TableName`, `Comm`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `description` (`OtherWID`, `TableName`, `Comm`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `description` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `description` SET `OtherWID`='{0}', `TableName`='{1}', `Comm`='{2}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `description` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `description` (`OtherWID`, `TableName`, `Comm`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, OtherWID, TableName, Comm)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `description` (`OtherWID`, `TableName`, `Comm`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, OtherWID, TableName, Comm)
        Else
        Return String.Format(INSERT_SQL, OtherWID, TableName, Comm)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{OtherWID}', '{TableName}', '{Comm}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `description` (`OtherWID`, `TableName`, `Comm`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, OtherWID, TableName, Comm)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `description` (`OtherWID`, `TableName`, `Comm`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, OtherWID, TableName, Comm)
        Else
        Return String.Format(REPLACE_SQL, OtherWID, TableName, Comm)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `description` SET `OtherWID`='{0}', `TableName`='{1}', `Comm`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As description
                         Return DirectCast(MyClass.MemberwiseClone, description)
                     End Function
End Class


End Namespace
