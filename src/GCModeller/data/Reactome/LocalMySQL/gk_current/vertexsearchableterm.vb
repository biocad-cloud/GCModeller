REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:14


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
''' DROP TABLE IF EXISTS `vertexsearchableterm`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `vertexsearchableterm` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `providerCount` int(10) DEFAULT NULL,
'''   `searchableTerm` varchar(255) DEFAULT NULL,
'''   `species` int(10) unsigned DEFAULT NULL,
'''   `species_class` varchar(64) DEFAULT NULL,
'''   `vertexCount` int(10) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `providerCount` (`providerCount`),
'''   KEY `searchableTerm` (`searchableTerm`),
'''   KEY `species` (`species`),
'''   KEY `vertexCount` (`vertexCount`),
'''   FULLTEXT KEY `searchableTerm_fulltext` (`searchableTerm`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("vertexsearchableterm", Database:="gk_current", SchemaSQL:="
CREATE TABLE `vertexsearchableterm` (
  `DB_ID` int(10) unsigned NOT NULL,
  `providerCount` int(10) DEFAULT NULL,
  `searchableTerm` varchar(255) DEFAULT NULL,
  `species` int(10) unsigned DEFAULT NULL,
  `species_class` varchar(64) DEFAULT NULL,
  `vertexCount` int(10) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `providerCount` (`providerCount`),
  KEY `searchableTerm` (`searchableTerm`),
  KEY `species` (`species`),
  KEY `vertexCount` (`vertexCount`),
  FULLTEXT KEY `searchableTerm_fulltext` (`searchableTerm`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class vertexsearchableterm: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("providerCount"), DataType(MySqlDbType.Int64, "10"), Column(Name:="providerCount")> Public Property providerCount As Long
    <DatabaseField("searchableTerm"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="searchableTerm")> Public Property searchableTerm As String
    <DatabaseField("species"), DataType(MySqlDbType.Int64, "10"), Column(Name:="species")> Public Property species As Long
    <DatabaseField("species_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="species_class")> Public Property species_class As String
    <DatabaseField("vertexCount"), DataType(MySqlDbType.Int64, "10"), Column(Name:="vertexCount")> Public Property vertexCount As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `vertexsearchableterm` (`DB_ID`, `providerCount`, `searchableTerm`, `species`, `species_class`, `vertexCount`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `vertexsearchableterm` (`DB_ID`, `providerCount`, `searchableTerm`, `species`, `species_class`, `vertexCount`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `vertexsearchableterm` (`DB_ID`, `providerCount`, `searchableTerm`, `species`, `species_class`, `vertexCount`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `vertexsearchableterm` (`DB_ID`, `providerCount`, `searchableTerm`, `species`, `species_class`, `vertexCount`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `vertexsearchableterm` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `vertexsearchableterm` SET `DB_ID`='{0}', `providerCount`='{1}', `searchableTerm`='{2}', `species`='{3}', `species_class`='{4}', `vertexCount`='{5}' WHERE `DB_ID` = '{6}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `vertexsearchableterm` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `vertexsearchableterm` (`DB_ID`, `providerCount`, `searchableTerm`, `species`, `species_class`, `vertexCount`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, providerCount, searchableTerm, species, species_class, vertexCount)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `vertexsearchableterm` (`DB_ID`, `providerCount`, `searchableTerm`, `species`, `species_class`, `vertexCount`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, providerCount, searchableTerm, species, species_class, vertexCount)
        Else
        Return String.Format(INSERT_SQL, DB_ID, providerCount, searchableTerm, species, species_class, vertexCount)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{providerCount}', '{searchableTerm}', '{species}', '{species_class}', '{vertexCount}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `vertexsearchableterm` (`DB_ID`, `providerCount`, `searchableTerm`, `species`, `species_class`, `vertexCount`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, providerCount, searchableTerm, species, species_class, vertexCount)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `vertexsearchableterm` (`DB_ID`, `providerCount`, `searchableTerm`, `species`, `species_class`, `vertexCount`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, providerCount, searchableTerm, species, species_class, vertexCount)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, providerCount, searchableTerm, species, species_class, vertexCount)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `vertexsearchableterm` SET `DB_ID`='{0}', `providerCount`='{1}', `searchableTerm`='{2}', `species`='{3}', `species_class`='{4}', `vertexCount`='{5}' WHERE `DB_ID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, providerCount, searchableTerm, species, species_class, vertexCount, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As vertexsearchableterm
                         Return DirectCast(MyClass.MemberwiseClone, vertexsearchableterm)
                     End Function
End Class


End Namespace
