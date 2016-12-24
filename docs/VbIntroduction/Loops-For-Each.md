---
layout: base
title: For Each Loop
---

For Each loops are similar to for loops but instead of looping using an incremental counter we loop through each position in the loop based on the type.  They are extremely easy to use.

To see the example code that goes along with lesson go to https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/ForEachLoops/Application.vb

Say we have the following list of strings.

```vb.net
Dim a As New List(Of String)
a.Add("Hello")
a.Add("World! ")
a.Add("It is a nice")
a.Add("night.")
```

To print each item to the console is as simple as:
```vb.net
For Each b As String In a
    System.Console.Write(b & " ")
Next
```

As can be seen to loop through a list of known types you just declare a variable, in this case b, and say in the list variables.  So in the above case we end up with:

```vb.net
For Each b As String In a
```


