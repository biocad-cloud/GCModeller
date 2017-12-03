﻿#Region "Microsoft.VisualBasic::e64d3fc98a63fa3135c4291aaf9f5c0e, ..\GCModeller\data\RegulonDatabase\Regtransbase\MySQL\dict_effectors.vb"

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

REM  Dump @3/29/2017 10:54:58 PM


Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes

Namespace Regtransbase.MySQL

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `dict_effectors`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `dict_effectors` (
'''   `effector_guid` int(11) NOT NULL DEFAULT '0',
'''   `name` text,
'''   `description` mediumtext NOT NULL,
'''   `effector_superclass_guid` int(11) DEFAULT NULL,
'''   PRIMARY KEY (`effector_guid`)
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' 
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("dict_effectors", Database:="dbregulation_update", SchemaSQL:="
CREATE TABLE `dict_effectors` (
  `effector_guid` int(11) NOT NULL DEFAULT '0',
  `name` text,
  `description` mediumtext NOT NULL,
  `effector_superclass_guid` int(11) DEFAULT NULL,
  PRIMARY KEY (`effector_guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;")>
Public Class dict_effectors: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("effector_guid"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "11")> Public Property effector_guid As Long
    <DatabaseField("name"), DataType(MySqlDbType.Text)> Public Property name As String
    <DatabaseField("description"), NotNull, DataType(MySqlDbType.Text)> Public Property description As String
    <DatabaseField("effector_superclass_guid"), DataType(MySqlDbType.Int64, "11")> Public Property effector_superclass_guid As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Private Shared ReadOnly INSERT_SQL As String = <SQL>INSERT INTO `dict_effectors` (`effector_guid`, `name`, `description`, `effector_superclass_guid`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly REPLACE_SQL As String = <SQL>REPLACE INTO `dict_effectors` (`effector_guid`, `name`, `description`, `effector_superclass_guid`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>
    Private Shared ReadOnly DELETE_SQL As String = <SQL>DELETE FROM `dict_effectors` WHERE `effector_guid` = '{0}';</SQL>
    Private Shared ReadOnly UPDATE_SQL As String = <SQL>UPDATE `dict_effectors` SET `effector_guid`='{0}', `name`='{1}', `description`='{2}', `effector_superclass_guid`='{3}' WHERE `effector_guid` = '{4}';</SQL>
#End Region
''' <summary>
''' ```SQL
''' DELETE FROM `dict_effectors` WHERE `effector_guid` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, effector_guid)
    End Function
''' <summary>
''' ```SQL
''' INSERT INTO `dict_effectors` (`effector_guid`, `name`, `description`, `effector_superclass_guid`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, effector_guid, name, description, effector_superclass_guid)
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue() As String
        Return $"('{effector_guid}', '{name}', '{description}', '{effector_superclass_guid}')"
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `dict_effectors` (`effector_guid`, `name`, `description`, `effector_superclass_guid`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, effector_guid, name, description, effector_superclass_guid)
    End Function
''' <summary>
''' ```SQL
''' UPDATE `dict_effectors` SET `effector_guid`='{0}', `name`='{1}', `description`='{2}', `effector_superclass_guid`='{3}' WHERE `effector_guid` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, effector_guid, name, description, effector_superclass_guid, effector_guid)
    End Function
#End Region
End Class


End Namespace

