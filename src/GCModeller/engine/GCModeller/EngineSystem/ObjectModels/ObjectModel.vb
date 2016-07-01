﻿Imports System.Xml.Serialization
Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.RuntimeObjects
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic

Namespace EngineSystem.ObjectModels

    Public MustInherit Class ObjectModel : Inherits RuntimeObject
        Implements IAddressHandle, sIdEnumerable

        ''' <summary>
        ''' Guid/MetaCyc UniqueId String.(Guid或者MetaCyc数据库里面的UniqueId字符串)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DumpNode> <XmlAttribute>
        Public Overridable Property Identifier As String Implements sIdEnumerable.Identifier

        ''' <summary>
        ''' The index handle of this object instance in the collection of the metabolite compounds in this system model.
        ''' (该对象在当前子系统模型对象实例中的代谢物列表中的索引号)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DumpNode> <XmlAttribute>
        Public Overridable Property Handle As Integer Implements IAddressHandle.Address

        Public MustOverride ReadOnly Property TypeId As TypeIds

        Public Overrides Function ToString() As String
            Return Identifier
        End Function

        Public Enum TypeIds
            MetabolismFlux
            EnzymaticFlux
            EntityCompound
            EntityReactionModifier
            EntityRegulator
            EntityTranscript

            ExpressionConstraintFlux
            ActiveTransportationFlux
            PassiveTransportationFlux
            BasalExpression
            CentralDogma
            Pathway

            FeatureMetabolismEnzyme
            FeatureGene
            FeatureTranscriptionUnit
            FeatureMotifSite

            EventTranslation
            EventTranscription
        End Enum

#Region "IDisposable Support"
        Private disposedValue As Boolean ' 检测冗余的调用

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO:  释放托管状态(托管对象)。
                End If

                ' TODO:  释放非托管资源(非托管对象)并重写下面的 Finalize()。
                ' TODO:  将大型字段设置为 null。
            End If
            Me.disposedValue = True
        End Sub

        ' TODO:  仅当上面的 Dispose( disposing As Boolean)具有释放非托管资源的代码时重写 Finalize()。
        'Protected Overrides Sub Finalize()
        '    ' 不要更改此代码。    请将清理代码放入上面的 Dispose( disposing As Boolean)中。
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' Visual Basic 添加此代码是为了正确实现可处置模式。
        Public Overridable Sub Dispose() Implements IDisposable.Dispose
            ' 不要更改此代码。    请将清理代码放入上面的 Dispose (disposing As Boolean)中。
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region
    End Class
End Namespace