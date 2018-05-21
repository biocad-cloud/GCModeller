REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:10


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `entry2comp`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `entry2comp` (
'''   `entry1_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `entry2_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `relation` char(2) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   PRIMARY KEY (`entry1_ac`,`entry2_ac`),
'''   KEY `fk_entry2comp$relation` (`relation`),
'''   KEY `fk_entry2comp$2` (`entry2_ac`),
'''   CONSTRAINT `fk_entry2comp$relation` FOREIGN KEY (`relation`) REFERENCES `cv_relation` (`code`) ON DELETE CASCADE ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_entry2comp$1` FOREIGN KEY (`entry1_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_entry2comp$2` FOREIGN KEY (`entry2_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("entry2comp", Database:="interpro", SchemaSQL:="
CREATE TABLE `entry2comp` (
  `entry1_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `entry2_ac` varchar(9) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `relation` char(2) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  PRIMARY KEY (`entry1_ac`,`entry2_ac`),
  KEY `fk_entry2comp$relation` (`relation`),
  KEY `fk_entry2comp$2` (`entry2_ac`),
  CONSTRAINT `fk_entry2comp$relation` FOREIGN KEY (`relation`) REFERENCES `cv_relation` (`code`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_entry2comp$1` FOREIGN KEY (`entry1_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION,
  CONSTRAINT `fk_entry2comp$2` FOREIGN KEY (`entry2_ac`) REFERENCES `entry` (`entry_ac`) ON DELETE CASCADE ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class entry2comp: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("entry1_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9"), Column(Name:="entry1_ac"), XmlAttribute> Public Property entry1_ac As String
    <DatabaseField("entry2_ac"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "9"), Column(Name:="entry2_ac"), XmlAttribute> Public Property entry2_ac As String
    <DatabaseField("relation"), NotNull, DataType(MySqlDbType.VarChar, "2"), Column(Name:="relation")> Public Property relation As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `entry2comp` (`entry1_ac`, `entry2_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `entry2comp` (`entry1_ac`, `entry2_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `entry2comp` (`entry1_ac`, `entry2_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `entry2comp` (`entry1_ac`, `entry2_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `entry2comp` WHERE `entry1_ac`='{0}' and `entry2_ac`='{1}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `entry2comp` SET `entry1_ac`='{0}', `entry2_ac`='{1}', `relation`='{2}' WHERE `entry1_ac`='{3}' and `entry2_ac`='{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `entry2comp` WHERE `entry1_ac`='{0}' and `entry2_ac`='{1}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, entry1_ac, entry2_ac)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `entry2comp` (`entry1_ac`, `entry2_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, entry1_ac, entry2_ac, relation)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `entry2comp` (`entry1_ac`, `entry2_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, entry1_ac, entry2_ac, relation)
        Else
        Return String.Format(INSERT_SQL, entry1_ac, entry2_ac, relation)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{entry1_ac}', '{entry2_ac}', '{relation}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `entry2comp` (`entry1_ac`, `entry2_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, entry1_ac, entry2_ac, relation)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `entry2comp` (`entry1_ac`, `entry2_ac`, `relation`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, entry1_ac, entry2_ac, relation)
        Else
        Return String.Format(REPLACE_SQL, entry1_ac, entry2_ac, relation)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `entry2comp` SET `entry1_ac`='{0}', `entry2_ac`='{1}', `relation`='{2}' WHERE `entry1_ac`='{3}' and `entry2_ac`='{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, entry1_ac, entry2_ac, relation, entry1_ac, entry2_ac)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As entry2comp
                         Return DirectCast(MyClass.MemberwiseClone, entry2comp)
                     End Function
End Class


End Namespace
