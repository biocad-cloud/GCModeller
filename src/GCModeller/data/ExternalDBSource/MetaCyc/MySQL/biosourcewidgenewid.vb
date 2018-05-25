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
''' DROP TABLE IF EXISTS `biosourcewidgenewid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `biosourcewidgenewid` (
'''   `BioSourceWID` bigint(20) NOT NULL,
'''   `GeneWID` bigint(20) NOT NULL,
'''   KEY `FK_BioSourceWIDGeneWID1` (`BioSourceWID`),
'''   KEY `FK_BioSourceWIDGeneWID2` (`GeneWID`),
'''   CONSTRAINT `FK_BioSourceWIDGeneWID1` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioSourceWIDGeneWID2` FOREIGN KEY (`GeneWID`) REFERENCES `gene` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("biosourcewidgenewid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `biosourcewidgenewid` (
  `BioSourceWID` bigint(20) NOT NULL,
  `GeneWID` bigint(20) NOT NULL,
  KEY `FK_BioSourceWIDGeneWID1` (`BioSourceWID`),
  KEY `FK_BioSourceWIDGeneWID2` (`GeneWID`),
  CONSTRAINT `FK_BioSourceWIDGeneWID1` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioSourceWIDGeneWID2` FOREIGN KEY (`GeneWID`) REFERENCES `gene` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class biosourcewidgenewid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("BioSourceWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="BioSourceWID"), XmlAttribute> Public Property BioSourceWID As Long
    <DatabaseField("GeneWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="GeneWID")> Public Property GeneWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `biosourcewidgenewid` (`BioSourceWID`, `GeneWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `biosourcewidgenewid` (`BioSourceWID`, `GeneWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `biosourcewidgenewid` (`BioSourceWID`, `GeneWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `biosourcewidgenewid` (`BioSourceWID`, `GeneWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `biosourcewidgenewid` WHERE `BioSourceWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `biosourcewidgenewid` SET `BioSourceWID`='{0}', `GeneWID`='{1}' WHERE `BioSourceWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `biosourcewidgenewid` WHERE `BioSourceWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioSourceWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `biosourcewidgenewid` (`BioSourceWID`, `GeneWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, BioSourceWID, GeneWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `biosourcewidgenewid` (`BioSourceWID`, `GeneWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, BioSourceWID, GeneWID)
        Else
        Return String.Format(INSERT_SQL, BioSourceWID, GeneWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{BioSourceWID}', '{GeneWID}')"
        Else
            Return $"('{BioSourceWID}', '{GeneWID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `biosourcewidgenewid` (`BioSourceWID`, `GeneWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, BioSourceWID, GeneWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `biosourcewidgenewid` (`BioSourceWID`, `GeneWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, BioSourceWID, GeneWID)
        Else
        Return String.Format(REPLACE_SQL, BioSourceWID, GeneWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `biosourcewidgenewid` SET `BioSourceWID`='{0}', `GeneWID`='{1}' WHERE `BioSourceWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, BioSourceWID, GeneWID, BioSourceWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As biosourcewidgenewid
                         Return DirectCast(MyClass.MemberwiseClone, biosourcewidgenewid)
                     End Function
End Class


End Namespace
