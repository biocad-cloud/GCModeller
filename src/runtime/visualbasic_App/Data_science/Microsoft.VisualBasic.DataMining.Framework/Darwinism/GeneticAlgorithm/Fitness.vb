﻿
' *****************************************************************************
' Copyright 2012 Yuriy Lagodiuk
' 
' Licensed under the Apache License, Version 2.0 (the "License");
' you may not use this file except in compliance with the License.
' You may obtain a copy of the License at
' 
'   http://www.apache.org/licenses/LICENSE-2.0
' 
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' See the License for the specific language governing permissions and
' limitations under the License.
' *****************************************************************************

Imports Microsoft.VisualBasic.DataMining.Darwinism.Models

Namespace Darwinism.GAF

    Public Interface Fitness(Of C As Chromosome(Of C), T As IComparable(Of T))

        ''' <summary>
        ''' Assume that chromosome1 is better than chromosome2 <br/>
        ''' fit1 = calculate(chromosome1) <br/>
        ''' fit2 = calculate(chromosome2) <br/>
        ''' So the following condition must be true <br/>
        ''' fit1.compareTo(fit2) &lt;= 0 <br/>
        ''' (假若是并行模式的之下，还要求这个函数是线程安全的)
        ''' </summary>
        Function Calculate(chromosome As C) As T
    End Interface
End Namespace