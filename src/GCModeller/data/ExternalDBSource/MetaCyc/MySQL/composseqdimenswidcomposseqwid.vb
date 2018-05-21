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
''' DROP TABLE IF EXISTS `composseqdimenswidcomposseqwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `composseqdimenswidcomposseqwid` (
'''   `CompositeSequenceDimensionWID` bigint(20) NOT NULL,
'''   `CompositeSequenceWID` bigint(20) NOT NULL,
'''   KEY `FK_ComposSeqDimensWIDComposS1` (`CompositeSequenceDimensionWID`),
'''   KEY `FK_ComposSeqDimensWIDComposS2` (`CompositeSequenceWID`),
'''   CONSTRAINT `FK_ComposSeqDimensWIDComposS1` FOREIGN KEY (`CompositeSequenceDimensionWID`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_ComposSeqDimensWIDComposS2` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("composseqdimenswidcomposseqwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `composseqdimenswidcomposseqwid` (
  `CompositeSequenceDimensionWID` bigint(20) NOT NULL,
  `CompositeSequenceWID` bigint(20) NOT NULL,
  KEY `FK_ComposSeqDimensWIDComposS1` (`CompositeSequenceDimensionWID`),
  KEY `FK_ComposSeqDimensWIDComposS2` (`CompositeSequenceWID`),
  CONSTRAINT `FK_ComposSeqDimensWIDComposS1` FOREIGN KEY (`CompositeSequenceDimensionWID`) REFERENCES `designelementdimension` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_ComposSeqDimensWIDComposS2` FOREIGN KEY (`CompositeSequenceWID`) REFERENCES `designelement` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class composseqdimenswidcomposseqwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("CompositeSequenceDimensionWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="CompositeSequenceDimensionWID"), XmlAttribute> Public Property CompositeSequenceDimensionWID As Long
    <DatabaseField("CompositeSequenceWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="CompositeSequenceWID")> Public Property CompositeSequenceWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `composseqdimenswidcomposseqwid` WHERE `CompositeSequenceDimensionWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `composseqdimenswidcomposseqwid` SET `CompositeSequenceDimensionWID`='{0}', `CompositeSequenceWID`='{1}' WHERE `CompositeSequenceDimensionWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `composseqdimenswidcomposseqwid` WHERE `CompositeSequenceDimensionWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, CompositeSequenceDimensionWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID)
        Else
        Return String.Format(INSERT_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{CompositeSequenceDimensionWID}', '{CompositeSequenceWID}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `composseqdimenswidcomposseqwid` (`CompositeSequenceDimensionWID`, `CompositeSequenceWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID)
        Else
        Return String.Format(REPLACE_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `composseqdimenswidcomposseqwid` SET `CompositeSequenceDimensionWID`='{0}', `CompositeSequenceWID`='{1}' WHERE `CompositeSequenceDimensionWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, CompositeSequenceDimensionWID, CompositeSequenceWID, CompositeSequenceDimensionWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As composseqdimenswidcomposseqwid
                         Return DirectCast(MyClass.MemberwiseClone, composseqdimenswidcomposseqwid)
                     End Function
End Class


End Namespace
