﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SMRUCC.genomics.AnalysisTools.CellularNetwork.PFSNet.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to                     GNU GENERAL PUBLIC LICENSE
        '''                       Version 3, 29 June 2007
        '''
        ''' Copyright (C) 2007 Free Software Foundation, Inc. &lt;http://fsf.org/&gt;
        ''' Everyone is permitted to copy and distribute verbatim copies
        ''' of this license document, but changing it is not allowed.
        '''
        '''                            Preamble
        '''
        '''  The GNU General Public License is a free, copyleft license for
        '''software and other kinds of works.
        '''
        '''  The licenses for most software and other practical works are designed
        '''to take away yo [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property gpl() As String
            Get
                Return ResourceManager.GetString("gpl", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to require(igraph)
        '''#require(rJava)
        '''
        '''loaddata&lt;-function(file){
        '''	a&lt;-read.table(file,row.names=1)
        '''	a
        '''}
        '''
        '''computew1&lt;-function(expr,theta1,theta2){
        '''	ranks&lt;-apply(expr,2,function(x){
        '''		rank(x)/length(x)
        '''	})
        '''	apply(ranks,2,function(x){
        '''		q2&lt;-quantile(x,theta2,na.rm=T)
        '''		q1&lt;-quantile(x,theta1,na.rm=T)
        '''		m&lt;-median(x)
        '''		mx&lt;-max(x)
        '''		sapply(x,function(y){
        '''			if(is.na(y)){
        '''				NA
        '''			}
        '''			else if(y&gt;=q1)
        '''				1
        '''			else if(y&gt;=q2)
        '''				(y-q2)/(q1-q2)
        '''			else
        '''				0
        '''		})
        '''	})
        '''}
        '''
        '''pfsnet.computegenelist&lt;-function(w,beta){
        '''	# within.m [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property pfsnet() As String
            Get
                Return ResourceManager.GetString("pfsnet", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
