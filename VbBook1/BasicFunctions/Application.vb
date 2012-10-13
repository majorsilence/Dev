

Public Class Application
	Public Shared Sub Main()
		System.Console.WriteLine("Welcome to the chapter on functions.")
		
		PrintMessage("This is not that useful of a function.")
		PrintMessage("I concur.  We can find a better use for a function.")
		
		Dim a As Integer = 5
		Dim b as Integer = 12
		System.Console.WriteLine("a is: " & a.ToString)
		System.Console.WriteLine("b is: " & b.ToString)
		SwapValues(a, b)
		System.Console.WriteLine("a after SwapValues is: " & a.ToString)
		System.Console.WriteLine("b after SwapValues is: " & b.ToString)
		
		System.Console.WriteLine("Now lets swap a and b back to their begining values using the generic swap function.")
		SwapGeneric(a, b)
		System.Console.WriteLine("a after SwapGeneric is: " & a.ToString)
		System.Console.WriteLine("b after SwapGeneric is: " & b.ToString)
		
	End Sub
	
	Public Shared Sub PrintMessage(ByVal message As String)
		System.Console.WriteLine(message)
	End Sub
		
	' Will swap integer values
	Public Shared Sub SwapValues(ByRef num1 As Integer, ByRef num2 As Integer)
		Dim valueHolder As Integer = num1
		num1 = num2
		num2 = valueHolder
	End Sub
	
	' Will swap any values as long as they are the same type
	Public Shared Sub SwapGeneric(Of T)(ByRef num1 As T, ByRef num2 As T)
		Dim valueHolder As T = num1
		num1 = num2
		num2 = valueHolder
	End Sub
	
End Class

