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
''' DROP TABLE IF EXISTS `complex_2_entityonothercell`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `complex_2_entityonothercell` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `entityOnOtherCell_rank` int(10) unsigned DEFAULT NULL,
'''   `entityOnOtherCell` int(10) unsigned DEFAULT NULL,
'''   `entityOnOtherCell_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `entityOnOtherCell` (`entityOnOtherCell`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("complex_2_entityonothercell", Database:="gk_current", SchemaSQL:="
CREATE TABLE `complex_2_entityonothercell` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `entityOnOtherCell_rank` int(10) unsigned DEFAULT NULL,
  `entityOnOtherCell` int(10) unsigned DEFAULT NULL,
  `entityOnOtherCell_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `entityOnOtherCell` (`entityOnOtherCell`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class complex_2_entityonothercell: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("entityOnOtherCell_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="entityOnOtherCell_rank")> Public Property entityOnOtherCell_rank As Long
    <DatabaseField("entityOnOtherCell"), DataType(MySqlDbType.Int64, "10"), Column(Name:="entityOnOtherCell")> Public Property entityOnOtherCell As Long
    <DatabaseField("entityOnOtherCell_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="entityOnOtherCell_class")> Public Property entityOnOtherCell_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `complex_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `complex_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `complex_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `complex_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `complex_2_entityonothercell` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `complex_2_entityonothercell` SET `DB_ID`='{0}', `entityOnOtherCell_rank`='{1}', `entityOnOtherCell`='{2}', `entityOnOtherCell_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `complex_2_entityonothercell` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `complex_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `complex_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class)
        Else
        Return String.Format(INSERT_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{entityOnOtherCell_rank}', '{entityOnOtherCell}', '{entityOnOtherCell_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `complex_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `complex_2_entityonothercell` (`DB_ID`, `entityOnOtherCell_rank`, `entityOnOtherCell`, `entityOnOtherCell_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `complex_2_entityonothercell` SET `DB_ID`='{0}', `entityOnOtherCell_rank`='{1}', `entityOnOtherCell`='{2}', `entityOnOtherCell_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, entityOnOtherCell_rank, entityOnOtherCell, entityOnOtherCell_class, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As complex_2_entityonothercell
                         Return DirectCast(MyClass.MemberwiseClone, complex_2_entityonothercell)
                     End Function
End Class


End Namespace
