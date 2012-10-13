imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
		System.Console.WriteLine("For Each Loop Chapter Example.")
		System.Console.WriteLine("")
		
		Dim a As New List(Of String)
		a.Add("Hello")
		a.Add("World! ")
		a.Add("It is a nice")
		a.Add("night.")
		
		For Each b As String In a
			System.Console.Write(b & " ")
		Next
		
		System.Console.WriteLine("")
		System.Console.WriteLine("")
		System.Console.WriteLine("The above uses Write instead of WriteLine.")
		System.Console.WriteLine("Write writes everything on the same line.")
		
	End Sub
End Class

