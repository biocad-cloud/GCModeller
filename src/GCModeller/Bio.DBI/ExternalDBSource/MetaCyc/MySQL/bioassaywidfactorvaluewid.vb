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
''' DROP TABLE IF EXISTS `bioassaywidfactorvaluewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `bioassaywidfactorvaluewid` (
'''   `BioAssayWID` bigint(20) NOT NULL,
'''   `FactorValueWID` bigint(20) NOT NULL,
'''   KEY `FK_BioAssayWIDFactorValueWID1` (`BioAssayWID`),
'''   KEY `FK_BioAssayWIDFactorValueWID2` (`FactorValueWID`),
'''   CONSTRAINT `FK_BioAssayWIDFactorValueWID1` FOREIGN KEY (`BioAssayWID`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayWIDFactorValueWID2` FOREIGN KEY (`FactorValueWID`) REFERENCES `factorvalue` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("bioassaywidfactorvaluewid", Database:="warehouse")>
Public Class bioassaywidfactorvaluewid: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("BioAssayWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property BioAssayWID As Long
    <DatabaseField("FactorValueWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property FactorValueWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `bioassaywidfactorvaluewid` (`BioAssayWID`, `FactorValueWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `bioassaywidfactorvaluewid` (`BioAssayWID`, `FactorValueWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `bioassaywidfactorvaluewid` WHERE `BioAssayWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `bioassaywidfactorvaluewid` SET `BioAssayWID`='{0}', `FactorValueWID`='{1}' WHERE `BioAssayWID` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioAssayWID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, BioAssayWID, FactorValueWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, BioAssayWID, FactorValueWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, BioAssayWID, FactorValueWID, BioAssayWID)
    End Function
#End Region
End Class


End Namespace
