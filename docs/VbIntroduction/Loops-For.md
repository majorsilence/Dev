---
layout: base
title: For Loop
---

Loops are used when you want to repeat some code [n] number of times.  It can be as simple as printing text to the console multiple times or prompting a user for multiple values. 

To see the example code that goes along with lesson go to https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/ForLoops/Application.vb.

The following example will print the numbers 0 - 100.  
```vb.net
For i As Integer = 0 To 100
    System.Console.WriteLine("Loop Count: " & i.ToString)
Next
```

The following example will print from 1 - 100:
```
For i As Integer = 1 To 100
    System.Console.WriteLine("Loop Count: " & i.ToString)
Next
```

Remember everything always starts from 0 so if you wanted to loop 100 times you should do:
```vb.net
For i As Integer = 0 To 99
    System.Console.WriteLine("Loop Count: " & i.ToString)
Next
```

For loops can also be used to loop through all values in a list.  For example if we have a generic list of strings and want to print all the values to the console we could do the following:
```vb.net
Dim a As New List(Of String)
a.Add("A string in the list")
a.Add("A second string in the list")
a.Add("You can use as many items as you want to the list")

For i As Integer = 0 To a.Count - 1
    System.Console.WriteLine(String.Format("Position {0} has value: {1}", i, a(i)))
Next
```