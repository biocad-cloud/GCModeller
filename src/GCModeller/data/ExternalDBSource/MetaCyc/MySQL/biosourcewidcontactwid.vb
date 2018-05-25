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
''' DROP TABLE IF EXISTS `biosourcewidcontactwid`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `biosourcewidcontactwid` (
'''   `BioSourceWID` bigint(20) NOT NULL,
'''   `ContactWID` bigint(20) NOT NULL,
'''   KEY `FK_BioSourceWIDContactWID1` (`BioSourceWID`),
'''   KEY `FK_BioSourceWIDContactWID2` (`ContactWID`),
'''   CONSTRAINT `FK_BioSourceWIDContactWID1` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
'''   CONSTRAINT `FK_BioSourceWIDContactWID2` FOREIGN KEY (`ContactWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("biosourcewidcontactwid", Database:="warehouse", SchemaSQL:="
CREATE TABLE `biosourcewidcontactwid` (
  `BioSourceWID` bigint(20) NOT NULL,
  `ContactWID` bigint(20) NOT NULL,
  KEY `FK_BioSourceWIDContactWID1` (`BioSourceWID`),
  KEY `FK_BioSourceWIDContactWID2` (`ContactWID`),
  CONSTRAINT `FK_BioSourceWIDContactWID1` FOREIGN KEY (`BioSourceWID`) REFERENCES `biosource` (`WID`) ON DELETE CASCADE,
  CONSTRAINT `FK_BioSourceWIDContactWID2` FOREIGN KEY (`ContactWID`) REFERENCES `contact` (`WID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class biosourcewidcontactwid: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("BioSourceWID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="BioSourceWID"), XmlAttribute> Public Property BioSourceWID As Long
    <DatabaseField("ContactWID"), NotNull, DataType(MySqlDbType.Int64, "20"), Column(Name:="ContactWID")> Public Property ContactWID As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `biosourcewidcontactwid` (`BioSourceWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `biosourcewidcontactwid` (`BioSourceWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `biosourcewidcontactwid` (`BioSourceWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `biosourcewidcontactwid` (`BioSourceWID`, `ContactWID`) VALUES ('{0}', '{1}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `biosourcewidcontactwid` WHERE `BioSourceWID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `biosourcewidcontactwid` SET `BioSourceWID`='{0}', `ContactWID`='{1}' WHERE `BioSourceWID` = '{2}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `biosourcewidcontactwid` WHERE `BioSourceWID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, BioSourceWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `biosourcewidcontactwid` (`BioSourceWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, BioSourceWID, ContactWID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `biosourcewidcontactwid` (`BioSourceWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, BioSourceWID, ContactWID)
        Else
        Return String.Format(INSERT_SQL, BioSourceWID, ContactWID)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{BioSourceWID}', '{ContactWID}')"
        Else
            Return $"('{BioSourceWID}', '{ContactWID}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `biosourcewidcontactwid` (`BioSourceWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, BioSourceWID, ContactWID)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `biosourcewidcontactwid` (`BioSourceWID`, `ContactWID`) VALUES ('{0}', '{1}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, BioSourceWID, ContactWID)
        Else
        Return String.Format(REPLACE_SQL, BioSourceWID, ContactWID)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `biosourcewidcontactwid` SET `BioSourceWID`='{0}', `ContactWID`='{1}' WHERE `BioSourceWID` = '{2}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, BioSourceWID, ContactWID, BioSourceWID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As biosourcewidcontactwid
                         Return DirectCast(MyClass.MemberwiseClone, biosourcewidcontactwid)
                     End Function
End Class


End Namespace
