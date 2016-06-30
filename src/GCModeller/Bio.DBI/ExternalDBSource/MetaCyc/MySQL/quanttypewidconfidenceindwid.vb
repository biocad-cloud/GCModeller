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
''' DROP TABLE IF EXISTS `quanttypewidconfidenceindwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `quanttypewidconfidenceindwid` (
'''   `QuantitationTypeWID` bigint(20) NOT NULL,
'''   `ConfidenceIndicatorWID` bigint(20) NOT NULL,
'''   KEY `FK_QuantTypeWIDConfidenceInd1` (`QuantitationTypeWID`),
'''   KEY `FK_QuantTypeWIDConfidenceInd2` (`ConfidenceIndicatorWID`),
'''   CONSTRAINT `FK_QuantTypeWIDConfidenceInd1` FOREIGN KEY (`QuantitationTypeWID`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_QuantTypeWIDConfidenceInd2` FOREIGN KEY (`ConfidenceIndicatorWID`) REFERENCES `quantitationtype` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("quanttypewidconfidenceindwid", Database:="warehouse")>
Public Class quanttypewidconfidenceindwid: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("QuantitationTypeWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property QuantitationTypeWID As Long
    <DatabaseField("ConfidenceIndicatorWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ConfidenceIndicatorWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `quanttypewidconfidenceindwid` (`QuantitationTypeWID`, `ConfidenceIndicatorWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `quanttypewidconfidenceindwid` (`QuantitationTypeWID`, `ConfidenceIndicatorWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `quanttypewidconfidenceindwid` WHERE `QuantitationTypeWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `quanttypewidconfidenceindwid` SET `QuantitationTypeWID`='{0}', `ConfidenceIndicatorWID`='{1}' WHERE `QuantitationTypeWID` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, QuantitationTypeWID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, QuantitationTypeWID, ConfidenceIndicatorWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, QuantitationTypeWID, ConfidenceIndicatorWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, QuantitationTypeWID, ConfidenceIndicatorWID, QuantitationTypeWID)
    End Function
#End Region
End Class


End Namespace
