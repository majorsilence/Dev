

Public Class Application

	Public Shared Sub Main()
	
		PrintPointLessMessage(10) ' Prints third message
		PrintPointLessMessage(9) ' Prints first message
		PrintPointLessMessage(11) ' Prints second message
		
	End Sub
	
	Private Shared Sub PrintPointLessMessage(ByVal numberValue As Integer)
		If numberValue < 10 Then
			System.Console.WriteLine("A is less then 10")
		ElseIf numberValue > 10 Then
			System.Console.WriteLine("A is greater then 10")
		ElseIf numberValue = 10 Then
			System.Console.WriteLine("Hurray, a is 10")
		End If
	End Sub
	
End Class

