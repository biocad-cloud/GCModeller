﻿#Region "Microsoft.VisualBasic::469cae97e2019f031b077b8b50774fdf, data\Reactome\LocalMySQL\gk_stable_ids\history.vb"

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

    ' Class history
    ' 
    '     Properties: [class], datetime, DB_ID, name, ReactomeRelease
    '                 ST_ID
    ' 
    '     Function: GetDeleteSQL, GetDumpInsertValue, GetInsertSQL, GetReplaceSQL, GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @3/16/2018 10:40:24 PM


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_stable_ids

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `history`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `history` (
'''   `DB_ID` int(12) unsigned NOT NULL AUTO_INCREMENT,
'''   `ST_ID` int(12) unsigned NOT NULL,
'''   `name` int(12) unsigned NOT NULL,
'''   `class` text NOT NULL,
'''   `ReactomeRelease` int(12) unsigned NOT NULL,
'''   `datetime` text NOT NULL,
'''   PRIMARY KEY (`DB_ID`)
''' ) ENGINE=MyISAM AUTO_INCREMENT=2608518 DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("history", Database:="gk_stable_ids", SchemaSQL:="
CREATE TABLE `history` (
  `DB_ID` int(12) unsigned NOT NULL AUTO_INCREMENT,
  `ST_ID` int(12) unsigned NOT NULL,
  `name` int(12) unsigned NOT NULL,
  `class` text NOT NULL,
  `ReactomeRelease` int(12) unsigned NOT NULL,
  `datetime` text NOT NULL,
  PRIMARY KEY (`DB_ID`)
) ENGINE=MyISAM AUTO_INCREMENT=2608518 DEFAULT CHARSET=latin1;")>
Public Class history: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, AutoIncrement, NotNull, DataType(MySqlDbType.Int64, "12"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("ST_ID"), NotNull, DataType(MySqlDbType.Int64, "12"), Column(Name:="ST_ID")> Public Property ST_ID As Long
    <DatabaseField("name"), NotNull, DataType(MySqlDbType.Int64, "12"), Column(Name:="name")> Public Property name As Long
    <DatabaseField("class"), NotNull, DataType(MySqlDbType.Text), Column(Name:="class")> Public Property [class] As String
    <DatabaseField("ReactomeRelease"), NotNull, DataType(MySqlDbType.Int64, "12"), Column(Name:="ReactomeRelease")> Public Property ReactomeRelease As Long
    <DatabaseField("datetime"), NotNull, DataType(MySqlDbType.Text), Column(Name:="datetime")> Public Property datetime As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `history` (`ST_ID`, `name`, `class`, `ReactomeRelease`, `datetime`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `history` (`ST_ID`, `name`, `class`, `ReactomeRelease`, `datetime`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `history` WHERE `DB_ID` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `history` SET `DB_ID`='{0}', `ST_ID`='{1}', `name`='{2}', `class`='{3}', `ReactomeRelease`='{4}', `datetime`='{5}' WHERE `DB_ID` = '{6}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `history` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `history` (`ST_ID`, `name`, `class`, `ReactomeRelease`, `datetime`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, ST_ID, name, [class], ReactomeRelease, datetime)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{ST_ID}', '{name}', '{[class]}', '{ReactomeRelease}', '{datetime}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `history` (`ST_ID`, `name`, `class`, `ReactomeRelease`, `datetime`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, ST_ID, name, [class], ReactomeRelease, datetime)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `history` SET `DB_ID`='{0}', `ST_ID`='{1}', `name`='{2}', `class`='{3}', `ReactomeRelease`='{4}', `datetime`='{5}' WHERE `DB_ID` = '{6}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, ST_ID, name, [class], ReactomeRelease, datetime, DB_ID)
    End Function
#End Region
Public Function Clone() As history
                  Return DirectCast(MyClass.MemberwiseClone, history)
              End Function
End Class


End Namespace
