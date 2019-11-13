﻿#Region "Microsoft.VisualBasic::d61fd9e010b171a3f2c550e7529219cb, data\Reactome\LocalMySQL\gk_current\physicalentity_2_literaturereference.vb"

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

    ' Class physicalentity_2_literaturereference
    ' 
    '     Properties: DB_ID, literatureReference, literatureReference_class, literatureReference_rank
    ' 
    '     Function: Clone, GetDeleteSQL, GetDumpInsertValue, (+2 Overloads) GetInsertSQL, (+2 Overloads) GetReplaceSQL
    '               GetUpdateSQL
    ' 
    ' 
    ' /********************************************************************************/

#End Region

REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:41


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace LocalMySQL.Tables.gk_current

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `physicalentity_2_literaturereference`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `physicalentity_2_literaturereference` (
'''   `DB_ID` int(10) unsigned DEFAULT NULL,
'''   `literatureReference_rank` int(10) unsigned DEFAULT NULL,
'''   `literatureReference` int(10) unsigned DEFAULT NULL,
'''   `literatureReference_class` varchar(64) DEFAULT NULL,
'''   KEY `DB_ID` (`DB_ID`),
'''   KEY `literatureReference` (`literatureReference`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("physicalentity_2_literaturereference", Database:="gk_current", SchemaSQL:="
CREATE TABLE `physicalentity_2_literaturereference` (
  `DB_ID` int(10) unsigned DEFAULT NULL,
  `literatureReference_rank` int(10) unsigned DEFAULT NULL,
  `literatureReference` int(10) unsigned DEFAULT NULL,
  `literatureReference_class` varchar(64) DEFAULT NULL,
  KEY `DB_ID` (`DB_ID`),
  KEY `literatureReference` (`literatureReference`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class physicalentity_2_literaturereference: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("literatureReference_rank"), DataType(MySqlDbType.Int64, "10"), Column(Name:="literatureReference_rank")> Public Property literatureReference_rank As Long
    <DatabaseField("literatureReference"), DataType(MySqlDbType.Int64, "10"), Column(Name:="literatureReference")> Public Property literatureReference As Long
    <DatabaseField("literatureReference_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="literatureReference_class")> Public Property literatureReference_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `physicalentity_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `physicalentity_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `physicalentity_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `physicalentity_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `physicalentity_2_literaturereference` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `physicalentity_2_literaturereference` SET `DB_ID`='{0}', `literatureReference_rank`='{1}', `literatureReference`='{2}', `literatureReference_class`='{3}' WHERE `DB_ID` = '{4}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `physicalentity_2_literaturereference` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `physicalentity_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `physicalentity_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class)
        Else
        Return String.Format(INSERT_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{DB_ID}', '{literatureReference_rank}', '{literatureReference}', '{literatureReference_class}')"
        Else
            Return $"('{DB_ID}', '{literatureReference_rank}', '{literatureReference}', '{literatureReference_class}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `physicalentity_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `physicalentity_2_literaturereference` (`DB_ID`, `literatureReference_rank`, `literatureReference`, `literatureReference_class`) VALUES ('{0}', '{1}', '{2}', '{3}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `physicalentity_2_literaturereference` SET `DB_ID`='{0}', `literatureReference_rank`='{1}', `literatureReference`='{2}', `literatureReference_class`='{3}' WHERE `DB_ID` = '{4}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, literatureReference_rank, literatureReference, literatureReference_class, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As physicalentity_2_literaturereference
                         Return DirectCast(MyClass.MemberwiseClone, physicalentity_2_literaturereference)
                     End Function
End Class


End Namespace
