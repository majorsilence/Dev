imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
		
		Dim a As New List(Of String)
		a.Add("A string in the list")
		a.Add("A second string in the list")
		a.Add("You can use as many items as you want to the list")
		System.Console.WriteLine("Generic Lists")
		System.Console.WriteLine("a(0) " & a(0))
		System.Console.WriteLine("a(1) " & a(1))
		System.Console.WriteLine("a(2) " & a(2))
		System.Console.WriteLine("")
		
		Dim b(3) As String
		b(0) = "String One"
		b(1) = "String Two"
		b(2) = "String Three"
		System.Console.WriteLine("String Array")
		System.Console.WriteLine("b(0) " & b(0))
		System.Console.WriteLine("b(1) " & b(1))
		System.Console.WriteLine("b(2) " & b(2))
		System.Console.WriteLine("")
		
		Dim c(3) As Integer
		c(0) = 43
		c(1) = 0
		c(2) = 1
		System.Console.WriteLine("Integer Array")
		System.Console.WriteLine("c(0) " & c(0))
		System.Console.WriteLine("c(1) " & c(1))
		System.Console.WriteLine("c(2) " & c(2))
		System.Console.WriteLine("")
		
	End Sub
End Class

