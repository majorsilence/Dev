

Public Class Application
	Public Shared Sub Main()
		System.Console.WriteLine("This chapter will teach basic math.")
		
		Dim a As Integer = 2
		System.Console.WriteLine("A is: " & a.ToString)
		
		a = (a + 2) ' Addition
		System.Console.WriteLine("A + 2 is: " & a.ToString)
		
		a = (a * 3) ' Multiplication
		System.Console.WriteLine("A * 3 is: " & a.ToString)
		
		a = cint(a / 2) ' Division
		System.Console.WriteLine("A / 2 is: " & a.ToString)
		
		System.Console.WriteLine("")
						
		Dim b As Decimal = 2.22D
		System.Console.WriteLine("B is: " & b.ToString)
		
		b = (b + 2) ' Addition
		System.Console.WriteLine("B + 2 is: " & b.ToString)
		b = (b + 1.65432D) ' Addition
		System.Console.WriteLine("B + 1.65432 is: " & b.ToString)
		
		b = (b * 3.01D) ' Multiplication
		System.Console.WriteLine("B * 3.01 is: " & b.ToString)
		
		b = (b / 2.4D) ' Division
		System.Console.WriteLine("B / 2.4 is: " & b.ToString)	
		
		System.Console.WriteLine("")
		System.Console.WriteLine("You can also of course do math without assigning the results to variables")
		System.Console.WriteLine(2+2)
	End Sub
End Class

