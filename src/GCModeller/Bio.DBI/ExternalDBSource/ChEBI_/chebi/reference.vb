REM  Oracle.LinuxCompatibility.MySQL.CodeGenerator
REM  Microsoft VisualBasic MYSQL




Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace ChEBI.Tables

''' <summary>
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `reference`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `reference` (
'''   `id` int(11) NOT NULL,
'''   `compound_id` int(11) NOT NULL,
'''   `reference_id` varchar(60) NOT NULL,
'''   `reference_db_name` varchar(60) NOT NULL,
'''   `location_in_ref` varchar(90) DEFAULT NULL,
'''   `reference_name` varchar(512) DEFAULT NULL,
'''   PRIMARY KEY (`id`),
'''   KEY `compound_id` (`compound_id`),
'''   CONSTRAINT `FK_REFERENCE_TO_COMPOUND` FOREIGN KEY (`compound_id`) REFERENCES `compounds` (`id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("reference")>
Public Class reference: Inherits Oracle.LinuxCompatibility.MySQL.SQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property id As Long
    <DatabaseField("compound_id"), NotNull, DataType(MySqlDbType.Int64, "11")> Public Property compound_id As Long
    <DatabaseField("reference_id"), NotNull, DataType(MySqlDbType.VarChar, "60")> Public Property reference_id As String
    <DatabaseField("reference_db_name"), NotNull, DataType(MySqlDbType.VarChar, "60")> Public Property reference_db_name As String
    <DatabaseField("location_in_ref"), DataType(MySqlDbType.VarChar, "90")> Public Property location_in_ref As String
    <DatabaseField("reference_name"), DataType(MySqlDbType.VarChar, "512")> Public Property reference_name As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `reference` (`id`, `compound_id`, `reference_id`, `reference_db_name`, `location_in_ref`, `reference_name`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `reference` WHERE `id`='{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `reference` SET `id`='{0}', `compound_id`='{1}', `reference_id`='{2}', `reference_db_name`='{3}', `location_in_ref`='{4}', `reference_name`='{5}' WHERE `id`='{6}';</SQL>
#End Region
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, id)
    End Function
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, id, compound_id, reference_id, reference_db_name, location_in_ref, reference_name)
    End Function
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, id, compound_id, reference_id, reference_db_name, location_in_ref, reference_name, id)
    End Function
#End Region
End Class


End Namespace
