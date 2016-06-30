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
''' DROP TABLE IF EXISTS `arraymanufacturewidarraywid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `arraymanufacturewidarraywid` (
'''   `ArrayManufactureWID` bigint(20) NOT NULL,
'''   `ArrayWID` bigint(20) NOT NULL,
'''   KEY `FK_ArrayManufactureWIDArrayW1` (`ArrayManufactureWID`),
'''   KEY `FK_ArrayManufactureWIDArrayW2` (`ArrayWID`),
'''   CONSTRAINT `FK_ArrayManufactureWIDArrayW1` FOREIGN KEY (`ArrayManufactureWID`) REFERENCES `arraymanufacture` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ArrayManufactureWIDArrayW2` FOREIGN KEY (`ArrayWID`) REFERENCES `array_` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("arraymanufacturewidarraywid", Database:="warehouse")>
Public Class arraymanufacturewidarraywid: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ArrayManufactureWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ArrayManufactureWID As Long
    <DatabaseField("ArrayWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property ArrayWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `arraymanufacturewidarraywid` (`ArrayManufactureWID`, `ArrayWID`) VALUES ('{0}', '{1}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `arraymanufacturewidarraywid` WHERE `ArrayManufactureWID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `arraymanufacturewidarraywid` SET `ArrayManufactureWID`='{0}', `ArrayWID`='{1}' WHERE `ArrayManufactureWID` = '{2}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ArrayManufactureWID)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ArrayManufactureWID, ArrayWID)
    End Function
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ArrayManufactureWID, ArrayWID)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ArrayManufactureWID, ArrayWID, ArrayManufactureWID)
    End Function
#End Region
End Class


End Namespace
