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
''' DROP TABLE IF EXISTS `valence`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `valence` (
'''   `OtherWID` bigint(20) NOT NULL,
'''   `Valence` smallint(6) NOT NULL,
'''   KEY `FK_Valence` (`OtherWID`),
'''   CONSTRAINT `FK_Valence` FOREIGN KEY (`OtherWID`) REFERENCES `element` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("valence", Database:="warehouse", SchemaSQL:="
CREATE TABLE `valence` (
  `OtherWID` bigint(20) NOT NULL,
  `Valence` smallint(6) NOT NULL,
  KEY `FK_Valence` (`OtherWID`),
  CONSTRAINT `FK_Valence` FOREIGN KEY (`OtherWID`) REFERENCES `element` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class valence: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("OtherWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="OtherWID"), XmlAttribute> Public Property OtherWID As Long
    <DatabaseField("Valence"), NotNull, DataType(MySqlDbType.Int64, "6"), Column(Name:="Valence")> Public Property Valence As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `valence` (`OtherWID`, `Valence`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `valence` (`OtherWID`, `Valence`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `valence` (`OtherWID`, `Valence`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `valence` (`OtherWID`, `Valence`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `valence` WHERE `OtherWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `valence` SET `OtherWID`='{0}', `Valence`='{1}' WHERE `OtherWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `valence` WHERE `OtherWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, OtherWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `valence` (`OtherWID`, `Valence`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, OtherWID, Valence)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `valence` (`OtherWID`, `Valence`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, OtherWID, Valence)
        Else
        Return String.Format(INSERT_SQL, OtherWID, Valence)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{OtherWID}', '{Valence}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `valence` (`OtherWID`, `Valence`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, OtherWID, Valence)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `valence` (`OtherWID`, `Valence`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, OtherWID, Valence)
        Else
        Return String.Format(REPLACE_SQL, OtherWID, Valence)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `valence` SET `OtherWID`='{0}', `Valence`='{1}' WHERE `OtherWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, OtherWID, Valence, OtherWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As valence
                         Return DirectCast(MyClass.MemberwiseClone, valence)
                     End Function
End Class


End Namespace
