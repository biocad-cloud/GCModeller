REM  Oracle.LinuxCompatibility.MySQL.CodeSolution.VisualBasic.CodeGenerator
REM  MYSQL Schema Mapper
REM      for Microsoft VisualBasic.NET 2.1.0.2569

REM  Dump @2018/5/23 13:13:37


Imports System.Data.Linq.Mapping
Imports System.Xml.Serialization
Imports Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes
Imports MySqlScript = Oracle.LinuxCompatibility.MySQL.Scripting.Extensions

Namespace Interpro.Tables

''' <summary>
''' ```SQL
''' 
''' --
''' 
''' DROP TABLE IF EXISTS `book2author`;
''' /*!40101 SET @saved_cs_client     = @@character_set_client */;
''' /*!40101 SET character_set_client = utf8 */;
''' CREATE TABLE `book2author` (
'''   `isbn` varchar(10) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
'''   `author_id` int(9) NOT NULL,
'''   `order_in` int(3) NOT NULL,
'''   PRIMARY KEY (`isbn`,`order_in`,`author_id`),
'''   UNIQUE KEY `uq_book2author$1` (`isbn`,`order_in`),
'''   KEY `i_book2author$fk_author_id` (`author_id`),
'''   CONSTRAINT `fk_book2author$author_id` FOREIGN KEY (`author_id`) REFERENCES `author` (`author_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
'''   CONSTRAINT `fk_book2author$isbn` FOREIGN KEY (`isbn`) REFERENCES `book` (`isbn`) ON DELETE NO ACTION ON UPDATE NO ACTION
''' ) ENGINE=InnoDB DEFAULT CHARSET=latin1;
''' /*!40101 SET character_set_client = @saved_cs_client */;
''' 
''' --
''' ```
''' </summary>
''' <remarks></remarks>
<Oracle.LinuxCompatibility.MySQL.Reflection.DbAttributes.TableName("book2author", Database:="interpro", SchemaSQL:="
CREATE TABLE `book2author` (
  `isbn` varchar(10) CHARACTER SET latin1 COLLATE latin1_bin NOT NULL,
  `author_id` int(9) NOT NULL,
  `order_in` int(3) NOT NULL,
  PRIMARY KEY (`isbn`,`order_in`,`author_id`),
  UNIQUE KEY `uq_book2author$1` (`isbn`,`order_in`),
  KEY `i_book2author$fk_author_id` (`author_id`),
  CONSTRAINT `fk_book2author$author_id` FOREIGN KEY (`author_id`) REFERENCES `author` (`author_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_book2author$isbn` FOREIGN KEY (`isbn`) REFERENCES `book` (`isbn`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;")>
Public Class book2author: Inherits Oracle.LinuxCompatibility.MySQL.MySQLTable
#Region "Public Property Mapping To Database Fields"
    <DatabaseField("isbn"), PrimaryKey, NotNull, DataType(MySqlDbType.VarChar, "10"), Column(Name:="isbn"), XmlAttribute> Public Property isbn As String
    <DatabaseField("author_id"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "9"), Column(Name:="author_id"), XmlAttribute> Public Property author_id As Long
    <DatabaseField("order_in"), PrimaryKey, NotNull, DataType(MySqlDbType.Int64, "3"), Column(Name:="order_in"), XmlAttribute> Public Property order_in As Long
#End Region
#Region "Public SQL Interface"
#Region "Interface SQL"
    Friend Shared ReadOnly INSERT_SQL$ = 
        <SQL>INSERT INTO `book2author` (`isbn`, `author_id`, `order_in`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly INSERT_AI_SQL$ = 
        <SQL>INSERT INTO `book2author` (`isbn`, `author_id`, `order_in`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_SQL$ = 
        <SQL>REPLACE INTO `book2author` (`isbn`, `author_id`, `order_in`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly REPLACE_AI_SQL$ = 
        <SQL>REPLACE INTO `book2author` (`isbn`, `author_id`, `order_in`) VALUES ('{0}', '{1}', '{2}');</SQL>

    Friend Shared ReadOnly DELETE_SQL$ =
        <SQL>DELETE FROM `book2author` WHERE `isbn`='{0}' and `order_in`='{1}' and `author_id`='{2}';</SQL>

    Friend Shared ReadOnly UPDATE_SQL$ = 
        <SQL>UPDATE `book2author` SET `isbn`='{0}', `author_id`='{1}', `order_in`='{2}' WHERE `isbn`='{3}' and `order_in`='{4}' and `author_id`='{5}';</SQL>

#End Region

''' <summary>
''' ```SQL
''' DELETE FROM `book2author` WHERE `isbn`='{0}' and `order_in`='{1}' and `author_id`='{2}';
''' ```
''' </summary>
    Public Overrides Function GetDeleteSQL() As String
        Return String.Format(DELETE_SQL, isbn, order_in, author_id)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `book2author` (`isbn`, `author_id`, `order_in`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL() As String
        Return String.Format(INSERT_SQL, isbn, author_id, order_in)
    End Function

''' <summary>
''' ```SQL
''' INSERT INTO `book2author` (`isbn`, `author_id`, `order_in`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetInsertSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(INSERT_AI_SQL, isbn, author_id, order_in)
        Else
        Return String.Format(INSERT_SQL, isbn, author_id, order_in)
        End If
    End Function

''' <summary>
''' <see cref="GetInsertSQL"/>
''' </summary>
    Public Overrides Function GetDumpInsertValue(AI As Boolean) As String
        If AI Then
            Return $"('{isbn}', '{author_id}', '{order_in}')"
        Else
            Return $"('{isbn}', '{author_id}', '{order_in}')"
        End If
    End Function


''' <summary>
''' ```SQL
''' REPLACE INTO `book2author` (`isbn`, `author_id`, `order_in`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL() As String
        Return String.Format(REPLACE_SQL, isbn, author_id, order_in)
    End Function

''' <summary>
''' ```SQL
''' REPLACE INTO `book2author` (`isbn`, `author_id`, `order_in`) VALUES ('{0}', '{1}', '{2}');
''' ```
''' </summary>
    Public Overrides Function GetReplaceSQL(AI As Boolean) As String
        If AI Then
        Return String.Format(REPLACE_AI_SQL, isbn, author_id, order_in)
        Else
        Return String.Format(REPLACE_SQL, isbn, author_id, order_in)
        End If
    End Function

''' <summary>
''' ```SQL
''' UPDATE `book2author` SET `isbn`='{0}', `author_id`='{1}', `order_in`='{2}' WHERE `isbn`='{3}' and `order_in`='{4}' and `author_id`='{5}';
''' ```
''' </summary>
    Public Overrides Function GetUpdateSQL() As String
        Return String.Format(UPDATE_SQL, isbn, author_id, order_in, isbn, order_in, author_id)
    End Function
#End Region

''' <summary>
                     ''' Memberwise clone of current table Object.
                     ''' </summary>
                     Public Function Clone() As book2author
                         Return DirectCast(MyClass.MemberwiseClone, book2author)
                     End Function
End Class


End Namespace
