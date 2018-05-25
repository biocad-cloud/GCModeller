REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:41


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `pathwaycoordinates`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `pathwaycoordinates` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `locatedEvent` int(10) unsigned DEFAULT NULL,
'''   `locatedEvent_class` varchar(64) DEFAULT NULL,
'''   `maxX` int(10) DEFAULT NULL,
'''   `maxY` int(10) DEFAULT NULL,
'''   `minX` int(10) DEFAULT NULL,
'''   `minY` int(10) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `locatedEvent` (`locatedEvent`),
'''   KEY `maxX` (`maxX`),
'''   KEY `maxY` (`maxY`),
'''   KEY `minX` (`minX`),
'''   KEY `minY` (`minY`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("pathwaycoordinates", Database:="gk_current", SchemaSQL:="
CREATE TABLE `pathwaycoordinates` (
  `DB_ID` int(10) unsigned NOT NULL,
  `locatedEvent` int(10) unsigned DEFAULT NULL,
  `locatedEvent_class` varchar(64) DEFAULT NULL,
  `maxX` int(10) DEFAULT NULL,
  `maxY` int(10) DEFAULT NULL,
  `minX` int(10) DEFAULT NULL,
  `minY` int(10) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `locatedEvent` (`locatedEvent`),
  KEY `maxX` (`maxX`),
  KEY `maxY` (`maxY`),
  KEY `minX` (`minX`),
  KEY `minY` (`minY`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class pathwaycoordinates: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("locatedEvent"), DataType(MySqlDbType.Int64, "10"), Column(Name:="locatedEvent")> Public Property locatedEvent As Long
    <DatabaseField("locatedEvent_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="locatedEvent_class")> Public Property locatedEvent_class As String
    <DatabaseField("maxX"), DataType(MySqlDbType.Int64, "10"), Column(Name:="maxX")> Public Property maxX As Long
    <DatabaseField("maxY"), DataType(MySqlDbType.Int64, "10"), Column(Name:="maxY")> Public Property maxY As Long
    <DatabaseField("minX"), DataType(MySqlDbType.Int64, "10"), Column(Name:="minX")> Public Property minX As Long
    <DatabaseField("minY"), DataType(MySqlDbType.Int64, "10"), Column(Name:="minY")> Public Property minY As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `pathwaycoordinates` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `pathwaycoordinates` SET `DB_ID`='{0}', `locatedEvent`='{1}', `locatedEvent_class`='{2}', `maxX`='{3}', `maxY`='{4}', `minX`='{5}', `minY`='{6}' WHERE `DB_ID` = '{7}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `pathwaycoordinates` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY)
        Else
        Return String.Format(INSERT_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{DB_ID}', '{locatedEvent}', '{locatedEvent_class}', '{maxX}', '{maxY}', '{minX}', '{minY}')"
        Else
            Return $"('{DB_ID}', '{locatedEvent}', '{locatedEvent_class}', '{maxX}', '{maxY}', '{minX}', '{minY}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `pathwaycoordinates` (`DB_ID`, `locatedEvent`, `locatedEvent_class`, `maxX`, `maxY`, `minX`, `minY`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `pathwaycoordinates` SET `DB_ID`='{0}', `locatedEvent`='{1}', `locatedEvent_class`='{2}', `maxX`='{3}', `maxY`='{4}', `minX`='{5}', `minY`='{6}' WHERE `DB_ID` = '{7}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, locatedEvent, locatedEvent_class, maxX, maxY, minX, minY, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As pathwaycoordinates
                         Return DirectCast(MyClass.MemberwiseClone, pathwaycoordinates)
                     End Function
End Class


End Namespace
