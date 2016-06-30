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
''' DROP TABLE IF EXISTS `bassaymappingwidbassaymapwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `bassaymappingwidbassaymapwid` (
'''   `BioAssayMappingWID` bigint(20) NOT NULL,
'''   `BioAssayMapWID` bigint(20) NOT NULL,
'''   KEY `FK_BAssayMappingWIDBAssayMap1` (`BioAssayMappingWID`),
'''   KEY `FK_BAssayMappingWIDBAssayMap2` (`BioAssayMapWID`),
'''   CONSTRAINT `FK_BAssayMappingWIDBAssayMap1` FOREIGN KEY (`BioAssayMappingWID`) REFERENCES `bioassaymapping` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BAssayMappingWIDBAssayMap2` FOREIGN KEY (`BioAssayMapWID`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("bassaymappingwidbassaymapwid", Database:="warehouse")>
Public Class bassaymappingwidbassaymapwid: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("BioAssayMappingWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioAssayMappingWID As Long
    <DatabaseField("BioAssayMapWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioAssayMapWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `bassaymappingwidbassaymapwid` (`BioAssayMappingWID`, `BioAssayMapWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `bassaymappingwidbassaymapwid` WHERE `BioAssayMappingWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `bassaymappingwidbassaymapwid` SET `BioAssayMappingWID`='{0}', `BioAssayMapWID`='{1}' WHERE `BioAssayMappingWID` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioAssayMappingWID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, BioAssayMappingWID, BioAssayMapWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, BioAssayMappingWID, BioAssayMapWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, BioAssayMappingWID, BioAssayMapWID, BioAssayMappingWID)
    End Function
#End Region
End Class


End Namespace
