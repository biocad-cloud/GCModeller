﻿#Region "Microsoft.VisualBasic::2eaebb7351ac282f111cdceab3ee9d3c, ..\R.Bioconductor\RDotNET.Extensions.VisualBasic\Extensions\DataFrameAPI.vb"

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

Imports System.Runtime.CompilerServices
Imports System.Text
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO
Imports Microsoft.VisualBasic.Data.csv.StorageProvider.Reflection
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Text
Imports RDotNET.Extensions.VisualBasic.API
Imports RDotNET.Extensions.VisualBasic.SymbolBuilder
Imports vbList = Microsoft.VisualBasic.Language.List(Of String)

Public Module DataFrameAPI

    <Extension>
    Public Function PushAsTable(table As IO.File, Optional skipFirst As Boolean = True) As String
        Dim var$ = App.NextTempName
        Call table.PushAsTable(var, skipFirst)
        Return var
    End Function

    ''' <summary>
    ''' Push the table data in the VisualBasic into R system.
    ''' </summary>
    ''' <param name="table"></param>
    ''' <param name="tableName"></param>
    ''' <param name="skipFirst">
    ''' If the first column is the rows name, and you don't want these names, then you should set this as TRUE to skips this data.
    ''' </param>
    <Extension>
    Public Sub PushAsTable(table As IO.File, tableName As String, Optional skipFirst As Boolean = True)
        Dim matrix As New vbList ' 因为Language命名空间下面的C命名空间和c函数有冲突，所以在这里导入类型别名
        Dim ncol As Integer

        For Each row In table.Skip(1)
            If skipFirst Then
                matrix += row.Skip(1)
            Else
                matrix += row.ToArray
            End If

            If ncol = 0 Then
                ncol = matrix.Count
            End If
        Next

        Dim sb As New StringBuilder()
        Dim colNames As String = RScripts.c(table.First.Skip(If(skipFirst, 1, 0)).ToArray)

        sb.AppendLine($"{tableName} <- matrix(c({matrix.JoinBy(",")}),ncol={ncol},byrow=TRUE);")
        sb.AppendLine($"colnames({tableName}) <- {colNames}")

        SyncLock R
            With R
                .call = sb.ToString
            End With
        End SyncLock
    End Sub

    ''' <summary>
    ''' A data frame is used for storing data tables. It is a list of vectors of equal length. 
    ''' For example, the following variable df is a data frame containing three vectors n, s, b.
    '''
    ''' ```R
    ''' n = c(2, 3, 5) 
    ''' s = c("aa", "bb", "cc") 
    ''' b = c(TRUE, FALSE, TRUE) 
    ''' df = data.frame(n, s, b)       # df Is a data frame
    ''' 
    ''' # df
    ''' #   n  s     b
    ''' # 1 2 aa  TRUE
    ''' # 2 3 bb FALSE
    ''' # 3 5 cc  TRUE
    ''' ```
    ''' 
    ''' (这个函数是不经过文件过程的，故而对于大csv文件而言，不适合。只推荐小csv文件使用)
    ''' </summary>
    ''' <param name="df"></param>
    ''' <param name="var"></param>
    <Extension>
    Public Sub PushAsDataFrame(df As File, var$,
                               Optional types As Dictionary(Of String, Type) = Nothing,
                               Optional typeParsing As Boolean = True,
                               Optional rowNames As IEnumerable(Of String) = Nothing)

        Dim names As String() = df.First.ToArray

        df = New IO.File(df.Skip(1))
        If types Is Nothing Then
            types = New Dictionary(Of String, Type)
        End If

        SyncLock R
            With R
                Dim ref$ = App.NextTempName
                Dim refNames$() = New String(names.Length - 1) {}

                .call = $"{ref} <- list();"

                For Each col As SeqValue(Of String()) In df.Columns.SeqIterator
                    Dim name As String = names(col.i)
                    Dim type As Type = If(
                        types.ContainsKey(name),
                        types(name),
                        If(typeParsing,
                           col.value.SampleForType,
                           GetType(String)))
                    Dim cc As String

                    Select Case type
                        Case GetType(String)
                            cc = RScripts.c(col.value)
                        Case GetType(Boolean)
                            cc = RScripts.c(col.value.ToArray(AddressOf ParseBoolean))
                        Case Else
                            cc = RScripts.c(col.value.ToArray(Function(x) DirectCast(x, Object)))
                    End Select

                    refNames(col.i) = $"{ref}$""{name}"""
                    name = refNames(col.i)
                    .call = $"{name} <- {cc}"   ' x <- c(....)
                Next

                .call = $"{var} <- data.frame({refNames.JoinBy(", ")})"
                .call = $"colnames({var}) <- {base.c(names, stringVector:=True)}"

                If rowNames IsNot Nothing Then
                    Dim rows As String() = rowNames.ToArray

                    If rows.Length > 0 Then
                        .call = $"rownames({var}) <- {RScripts.c(rows)}"
                    End If
                End If
            End With
        End SyncLock
    End Sub

    <Extension>
    Public Function PushAsDataFrame(df As IO.File,
                                    Optional types As Dictionary(Of String, Type) = Nothing,
                                    Optional typeParsing As Boolean = True,
                                    Optional rowNames As IEnumerable(Of String) = Nothing) As String
        Dim var$ = App.NextTempName
        Call df.PushAsDataFrame(var, types, typeParsing, rowNames)
        Return var
    End Function

    ''' <summary>
    ''' Push this object collection into the R memory as dataframe object.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="var"></param>
    Public Sub PushAsDataFrame(Of T)(source As IEnumerable(Of T), var As String, Optional maps As Dictionary(Of String, String) = Nothing)
        Dim schema As Dictionary(Of String, Type) = Nothing

        ' 初始化schema对象会在save函数之中完成，然后被pushasdataframe调用
        Call Reflector _
            .Save(source, schemaOut:=schema, maps:=maps, strict:=False) _
            .PushAsDataFrame(var, types:=schema, typeParsing:=False)
    End Sub

    ''' <summary>
    ''' Push this object collection into the R memory as dataframe object.(函数返回的是一个用于对象引用的临时编号)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <returns>Returns the temp variable name that reference to the dataframe object in R memory.</returns>
    <Extension>
    Public Function dataframe(Of T)(source As IEnumerable(Of T), Optional maps As Dictionary(Of String, String) = Nothing) As String
        Dim tmp As String = App.NextTempName
        Call PushAsDataFrame(source, var:=tmp, maps:=maps)
        Return tmp
    End Function

    ''' <summary>
    ''' Helper script for converts the R dataframe to VB.NET dataframe
    ''' 
    ''' ```R
    ''' l &lt;- as.list(%dataframe%);
    '''
    ''' for(name in names(l)) {
    '''     l[[name]] &lt;- as.vector(l[[name]]);
    ''' }
    '''
    ''' l;
    ''' ```
    ''' </summary>
    Const Rscript$ = "
## Helper script for converts the R dataframe to VB.NET dataframe

l <- as.list(%dataframe%);

for(name in names(l)) {
    l[[name]] <- as.vector(l[[name]]);
}

l;
"

    ''' <summary>
    ''' 将R之中的dataframe对象转换为.NET之中的csv文件数据框
    ''' </summary>
    ''' <param name="dataframe$"></param>
    ''' <returns></returns>
    Public Function GetDataFrame(dataframe$) As File

        SyncLock R
            With R
                Dim data As SymbolicExpression = .Evaluate(statement:=Rscript.Replace("%dataframe%", dataframe))
                Dim list As SymbolicExpression() = data.AsList.ToArray ' dataframe对象实际上是一个list对象
                Dim names$() = base.names(dataframe)
                Dim csv As New File
                Dim columns = list _
                    .Select(Function(c) c.ToStringsGeneric) _
                    .ToArray

                csv += names ' The csv header row 

                For i% = 0 To columns(Scan0).Length - 1
                    Dim row As New List(Of String)

                    For Each column As String() In columns
                        row += column(i)
                    Next

                    csv += row
                Next

                Return csv
            End With
        End SyncLock
    End Function

    ''' <summary>
    ''' 将一个R变量转换为数据框对象
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="var"></param>
    ''' <returns></returns>
    <Extension> Public Function AsDataFrame(Of T As Class)(var As var, Optional maps As Dictionary(Of String, String) = Nothing) As T()
        Dim tmp$ = App.GetAppSysTempFile
        Dim out As T()

        utils.write.csv(x:=var.Name, file:=tmp, rowNames:=False)
        out = tmp.LoadCsv(Of T)(
            encoding:=Encodings.UTF8.CodePage,
            maps:=maps) ' R的write.csv函数所保存的文件编码默认为UTF8编码

        Return out
    End Function

    ''' <summary>
    ''' Write the ``vb.net`` csv dataframe into the R server memory through file IO.
    ''' (函数所返回来的字符串值为临时变量的名称)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="df"></param>
    ''' <returns></returns>
    <Extension>
    Public Function WriteDataFrame(Of T)(df As IEnumerable(Of T), Optional encoding As Encodings = Encodings.UTF8) As String
        Dim tmp$ = App.GetAppSysTempFile(sessionID:=App.PID).UnixPath
        Dim var$ = App.NextTempName

        SyncLock R
            With R
                df.SaveTo(tmp,, encoding.CodePage)
                .call = $"{var} <- read.csv({Rstring(tmp)})"
            End With
        End SyncLock

        Return var
    End Function
End Module
