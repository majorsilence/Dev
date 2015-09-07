Functions are used to break code apartment into smaller chunks.  Functions should do one task and do it well.  Functions can be called again and again.  They are used to keep duplicate code from building up.  This makes things easier to understand.  They can be chained/used together to perform complex tasks.

To see the example code that goes along with lesson go to https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/BasicFunctions/Application.vb.

Functions can return a value or return no value.  In vb functions that return a value use the key word **Function** and ones that do not return a value use the keyword **Sub**.

```vb.net
Public Shared Sub AUserDefinedFunction()
    ' Do stuff
End Sub
```

This example will only use the keyword **Sub**.  Functions can have parameters.  Parameters are values that are passed to the function from the code that is calling the function.  Parameters can be any variable type that was covered in the [earlier variables](https://github.com/majorsilence/VB-Notes/wiki/Variables---Basic) section or any [custom object](https://github.com/majorsilence/VB-Notes/wiki/Objects).

The following is a function called PrintMessage that takes one parameter of type string called message.
```vb.net
Public Shared Sub PrintMessage(ByVal message As String)
    System.Console.WriteLine(message)
End Sub
```

You can put any code you like inside a function.  The above function is simple and only prints to the console the string that is passed in.

Functions can have multiple parameters.  The next example will be passed two integer parameters and swap their values.

```vb.net
Public Shared Sub SwapValues(ByRef num1 As Integer, ByRef num2 As Integer)
    Dim valueHolder As Integer = num1
    num1 = num2
    num2 = valueHolder
End Sub
```

Function parameters can be passed as either **ByVal** or **ByRef**.  
* [ByVal](http://msdn.microsoft.com/en-us/library/h2b185t2.aspx) - the variable is copied and the value is passed to the function.  Changes to the value inside the function should not change the value outside the function in the calling location.
* [ByRef](http://msdn.microsoft.com/en-us/library/c84t73c2.aspx) - the variable is passed by reference.  This means the function is directly pointing to the variable from the calling location.  If you change the value of the variable in the function it also changes the value of the variable in the location that called the function.

Since the SwapValues parameters are ByRef when we change the values inside the location that called them have the values changed as well.

The following example the value of a is 7 and b is 12.  After calling SwapValues a is 12 and b is 7.
```vb.net
Dim a As Integer = 7
Dim b as Integer = 12
System.Console.WriteLine("a is: " & a.ToString)
System.Console.WriteLine("b is: " & b.ToString)
SwapValues(a, b)
System.Console.WriteLine("a after SwapValues is: " & a.ToString)
System.Console.WriteLine("b after SwapValues is: " & b.ToString)
```