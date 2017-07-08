﻿Imports Microsoft.VisualBasic.ComponentModel.Collection.Generic
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel.Repository
Imports Microsoft.VisualBasic.Math.LinearAlgebra

''' <summary>
''' 质点，没有体积和大小，只有质量和电荷量的理想物理对象
''' </summary>
Public Class MassPoint : Implements INamedValue

    ''' <summary>
    ''' 物体的质量，会影响重力，可能会影响摩擦力
    ''' </summary>
    ''' <returns></returns>
    Public Property Mass As Double

    ''' <summary>
    ''' 用来兼容2D/3D
    ''' </summary>
    ''' <returns></returns>
    Public Property Point As Vector

    ''' <summary>
    ''' 用于计算库仑力的电荷量
    ''' </summary>
    ''' <returns></returns>
    Public Property Charge As Double

    ''' <summary>
    ''' 速度
    ''' </summary>
    ''' <returns></returns>
    Public Property Velocity As Vector
    ''' <summary>
    ''' 加速度
    ''' </summary>
    ''' <returns></returns>
    Public Property Acceleration As Vector

    ''' <summary>
    ''' 对象所处的世界的空间类型
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property World As World.Type
        Get
            Return CType(Point.Count, World.Type)
        End Get
    End Property

    ''' <summary>
    ''' 当前的这个物体的唯一标识符
    ''' </summary>
    ''' <returns></returns>
    Public Property ID As String Implements IKeyedEntity(Of String).Key

    ''' <summary>
    ''' 物体在dt时间段内以当前的速度<see cref="Velocity"/>之下产生一小部分的位移
    ''' </summary>
    Public Sub Displacement()
        Point += Velocity
    End Sub

    Public Overrides Function ToString() As String
        If World = Physics.World.Type.Plain2D Then
            Return Point.Vector2D.ToString
        Else
            Return Point.ToString
        End If
    End Function

    ''' <summary>
    ''' 物体受到外部力的作用下改变了加速度
    ''' </summary>
    ''' <param name="m"></param>
    ''' <param name="F">这个是最终的合力</param>
    ''' <returns></returns>
    Public Shared Operator +(m As MassPoint, F As Force) As MassPoint
        With m
            Dim Fxyz As Vector = If(
                .World = Physics.World.Type.Plain2D,
                F.Decomposition2D,
                F.Decomposition3D)
            Dim a As Vector = Fxyz / .Mass  ' F=ma， 得到了各个空间分量上面的加速度

            .Acceleration += a
        End With

        Return m
    End Operator
End Class
