REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:40


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
''' DROP TABLE IF EXISTS `taxon`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `taxon` (
'''   `WID` bigint(20) NOT NULL,
'''   `ParentWID` bigint(20) DEFAULT NULL,
'''   `Name` varchar(100) DEFAULT NULL,
'''   `Rank` varchar(100) DEFAULT NULL,
'''   `DivisionWID` bigint(20) DEFAULT NULL,
'''   `InheritedDivision` char(1) DEFAULT NULL,
'''   `GencodeWID` bigint(20) DEFAULT NULL,
'''   `InheritedGencode` char(1) DEFAULT NULL,
'''   `MCGencodeWID` bigint(20) DEFAULT NULL,
'''   `InheritedMCGencode` char(1) DEFAULT NULL,
'''   `DataSetWID` bigint(20) NOT NULL,
'''   PRIMARY KEY (`WID`),
'''   KEY `FK_Taxon_Division` (`DivisionWID`),
'''   KEY `FK_Taxon_GeneticCode` (`GencodeWID`),
'''   KEY `FK_Taxon` (`DataSetWID`),
'''   CONSTRAINT `FK_Taxon` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Taxon_Division` FOREIGN KEY (`DivisionWID`) REFERENCES `division` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_Taxon_GeneticCode` FOREIGN KEY (`GencodeWID`) REFERENCES `geneticcode` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("taxon", Database:="warehouse", SchemaSQL:="
CREATE TABLE `taxon` (
  `WID` bigint(20) NOT NULL,
  `ParentWID` bigint(20) DEFAULT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Rank` varchar(100) DEFAULT NULL,
  `DivisionWID` bigint(20) DEFAULT NULL,
  `InheritedDivision` char(1) DEFAULT NULL,
  `GencodeWID` bigint(20) DEFAULT NULL,
  `InheritedGencode` char(1) DEFAULT NULL,
  `MCGencodeWID` bigint(20) DEFAULT NULL,
  `InheritedMCGencode` char(1) DEFAULT NULL,
  `DataSetWID` bigint(20) NOT NULL,
  PRIMARY KEY (`WID`),
  KEY `FK_Taxon_Division` (`DivisionWID`),
  KEY `FK_Taxon_GeneticCode` (`GencodeWID`),
  KEY `FK_Taxon` (`DataSetWID`),
  CONSTRAINT `FK_Taxon` FOREIGN KEY (`DataSetWID`) REFERENCES `dataset` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Taxon_Division` FOREIGN KEY (`DivisionWID`) REFERENCES `division` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_Taxon_GeneticCode` FOREIGN KEY (`GencodeWID`) REFERENCES `geneticcode` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class taxon: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("WID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="WID"), XmlAttribute> Public Property WID As Long
    <DatabaseField("ParentWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="ParentWID")> Public Property ParentWID As Long
    <DatabaseField("Name"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="Name")> Public Property Name As String
    <DatabaseField("Rank"), DataType(MySqlDbType.VarChar, "100"), Column(Name:="Rank")> Public Property Rank As String
    <DatabaseField("DivisionWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="DivisionWID")> Public Property DivisionWID As Long
    <DatabaseField("InheritedDivision"), DataType(MySqlDbType.VarChar, "1"), Column(Name:="InheritedDivision")> Public Property InheritedDivision As String
    <DatabaseField("GencodeWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="GencodeWID")> Public Property GencodeWID As Long
    <DatabaseField("InheritedGencode"), DataType(MySqlDbType.VarChar, "1"), Column(Name:="InheritedGencode")> Public Property InheritedGencode As String
    <DatabaseField("MCGencodeWID"), DataType(MySqlDbType.Int64, "20"), Column(Name:="MCGencodeWID")> Public Property MCGencodeWID As Long
    <DatabaseField("InheritedMCGencode"), DataType(MySqlDbType.VarChar, "1"), Column(Name:="InheritedMCGencode")> Public Property InheritedMCGencode As String
    <DatabaseField("DataSetWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="DataSetWID")> Public Property DataSetWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `taxon` (`WID`, `ParentWID`, `Name`, `Rank`, `DivisionWID`, `InheritedDivision`, `GencodeWID`, `InheritedGencode`, `MCGencodeWID`, `InheritedMCGencode`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `taxon` (`WID`, `ParentWID`, `Name`, `Rank`, `DivisionWID`, `InheritedDivision`, `GencodeWID`, `InheritedGencode`, `MCGencodeWID`, `InheritedMCGencode`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `taxon` (`WID`, `ParentWID`, `Name`, `Rank`, `DivisionWID`, `InheritedDivision`, `GencodeWID`, `InheritedGencode`, `MCGencodeWID`, `InheritedMCGencode`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `taxon` (`WID`, `ParentWID`, `Name`, `Rank`, `DivisionWID`, `InheritedDivision`, `GencodeWID`, `InheritedGencode`, `MCGencodeWID`, `InheritedMCGencode`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `taxon` WHERE `WID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `taxon` SET `WID`='{0}', `ParentWID`='{1}', `Name`='{2}', `Rank`='{3}', `DivisionWID`='{4}', `InheritedDivision`='{5}', `GencodeWID`='{6}', `InheritedGencode`='{7}', `MCGencodeWID`='{8}', `InheritedMCGencode`='{9}', `DataSetWID`='{10}' WHERE `WID` = '{11}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `taxon` WHERE `WID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, WID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `taxon` (`WID`, `ParentWID`, `Name`, `Rank`, `DivisionWID`, `InheritedDivision`, `GencodeWID`, `InheritedGencode`, `MCGencodeWID`, `InheritedMCGencode`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, WID, ParentWID, Name, Rank, DivisionWID, InheritedDivision, GencodeWID, InheritedGencode, MCGencodeWID, InheritedMCGencode, DataSetWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `taxon` (`WID`, `ParentWID`, `Name`, `Rank`, `DivisionWID`, `InheritedDivision`, `GencodeWID`, `InheritedGencode`, `MCGencodeWID`, `InheritedMCGencode`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, WID, ParentWID, Name, Rank, DivisionWID, InheritedDivision, GencodeWID, InheritedGencode, MCGencodeWID, InheritedMCGencode, DataSetWID)
        Else
        Return String.Format(INSERT_SQL, WID, ParentWID, Name, Rank, DivisionWID, InheritedDivision, GencodeWID, InheritedGencode, MCGencodeWID, InheritedMCGencode, DataSetWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{WID}', '{ParentWID}', '{Name}', '{Rank}', '{DivisionWID}', '{InheritedDivision}', '{GencodeWID}', '{InheritedGencode}', '{MCGencodeWID}', '{InheritedMCGencode}', '{DataSetWID}')"
        Else
            Return $"('{WID}', '{ParentWID}', '{Name}', '{Rank}', '{DivisionWID}', '{InheritedDivision}', '{GencodeWID}', '{InheritedGencode}', '{MCGencodeWID}', '{InheritedMCGencode}', '{DataSetWID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `taxon` (`WID`, `ParentWID`, `Name`, `Rank`, `DivisionWID`, `InheritedDivision`, `GencodeWID`, `InheritedGencode`, `MCGencodeWID`, `InheritedMCGencode`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, WID, ParentWID, Name, Rank, DivisionWID, InheritedDivision, GencodeWID, InheritedGencode, MCGencodeWID, InheritedMCGencode, DataSetWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `taxon` (`WID`, `ParentWID`, `Name`, `Rank`, `DivisionWID`, `InheritedDivision`, `GencodeWID`, `InheritedGencode`, `MCGencodeWID`, `InheritedMCGencode`, `DataSetWID`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, WID, ParentWID, Name, Rank, DivisionWID, InheritedDivision, GencodeWID, InheritedGencode, MCGencodeWID, InheritedMCGencode, DataSetWID)
        Else
        Return String.Format(REPLACE_SQL, WID, ParentWID, Name, Rank, DivisionWID, InheritedDivision, GencodeWID, InheritedGencode, MCGencodeWID, InheritedMCGencode, DataSetWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `taxon` SET `WID`='{0}', `ParentWID`='{1}', `Name`='{2}', `Rank`='{3}', `DivisionWID`='{4}', `InheritedDivision`='{5}', `GencodeWID`='{6}', `InheritedGencode`='{7}', `MCGencodeWID`='{8}', `InheritedMCGencode`='{9}', `DataSetWID`='{10}' WHERE `WID` = '{11}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, WID, ParentWID, Name, Rank, DivisionWID, InheritedDivision, GencodeWID, InheritedGencode, MCGencodeWID, InheritedMCGencode, DataSetWID, WID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As taxon
                         Return DirectCast(MyClass.MemberwiseClone, taxon)
                     End Function
End Class


End Namespace
