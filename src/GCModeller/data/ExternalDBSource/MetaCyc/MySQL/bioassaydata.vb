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
''' DROP TABLE IF EXISTS `bioassaydata`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `bioassaydata` (
'''   `WID` bigint(20) NOT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   `MAGEClass` varchar(100) NOT NULL,
'''   `Identifier` varchar(255) DEFAULT NULL,
'''   `Name` varchar(255) DEFAULT NULL,
'''   `BioAssayDimension` bigint(20) DEFAULT NULL,
'''   `DesignElementDimension` bigint(20) DEFAULT NULL,
'''   `QuantitationTypeDimension` bigint(20) DEFAULT NULL,
'''   `BioAssayData_BioDataValues` bigint(20) DEFAULT NULL,
'''   `ProducerTransformation` bigint(20) DEFAULT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_BioAssayData1` (`DataSetWID`),
'''   KEY `FK_BioAssayData3` (`BioAssayDimension`),
'''   KEY `FK_BioAssayData4` (`DesignElementDimension`),
'''   KEY `FK_BioAssayData5` (`QuantitationTypeDimension`),
'''   KEY `FK_BioAssayData6` (`BioAssayData_BioDataValues`),
'''   KEY `FK_BioAssayData7` (`ProducerTransformation`),
'''   CONSTRAINT `FK_BioAssayData1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayData3` FOREIGN KEY (`BioAssayDimension`) REFERENCES `bioassaydimension` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayData4` FOREIGN KEY (`DesignElementDimension`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayData5` FOREIGN KEY (`QuantitationTypeDimension`) REFERENCES `quantitationtypedimension` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayData6` FOREIGN KEY (`BioAssayData_BioDataValues`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioAssayData7` FOREIGN KEY (`ProducerTransformation`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("bioassaydata", Database:="warehouse", SchemaSQL:="
CREATE TABLE `bioassaydata` (
  `WID` bigint(20) NOT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  `MAGEClass` varchar(100) NOT NULL,
  `Identifier` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `BioAssayDimension` bigint(20) DEFAULT NULL,
  `DesignElementDimension` bigint(20) DEFAULT NULL,
  `QuantitationTypeDimension` bigint(20) DEFAULT NULL,
  `BioAssayData_BioDataValues` bigint(20) DEFAULT NULL,
  `ProducerTransformation` bigint(20) DEFAULT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_BioAssayData1` (`DataSetWID`),
  KEY `FK_BioAssayData3` (`BioAssayDimension`),
  KEY `FK_BioAssayData4` (`DesignElementDimension`),
  KEY `FK_BioAssayData5` (`QuantitationTypeDimension`),
  KEY `FK_BioAssayData6` (`BioAssayData_BioDataValues`),
  KEY `FK_BioAssayData7` (`ProducerTransformation`),
  CONSTRAINT `FK_BioAssayData1` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayData3` FOREIGN KEY (`BioAssayDimension`) REFERENCES `bioassaydimension` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayData4` FOREIGN KEY (`DesignElementDimension`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayData5` FOREIGN KEY (`QuantitationTypeDimension`) REFERENCES `quantitationtypedimension` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayData6` FOREIGN KEY (`BioAssayData_BioDataValues`) REFERENCES `biodatavalues` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioAssayData7` FOREIGN KEY (`ProducerTransformation`) REFERENCES `bioevent` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class bioassaydata: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
    <DatabaseField("MAGEClass"), NotNull, DataType(MySqlDbType.VarChar, "100"), Column(Name:="MAGEClass")> Public Property MAGEClass As String
    <DatabaseField("Identifier"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Identifier")> Public Property Identifier As String
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="Name")> Public Property Name As String
    <DatabaseField("BioAssayDimension"), DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssayDimension")> Public Property BioAssayDimension As Long
    <DatabaseField("DesignElementDimension"), DataType(MySqlDbType.Int64, "20"), Column(Name:="DesignElementDimension")> Public Property DesignElementDimension As Long
    <DatabaseField("QuantitationTypeDimension"), DataType(MySqlDbType.Int64, "20"), Column(Name:="QuantitationTypeDimension")> Public Property QuantitationTypeDimension As Long
    <DatabaseField("BioAssayData_BioDataValues"), DataType(MySqlDbType.Int64, "20"), Column(Name:="BioAssayData_BioDataValues")> Public Property BioAssayData_BioDataValues As Long
    <DatabaseField("ProducerTransformation"), DataType(MySqlDbType.Int64, "20"), Column(Name:="ProducerTransformation")> Public Property ProducerTransformation As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `bioassaydata` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `BioAssayDimension`, `DesignElementDimension`, `QuantitationTypeDimension`, `BioAssayData_BioDataValues`, `ProducerTransformation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `bioassaydata` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `BioAssayDimension`, `DesignElementDimension`, `QuantitationTypeDimension`, `BioAssayData_BioDataValues`, `ProducerTransformation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `bioassaydata` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `BioAssayDimension`, `DesignElementDimension`, `QuantitationTypeDimension`, `BioAssayData_BioDataValues`, `ProducerTransformation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `bioassaydata` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `BioAssayDimension`, `DesignElementDimension`, `QuantitationTypeDimension`, `BioAssayData_BioDataValues`, `ProducerTransformation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `bioassaydata` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `bioassaydata` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `BioAssayDimension`='{5}', `DesignElementDimension`='{6}', `QuantitationTypeDimension`='{7}', `BioAssayData_BioDataValues`='{8}', `ProducerTransformation`='{9}' WHERE `WID` = '{10}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `bioassaydata` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `bioassaydata` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `BioAssayDimension`, `DesignElementDimension`, `QuantitationTypeDimension`, `BioAssayData_BioDataValues`, `ProducerTransformation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, BioAssayDimension, DesignElementDimension, QuantitationTypeDimension, BioAssayData_BioDataValues, ProducerTransformation)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `bioassaydata` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `BioAssayDimension`, `DesignElementDimension`, `QuantitationTypeDimension`, `BioAssayData_BioDataValues`, `ProducerTransformation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, BioAssayDimension, DesignElementDimension, QuantitationTypeDimension, BioAssayData_BioDataValues, ProducerTransformation)
        Else
        Return String.Format(INSERT_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, BioAssayDimension, DesignElementDimension, QuantitationTypeDimension, BioAssayData_BioDataValues, ProducerTransformation)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{WID}', '{DataSetWID}', '{MAGEClass}', '{Identifier}', '{Name}', '{BioAssayDimension}', '{DesignElementDimension}', '{QuantitationTypeDimension}', '{BioAssayData_BioDataValues}', '{ProducerTransformation}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `bioassaydata` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `BioAssayDimension`, `DesignElementDimension`, `QuantitationTypeDimension`, `BioAssayData_BioDataValues`, `ProducerTransformation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, BioAssayDimension, DesignElementDimension, QuantitationTypeDimension, BioAssayData_BioDataValues, ProducerTransformation)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `bioassaydata` (`WID`, `DataSetWID`, `MAGEClass`, `Identifier`, `Name`, `BioAssayDimension`, `DesignElementDimension`, `QuantitationTypeDimension`, `BioAssayData_BioDataValues`, `ProducerTransformation`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, BioAssayDimension, DesignElementDimension, QuantitationTypeDimension, BioAssayData_BioDataValues, ProducerTransformation)
        Else
        Return String.Format(REPLACE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, BioAssayDimension, DesignElementDimension, QuantitationTypeDimension, BioAssayData_BioDataValues, ProducerTransformation)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `bioassaydata` SET `WID`='{0}', `DataSetWID`='{1}', `MAGEClass`='{2}', `Identifier`='{3}', `Name`='{4}', `BioAssayDimension`='{5}', `DesignElementDimension`='{6}', `QuantitationTypeDimension`='{7}', `BioAssayData_BioDataValues`='{8}', `ProducerTransformation`='{9}' WHERE `WID` = '{10}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, DataSetWID, MAGEClass, Identifier, Name, BioAssayDimension, DesignElementDimension, QuantitationTypeDimension, BioAssayData_BioDataValues, ProducerTransformation, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As bioassaydata
                         Return DirectCast(MyClass.MemberwiseClone, bioassaydata)
                     End Function
End Class


End Namespace
