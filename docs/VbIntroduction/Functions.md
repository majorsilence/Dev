---
layout: base
title: Functions
---

In the last section we covered functions that do work but do not return any values.  The functions below will do work and also return a value.

The following function can be used to do a calculation an it will return a decimal value of the result.

```vb.net
Public Shared Function Calculate(ByVal num1 As Decimal, Byval num2 As Decimal, ByVal num3 As Decimal) As Decimal
	Dim finalValue As Decimal = num1 * num2
	finalValue = finalValue + num3
	
	Return finalValue
End Function
```

This function can compute a fibonacci sequence up to 100.  It returns an integer value with the count of how many loops were performed to run the calculation.

```vb.net
Public Shared Function FibonacciSequenceToOneHundred() As Integer
	' See http://en.wikipedia.org/wiki/Fibonacci_number
	' By definition, the first two Fibonacci numbers are 0 and 1, and each subsequent number is the sum of the previous two.

	Dim a As Integer = 0
	Dim b As integer = 1
	
	Dim loopCount As Integer = b
	
	While b < 1000		
		System.Console.WriteLine(b.Tostring)
		a = b
		b = a+b
		
		loopCount +=1
	End While
	
	return loopCount
End Function
```

The main sub calls each function and sets variables with their return values.

```vb.net
Public Shared Sub Main()
	Dim calculatedValue as Decimal = Calculate(5.25D, 2.0D, 10.50D)
	System.Console.WriteLine("The calculated value is {0}", calculatedValue.ToString)
	
	System.Console.WriteLine("")
	System.Console.WriteLine("Calculate how many times through the loop to do a fibonacci sequence to 1000.")
	Dim result As Integer = FibonacciSequenceToOneHundred()
	System.Console.WriteLine("Had to loop {0} times.  Never reached 1000 because of loop logic.", result)
End Sub
```

See: https://github.com/majorsilence/VB-Notes/tree/master/VbBook1/Functions