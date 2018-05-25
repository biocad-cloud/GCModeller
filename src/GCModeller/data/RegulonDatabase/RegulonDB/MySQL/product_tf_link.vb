REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:36


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
''' DROP TABLE IF EXISTS `product_tf_link`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `product_tf_link` (
'''   `transcription_factor_id` char(12) NOT NULL,
'''   `product_id` char(12) NOT NULL,
'''   `compon_coefficient` decimal(10,0) DEFAULT NULL
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("product_tf_link", Database:="regulondb_93", SchemaSQL:="
CREATE TABLE `product_tf_link` (
  `transcription_factor_id` char(12) NOT NULL,
  `product_id` char(12) NOT NULL,
  `compon_coefficient` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;")>
Public Class product_tf_link: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("transcription_factor_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="transcription_factor_id")> Public Property transcription_factor_id As String
    <DatabaseField("product_id"), NotNull, DataType(MySqlDbType.VarChar, "12"), Column(Name:="product_id")> Public Property product_id As String
    <DatabaseField("compon_coefficient"), DataType(MySqlDbType.Decimal), Column(Name:="compon_coefficient")> Public Property compon_coefficient As Decimal
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `product_tf_link` (`transcription_factor_id`, `product_id`, `compon_coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `product_tf_link` (`transcription_factor_id`, `product_id`, `compon_coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `product_tf_link` (`transcription_factor_id`, `product_id`, `compon_coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `product_tf_link` (`transcription_factor_id`, `product_id`, `compon_coefficient`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `product_tf_link` WHERE ;</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `product_tf_link` SET `transcription_factor_id`='{0}', `product_id`='{1}', `compon_coefficient`='{2}' WHERE ;</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `product_tf_link` WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___DELETE_SQL_Invoke automatically, please edit this Function manually!")
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `product_tf_link` (`transcription_factor_id`, `product_id`, `compon_coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, transcription_factor_id, product_id, compon_coefficient)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `product_tf_link` (`transcription_factor_id`, `product_id`, `compon_coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, transcription_factor_id, product_id, compon_coefficient)
        Else
        Return String.Format(INSERT_SQL, transcription_factor_id, product_id, compon_coefficient)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{transcription_factor_id}', '{product_id}', '{compon_coefficient}')"
        Else
            Return $"('{transcription_factor_id}', '{product_id}', '{compon_coefficient}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `product_tf_link` (`transcription_factor_id`, `product_id`, `compon_coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, transcription_factor_id, product_id, compon_coefficient)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `product_tf_link` (`transcription_factor_id`, `product_id`, `compon_coefficient`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, transcription_factor_id, product_id, compon_coefficient)
        Else
        Return String.Format(REPLACE_SQL, transcription_factor_id, product_id, compon_coefficient)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `product_tf_link` SET `transcription_factor_id`='{0}', `product_id`='{1}', `compon_coefficient`='{2}' WHERE ;
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Throw New NotImplementedException("Table key was Not found, unable To generate ___UPDATE_SQL_Invoke automatically, please edit this Function manually!")
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As product_tf_link
                         Return DirectCast(MyClass.MemberwiseClone, product_tf_link)
                     End Function
End Class


End Namespace
