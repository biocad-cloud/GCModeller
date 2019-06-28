﻿#Region "Microsoft.VisualBasic::3a504045db45c69fc6b79a304a4e2bac, CLI_tools\ANN\CLI.vb"

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

' Module CLI
' 
'     Function: ANNInputImportantFactors, ConfigTemplate, Encourage, ExportErrorCurve, MinErrorSnapshot
'               ROCData, runTrainingCommon, Train
' 
'     Sub: SummaryDebuggerDump
' 
' /********************************************************************************/

#End Region

Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CommandLine
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.ComponentModel.Settings.Inf
Imports Microsoft.VisualBasic.Data.csv
Imports Microsoft.VisualBasic.Data.csv.IO.Linq
Imports Microsoft.VisualBasic.Data.IO.netCDF
Imports Microsoft.VisualBasic.DataMining
Imports Microsoft.VisualBasic.DataMining.ComponentModel
Imports Microsoft.VisualBasic.Language
Imports Microsoft.VisualBasic.Language.Default
Imports Microsoft.VisualBasic.Linq
Imports Microsoft.VisualBasic.MachineLearning.Debugger
Imports Microsoft.VisualBasic.MachineLearning.NeuralNetwork
Imports Microsoft.VisualBasic.MachineLearning.NeuralNetwork.Accelerator
Imports Microsoft.VisualBasic.MachineLearning.NeuralNetwork.StoreProcedure
Imports DataFrame = Microsoft.VisualBasic.Data.csv.IO.DataFrame
Imports Excel = Microsoft.VisualBasic.Data.csv.IO.DataSet

