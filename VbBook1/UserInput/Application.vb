Imports System

Public Class Application
	Public Shared Sub Main()
		' A nice thing about this example is it will demonstrate program
		' errors/exceptions if the wrong values are entered.
		' You will learn more about that in the data validation and
		' error handling chapters.
	
		System.Console.WriteLine("Enter a Integer and press enter")
		Dim a As Integer = CInt(Console.ReadLine())
		System.Console.WriteLine("You have entered the integer: " & a.ToString )
		System.Console.WriteLine("")
		
		System.Console.WriteLine("Enter a Decimal (eg 5.55) and press enter")
		Dim b As Decimal = CDec(Console.ReadLine())
		System.Console.WriteLine("You have entered the decimal: " & b.ToString)
		System.Console.WriteLine("")
			
		System.Console.WriteLine("Enter a String and press enter")
		Dim c As String = Console.ReadLine()
		System.Console.WriteLine("You have entered the string: " & c)
		System.Console.WriteLine("")
		
	End Sub
End Class

