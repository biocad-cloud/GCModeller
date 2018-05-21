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
''' DROP TABLE IF EXISTS `measurement`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `measurement` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `Type_` varchar(25) DEFAULT NULL,
'''   `Value` varchar(255) DEFAULT NULL,
'''   `KindCV` varchar(25) DEFAULT NULL,
'''   `OtherKind` varchar(255) DEFAULT NULL,
'''   `Measurement_Unit` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Measurement1` (`DataSetWID`),
'''   KEY `FK_Measurement2` (`Measurement_Unit`),
'''   CONSTRAINT `FK_Measurement1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Measurement2` FOREIGN KEY (`Measurement_Unit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("measurement", Database:="warehouse", SchemaSQL:="
CREATE TABLE `measurement` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `Type_` varchar(25) DEFAULT NULL,
  `Value` varchar(255) DEFAULT NULL,
  `KindCV` varchar(25) DEFAULT NULL,
  `OtherKind` varchar(255) DEFAULT NULL,
  `Measurement_Unit` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Measurement1` (`DataSetWID`),
  KEY `FK_Measurement2` (`Measurement_Unit`),
  CONSTRAINT `FK_Measurement1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Measurement2` FOREIGN KEY (`Measurement_Unit`) REFERENCES `unit` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class measurement: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("Type_"), DataType(MySqlDbType.VarChar, "25"), Column(Name:="Type_")> Public Property Type_ As String
    <DatabaseField("Value"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Value")> Public Property Value As String
    <DatabaseField("KindCV"), DataType(MySqlDbType.VarChar, "25"), Column(Name:="KindCV")> Public Property KindCV As String
    <DatabaseField("OtherKind"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="OtherKind")> Public Property OtherKind As String
    <DatabaseField("Measurement_Unit"), DataType(MySqlDbType.Int64, "20"), Column(Name:="Measurement_Unit")> Public Property Measurement_Unit As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `measurement` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `measurement` SET `WID`='{0}', `DataSetWID`='{1}', `Type_`='{2}', `Value`='{3}', `KindCV`='{4}', `OtherKind`='{5}', `Measurement_Unit`='{6}' WHERE `WID` = '{7}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `measurement` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{Type_}', '{Value}', '{KindCV}', '{OtherKind}', '{Measurement_Unit}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `measurement` (`WID`, `DataSetWID`, `Type_`, `Value`, `KindCV`, `OtherKind`, `Measurement_Unit`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `measurement` SET `WID`='{0}', `DataSetWID`='{1}', `Type_`='{2}', `Value`='{3}', `KindCV`='{4}', `OtherKind`='{5}', `Measurement_Unit`='{6}' WHERE `WID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, Type_, Value, KindCV, OtherKind, Measurement_Unit, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As measurement
                         Return DirectCast(MyClass.MemberwiseClone, measurement)
                     End Function
End Class


End Namespace
