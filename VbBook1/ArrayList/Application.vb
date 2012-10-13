imports System.Collections

Public Class Application
	Public Shared Sub Main()
		' An array list is a list of any type.
		System.Console.WriteLine("Using an ArrayList.")
		System.Console.WriteLine("I generally avoid ArrayLists but they do work.")
		
		Dim a As New ArrayList()
		a.Add("A String")
		a.Add(1)
		a.Add("a"c)
		a.Add(343.32D)
		
		System.Console.WriteLine("")
		System.Console.WriteLine("a(0) " & a(0).ToString)
		System.Console.WriteLine("a(0) type " & a(0).GetType().ToString)
		System.Console.WriteLine("")
		
		System.Console.WriteLine("a(1) " & a(1).ToString)
		System.Console.WriteLine("a(1) type " & a(1).GetType().ToString)
		System.Console.WriteLine("")
		
		System.Console.WriteLine("a(2) " & a(2).ToString)
		System.Console.WriteLine("a(2) type " & a(2).GetType().ToString)
		System.Console.WriteLine("")
		
		System.Console.WriteLine("a(3) " & a(3).ToString)
		System.Console.WriteLine("a(3) type " & a(3).GetType().ToString)
		System.Console.WriteLine("")
				
	End Sub
End Class

