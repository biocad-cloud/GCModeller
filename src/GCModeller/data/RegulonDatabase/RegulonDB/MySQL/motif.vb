REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/21 16:53:09


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace RegulonDB.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `motif`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `motif` (
'''   `motif_id` char(12) NOT NULL,
'''   `product_id` char(12) NOT NULL,
'''   `motif_posleft` decimal(10,0) NOT NULL,
'''   `motif_posright` decimal(10,0) NOT NULL,
'''   `motif_sequence` varchar(3000) DEFAULT NULL,
'''   `motif_description` varchar(4000) DEFAULT NULL,
'''   `motif_type` varchar(255) DEFAULT NULL,
'''   `motif_note` varchar(2000) DEFAULT NULL,
'''   `motif_internal_comment` longtext,
'''   `key_id_org` varchar(5) NOT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("motif", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `motif` (
  `motif_id` char(12) NOT NULL,
  `product_id` char(12) NOT NULL,
  `motif_posleft` decimal(10,0) NOT NULL,
  `motif_posright` decimal(10,0) NOT NULL,
  `motif_sequence` varchar(3000) DEFAULT NULL,
  `motif_description` varchar(4000) DEFAULT NULL,
  `motif_type` varchar(255) DEFAULT NULL,
  `motif_note` varchar(2000) DEFAULT NULL,
  `motif_internal_comment` longtext,
  `key_id_org` varchar(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class motif: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("motif_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="motif_id")> Public Property motif_id As String
    <DatabaseField("product_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="product_id")> Public Property product_id As String
    <DatabaseField("motif_posleft"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="motif_posleft")> Public Property motif_posleft As Decimal
    <DatabaseField("motif_posright"), NotNull, DataType(MySqlDbType.Decimal), Column(Name:="motif_posright")> Public Property motif_posright As Decimal
    <DatabaseField("motif_sequence"), DataType(MySqlDbType.VarChar, "3000"), Column(Name:="motif_sequence")> Public Property motif_sequence As String
    <DatabaseField("motif_description"), DataType(MySqlDbType.VarChar, "4000"), Column(Name:="motif_description")> Public Property motif_description As String
    <DatabaseField("motif_type"), DataType(MySqlDbType.VarChar, "255"), Column(Name:="motif_type")> Public Property motif_type As String
    <DatabaseField("motif_note"), DataType(MySqlDbType.VarChar, "2000"), Column(Name:="motif_note")> Public Property motif_note As String
    <DatabaseField("motif_internal_comment"), DataType(MySqlDbType.Text), Column(Name:="motif_internal_comment")> Public Property motif_internal_comment As String
    <DatabaseField("key_id_org"), NotNull, DataType(MySqlDbType.VarChar, "5"), Column(Name:="key_id_org")> Public Property key_id_org As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `motif` (`motif_id`, `product_id`, `motif_posleft`, `motif_posright`, `motif_sequence`, `motif_description`, `motif_type`, `motif_note`, `motif_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `motif` (`motif_id`, `product_id`, `motif_posleft`, `motif_posright`, `motif_sequence`, `motif_description`, `motif_type`, `motif_note`, `motif_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `motif` (`motif_id`, `product_id`, `motif_posleft`, `motif_posright`, `motif_sequence`, `motif_description`, `motif_type`, `motif_note`, `motif_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `motif` (`motif_id`, `product_id`, `motif_posleft`, `motif_posright`, `motif_sequence`, `motif_description`, `motif_type`, `motif_note`, `motif_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `motif` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `motif` SET `motif_id`='{0}', `product_id`='{1}', `motif_posleft`='{2}', `motif_posright`='{3}', `motif_sequence`='{4}', `motif_description`='{5}', `motif_type`='{6}', `motif_note`='{7}', `motif_internal_comment`='{8}', `key_id_org`='{9}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `motif` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `motif` (`motif_id`, `product_id`, `motif_posleft`, `motif_posright`, `motif_sequence`, `motif_description`, `motif_type`, `motif_note`, `motif_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, motif_id, product_id, motif_posleft, motif_posright, motif_sequence, motif_description, motif_type, motif_note, motif_internal_comment, key_id_org)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `motif` (`motif_id`, `product_id`, `motif_posleft`, `motif_posright`, `motif_sequence`, `motif_description`, `motif_type`, `motif_note`, `motif_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, motif_id, product_id, motif_posleft, motif_posright, motif_sequence, motif_description, motif_type, motif_note, motif_internal_comment, key_id_org)
        Else
        Return String.Format(INSERT_SQL, motif_id, product_id, motif_posleft, motif_posright, motif_sequence, motif_description, motif_type, motif_note, motif_internal_comment, key_id_org)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{motif_id}', '{product_id}', '{motif_posleft}', '{motif_posright}', '{motif_sequence}', '{motif_description}', '{motif_type}', '{motif_note}', '{motif_internal_comment}', '{key_id_org}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `motif` (`motif_id`, `product_id`, `motif_posleft`, `motif_posright`, `motif_sequence`, `motif_description`, `motif_type`, `motif_note`, `motif_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, motif_id, product_id, motif_posleft, motif_posright, motif_sequence, motif_description, motif_type, motif_note, motif_internal_comment, key_id_org)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `motif` (`motif_id`, `product_id`, `motif_posleft`, `motif_posright`, `motif_sequence`, `motif_description`, `motif_type`, `motif_note`, `motif_internal_comment`, `key_id_org`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, motif_id, product_id, motif_posleft, motif_posright, motif_sequence, motif_description, motif_type, motif_note, motif_internal_comment, key_id_org)
        Else
        Return String.Format(REPLACE_SQL, motif_id, product_id, motif_posleft, motif_posright, motif_sequence, motif_description, motif_type, motif_note, motif_internal_comment, key_id_org)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `motif` SET `motif_id`='{0}', `product_id`='{1}', `motif_posleft`='{2}', `motif_posright`='{3}', `motif_sequence`='{4}', `motif_description`='{5}', `motif_type`='{6}', `motif_note`='{7}', `motif_internal_comment`='{8}', `key_id_org`='{9}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As motif
                         Return DirectCast(MyClass.MemberwiseClone, motif)
                     End Function
End Class


End Namespace
