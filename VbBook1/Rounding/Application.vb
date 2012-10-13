Imports System

Public Class Application
	Public Shared Sub Main()
		System.Console.WriteLine("Welcome to the chapter on rounding.")
		System.Console.WriteLine("")
		
		' Bankers rounding:  MidpointRounding.ToEven - VB Defaults to this.  Good for statistical calculation
		' Arithmetic Rounding: MidpointRounding.AwayFromZero - However most financial calutions should be using Arithmetic rounding.
		
		System.Console.WriteLine("Arithmetic Rounding")
		' Arithmetic Roudning
		Dim a As Decimal = Math.Round(5.245D, 2, MidpointRounding.AwayFromZero) 
		System.Console.WriteLine("a: " & a.ToString)
		
		
		System.Console.WriteLine("")
		System.Console.WriteLine("Bankers Rounding")
		' Bankers Rounding
		' VB defaults to this if MidpointRounding is not specefied.
		Dim b As Decimal = Math.Round(5.245D, 2, MidpointRounding.ToEven)
		Dim c As Decimal = Math.Round(5.245D, 2)
		System.Console.WriteLine("b: " & b.ToString)
		System.Console.WriteLine("c: " & c.ToString)
		
	End Sub
	
	


End Class

