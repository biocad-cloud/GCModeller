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
''' DROP TABLE IF EXISTS `superpathway`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `superpathway` (
'''   `SubPathwayWID` bigint(20) NOT NULL,
'''   `SuperPathwayWID` bigint(20) NOT NULL,
'''   KEY `FK_SuperPathway1` (`SubPathwayWID`),
'''   KEY `FK_SuperPathway2` (`SuperPathwayWID`),
'''   CONSTRAINT `FK_SuperPathway1` FOREIGN KEY (`SubPathwayWID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_SuperPathway2` FOREIGN KEY (`SuperPathwayWID`) REFERENCES `pathway` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("superpathway", Database:="warehouse")>
Public Class superpathway: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("SubPathwayWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SubPathwayWID As Long
    <DatabaseField("SuperPathwayWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SuperPathwayWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `superpathway` (`SubPathwayWID`, `SuperPathwayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `superpathway` (`SubPathwayWID`, `SuperPathwayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `superpathway` WHERE `SubPathwayWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `superpathway` SET `SubPathwayWID`='{0}', `SuperPathwayWID`='{1}' WHERE `SubPathwayWID` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, SubPathwayWID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, SubPathwayWID, SuperPathwayWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, SubPathwayWID, SuperPathwayWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, SubPathwayWID, SuperPathwayWID, SubPathwayWID)
    End Function
#End Region
End Class


End Namespace