Module CLI

    <ExportAPI("/ROC")>
    <Usage("/ROC /in <result.csv> [/label.predicts <default=predicts> /label.actual <default=labels> /out <out.csv>]")>
    <Description("Output a matrix file for draw a ROC curve")>
    <Argument("/in", False, CLITypes.File, PipelineTypes.std_in,
              AcceptTypes:={GetType(IO.DataSet)},
              Extensions:="*.csv",
              Description:="The validation data file input.")>
    <Argument("/label.predicts", True, CLITypes.String,
              AcceptTypes:={GetType(String)},
              Description:="The column name label for read result data of the model prediction output. Value of this column should in range of [0, 1]")>
    <Argument("/label.actual", True, CLITypes.String,
              AcceptTypes:={GetType(String)},
              Description:="The column name label for read the actual classfication data. Value of this column should only be 0 or 1.")>
    Public Function ROCData(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim labelPredicts = args("/label.predicts") Or "predicts"
        Dim labelActuals = args("/label.actual") Or "labels"
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}.confusionOf({labelActuals.NormalizePathString()}).csv"
        Dim result = DataFrame.LoadDataSet([in])
        Dim ROCMatrix = Validation _
            .ROC(result, Function(a, p) a(labelActuals) >= p, Function(a, p) a(labelPredicts) >= p) _
            .Select(Function(level)
                        Return New IO.DataSet With {
                            .ID = level.Threshold,
                            .Properties = level.ToDataSet
                        }
                    End Function) _
            .ToArray

        Return ROCMatrix.SaveTo(out).CLICode
    End Function

    <ExportAPI("/Summary.Debugger.Dump")>
    <Usage("/Summary.Debugger.Dump /in <debugger_out.cdf>")>
    Public Sub SummaryDebuggerDump(args As CommandLine)
        Call New netCDFReader(args <= "/in").Print()
    End Sub

    <ExportAPI("/Snapshot.min_errors")>
    <Usage("/Snapshot.min_errors /in <debugger.cdf> [/out <snapshot.Xml>]")>
    Public Function MinErrorSnapshot(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}.Snapshot.min_errors.Xml"
        Dim debugger As New netCDFReader([in])
        Dim errors = debugger.getDataVariable("fitness").numerics
        Dim index = Which.Min(errors)

    End Function

    <ExportAPI("/input.important")>
    <Usage("/input.important /in <ANN_model.Xml> /sample <trainingSet.Xml/names.list.txt> [/out <factors.csv>]")>
    Public Function ANNInputImportantFactors(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim sample$ = args <= "/sample"
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}.input_factors.csv"
        Dim model As NeuralNetwork
        Dim inputNames As String()

        If [in].FileExists Then
            model = [in].LoadXml(Of NeuralNetwork)
        ElseIf [in].DirectoryExists Then
            model = StoreProcedure.ScatteredLoader([in])
        Else
            Throw New InvalidProgramException($"'{[in]}' is missing on your file system!")
        End If

        If sample.ExtensionSuffix.TextEquals("xml") Then
            inputNames = sample.LoadXml(Of DataSet).NormalizeMatrix.names
        Else
            inputNames = sample.ReadAllLines
        End If

        Return model.SumWeight(inputNames) _
            .ToArray _
            .SaveTo(out) _
            .CLICode
    End Function

    ''' <summary>
    ''' 导出误差率曲线数据
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    ''' 
    <ExportAPI("/Export.Errors.Curve")>
    <Usage("/Export.Errors.Curve /in <debugger_out.cdf> [/out <errors.csv>]")>
    Public Function ExportErrorCurve(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}.errors.csv"

        Using cdf As New netCDFReader([in])
            Return FrameExports.ExportErrorCurve(cdf) _
                .csv _
                .Save(out) _
                .CLICode
        End Using
    End Function

    <ExportAPI("/Export.NodeValue.Frames")>
    <Usage("/Export.NodeValue.Frames /in <debugger.cdf> [/out <table.csv>]")>
    <Description("Export node value of each iteration frame, for debug used only!")>
    Public Function ExportValueFrames(args As CommandLine) As Integer
        Dim dump$ = args <= "/in"
        Dim out$ = args("/out") Or $"{dump.TrimSuffix}.nodeValue_frames.csv"

        Using cdf As netCDFReader = netCDFReader.Open(dump)
            Dim times = FrameExports.GetTimeIndex(cdf)

            Using csv As New WriteStream(Of Excel)(out, metaKeys:=times)
                For Each node As Excel In FrameExports.ExportValueFrames(cdf)
                    csv.Flush(node)
                Next
            End Using
        End Using

        Return 0
    End Function

    <ExportAPI("/config.template")>
    <Usage("/config.template [/save <default=./config.ini>]")>
    <Description("Create the default config file for the ANN model.")>
    Public Function ConfigTemplate(args As CommandLine) As Integer
        Return New Config().WriteProfile(args("/save") Or "./config.ini")
    End Function

    ''' <summary>
    ''' Print all of the available activation functions for write config file.
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/list.activations")>
    Public Function ListActiveFunction(args As CommandLine) As Integer

    End Function

    ''' <summary>
    ''' 输出归一化之后的样本数据,测试用
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/sample.normalize")>
    <Description("Debug used only.")>
    <Usage("/sample.normalize /in <sample_matrix.Xml> [/method <name> /out <dataset.csv>]")>
    Public Function NormalizeSampleDebugger(args As CommandLine) As Integer
        Dim in$ = args <= "/in"
        Dim method$ = args("/method") Or $"{Normalizer.Methods.NormalScaler.Description}"
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}.{method}.csv"
        Dim samples As DataSet = [in].LoadXml(Of DataSet)
        Dim matrix As Sample() = samples.PopulateNormalizedSamples(Normalizer.ParseMethod(method)).ToArray
        Dim names = samples.NormalizeMatrix.names.SeqIterator.ToArray
        Dim dataset = matrix _
            .Select(Function(r)
                        Return New Excel With {
                            .ID = r.ID,
                            .Properties = names.ToDictionary(
                                Function(name) name.value,
                                Function(name)
                                    Return r.status(name)
                                End Function)
                        }
                    End Function) _
            .ToArray

        Return dataset.SaveTo(out).CLICode
    End Function

    ''' <summary>
    ''' 这个函数会输出训练好的模型, 训练集测试结果, 错误率变化曲线图, 训练日志
    ''' 配置文件不存在的画，则使用默认的配置数据
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    <ExportAPI("/training")>
    <Usage("/training /samples <sample_matrix.Xml> [/config <config.ini> /debug /parallel /GA.optimize /out <ANN.Xml>]")>
    <Description("Training a ANN model based on the training set input.")>
    <Argument("/samples", False, CLITypes.File, PipelineTypes.std_in,
              Extensions:="*.Xml",
              Description:="Training dataset as the data set input for the ANN model")>
    Public Function Train(args As CommandLine) As Integer
        Dim in$ = args <= "/samples"
        Dim parallel As Boolean = args("/parallel")
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}_ANN_trained.Xml"
        Dim samples As DataSet = [in].LoadXml(Of DataSet)
        Dim config As Config = (args <= "/config").LoadProfile(Of Config) Or Config.Default
        Dim hiddenSize As Integer()

        If config.hidden_size.StringEmpty Then
            hiddenSize = {
                CInt(samples.Size.Width * 1.25),
                CInt((samples.OutputSize + samples.Size.Width) / 2),
                CInt(samples.OutputSize * 1.25)
            }
        Else
            hiddenSize = config.hidden_size _
                .Split(","c) _
                .Select(Function(s) CInt(Val(s))) _
                .ToArray
        End If

        Dim weightInit As Func(Of Double) = Helpers.UnifyWeightInitializer(Val(config.initializer)) Or Helpers.RandomWeightInitializer.When(config.initializer.TextEquals("random"))
        Dim defaultActive As [Default](Of String) = config.default_active Or ActiveFunction.Sigmoid
        Dim actives As New Activations.LayerActives With {
            .hiddens = ActiveFunction.Parse(config.hiddens_active Or defaultActive),
            .input = ActiveFunction.Parse(config.input_active Or defaultActive),
            .output = ActiveFunction.Parse(config.output_active Or defaultActive)
        }
        Dim dummyExtends% = 0
        Dim trainingHelper As New TrainingUtils(
            samples.Size.Width, hiddenSize,
            samples.OutputSize + dummyExtends,
            config.learnRate,
            config.momentum,
            actives,
            weightInit:=weightInit
        ) With {.Selective = config.selective.ParseBoolean}

        trainingHelper.NeuronNetwork.LearnRateDecay = config.learnRateDecay
        trainingHelper.Truncate = config.truncate

        If True = config.layerNormalize.ParseBoolean Then
            For Each layer As Layer In trainingHelper.NeuronNetwork.HiddenLayer
                layer.doNormalize = True
            Next
        End If
        If config.dropoutRate > 0 AndAlso config.dropoutRate < 1 Then
            Call trainingHelper.SetDropOut(percentage:=config.dropoutRate)
        End If

        For Each sample As Sample In samples.PopulateNormalizedSamples(alternativeNormalize:=config.normalize.TextEquals("min/max"))
            Call trainingHelper.Add(sample.status, sample.target)
        Next

        Helpers.MaxEpochs = config.iterations

        ' Call Console.WriteLine(trainingHelper.NeuronNetwork.ToString)

        If Not args("/GA.optimize").IsTrue Then
            Call trainingHelper.runTrainingCommon(
                out.TrimSuffix & ".debugger.CDF",
                [in],
                parallel,
                args("/debug"),
                config.scattered.ParseBoolean
            )
        Else
            Call trainingHelper _
                .NeuronNetwork _
                .RunGAAccelerator(
                    trainingSet:=trainingHelper.TrainingSet,
                    iterations:=config.iterations
                 )
        End If


        With trainingHelper.TakeSnapshot
            If config.scattered.ParseBoolean Then
                Return .ScatteredStore(out.TrimSuffix) _
                    .CLICode
            Else
                Return .GetXml _
                    .SaveTo(out) _
                    .CLICode
            End If
        End With
    End Function

    <Extension>
    Private Function runTrainingCommon(trainer As TrainingUtils,
                                       debugCDF$,
                                       inFile$,
                                       parallel As Boolean,
                                       debug As Boolean,
                                       multipleParts As Boolean) As TrainingUtils

        Dim debugger As New ANNDebugger(trainer.NeuronNetwork)
        Dim minError# = 999999
        Dim snapshotFile$ = inFile.TrimSuffix & ".minerr.Xml"
        Dim circle As VBInteger = 666

        Call Console.WriteLine(trainer.NeuronNetwork.ToString)
        Call trainer _
            .AttachReporter(Sub(i, err, model)
                                If debug Then
                                    Call debugger.WriteFrame(i, err, model)
                                End If

                                If err < minError Then
                                    ' 因为这个只是保存一个临时文件,可能在测试的时候会因为占用
                                    ' 这个临时文件而导致保存失败
                                    ' 所以在这里忽略掉这个错误就好了
                                    With trainer.TakeSnapshot
                                        Call $"  [{circle.Hex}] start write snapshot....".__DEBUG_ECHO
                                        Call $"  Current min_error={err}".__INFO_ECHO

                                        If multipleParts Then
                                            Call .ScatteredStore(snapshotFile.TrimSuffix)
                                        Else
                                            Call .GetXml.SaveTo(snapshotFile, throwEx:=False)
                                        End If

                                        Call $"  [{(++circle).ToHexString}] done!".__INFO_ECHO
                                    End With

                                    minError = err
                                End If

                                If i Mod 5 = 0 AndAlso trainer.dropOutRate > 0 Then
                                    ' 因为在dropout模式下,有一部分的神经元随机失活
                                    ' 所以非最小error的网络不一定是不和要求的
                                    ' 在开启dropout模式之后,程序会定时写网络文件供调试监控
                                    With trainer.TakeSnapshot
                                        Call $"  [{circle.Hex}] start write dropout snapshot....".__DEBUG_ECHO
                                        Call $"  Current min_error={err}".__INFO_ECHO

                                        If multipleParts Then
                                            Call .ScatteredStore(inFile.TrimSuffix & ".dropout")
                                        Else
                                            Call .GetXml.SaveTo(inFile.TrimSuffix & ".dropout.Xml", throwEx:=False)
                                        End If

                                        Call $"  [{(++circle).ToHexString}] done!".__INFO_ECHO
                                    End With
                                End If
                            End Sub) _
            .Train(parallel)

        If debug Then
            Call debugger.Save(cdf:=debugCDF, network:=trainer.NeuronNetwork)
        End If

        Return trainer
    End Function

    ''' <summary>
    ''' 使用测试训练数据集继续训练人工神经网络模型
    ''' </summary>
    ''' <param name="args"></param>
    ''' <returns></returns>
    ''' 
    <ExportAPI("/encourage")>
    <Usage("/encourage /model <ANN.xml> /samples <samples.Xml> [/parallel /debug /iterations <default=10000> /out <out.Xml>]")>
    Public Function Encourage(args As CommandLine) As Integer
        Dim in$ = args <= "/model"
        Dim samples$ = args <= "/samples"
        Dim out$ = args("/out") Or $"{[in].TrimSuffix}.encouraged.Xml"
        Dim parallel As Boolean = args("/parallel")
        Dim network As Network = [in].LoadXml(Of NeuralNetwork).LoadModel
        Dim training As New TrainingUtils(network)

        Helpers.MaxEpochs = args("/iterations") Or 10000

        For Each sample As Sample In samples.LoadXml(Of DataSet).PopulateNormalizedSamples()
            Call training.Add(sample.status, sample.target)
        Next

        Return training _
            .runTrainingCommon(out.TrimSuffix & ".debugger.CDF", [in], parallel, args("/debug"), False) _
            .TakeSnapshot _
            .GetXml _
            .SaveTo(out) _
            .CLICode
    End Function
End Module
