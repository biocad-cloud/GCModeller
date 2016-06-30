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
''' DROP TABLE IF EXISTS `gellocation`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gellocation` (
'''   `WID` bigint(20) NOT NULL,
'''   `SpotWID` bigint(20) NOT NULL,
'''   `Xcoord` float DEFAULT NULL,
'''   `Ycoord` float DEFAULT NULL,
'''   `refGel` varchar(1) DEFAULT NULL,
'''   `ExperimentWID` bigint(20) NOT NULL,
'''   `DatasetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_GelLocSpotWid` (`SpotWID`),
'''   KEY `FK_GelLocExp` (`ExperimentWID`),
'''   KEY `FK_GelLocDataset` (`DatasetWID`),
'''   CONSTRAINT `FK_GelLocDataset` FOREIGN KEY (`DatasetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_GelLocExp` FOREIGN KEY (`ExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_GelLocSpotWid` FOREIGN KEY (`SpotWID`) REFERENCES `spot` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gellocation", Database:="warehouse")>
Public Class gellocation: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("SpotWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SpotWID As Long
    <DatabaseField("Xcoord"), DataType(MySqlDbType.Double)> Public Property Xcoord As Double
    <DatabaseField("Ycoord"), DataType(MySqlDbType.Double)> Public Property Ycoord As Double
    <DatabaseField("refGel"), DataType(MySqlDbType.VarChar, "1")> Public Property refGel As String
    <DatabaseField("ExperimentWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ExperimentWID As Long
    <DatabaseField("DatasetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DatasetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `gellocation` (`WID`, `SpotWID`, `Xcoord`, `Ycoord`, `refGel`, `ExperimentWID`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `gellocation` (`WID`, `SpotWID`, `Xcoord`, `Ycoord`, `refGel`, `ExperimentWID`, `DatasetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `gellocation` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `gellocation` SET `WID`='{0}', `SpotWID`='{1}', `Xcoord`='{2}', `Ycoord`='{3}', `refGel`='{4}', `ExperimentWID`='{5}', `DatasetWID`='{6}' WHERE `WID` = '{7}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, SpotWID, Xcoord, Ycoord, refGel, ExperimentWID, DatasetWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, SpotWID, Xcoord, Ycoord, refGel, ExperimentWID, DatasetWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, SpotWID, Xcoord, Ycoord, refGel, ExperimentWID, DatasetWID, WID)
    End Function
#End Region
End Class


End Namespace
