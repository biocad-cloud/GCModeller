﻿#Region "Microsoft.VisualBasic::63aeab8309b426d49d2f09cc7ad18a02, ..\repository\DataMySql\Xfam\Rfam\Tables\db_version.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 1.0.0.0

REM  Dump @3/29/2017 11:55:32 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Xfam.Rfam.MySQL.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `db_version`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `db_version` (
'''   `rfam_release` double(4,1) NOT NULL,
'''   `rfam_release_date` datetime NOT NULL,
'''   `number_families` int(10) NOT NULL,
'''   `embl_release` tinytext NOT NULL,
'''   `genome_collection_date` datetime DEFAULT NULL,
'''   `refseq_version` int(11) DEFAULT NULL,
'''   `pdb_date` datetime DEFAULT NULL,
'''   `infernal_version` varchar(45) DEFAULT NULL,
'''   PRIMARY KEY (`rfam_release`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("db_version", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `db_version` (
  `rfam_release` double(4,1) NOT NULL,
  `rfam_release_date` datetime NOT NULL,
  `number_families` int(10) NOT NULL,
  `embl_release` tinytext NOT NULL,
  `genome_collection_date` datetime DEFAULT NULL,
  `refseq_version` int(11) DEFAULT NULL,
  `pdb_date` datetime DEFAULT NULL,
  `infernal_version` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`rfam_release`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class db_version: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("rfam_release"), PrimaryKey, NotNull, DataType(MySqlDbType.Double)> Public Property rfam_release As Double
    <DatabaseField("rfam_release_date"), NotNull, DataType(MySqlDbType.DateTime)> Public Property rfam_release_date As Date
    <DatabaseField("number_families"), NotNull, DataType(MySqlDbType.Int64, "10")> Public Property number_families As Long
    <DatabaseField("embl_release"), NotNull, DataType(MySqlDbType.Text)> Public Property embl_release As String
    <DatabaseField("genome_collection_date"), DataType(MySqlDbType.DateTime)> Public Property genome_collection_date As Date
    <DatabaseField("refseq_version"), DataType(MySqlDbType.Int64, "11")> Public Property refseq_version As Long
    <DatabaseField("pdb_date"), DataType(MySqlDbType.DateTime)> Public Property pdb_date As Date
    <DatabaseField("infernal_version"), DataType(MySqlDbType.VarChar, "45")> Public Property infernal_version As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `db_version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`, `genome_collection_date`, `refseq_version`, `pdb_date`, `infernal_version`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `db_version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`, `genome_collection_date`, `refseq_version`, `pdb_date`, `infernal_version`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `db_version` WHERE `rfam_release` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `db_version` SET `rfam_release`='{0}', `rfam_release_date`='{1}', `number_families`='{2}', `embl_release`='{3}', `genome_collection_date`='{4}', `refseq_version`='{5}', `pdb_date`='{6}', `infernal_version`='{7}' WHERE `rfam_release` = '{8}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `db_version` WHERE `rfam_release` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, rfam_release)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `db_version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`, `genome_collection_date`, `refseq_version`, `pdb_date`, `infernal_version`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, rfam_release, DataType.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release, DataType.ToMySqlDateTimeString(genome_collection_date), refseq_version, DataType.ToMySqlDateTimeString(pdb_date), infernal_version)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{rfam_release}', '{rfam_release_date}', '{number_families}', '{embl_release}', '{genome_collection_date}', '{refseq_version}', '{pdb_date}', '{infernal_version}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `db_version` (`rfam_release`, `rfam_release_date`, `number_families`, `embl_release`, `genome_collection_date`, `refseq_version`, `pdb_date`, `infernal_version`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, rfam_release, DataType.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release, DataType.ToMySqlDateTimeString(genome_collection_date), refseq_version, DataType.ToMySqlDateTimeString(pdb_date), infernal_version)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `db_version` SET `rfam_release`='{0}', `rfam_release_date`='{1}', `number_families`='{2}', `embl_release`='{3}', `genome_collection_date`='{4}', `refseq_version`='{5}', `pdb_date`='{6}', `infernal_version`='{7}' WHERE `rfam_release` = '{8}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, rfam_release, DataType.ToMySqlDateTimeString(rfam_release_date), number_families, embl_release, DataType.ToMySqlDateTimeString(genome_collection_date), refseq_version, DataType.ToMySqlDateTimeString(pdb_date), infernal_version, rfam_release)
    End Function
#End Region
End Class


End Namespace

