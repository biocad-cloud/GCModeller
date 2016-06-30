REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 

REM  Dump @12/3/2015 8:02:47 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MetaCyc.MySQL

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `quanttypemapwidquanttypewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `quanttypemapwidquanttypewid` (
'''   `QuantitationTypeMapWID` bigint(20) NOT NULL,
'''   `QuantitationTypeWID` bigint(20) NOT NULL,
'''   KEY `FK_QuantTypeMapWIDQuantTypeW1` (`QuantitationTypeMapWID`),
'''   KEY `FK_QuantTypeMapWIDQuantTypeW2` (`QuantitationTypeWID`),
'''   CONSTRAINT `FK_QuantTypeMapWIDQuantTypeW1` FOREIGN KEY (`QuantitationTypeMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantTypeMapWIDQuantTypeW2` FOREIGN KEY (`QuantitationTypeWID`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("quanttypemapwidquanttypewid", Database:="warehouse")>
Public Class quanttypemapwidquanttypewid: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("QuantitationTypeMapWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property QuantitationTypeMapWID As Long
    <DatabaseField("QuantitationTypeWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property QuantitationTypeWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `quanttypemapwidquanttypewid` (`QuantitationTypeMapWID`, `QuantitationTypeWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `quanttypemapwidquanttypewid` (`QuantitationTypeMapWID`, `QuantitationTypeWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `quanttypemapwidquanttypewid` WHERE `QuantitationTypeMapWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `quanttypemapwidquanttypewid` SET `QuantitationTypeMapWID`='{0}', `QuantitationTypeWID`='{1}' WHERE `QuantitationTypeMapWID` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, QuantitationTypeMapWID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, QuantitationTypeMapWID, QuantitationTypeWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, QuantitationTypeMapWID, QuantitationTypeWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, QuantitationTypeMapWID, QuantitationTypeWID, QuantitationTypeMapWID)
    End Function
#End Region
End Class


End Namespace
