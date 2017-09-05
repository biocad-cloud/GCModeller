REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 8:48:56 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `gene`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `gene` (
'''   `WID` bigint(20) NOT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `NucleicAcidWID` bigint(20) DEFAULT NULL,
'''   `SubsequenceWID` bigint(20) DEFAULT NULL,
'''   `Type` varchar(100) DEFAULT NULL,
'''   `GenomeID` varchar(35) DEFAULT NULL,
'''   `CodingRegionStart` int(11) DEFAULT NULL,
'''   `CodingRegionEnd` int(11) DEFAULT NULL,
'''   `CodingRegionStartApproximate` varchar(10) DEFAULT NULL,
'''   `CodingRegionEndApproximate` varchar(10) DEFAULT NULL,
'''   `Direction` varchar(25) DEFAULT NULL,
'''   `Interrupted` char(1) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `GENE_DATASETWID` (`DataSetWID`),
'''   KEY `FK_Gene1` (`NucleicAcidWID`),
'''   CONSTRAINT `FK_Gene1` FOREIGN KEY (`NucleicAcidWID`) REFERENCES `nucleicacid` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Gene2` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("gene", Database:="warehouse", SchemaSQL:="
CREATE TABLE `gene` (
  `WID` bigint(20) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `NucleicAcidWID` bigint(20) DEFAULT NULL,
  `SubsequenceWID` bigint(20) DEFAULT NULL,
  `Type` varchar(100) DEFAULT NULL,
  `GenomeID` varchar(35) DEFAULT NULL,
  `CodingRegionStart` int(11) DEFAULT NULL,
  `CodingRegionEnd` int(11) DEFAULT NULL,
  `CodingRegionStartApproximate` varchar(10) DEFAULT NULL,
  `CodingRegionEndApproximate` varchar(10) DEFAULT NULL,
  `Direction` varchar(25) DEFAULT NULL,
  `Interrupted` char(1) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `GENE_DATASETWID` (`DataSetWID`),
  KEY `FK_Gene1` (`NucleicAcidWID`),
  CONSTRAINT `FK_Gene1` FOREIGN KEY (`NucleicAcidWID`) REFERENCES `nucleicacid` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Gene2` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class gene: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20")> Public Property WID As Long
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255")> Public Property Name As String
    <DatabaseField("NucleicAcidWID"), DataType(MySqlDbType.Int64, "20")> Public Property NucleicAcidWID As Long
    <DatabaseField("SubsequenceWID"), DataType(MySqlDbType.Int64, "20")> Public Property SubsequenceWID As Long
    <DatabaseField("Type"), DataType(MySqlDbType.VarChar, "100")> Public Property Type As String
    <DatabaseField("GenomeID"), DataType(MySqlDbType.VarChar, "35")> Public Property GenomeID As String
    <DatabaseField("CodingRegionStart"), DataType(MySqlDbType.Int64, "11")> Public Property CodingRegionStart As Long
    <DatabaseField("CodingRegionEnd"), DataType(MySqlDbType.Int64, "11")> Public Property CodingRegionEnd As Long
    <DatabaseField("CodingRegionStartApproximate"), DataType(MySqlDbType.VarChar, "10")> Public Property CodingRegionStartApproximate As String
    <DatabaseField("CodingRegionEndApproximate"), DataType(MySqlDbType.VarChar, "10")> Public Property CodingRegionEndApproximate As String
    <DatabaseField("Direction"), DataType(MySqlDbType.VarChar, "25")> Public Property Direction As String
    <DatabaseField("Interrupted"), DataType(MySqlDbType.VarChar, "1")> Public Property Interrupted As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `gene` (`WID`, `Name`, `NucleicAcidWID`, `SubsequenceWID`, `Type`, `GenomeID`, `CodingRegionStart`, `CodingRegionEnd`, `CodingRegionStartApproximate`, `CodingRegionEndApproximate`, `Direction`, `Interrupted`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `gene` (`WID`, `Name`, `NucleicAcidWID`, `SubsequenceWID`, `Type`, `GenomeID`, `CodingRegionStart`, `CodingRegionEnd`, `CodingRegionStartApproximate`, `CodingRegionEndApproximate`, `Direction`, `Interrupted`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `gene` WHERE `WID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `gene` SET `WID`='{0}', `Name`='{1}', `NucleicAcidWID`='{2}', `SubsequenceWID`='{3}', `Type`='{4}', `GenomeID`='{5}', `CodingRegionStart`='{6}', `CodingRegionEnd`='{7}', `CodingRegionStartApproximate`='{8}', `CodingRegionEndApproximate`='{9}', `Direction`='{10}', `Interrupted`='{11}', `DataSetWID`='{12}' WHERE `WID` = '{13}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `gene` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `gene` (`WID`, `Name`, `NucleicAcidWID`, `SubsequenceWID`, `Type`, `GenomeID`, `CodingRegionStart`, `CodingRegionEnd`, `CodingRegionStartApproximate`, `CodingRegionEndApproximate`, `Direction`, `Interrupted`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, Name, NucleicAcidWID, SubsequenceWID, Type, GenomeID, CodingRegionStart, CodingRegionEnd, CodingRegionStartApproximate, CodingRegionEndApproximate, Direction, Interrupted, DataSetWID)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{Name}', '{NucleicAcidWID}', '{SubsequenceWID}', '{Type}', '{GenomeID}', '{CodingRegionStart}', '{CodingRegionEnd}', '{CodingRegionStartApproximate}', '{CodingRegionEndApproximate}', '{Direction}', '{Interrupted}', '{DataSetWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `gene` (`WID`, `Name`, `NucleicAcidWID`, `SubsequenceWID`, `Type`, `GenomeID`, `CodingRegionStart`, `CodingRegionEnd`, `CodingRegionStartApproximate`, `CodingRegionEndApproximate`, `Direction`, `Interrupted`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, Name, NucleicAcidWID, SubsequenceWID, Type, GenomeID, CodingRegionStart, CodingRegionEnd, CodingRegionStartApproximate, CodingRegionEndApproximate, Direction, Interrupted, DataSetWID)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `gene` SET `WID`='{0}', `Name`='{1}', `NucleicAcidWID`='{2}', `SubsequenceWID`='{3}', `Type`='{4}', `GenomeID`='{5}', `CodingRegionStart`='{6}', `CodingRegionEnd`='{7}', `CodingRegionStartApproximate`='{8}', `CodingRegionEndApproximate`='{9}', `Direction`='{10}', `Interrupted`='{11}', `DataSetWID`='{12}' WHERE `WID` = '{13}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, Name, NucleicAcidWID, SubsequenceWID, Type, GenomeID, CodingRegionStart, CodingRegionEnd, CodingRegionStartApproximate, CodingRegionEndApproximate, Direction, Interrupted, DataSetWID, WID)
    End Function
#End Region
End Class


End Namespace
