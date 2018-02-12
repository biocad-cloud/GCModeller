﻿#Region "Microsoft.VisualBasic::2b56c156a6484a0d5a1f4cbd9c34d885, DataMySql\Xfam\Rfam\Tables\family_ncbi.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
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



    ' /********************************************************************************/

    ' Summaries:

    ' Class family_ncbi
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

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
''' DROP TABLE IF EXISTS `family_ncbi`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `family_ncbi` (
'''   `ncbi_id` int(10) unsigned NOT NULL,
'''   `rfam_id` varchar(40) DEFAULT NULL COMMENT 'Is this really needed?',
'''   `rfam_acc` varchar(7) NOT NULL,
'''   KEY `fk_rfam_ncbi_family1_idx` (`rfam_acc`),
'''   KEY `fk_family_ncbi_taxonomy1_idx` (`ncbi_id`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("family_ncbi", Database:="rfam_12_2", SchemaSQL:="
CREATE TABLE `family_ncbi` (
  `ncbi_id` int(10) unsigned NOT NULL,
  `rfam_id` varchar(40) DEFAULT NULL COMMENT 'Is this really needed?',
  `rfam_acc` varchar(7) NOT NULL,
  KEY `fk_rfam_ncbi_family1_idx` (`rfam_acc`),
  KEY `fk_family_ncbi_taxonomy1_idx` (`ncbi_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class family_ncbi: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("ncbi_id"), NotNull, DataType(MySqlDbType.Int64, "10")> Public Property ncbi_id As Long
''' <summary>
''' Is this really needed?
''' </summary>
''' <value></value>
''' <returns></returns>
''' <remarks></remarks>
    <DatabaseField("rfam_id"), DataType(MySqlDbType.VarChar, "40")> Public Property rfam_id As String
    <DatabaseField("rfam_acc"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "7")> Public Property rfam_acc As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `family_ncbi` (`ncbi_id`, `rfam_id`, `rfam_acc`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `family_ncbi` (`ncbi_id`, `rfam_id`, `rfam_acc`) VALUES ('{0}', '{1}', '{2}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `family_ncbi` WHERE `rfam_acc` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `family_ncbi` SET `ncbi_id`='{0}', `rfam_id`='{1}', `rfam_acc`='{2}' WHERE `rfam_acc` = '{3}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `family_ncbi` WHERE `rfam_acc` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, rfam_acc)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `family_ncbi` (`ncbi_id`, `rfam_id`, `rfam_acc`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ncbi_id, rfam_id, rfam_acc)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ncbi_id}', '{rfam_id}', '{rfam_acc}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `family_ncbi` (`ncbi_id`, `rfam_id`, `rfam_acc`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ncbi_id, rfam_id, rfam_acc)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `family_ncbi` SET `ncbi_id`='{0}', `rfam_id`='{1}', `rfam_acc`='{2}' WHERE `rfam_acc` = '{3}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, ncbi_id, rfam_id, rfam_acc, rfam_acc)
    End Function
#End Region
End Class


End Namespace
