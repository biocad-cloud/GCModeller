﻿Imports System.IO
Imports System.Reflection
Imports System.Reflection.Emit
Imports System.Threading
Imports Microsoft.VisualBasic.Language
Imports stdNum = System.Math

Namespace IL

    ''' <summary>
    ''' Parsing the IL of a Method Body
    ''' 
    ''' > https://www.codeproject.com/articles/14058/parsing-the-il-of-a-method-body
    ''' </summary>
    Public Class MethodBodyReader : Implements IEnumerable(Of ILInstruction)
        Implements IDisposable

        ReadOnly instructions As New List(Of ILInstruction)
        ReadOnly il As Stream
        ReadOnly mi As MethodInfo = Nothing

        Private disposedValue As Boolean

        ''' <summary>
        ''' MethodBodyReader constructor
        ''' </summary>
        ''' <param name="mi">
        ''' The System.Reflection defined MethodInfo
        ''' </param>
        Public Sub New(ByVal mi As MethodInfo)
            Me.mi = mi

            If mi.GetMethodBody() IsNot Nothing Then
                il = New MemoryStream(mi.GetMethodBody().GetILAsByteArray())
                ConstructInstructions(mi.Module)
            End If
        End Sub

        ''' <summary>
        ''' Constructs the array of ILInstructions according to the IL byte code.
        ''' </summary>
        ''' <param name="module"></param>
        Private Sub ConstructInstructions(ByVal [module] As [Module])
            ' Dim position As i32 = Scan0
            Dim il As New BinaryReader(Me.il)

            While il.BaseStream.Position < il.BaseStream.Length   'position < il.Length
                Dim instruction As New ILInstruction()

                ' get the operation code of the current instruction
                Dim code = OpCodes.Nop
                Dim value As UShort = il.ReadByte '(++position)

                If value <> &HFE Then
                    code = singleByteOpCodes(value)
                Else
                    value = il.ReadByte  ' il(++position)
                    code = multiByteOpCodes(value)
                    value = CUShort(value Or &HFE00)
                End If

                instruction.Code = code
                instruction.Offset = il.BaseStream.Position - 1

                Dim metadataToken = 0

                ' get the operand of the current operation
                Select Case code.OperandType
                    Case OperandType.InlineBrTarget
                        metadataToken = il.ReadInt32 ' (il, position)
                        metadataToken += il.BaseStream.Position  ' position
                        instruction.Operand = metadataToken
                    Case OperandType.InlineField
                        metadataToken = il.ReadInt32 ' (il, position)
                        instruction.Operand = [module].ResolveField(metadataToken)
                    Case OperandType.InlineMethod
                        metadataToken = il.ReadInt32 ' (il, position)

                        Try
                            instruction.Operand = [module].ResolveMethod(metadataToken)
                        Catch
                            instruction.Operand = [module].ResolveMember(metadataToken)
                            ' Continue While
                        End Try

                    Case OperandType.InlineSig
                        metadataToken = il.ReadInt32 ' (il, position)
                        instruction.Operand = [module].ResolveSignature(metadataToken)
                    Case OperandType.InlineTok
                        metadataToken = il.ReadInt32 ' (il, position)

                        Try
                            instruction.Operand = [module].ResolveType(metadataToken)
                        Catch
                            ' SSS : see what to do here
                        End Try

                    Case OperandType.InlineType
                        metadataToken = il.ReadInt32 ' (il, position)
                        ' now we call the ResolveType always using the generic attributes type in order
                        ' to support decompilation of generic methods and classes

                        ' thanks to the guys from code project who commented on this missing feature

                        instruction.Operand = [module].ResolveType(metadataToken, mi.DeclaringType.GetGenericArguments(), mi.GetGenericArguments())
                    Case OperandType.InlineI
                        instruction.Operand = il.ReadInt32' (il, position)

                    Case OperandType.InlineI8
                        instruction.Operand = il.ReadInt64' (il, position)

                    Case OperandType.InlineNone
                        instruction.Operand = Nothing

                    Case OperandType.InlineR
                        instruction.Operand = il.ReadDouble' (il, position)

                    Case OperandType.InlineString
                        metadataToken = il.ReadInt32 '(il, position)
                        instruction.Operand = [module].ResolveString(metadataToken)

                    Case OperandType.InlineSwitch
                        Dim count = il.ReadInt32 ' (il, position)
                        Dim casesAddresses = New Integer(count - 1) {}

                        For i = 0 To count - 1
                            casesAddresses(i) = il.ReadInt32 ' (il, position)
                        Next

                        Dim cases = New Integer(count - 1) {}
                        Dim position_i As Integer = il.BaseStream.Position

                        For i = 0 To count - 1
                            cases(i) = position_i + casesAddresses(i)
                        Next


                    Case OperandType.InlineVar
                        instruction.Operand = il.ReadUInt16' (il, position)

                    Case OperandType.ShortInlineBrTarget
                        instruction.Operand = il.ReadSByte + il.BaseStream.Position  ' (il, position) + position

                    Case OperandType.ShortInlineI
                        instruction.Operand = il.ReadSByte'(il, position)

                    Case OperandType.ShortInlineR
                        instruction.Operand = il.ReadSingle' (il, position)

                    Case OperandType.ShortInlineVar
                        instruction.Operand = il.ReadByte '(il, position)

                    Case Else
                        Throw New Exception("Unknown operand type.")
                End Select

                instructions.Add(instruction)
            End While
        End Sub

        Public Function GetRefferencedOperand(ByVal [module] As [Module], ByVal metadataToken As Integer) As Object
            Dim assemblyNames As AssemblyName() = [module].Assembly.GetReferencedAssemblies()
            Dim modules As [Module]()

            For i As Integer = 0 To assemblyNames.Length - 1
                modules = Assembly.Load(assemblyNames(i)).GetModules()

                For j As Integer = 0 To modules.Length - 1
                    Try
                        Dim t = modules(j).ResolveType(metadataToken)
                        Return t
                    Catch
                    End Try
                Next
            Next

            Return Nothing
        End Function

        ''' <summary>
        ''' Gets the IL code of the method
        ''' </summary>
        ''' <returns></returns>
        Public Function GetBodyCode() As String
            Dim result = ""

            If instructions IsNot Nothing Then
                For i As Integer = 0 To instructions.Count - 1
                    result += instructions(i).GetCode() & vbLf
                Next
            End If

            Return result
        End Function

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: 释放托管状态(托管对象)
                    Call il.Dispose()
                    Call instructions.Clear()
                End If

                ' TODO: 释放未托管的资源(未托管的对象)并替代终结器
                ' TODO: 将大型字段设置为 null
                disposedValue = True
            End If
        End Sub

        ' ' TODO: 仅当“Dispose(disposing As Boolean)”拥有用于释放未托管资源的代码时才替代终结器
        ' Protected Overrides Sub Finalize()
        '     ' 不要更改此代码。请将清理代码放入“Dispose(disposing As Boolean)”方法中
        '     Dispose(disposing:=False)
        '     MyBase.Finalize()
        ' End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' 不要更改此代码。请将清理代码放入“Dispose(disposing As Boolean)”方法中
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub

        Public Iterator Function GetEnumerator() As IEnumerator(Of ILInstruction) Implements IEnumerable(Of ILInstruction).GetEnumerator
            For Each il As ILInstruction In instructions
                Yield il
            Next
        End Function

        Private Iterator Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Yield GetEnumerator()
        End Function
    End Class
End Namespace
