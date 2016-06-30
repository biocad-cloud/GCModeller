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
''' DROP TABLE IF EXISTS `protocolwidsoftwarewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `protocolwidsoftwarewid` (
'''   `ProtocolWID` bigint(20) NOT NULL,
'''   `SoftwareWID` bigint(20) NOT NULL,
'''   KEY `FK_ProtocolWIDSoftwareWID1` (`ProtocolWID`),
'''   KEY `FK_ProtocolWIDSoftwareWID2` (`SoftwareWID`),
'''   CONSTRAINT `FK_ProtocolWIDSoftwareWID1` FOREIGN KEY (`ProtocolWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ProtocolWIDSoftwareWID2` FOREIGN KEY (`SoftwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("protocolwidsoftwarewid", Database:="warehouse")>
Public Class protocolwidsoftwarewid: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ProtocolWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ProtocolWID As Long
    <DatabaseField("SoftwareWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SoftwareWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `protocolwidsoftwarewid` (`ProtocolWID`, `SoftwareWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `protocolwidsoftwarewid` (`ProtocolWID`, `SoftwareWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `protocolwidsoftwarewid` WHERE `ProtocolWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `protocolwidsoftwarewid` SET `ProtocolWID`='{0}', `SoftwareWID`='{1}' WHERE `ProtocolWID` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ProtocolWID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ProtocolWID, SoftwareWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ProtocolWID, SoftwareWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ProtocolWID, SoftwareWID, ProtocolWID)
    End Function
#End Region
End Class


End Namespace
