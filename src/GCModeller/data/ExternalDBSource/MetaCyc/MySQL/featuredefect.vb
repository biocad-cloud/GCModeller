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
''' DROP TABLE IF EXISTS `featuredefect`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `featuredefect` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `ArrayManufactureDeviation` bigint(20) DEFAULT NULL,
'''   `FeatureDefect_DefectType` bigint(20) DEFAULT NULL,
'''   `FeatureDefect_PositionDelta` bigint(20) DEFAULT NULL,
'''   `Feature` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_FeatureDefect1` (`DataSetWID`),
'''   KEY `FK_FeatureDefect2` (`ArrayManufactureDeviation`),
'''   KEY `FK_FeatureDefect3` (`FeatureDefect_DefectType`),
'''   KEY `FK_FeatureDefect4` (`FeatureDefect_PositionDelta`),
'''   KEY `FK_FeatureDefect5` (`Feature`),
'''   CONSTRAINT `FK_FeatureDefect1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FeatureDefect2` FOREIGN KEY (`ArrayManufactureDeviation`) REFERENCES `arraymanufacturedeviation` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FeatureDefect3` FOREIGN KEY (`FeatureDefect_DefectType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FeatureDefect4` FOREIGN KEY (`FeatureDefect_PositionDelta`) REFERENCES `positiondelta` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_FeatureDefect5` FOREIGN KEY (`Feature`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("featuredefect", Database:="warehouse", SchemaSQL:="
CREATE TABLE `featuredefect` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `ArrayManufactureDeviation` bigint(20) DEFAULT NULL,
  `FeatureDefect_DefectType` bigint(20) DEFAULT NULL,
  `FeatureDefect_PositionDelta` bigint(20) DEFAULT NULL,
  `Feature` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_FeatureDefect1` (`DataSetWID`),
  KEY `FK_FeatureDefect2` (`ArrayManufactureDeviation`),
  KEY `FK_FeatureDefect3` (`FeatureDefect_DefectType`),
  KEY `FK_FeatureDefect4` (`FeatureDefect_PositionDelta`),
  KEY `FK_FeatureDefect5` (`Feature`),
  CONSTRAINT `FK_FeatureDefect1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FeatureDefect2` FOREIGN KEY (`ArrayManufactureDeviation`) REFERENCES `arraymanufacturedeviation` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FeatureDefect3` FOREIGN KEY (`FeatureDefect_DefectType`) REFERENCES `term` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FeatureDefect4` FOREIGN KEY (`FeatureDefect_PositionDelta`) REFERENCES `positiondelta` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_FeatureDefect5` FOREIGN KEY (`Feature`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class featuredefect: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("ArrayManufactureDeviation"), DataType(MySqlDbType.Int64, "20"), Column(Name:="ArrayManufactureDeviation")> Public Property ArrayManufactureDeviation As Long
    <DatabaseField("FeatureDefect_DefectType"), DataType(MySqlDbType.Int64, "20"), Column(Name:="FeatureDefect_DefectType")> Public Property FeatureDefect_DefectType As Long
    <DatabaseField("FeatureDefect_PositionDelta"), DataType(MySqlDbType.Int64, "20"), Column(Name:="FeatureDefect_PositionDelta")> Public Property FeatureDefect_PositionDelta As Long
    <DatabaseField("Feature"), DataType(MySqlDbType.Int64, "20"), Column(Name:="Feature")> Public Property Feature As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `featuredefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `FeatureDefect_DefectType`, `FeatureDefect_PositionDelta`, `Feature`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `featuredefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `FeatureDefect_DefectType`, `FeatureDefect_PositionDelta`, `Feature`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `featuredefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `FeatureDefect_DefectType`, `FeatureDefect_PositionDelta`, `Feature`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `featuredefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `FeatureDefect_DefectType`, `FeatureDefect_PositionDelta`, `Feature`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `featuredefect` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `featuredefect` SET `WID`='{0}', `DataSetWID`='{1}', `ArrayManufactureDeviation`='{2}', `FeatureDefect_DefectType`='{3}', `FeatureDefect_PositionDelta`='{4}', `Feature`='{5}' WHERE `WID` = '{6}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `featuredefect` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `featuredefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `FeatureDefect_DefectType`, `FeatureDefect_PositionDelta`, `Feature`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, ArrayManufactureDeviation, FeatureDefect_DefectType, FeatureDefect_PositionDelta, Feature)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `featuredefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `FeatureDefect_DefectType`, `FeatureDefect_PositionDelta`, `Feature`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, ArrayManufactureDeviation, FeatureDefect_DefectType, FeatureDefect_PositionDelta, Feature)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, ArrayManufactureDeviation, FeatureDefect_DefectType, FeatureDefect_PositionDelta, Feature)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{ArrayManufactureDeviation}', '{FeatureDefect_DefectType}', '{FeatureDefect_PositionDelta}', '{Feature}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `featuredefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `FeatureDefect_DefectType`, `FeatureDefect_PositionDelta`, `Feature`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, ArrayManufactureDeviation, FeatureDefect_DefectType, FeatureDefect_PositionDelta, Feature)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `featuredefect` (`WID`, `DataSetWID`, `ArrayManufactureDeviation`, `FeatureDefect_DefectType`, `FeatureDefect_PositionDelta`, `Feature`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, ArrayManufactureDeviation, FeatureDefect_DefectType, FeatureDefect_PositionDelta, Feature)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, ArrayManufactureDeviation, FeatureDefect_DefectType, FeatureDefect_PositionDelta, Feature)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `featuredefect` SET `WID`='{0}', `DataSetWID`='{1}', `ArrayManufactureDeviation`='{2}', `FeatureDefect_DefectType`='{3}', `FeatureDefect_PositionDelta`='{4}', `Feature`='{5}' WHERE `WID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, ArrayManufactureDeviation, FeatureDefect_DefectType, FeatureDefect_PositionDelta, Feature, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As featuredefect
                         Return DirectCast(MyClass.MemberwiseClone, featuredefect)
                     End Function
End Class


End Namespace
