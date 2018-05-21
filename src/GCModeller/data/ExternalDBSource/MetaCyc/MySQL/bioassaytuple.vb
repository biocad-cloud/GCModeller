REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:13


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace MetaCyc.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `bioassaytuple`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `bioassaytuple` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `BioAssay` bigint(20) DEFAULT NULL,
'''   `BioDataTuples_BioAssayTuples` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_BioAssayTuple1` (`DataSetWID`),
'''   KEY `FK_BioAssayTuple2` (`BioAssay`),
'''   KEY `FK_BioAssayTuple3` (`BioDataTuples_BioAssayTuples`),
'''   CONSTRAINT `FK_BioAssayTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayTuple2` FOREIGN KEY (`BioAssay`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayTuple3` FOREIGN KEY (`BioDataTuples_BioAssayTuples`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("bioassaytuple", Database:="warehouse", SchemaSQL:="
CREATE TABLE `bioassaytuple` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `BioAssay` bigint(20) DEFAULT NULL,
  `BioDataTuples_BioAssayTuples` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_BioAssayTuple1` (`DataSetWID`),
  KEY `FK_BioAssayTuple2` (`BioAssay`),
  KEY `FK_BioAssayTuple3` (`BioDataTuples_BioAssayTuples`),
  CONSTRAINT `FK_BioAssayTuple1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayTuple2` FOREIGN KEY (`BioAssay`) REFERENCES `bioassay` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayTuple3` FOREIGN KEY (`BioDataTuples_BioAssayTuples`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class bioassaytuple: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("BioAssay"), DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssay")> Public Property BioAssay As Long
    <DatabaseField("BioDataTuples_BioAssayTuples"), DataType(MySqlDbType.Int64, "20"), Column(Name:="BioDataTuples_BioAssayTuples")> Public Property BioDataTuples_BioAssayTuples As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `bioassaytuple` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `bioassaytuple` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssay`='{2}', `BioDataTuples_BioAssayTuples`='{3}' WHERE `WID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `bioassaytuple` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{BioAssay}', '{BioDataTuples_BioAssayTuples}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `bioassaytuple` (`WID`, `DataSetWID`, `BioAssay`, `BioDataTuples_BioAssayTuples`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `bioassaytuple` SET `WID`='{0}', `DataSetWID`='{1}', `BioAssay`='{2}', `BioDataTuples_BioAssayTuples`='{3}' WHERE `WID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, BioAssay, BioDataTuples_BioAssayTuples, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As bioassaytuple
                         Return DirectCast(MyClass.MemberwiseClone, bioassaytuple)
                     End Function
End Class


End Namespace
