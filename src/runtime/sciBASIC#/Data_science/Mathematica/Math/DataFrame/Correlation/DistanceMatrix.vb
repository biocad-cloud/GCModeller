﻿Imports Microsoft.VisualBasic.ComponentModel.Collection
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.Serialization.JSON

Public Class DistanceMatrix

    ReadOnly names As Index(Of String)
    ReadOnly matrix As Double()()

    Default Public Property dist(a$, b$) As Double
        Get
            Return Me(names(a), names(b))
        End Get
        Set
            Me(names(a), names(b)) = Value
        End Set
    End Property

    Default Public Property dist(i%, j%) As Double
        Get
            Return matrix(j)(i)
        End Get
        Set(value As Double)
            matrix(j)(i) = value
        End Set
    End Property

    Public ReadOnly Property Keys As String()
        Get
            Return names.Objects
        End Get
    End Property

    Sub New(names As IEnumerable(Of String))
        Me.names = names.Indexing
        Me.matrix = MAT(Of Double)(Me.names.Count, Me.names.Count)
    End Sub

    Sub New(names As Index(Of String), matrix As Double()())
        Me.names = names
        Me.matrix = matrix

        If Me.names.Count <> matrix.Length Then
            Throw New InvalidConstraintException("the given member names is not equals to the matrix size!")
        End If
    End Sub

    Public Function Visit(Of DataSet As {New, INamedValue, DynamicPropertyBase(Of Double)})(projectName As String, direction As MatrixVisit) As DataSet
        Dim v As New DataSet With {.Key = projectName}
        Dim i As Integer = names(projectName)

        If direction = MatrixVisit.ByRow Then
            For Each name As SeqValue(Of String) In names
                Call v.Add(name.value, matrix(i)(name.i))
            Next
        Else
            For Each name As SeqValue(Of String) In names
                Call v.Add(name.value, matrix(name.i)(i))
            Next
        End If

        Return v
    End Function

    Public Iterator Function PopulateRows() As IEnumerable(Of IReadOnlyCollection(Of Double))
        For Each row As Double() In matrix
            Yield DirectCast(row, IReadOnlyCollection(Of Double))
        Next
    End Function

    Public Iterator Function PopulateRowObjects(Of DataSet As {New, INamedValue, DynamicPropertyBase(Of Double)})() As IEnumerable(Of DataSet)
        Dim names As String() = Me.names.Objects

        For Each item As SeqValue(Of String) In names.SeqIterator
            Yield New DataSet With {
                .Key = item,
                .Properties = names _
                    .ToDictionary(Function(a) a,
                                  Function(a)
                                      Return Me(a, item.value)
                                  End Function)
            }
        Next
    End Function

    Public Overrides Function ToString() As String
        If names.Count <= 6 Then
            Return names.Objects.GetJson
        Else
            Return "[" & names.Objects.Take(6).JoinBy(", ") & "..."
        End If
    End Function

    Public Shared Function CreateMatrix(Of T As {INamedValue, DynamicPropertyBase(Of Double)})(data As IEnumerable(Of T)) As DistanceMatrix
        Dim matrix As New List(Of Double())
        Dim dataVec As T() = data.SafeQuery.ToArray
        Dim names = dataVec.Keys

        For Each row As T In data
            matrix += names _
                .Select(Function(key)
                            Return row.Properties(key)
                        End Function) _
                .ToArray
        Next

        Return New DistanceMatrix(names, matrix)
    End Function

End Class
