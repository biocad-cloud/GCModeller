﻿Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel

''' <summary>
''' A very simple orthology tree.(仅仅依靠``is_a``关系来构建出直系同源树)
''' </summary>
Public Class GenericTree

    Public Property ID As String
    Public Property name As String
    ''' <summary>
    ''' multiple inheritance? (basetype)
    ''' </summary>
    ''' <returns></returns>
    Public Property is_a As GenericTree()
    Public Property Data As NamedValue(Of String())()

    ''' <summary>
    ''' Does the term with <paramref name="id"/> is my root or parent?
    ''' </summary>
    ''' <param name="id"></param>
    ''' <returns></returns>
    Public Function IsBaseType(id As String) As Boolean
        If id = Me.ID Then
            ' 自己也应该是自己的base type？？
            Return True
        Else
            For Each parent As GenericTree In is_a
                If parent.IsBaseType(id) Then
                    Return True
                End If
            Next
        End If

        Return False
    End Function

    Public Shared Function BuildTree(terms As IEnumerable(Of RawTerm)) As Dictionary(Of String, GenericTree)
        Dim vertex As Dictionary(Of String, GenericTree) = terms _
            .Where(Function(t) t.Type = "Term") _
            .Select(Function(t)
                        Dim id = t.data _
                            .Where(Function(k) k.Name = "id") _
                            .First _
                            .Value _
                            .First
                        Return (id:=id, term:=t)
                    End Function) _
            .ToDictionary(Function(t) t.id,
                          Function(k)
                              Dim name = k.term _
                                  .data _
                                  .Where(Function(t) t.Name = "name") _
                                  .First _
                                  .Value _
                                  .First
                              Return New GenericTree With {
                                  .ID = k.id,
                                  .Data = k.term.data,
                                  .name = name
                              }
                          End Function)

        For Each v As GenericTree In vertex.Values
            Dim is_a = v.Data _
                .Where(Function(t) t.Name = "is_a") _
                .First _
                .Value _
                .Select(Function(value)
                            Return value.StringSplit("\s*!\s*").First.Trim
                        End Function) _
                .ToArray

            v.is_a = is_a _
                .Select(Function(id) vertex(id)) _
                .ToArray
        Next

        Return vertex
    End Function
End Class
