﻿Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.Default
Imports Microsoft.VisualBasic.Linq

Namespace ComponentModel.DataSourceModel.Repository

    ''' <summary>
    ''' 这个库检索模型仅建议在目标数据量非常巨大的时候使用，如果数据量比较小，可以直接保存在一个文件之中，然后一次性加载在内存之中来进行查找
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    Public MustInherit Class QueryCacheFactory(Of T As IKeyedEntity(Of String))
        Implements IRepositoryRead(Of String, T)

        Dim cache As New Dictionary(Of String, T)
        Dim factory As Func(Of String, T)
        Dim assertIsNothing As Assert(Of Object)

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="factory"></param>
        ''' <param name="cache"></param>
        ''' <param name="assertIsNothing">如果这个函数返回的结果是True，说明目标为空值，这个主要是针对于structure类型而言的</param>
        Sub New(factory As Func(Of String, T), Optional cache As IReadOnlyDictionary(Of String, T) = Nothing, Optional assertIsNothing As Assert(Of Object) = Nothing)
            Me.factory = factory
            Me.cache = cache.SafeQuery.ToDictionary
            Me.assertIsNothing = assertIsNothing Or defaultAssert
        End Sub

        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overrides Function ToString() As String
            Return $"{cache.Count} entity was cached. (keys={cache.Keys.Take(5).JoinBy("; ")}...)"
        End Function

        ''' <summary>
        ''' Clear the cache memory
        ''' </summary>
        ''' 
        <MethodImpl(MethodImplOptions.AggressiveInlining)>
        Public Overridable Sub Clear()
            Call cache.Clear()
        End Sub

        Public Overridable Function Exists(key As String) As Boolean Implements IRepositoryRead(Of String, T).Exists
            If cache.ContainsKey(key) Then
                Return True
            Else
                Return Not assertIsNothing(GetByKey(key))
            End If
        End Function

        ''' <summary>
        ''' Load by <see cref="factory"/> or read from <see cref="cache"/>.
        ''' </summary>
        ''' <param name="key"></param>
        ''' <returns></returns>
        Public Overridable Function GetByKey(key As String) As T Implements IRepositoryRead(Of String, T).GetByKey
            If cache.ContainsKey(key) Then
                ' hit in cache
                Return cache(key)
            Else
                Dim entity As T = factory(key)

                If assertIsNothing(entity) = True Then
                    Return Nothing
                Else
                    cache.Add(entity.Key, entity)
                End If

                Return entity
            End If
        End Function

        ''' <summary>
        ''' Only works on cache
        ''' </summary>
        ''' <param name="clause"></param>
        ''' <returns></returns>
        Public Overridable Function GetWhere(clause As Func(Of T, Boolean)) As IReadOnlyDictionary(Of String, T) Implements IRepositoryRead(Of String, T).GetWhere
            Return cache.Values.Where(clause).ToDictionary(Function(t) t.Key)
        End Function

        ''' <summary>
        ''' Only works on cache
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Function GetAll() As IReadOnlyDictionary(Of String, T) Implements IRepositoryRead(Of String, T).GetAll
            Return New Dictionary(Of String, T)(cache)
        End Function
    End Class
End Namespace