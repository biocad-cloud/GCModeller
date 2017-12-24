﻿#Region "Microsoft.VisualBasic::4614723c618b9b7c4186cf1e8af1183c, ..\GCModeller\data\Reactome\LocalMySQL\gk_current\regulation_2_reviewed.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
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

REM  Dump @3/29/2017 9:40:28 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `regulation_2_reviewed`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `regulation_2_reviewed` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `reviewed_rank` int(10) unsigned DEFAULT NULL,
'''   `reviewed` int(10) unsigned DEFAULT NULL,
'''   `reviewed_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `reviewed` (`reviewed`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("regulation_2_reviewed", Database:="gk_current", SchemaSQL:="
CREATE TABLE `regulation_2_reviewed` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `reviewed_rank` int(10) unsigned DEFAULT NULL,
  `reviewed` int(10) unsigned DEFAULT NULL,
  `reviewed_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `reviewed` (`reviewed`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class regulation_2_reviewed: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10")> Public Property DB_ID As Long
    <DatabaseField("reviewed_rank"), DataType(MySqlDbType.Int64, "10")> Public Property reviewed_rank As Long
    <DatabaseField("reviewed"), DataType(MySqlDbType.Int64, "10")> Public Property reviewed As Long
    <DatabaseField("reviewed_class"), DataType(MySqlDbType.VarChar, "64")> Public Property reviewed_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `regulation_2_reviewed` (`DB_ID`, `reviewed_rank`, `reviewed`, `reviewed_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `regulation_2_reviewed` (`DB_ID`, `reviewed_rank`, `reviewed`, `reviewed_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `regulation_2_reviewed` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `regulation_2_reviewed` SET `DB_ID`='{0}', `reviewed_rank`='{1}', `reviewed`='{2}', `reviewed_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `regulation_2_reviewed` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `regulation_2_reviewed` (`DB_ID`, `reviewed_rank`, `reviewed`, `reviewed_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, reviewed_rank, reviewed, reviewed_class)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{DB_ID}', '{reviewed_rank}', '{reviewed}', '{reviewed_class}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `regulation_2_reviewed` (`DB_ID`, `reviewed_rank`, `reviewed`, `reviewed_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, reviewed_rank, reviewed, reviewed_class)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `regulation_2_reviewed` SET `DB_ID`='{0}', `reviewed_rank`='{1}', `reviewed`='{2}', `reviewed_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, reviewed_rank, reviewed, reviewed_class, DB_ID)
    End Function
#End Region
End Class


End Namespace
