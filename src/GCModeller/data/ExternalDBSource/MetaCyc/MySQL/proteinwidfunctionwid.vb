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
''' DROP TABLE IF EXISTS `proteinwidfunctionwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `proteinwidfunctionwid` (
'''   `ProteinWID` bigint(20) NOT NULL,
'''   `FunctionWID` bigint(20) NOT NULL,
'''   KEY `FK_ProteinWIDFunctionWID2` (`ProteinWID`),
'''   KEY `FK_ProteinWIDFunctionWID3` (`FunctionWID`),
'''   CONSTRAINT `FK_ProteinWIDFunctionWID2` FOREIGN KEY (`ProteinWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ProteinWIDFunctionWID3` FOREIGN KEY (`FunctionWID`) REFERENCES `function` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("proteinwidfunctionwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `proteinwidfunctionwid` (
  `ProteinWID` bigint(20) NOT NULL,
  `FunctionWID` bigint(20) NOT NULL,
  KEY `FK_ProteinWIDFunctionWID2` (`ProteinWID`),
  KEY `FK_ProteinWIDFunctionWID3` (`FunctionWID`),
  CONSTRAINT `FK_ProteinWIDFunctionWID2` FOREIGN KEY (`ProteinWID`) REFERENCES `protein` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ProteinWIDFunctionWID3` FOREIGN KEY (`FunctionWID`) REFERENCES `function` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class proteinwidfunctionwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ProteinWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ProteinWID"), XmlAttribute> Public Property ProteinWID As Long
    <DatabaseField("FunctionWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="FunctionWID")> Public Property FunctionWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `proteinwidfunctionwid` (`ProteinWID`, `FunctionWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `proteinwidfunctionwid` (`ProteinWID`, `FunctionWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `proteinwidfunctionwid` (`ProteinWID`, `FunctionWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `proteinwidfunctionwid` (`ProteinWID`, `FunctionWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `proteinwidfunctionwid` WHERE `ProteinWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `proteinwidfunctionwid` SET `ProteinWID`='{0}', `FunctionWID`='{1}' WHERE `ProteinWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `proteinwidfunctionwid` WHERE `ProteinWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ProteinWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `proteinwidfunctionwid` (`ProteinWID`, `FunctionWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ProteinWID, FunctionWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `proteinwidfunctionwid` (`ProteinWID`, `FunctionWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, ProteinWID, FunctionWID)
        Else
        Return String.Format(INSERT_SQL, ProteinWID, FunctionWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ProteinWID}', '{FunctionWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `proteinwidfunctionwid` (`ProteinWID`, `FunctionWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ProteinWID, FunctionWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `proteinwidfunctionwid` (`ProteinWID`, `FunctionWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, ProteinWID, FunctionWID)
        Else
        Return String.Format(REPLACE_SQL, ProteinWID, FunctionWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `proteinwidfunctionwid` SET `ProteinWID`='{0}', `FunctionWID`='{1}' WHERE `ProteinWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ProteinWID, FunctionWID, ProteinWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As proteinwidfunctionwid
                         Return DirectCast(MyClass.MemberwiseClone, proteinwidfunctionwid)
                     End Function
End Class


End Namespace
