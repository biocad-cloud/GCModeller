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
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SMRUCC.genomics.AnalysisTools.ClustalOrg.Resources", GetType(Resources).Assembly)
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
        '''  Looks up a localized string similar to * Clustal Omega:
        '''Fabian Sievers   UCD Dublin, Ireland
        '''Andreas Wilm     UCD Dublin, Ireland
        '''David Dineen     UCD Dublin, Ireland
        '''Johannes Söding  Gene Center Munich, Germany
        '''Michael Remmert  Gene Center Munich, Germany
        '''
        '''* Clustal 2
        '''Mark Larkin      UCD Dublin, Ireland
        '''
        '''* Clustal 1.X
        '''Toby Gibson      EMBL Heidelberg, Germany
        '''Des Higgins      UCC Cork, Ireland
        '''Julie Thompson   IGBMC Strasbourg, France
        '''
        '''* Contributors:
        '''Chenna Ramu      EMBL Heidelberg, Germany
        '''Nigel Brown      EMBL Heidelberg,  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property AUTHORS() As String
            Get
                Return ResourceManager.GetString("AUTHORS", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property ChangeLog() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("ChangeLog", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property clustalo() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("clustalo", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to                     GNU GENERAL PUBLIC LICENSE
        '''                       Version 2, June 1991
        '''
        ''' Copyright (C) 1989, 1991 Free Software Foundation, Inc.,
        ''' 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA
        ''' Everyone is permitted to copy and distribute verbatim copies
        ''' of this license document, but changing it is not allowed.
        '''
        '''                            Preamble
        '''
        '''  The licenses for most software are designed to take away your
        '''freedom to share and change it.  By contrast, the GNU General Publi [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property COPYING() As String
            Get
                Return ResourceManager.GetString("COPYING", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property icon() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("icon", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to The impatient can try:
        '''
        '''$ ./configure
        '''$ make
        '''$ make install
        '''
        '''
        '''Clustal-Omega needs argtable2 (http://argtable.sourceforge.net/). If
        '''argtable2 is installed in a non-standard directory you might have to
        '''point configure to its installation directory. For example, if you are
        '''on a Mac and have argtable installed via MacPorts then you should use
        '''the following command line:
        '''
        '''$ ./configure CFLAGS=&apos;-I/opt/local/include&apos; LDFLAGS=&apos;-L/opt/local/lib&apos;
        '''
        '''ClustalO will automatically support multi-threading if  [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property INSTALL() As String
            Get
                Return ResourceManager.GetString("INSTALL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property libgcc_s_dw2_1() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("libgcc_s_dw2_1", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property libgomp_1() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("libgomp_1", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property libstdc___6() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("libstdc___6", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property mingwm10() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("mingwm10", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property pthreadGC2() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("pthreadGC2", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized resource of type System.Byte[].
        '''</summary>
        Friend ReadOnly Property README() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("README", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
    End Module
End Namespace
