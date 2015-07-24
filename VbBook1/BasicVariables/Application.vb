

Public Class Application
	Public Shared Sub Main()
		
		Dim a As Integer = 1
		Dim b As String = "This is a string"
		Dim c As Decimal = 2.22D
		Dim d As Boolean = True
		
		System.Console.WriteLine("a: " & a.ToString)
		System.Console.WriteLine("b: " & b)
		System.Console.WriteLine("c: " & c.ToString)
		System.Console.WriteLine("d: " & d.ToString)
		
		' This will print an empty line.
		System.Console.WriteLine("")
				
		a = 44
		b = "See, I have changed the value of the b string variable."
		c = 5.55642d
		d = False
		
		System.Console.WriteLine("Now we see that the values have changed.")
		System.Console.WriteLine("a: " & a.ToString)
		System.Console.WriteLine("b: " & b)
		System.Console.WriteLine("c: " & c.ToString)
		System.Console.WriteLine("d: " & d.ToString)

	End Sub
End Class

