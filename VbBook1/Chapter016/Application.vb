

Public Class Application
	Public Shared Sub Main()
		System.Console.WriteLine("Welcome to the data validation chapter.")
		
		Message()
		While System.Console.ReadLine().ToLower = "y"
			InputData()
			Message()
		End While
			
	End Sub
	
	Private Shared Sub Message()
		System.Console.WriteLine("Press Y and Enter to input data.")
		System.Console.WriteLine("Press anything else and Enter to exit.")
	End Sub
	
	Public Shared Sub InputData()
		System.Console.WriteLine("Enter a number between 1 and 100")
		
		Try
			While IsDataValid(Integer.Parse(Console.ReadLine())) = False
				System.Console.WriteLine("Invalid number.")
				System.Console.WriteLine("Enter a number between 1 and 100")
			End While
		Catch ex as Exception
			System.Console.WriteLine(ex.Message)
		End Try
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

