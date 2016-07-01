﻿Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.ObjectModels.Module
Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.Services.DataAcquisition.Services
Imports SMRUCC.genomics.GCModeller.ModellingEngine.EngineSystem.Services.MySQL

Namespace EngineSystem.ObjectModels.SubSystem

    ''' <summary>
    ''' degradation event handler for the <see cref="ObjectModels.Entity.Transcript"></see> and <see cref="ObjectModels.Entity.Peptide"></see>
    ''' </summary>
    ''' <typeparam name="MolecularType"></typeparam>
    ''' <remarks></remarks>
    Public Class DisposerSystem(Of MolecularType As Entity.IDisposableCompound)
        Inherits CellComponentSystemFramework(Of DisposableCompound(Of MolecularType))

        <DumpNode> Dim Type As Entity.IDisposableCompound.DisposableCompoundTypes

        Protected Friend Overrides ReadOnly Property SystemLogging As Logging.LogFile
            Get
                Return _CellComponentContainer.SystemLogging
            End Get
        End Property

        Dim DisposibleMetabolites As MolecularType()

        Sub New(DisposibleMetabolites As EngineSystem.ObjectModels.Entity.IDisposableCompound(), Metabolism As SubSystem.MetabolismCompartment, Type As Entity.IDisposableCompound.DisposableCompoundTypes)
            Call MyBase.New(Metabolism)
            Me.DisposibleMetabolites = DisposibleMetabolites
            Me.Type = Type
            Me._CellComponentContainer = Metabolism
            Me.IRuntimeContainer = Metabolism.get_runtimeContainer
        End Sub

        Public Overrides Function CreateServiceSerials() As IDataAcquisitionService()
            Return New IDataAcquisitionService() {
                New DataAcquisitionService(New EngineSystem.Services.DataAcquisition.DataAdapters.DisposableSystem(Of MolecularType)(Me, Type), Me.IRuntimeContainer)
            }
        End Function

        Public Overrides Function Initialize() As Integer
            Dim Metabolism = DirectCast(Me._CellComponentContainer, SubSystem.MetabolismCompartment)

            Dim CreationMethod As Func(Of EngineSystem.ObjectModels.Entity.IDisposableCompound,
                                          EngineSystem.ObjectModels.SubSystem.MetabolismCompartment,
                                          Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Metabolism.DispositionReactant,
                                          EngineSystem.ObjectModels.Entity.Compound(),
                                          String(),
                                          [Module].DisposableCompound(Of MolecularType))

            Dim ProductMetabolites As EngineSystem.ObjectModels.Entity.Compound()
            Dim ConstraintMetabolite = Metabolism.ConstraintMetabolite
            Dim EnzymeIdList As String()

            If Type = Entity.IDisposableCompound.DisposableCompoundTypes.Polypeptide Then
                CreationMethod = AddressOf EngineSystem.ObjectModels.Module.DisposableCompound(Of MolecularType).CreatePeptideDisposalObject
                ProductMetabolites = New EngineSystem.ObjectModels.Entity.Compound() {ConstraintMetabolite.CONSTRAINT_ALA,
                                                                                      ConstraintMetabolite.CONSTRAINT_ARG,
                                                                                      ConstraintMetabolite.CONSTRAINT_ASP,
                                                                                      ConstraintMetabolite.CONSTRAINT_ASN,
                                                                                      ConstraintMetabolite.CONSTRAINT_CYS,
                                                                                      ConstraintMetabolite.CONSTRAINT_GLN,
                                                                                      ConstraintMetabolite.CONSTRAINT_GLU,
                                                                                      ConstraintMetabolite.CONSTRAINT_GLY,
                                                                                      ConstraintMetabolite.CONSTRAINT_HIS,
                                                                                      ConstraintMetabolite.CONSTRAINT_ILE,
                                                                                      ConstraintMetabolite.CONSTRAINT_LEU,
                                                                                      ConstraintMetabolite.CONSTRAINT_LYS,
                                                                                      ConstraintMetabolite.CONSTRAINT_MET,
                                                                                      ConstraintMetabolite.CONSTRAINT_PHE,
                                                                                      ConstraintMetabolite.CONSTRAINT_PRO,
                                                                                      ConstraintMetabolite.CONSTRAINT_SER,
                                                                                      ConstraintMetabolite.CONSTRAINT_THR,
                                                                                      ConstraintMetabolite.CONSTRAINT_TRP,
                                                                                      ConstraintMetabolite.CONSTRAINT_TYR,
                                                                                      ConstraintMetabolite.CONSTRAINT_VAL}
                EnzymeIdList = Strings.Split(_CellComponentContainer.get_runtimeContainer.SystemVariable(Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.ComponentModels.SystemVariables.ID_POLYPEPTIDE_DISPOSE_CATALYST), "; ")
            Else
                CreationMethod = AddressOf EngineSystem.ObjectModels.Module.DisposableCompound(Of MolecularType).CreateTranscriptDisposalObject
                ProductMetabolites = New EngineSystem.ObjectModels.Entity.Compound() {ConstraintMetabolite.CONSTRAINT_ADP,
                                                                                      ConstraintMetabolite.CONSTRAINT_GTP,
                                                                                      ConstraintMetabolite.CONSTRAINT_CTP,
                                                                                      ConstraintMetabolite.CONSTRAINT_UTP}
                EnzymeIdList = Strings.Split(_CellComponentContainer.get_runtimeContainer.SystemVariable(Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.ComponentModels.SystemVariables.ID_TRANSCRIPT_DISPOSE_CATALYST), "; ")
            End If

            Dim Model = [Module].DisposableCompound(Of MolecularType).GetModelBase(Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Metabolism.DispositionReactant.GENERAL_TYPE_ID_POLYPEPTIDE, Metabolism._CellSystem.DataModel.DispositionModels)

#If DEBUG Then
            Dim LQuery = (From item In DisposibleMetabolites Select CreationMethod(item, Metabolism, Model, ProductMetabolites, EnzymeIdList)).ToArray
#Else
            Dim LQuery = (From item In DisposibleMetabolites.AsParallel Select CreationMethod(item, Metabolism, Model, ProductMetabolites, EnzymeIdList)).ToArray
#End If
            MyBase._DynamicsExprs = LQuery.AddHandle.ToArray

            If Type = Entity.IDisposableCompound.DisposableCompoundTypes.Transcripts Then
                Dim WeightVector As Dictionary(Of SMRUCC.genomics.GCModeller.ModellingEngine.Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Bacterial_GENOME.Transcript.TranscriptTypes, Double) =
                    New Global.System.Collections.Generic.Dictionary(Of Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Bacterial_GENOME.Transcript.TranscriptTypes, Double)
                Call WeightVector.Add(Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Bacterial_GENOME.Transcript.TranscriptTypes.mRNA, IRuntimeContainer.ConfigurationData.LambdaWeight_mRNA)
                Call WeightVector.Add(Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Bacterial_GENOME.Transcript.TranscriptTypes.rRNA, IRuntimeContainer.ConfigurationData.LambdaWeight_rRNA)
                Call WeightVector.Add(Assembly.DocumentFormat.GCMarkupLanguage.GCML_Documents.XmlElements.Bacterial_GENOME.Transcript.TranscriptTypes.tRNA, IRuntimeContainer.ConfigurationData.LambdaWeight_tRNA)

                For i As Integer = 0 To _DynamicsExprs.Count - 1
                    Dim TranscriptDispose As Entity.Transcript = DirectCast(_DynamicsExprs(i).DisposalSubstrate, Entity.Transcript)
                    Dim LambdaWeight As Double = WeightVector(TranscriptDispose._TranscriptModelBase.TranscriptType)
                    TranscriptDispose.Lamda += LambdaWeight
                Next
            End If

            Return Me._DynamicsExprs.Count
        End Function

        Public Overrides Sub MemoryDump(Dir As String)
            Call Me.I_CreateDump.SaveTo(String.Format("{0}/{1}.log", Dir, Me.GetType.Name))
        End Sub
    End Class
End Namespace