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
''' DROP TABLE IF EXISTS `experimentdesignwidbioassaywid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `experimentdesignwidbioassaywid` (
'''   `ExperimentDesignWID` bigint(20) NOT NULL,
'''   `BioAssayWID` bigint(20) NOT NULL,
'''   KEY `FK_ExperimentDesignWIDBioAss1` (`ExperimentDesignWID`),
'''   KEY `FK_ExperimentDesignWIDBioAss2` (`BioAssayWID`),
'''   CONSTRAINT `FK_ExperimentDesignWIDBioAss1` FOREIGN KEY (`ExperimentDesignWID`) REFERENCES `experimentdesign` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ExperimentDesignWIDBioAss2` FOREIGN KEY (`BioAssayWID`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("experimentdesignwidbioassaywid", Database:="warehouse")>
Public Class experimentdesignwidbioassaywid: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ExperimentDesignWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ExperimentDesignWID As Long
    <DatabaseField("BioAssayWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioAssayWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `experimentdesignwidbioassaywid` (`ExperimentDesignWID`, `BioAssayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `experimentdesignwidbioassaywid` (`ExperimentDesignWID`, `BioAssayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `experimentdesignwidbioassaywid` WHERE `ExperimentDesignWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `experimentdesignwidbioassaywid` SET `ExperimentDesignWID`='{0}', `BioAssayWID`='{1}' WHERE `ExperimentDesignWID` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ExperimentDesignWID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ExperimentDesignWID, BioAssayWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ExperimentDesignWID, BioAssayWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ExperimentDesignWID, BioAssayWID, ExperimentDesignWID)
    End Function
#End Region
End Class


End Namespace
