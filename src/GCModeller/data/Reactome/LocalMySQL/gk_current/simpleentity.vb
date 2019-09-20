﻿#Region "Microsoft.VisualBasic::f46c8f390f2527fd1ccbf42998cc413d, Reactome\LocalMySQL\gk_current\simpleentity.vb"

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

    ' Class simpleentity
    ' 
    '     Properties: DB_ID, referenceEntity, referenceEntity_class, species, species_class
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
''' DROP TABLE IF EXISTS `simpleentity`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `simpleentity` (
'''   `DB_ID` int(10) unsigned NOT NULL,
'''   `referenceEntity` int(10) unsigned DEFAULT NULL,
'''   `referenceEntity_class` varchar(64) DEFAULT NULL,
'''   `species` int(10) unsigned DEFAULT NULL,
'''   `species_class` varchar(64) DEFAULT NULL,
'''   PRIMARY KEY (`DB_ID`),
'''   KEY `referenceEntity` (`referenceEntity`),
'''   KEY `species` (`species`)
''' ) ENGINE=MyISAM DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("simpleentity", Database:="gk_current", SchemaSQL:="
CREATE TABLE `simpleentity` (
  `DB_ID` int(10) unsigned NOT NULL,
  `referenceEntity` int(10) unsigned DEFAULT NULL,
  `referenceEntity_class` varchar(64) DEFAULT NULL,
  `species` int(10) unsigned DEFAULT NULL,
  `species_class` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`DB_ID`),
  KEY `referenceEntity` (`referenceEntity`),
  KEY `species` (`species`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;")>
Public Class simpleentity: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("DB_ID"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "10"), Column(Name:="DB_ID"), XmlAttribute> Public Property DB_ID As Long
    <DatabaseField("referenceEntity"), DataType(MySqlDbType.Int64, "10"), Column(Name:="referenceEntity")> Public Property referenceEntity As Long
    <DatabaseField("referenceEntity_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="referenceEntity_class")> Public Property referenceEntity_class As String
    <DatabaseField("species"), DataType(MySqlDbType.Int64, "10"), Column(Name:="species")> Public Property species As Long
    <DatabaseField("species_class"), DataType(MySqlDbType.VarChar, "64"), Column(Name:="species_class")> Public Property species_class As String
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `simpleentity` (`DB_ID`, `referenceEntity`, `referenceEntity_class`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `simpleentity` (`DB_ID`, `referenceEntity`, `referenceEntity_class`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `simpleentity` (`DB_ID`, `referenceEntity`, `referenceEntity_class`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `simpleentity` (`DB_ID`, `referenceEntity`, `referenceEntity_class`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `simpleentity` WHERE `DB_ID` = '{0}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `simpleentity` SET `DB_ID`='{0}', `referenceEntity`='{1}', `referenceEntity_class`='{2}', `species`='{3}', `species_class`='{4}' WHERE `DB_ID` = '{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `simpleentity` WHERE `DB_ID` = '{0}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, DB_ID)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `simpleentity` (`DB_ID`, `referenceEntity`, `referenceEntity_class`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, DB_ID, referenceEntity, referenceEntity_class, species, species_class)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `simpleentity` (`DB_ID`, `referenceEntity`, `referenceEntity_class`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, DB_ID, referenceEntity, referenceEntity_class, species, species_class)
        Else
        Return String.Format(INSERT_SQL, DB_ID, referenceEntity, referenceEntity_class, species, species_class)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{DB_ID}', '{referenceEntity}', '{referenceEntity_class}', '{species}', '{species_class}')"
        Else
            Return $"('{DB_ID}', '{referenceEntity}', '{referenceEntity_class}', '{species}', '{species_class}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `simpleentity` (`DB_ID`, `referenceEntity`, `referenceEntity_class`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, DB_ID, referenceEntity, referenceEntity_class, species, species_class)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `simpleentity` (`DB_ID`, `referenceEntity`, `referenceEntity_class`, `species`, `species_class`) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, DB_ID, referenceEntity, referenceEntity_class, species, species_class)
        Else
        Return String.Format(REPLACE_SQL, DB_ID, referenceEntity, referenceEntity_class, species, species_class)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `simpleentity` SET `DB_ID`='{0}', `referenceEntity`='{1}', `referenceEntity_class`='{2}', `species`='{3}', `species_class`='{4}' WHERE `DB_ID` = '{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, DB_ID, referenceEntity, referenceEntity_class, species, species_class, DB_ID)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As simpleentity
                         Return DirectCast(MyClass.MemberwiseClone, simpleentity)
                     End Function
End Class


End Namespace
