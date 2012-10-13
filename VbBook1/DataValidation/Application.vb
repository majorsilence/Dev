Imports System

Public Class Application
	Public Shared Sub Main()
		System.Console.WriteLine("Welcome to the data validation chapter.")
		
		InputData()
		
	End Sub
	
	Public Shared Sub InputData()
		System.Console.WriteLine("Enter a number between 1 and 100")
		
		While IsDataValid(Integer.Parse(Console.ReadLine())) = False
			System.Console.WriteLine("Invalid number.")
			System.Console.WriteLine("Enter a number between 1 and 100")
		End While
	End Sub
	
	Public Shared Function IsDataValid(ByVal input As Integer) As Boolean
		If input < 1 Then
			Return False
		End If
		
		If input > 100 Then
			Return False
		End If
		
		Return True
	End Function
	
End Class

