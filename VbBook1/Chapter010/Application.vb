

Public Class Application
	Public Shared Sub Main()
		
		Dim keepRunning As Boolean = True
		System.Console.WriteLine("This loop will continue until the value entered is q.")
		
		Dim loopCount As Integer = 0
		
		While keepRunning = True
		
			System.Console.WriteLine("Enter a String and press enter.")
			Dim input As String = Console.ReadLine()
			If input = "q" Then
				keepRunning = False ' The loop will exit 
				System.Console.WriteLine("The loop finishes before exiting.")
			End If
				
			loopCount += 1
			System.Console.WriteLine("Has looped {0} times.", loopCount.ToString)
		End While
		
	End Sub
End Class

