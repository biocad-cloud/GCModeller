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
''' DROP TABLE IF EXISTS `experimentrelationship`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `experimentrelationship` (
'''   `ExperimentWID` bigint(20) NOT NULL,
'''   `RelatedExperimentWID` bigint(20) NOT NULL,
'''   KEY `FK_ExpRelationship1` (`ExperimentWID`),
'''   KEY `FK_ExpRelationship2` (`RelatedExperimentWID`),
'''   CONSTRAINT `FK_ExpRelationship1` FOREIGN KEY (`ExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ExpRelationship2` FOREIGN KEY (`RelatedExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("experimentrelationship", Database:="warehouse", SchemaSQL:="
CREATE TABLE `experimentrelationship` (
  `ExperimentWID` bigint(20) NOT NULL,
  `RelatedExperimentWID` bigint(20) NOT NULL,
  KEY `FK_ExpRelationship1` (`ExperimentWID`),
  KEY `FK_ExpRelationship2` (`RelatedExperimentWID`),
  CONSTRAINT `FK_ExpRelationship1` FOREIGN KEY (`ExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ExpRelationship2` FOREIGN KEY (`RelatedExperimentWID`) REFERENCES `experiment` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class experimentrelationship: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ExperimentWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ExperimentWID"), XmlAttribute> Public Property ExperimentWID As Long
    <DatabaseField("RelatedExperimentWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="RelatedExperimentWID")> Public Property RelatedExperimentWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `experimentrelationship` WHERE `ExperimentWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `experimentrelationship` SET `ExperimentWID`='{0}', `RelatedExperimentWID`='{1}' WHERE `ExperimentWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `experimentrelationship` WHERE `ExperimentWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, ExperimentWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ExperimentWID, RelatedExperimentWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, ExperimentWID, RelatedExperimentWID)
        Else
        Return String.Format(INSERT_SQL, ExperimentWID, RelatedExperimentWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ExperimentWID}', '{RelatedExperimentWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ExperimentWID, RelatedExperimentWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `experimentrelationship` (`ExperimentWID`, `RelatedExperimentWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, ExperimentWID, RelatedExperimentWID)
        Else
        Return String.Format(REPLACE_SQL, ExperimentWID, RelatedExperimentWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `experimentrelationship` SET `ExperimentWID`='{0}', `RelatedExperimentWID`='{1}' WHERE `ExperimentWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ExperimentWID, RelatedExperimentWID, ExperimentWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As experimentrelationship
                         Return DirectCast(MyClass.MemberwiseClone, experimentrelationship)
                     End Function
End Class


End Namespace
