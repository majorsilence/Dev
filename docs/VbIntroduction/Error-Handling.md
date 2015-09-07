---
layout: base
title: Error Handling
---

You do not want invalid data to be entered into your programs.  You also do not want your program to crash if it does not need to.  

For example if you have a console application that is letting users entered numbers you do not want to have your program crash if a letter is entered.  One option is to use exception handling (try/catch).  The the specific error that you want to handle and display a message to the user.

Here we have some code that reads console in put and attempts to parse it as an integer.  Once parsed it calls the IsDataValid function to do some further business logic.

You should notice that the code is between a try and a catch.  What this does is if there is an exception the catch will catch it and you can handle the problem.  This example is catching all exceptions (Catch ex as Exception).  This is a bad way to handle exceptions.

The recommend approach is to catch the specific exception you mean to handle and let unexpected exceptions crash your program.  Or if you are catching all exception at least log the errors and then exit the program.  The reason is, if you are not handling/recovering from a particular exception your program is now in an unknown state.  

Since it is in an unknown state it is no longer safe to run.  So exit or crash the program.

```vb.net
Try
    While IsDataValid(Integer.Parse(Console.ReadLine())) = False
        System.Console.WriteLine("Invalid number.")
        System.Console.WriteLine("Enter a number between 1 and 100")
    End While
Catch ex as Exception
    System.Console.WriteLine(ex.Message)
End Try
```

A function that validates that the number entered is between 1 and 100.
```vb.net
Public Shared Function IsDataValid(ByVal input As Integer) As Boolean
    If input < 1 Then
        Return False
    End If
    If input > 100 Then
        Return False
    End If
    Return True
End Function
```


https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/ErrorHandling/Application.vb