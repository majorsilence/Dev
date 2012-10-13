Imports System

Public Class Application
	Public Shared Sub Main()
		Dim a As Char = "a"c
		Dim b As DateTime = DateTime.Now
		Dim c As Double = 1.1345
		
		' Please do not do this with objects.  Use the correct data types.
		Dim d As Object = "Hello" ' Should be String
		Dim e As Object = 1 ' Should be Integer
		Dim f As Object = True ' Should be Boolean
		Dim g As Object = 34.233D ' Should be Decimal
		
		System.Console.WriteLine("a: " & a.ToString)
		
		' There are a lot of cool functions that can be used with DateTime variables but for now 
		' this exmaple will stick with these three.
		System.Console.WriteLine("b: " & b.ToString)
		System.Console.WriteLine("b: " & b.ToShortDateString)
		System.Console.WriteLine("b: " & b.AddDays(15).ToString)
		
		' Change the DateTime local culture
		
		System.Console.WriteLine("c: " & c.ToString)
		System.Console.WriteLine("d: " & d.ToString)
		System.Console.WriteLine("e: " & e.ToString)
		System.Console.WriteLine("f: " & f.ToString)
		System.Console.WriteLine("g: " & g.ToString)
		
		' This will print an empty line.
		System.Console.WriteLine("")
						
	End Sub
End Class

