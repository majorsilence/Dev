This has probably already been spotted in an earlier chapter but who cares.  It will be covered here anyway.  If and Else are used to test which path to follow based on the conditions that are specified.

The following example shows how if statements can be used.  Note that they can be used any type, not just integers. 

```vb.net
Private Shared Sub PrintPointLessMessage(ByVal numberValue As Integer)
	If numberValue < 10 Then
		System.Console.WriteLine("A is less then 10")
	ElseIf numberValue > 10 Then
		System.Console.WriteLine("A is greater then 10")
	ElseIf numberValue = 10 Then
		System.Console.WriteLine("Hurray, a is 10")
	End If
End Sub
```

The example function is passed a integer.  Depending if the value __numberValue__ is less/greater/equal to 10 a different message is printed.  As you can see if one then one condition is being tested you can use if/elseif/endif.


See: https://github.com/majorsilence/VB-Notes/tree/master/VbBook1/Conditionals-If-Else