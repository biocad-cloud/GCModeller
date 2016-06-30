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
''' DROP TABLE IF EXISTS `softwarewidcontactwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `softwarewidcontactwid` (
'''   `SoftwareWID` bigint(20) NOT NULL,
'''   `ContactWID` bigint(20) NOT NULL,
'''   KEY `FK_SoftwareWIDContactWID1` (`SoftwareWID`),
'''   KEY `FK_SoftwareWIDContactWID2` (`ContactWID`),
'''   CONSTRAINT `FK_SoftwareWIDContactWID1` FOREIGN KEY (`SoftwareWID`) REFERENCES `parameterizable` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_SoftwareWIDContactWID2` FOREIGN KEY (`ContactWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("softwarewidcontactwid", Database:="warehouse")>
Public Class softwarewidcontactwid: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("SoftwareWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property SoftwareWID As Long
    <DatabaseField("ContactWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ContactWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `softwarewidcontactwid` (`SoftwareWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `softwarewidcontactwid` WHERE `SoftwareWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `softwarewidcontactwid` SET `SoftwareWID`='{0}', `ContactWID`='{1}' WHERE `SoftwareWID` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, SoftwareWID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, SoftwareWID, ContactWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, SoftwareWID, ContactWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, SoftwareWID, ContactWID, SoftwareWID)
    End Function
#End Region
End Class


End Namespace
