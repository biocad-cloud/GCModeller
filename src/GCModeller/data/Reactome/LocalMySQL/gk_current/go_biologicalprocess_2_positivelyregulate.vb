﻿#Region "Microsoft.VisualBasic::b7f1b6730ae69aa7db67167d231d3e20, ..\GCModeller\data\Reactome\LocalMySQL\gk_current\go_biologicalprocess_2_positivelyregulate.vb"

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

REM  Dump @3/29/2017 9:40:27 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `go_biologicalprocess_2_positivelyregulate`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `go_biologicalprocess_2_positivelyregulate` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `positivelyRegulate_rank` int(10) unsigned DEFAULT NULL,
'''   `positivelyRegulate` int(10) unsigned DEFAULT NULL,
'''   `positivelyRegulate_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `positivelyRegulate` (`positivelyRegulate`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("go_biologicalprocess_2_positivelyregulate", Database:="gk_current", SchemaSQL:="
CREATE TABLE `go_biologicalprocess_2_positivelyregulate` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `positivelyRegulate_rank` int(10) unsigned DEFAULT NULL,
  `positivelyRegulate` int(10) unsigned DEFAULT NULL,
  `positivelyRegulate_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `positivelyRegulate` (`positivelyRegulate`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class go_biologicalprocess_2_positivelyregulate: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("positivelyRegulate_rank"), DataType(MySqlDbType.Int64, "10")> Public Property positivelyRegulate_rank As Long
    <DatabaseField("positivelyRegulate"), DataType(MySqlDbType.Int64, "10")> Public Property positivelyRegulate As Long
    <DatabaseField("positivelyRegulate_class"), DataType(MySqlDbType.VarChar, "64")> Public Property positivelyRegulate_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `go_biologicalprocess_2_positivelyregulate` (`DB_ID`, `positivelyRegulate_rank`, `positivelyRegulate`, `positivelyRegulate_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `go_biologicalprocess_2_positivelyregulate` (`DB_ID`, `positivelyRegulate_rank`, `positivelyRegulate`, `positivelyRegulate_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `go_biologicalprocess_2_positivelyregulate` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `go_biologicalprocess_2_positivelyregulate` SET `DB_ID`='{0}', `positivelyRegulate_rank`='{1}', `positivelyRegulate`='{2}', `positivelyRegulate_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `go_biologicalprocess_2_positivelyregulate` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `go_biologicalprocess_2_positivelyregulate` (`DB_ID`, `positivelyRegulate_rank`, `positivelyRegulate`, `positivelyRegulate_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, positivelyRegulate_rank, positivelyRegulate, positivelyRegulate_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{positivelyRegulate_rank}', '{positivelyRegulate}', '{positivelyRegulate_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `go_biologicalprocess_2_positivelyregulate` (`DB_ID`, `positivelyRegulate_rank`, `positivelyRegulate`, `positivelyRegulate_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, positivelyRegulate_rank, positivelyRegulate, positivelyRegulate_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `go_biologicalprocess_2_positivelyregulate` SET `DB_ID`='{0}', `positivelyRegulate_rank`='{1}', `positivelyRegulate`='{2}', `positivelyRegulate_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, positivelyRegulate_rank, positivelyRegulate, positivelyRegulate_class, DB_ID)
    End Function
#End Region
End Class


End Namespace

