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
''' DROP TABLE IF EXISTS `function`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `function` (
'''   `WID` bigint(20) NOT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Function` (`DataSetWID`),
'''   CONSTRAINT `FK_Function` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("function", Database:="warehouse", SchemaSQL:="
CREATE TABLE `function` (
  `WID` bigint(20) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Function` (`DataSetWID`),
  CONSTRAINT `FK_Function` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class [function]: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Name")> Public Property Name As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `function` (`WID`, `Name`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `function` (`WID`, `Name`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `function` (`WID`, `Name`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `function` (`WID`, `Name`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `function` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `function` SET `WID`='{0}', `Name`='{1}', `DataSetWID`='{2}' WHERE `WID` = '{3}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `function` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `function` (`WID`, `Name`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Name, DataSetWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `function` (`WID`, `Name`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, Name, DataSetWID)
        Else
        Return String.Format(INSERT_SQL, WID, Name, DataSetWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Name}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `function` (`WID`, `Name`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Name, DataSetWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `function` (`WID`, `Name`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, Name, DataSetWID)
        Else
        Return String.Format(REPLACE_SQL, WID, Name, DataSetWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `function` SET `WID`='{0}', `Name`='{1}', `DataSetWID`='{2}' WHERE `WID` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Name, DataSetWID, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As [function]
                         Return DirectCast(MyClass.MemberwiseClone, [function])
                     End Function
End Class


End Namespace
