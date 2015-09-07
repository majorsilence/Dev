This lesson will be providing a basic overview of getting input from a user from the console.

To see the example code that goes along with lesson go to [https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/UserInput/Application.vb](https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/UserInput/Application.vb).

To read input from the console use System.Console.ReadLine() to retrieve all entered data until the Enter key is pressed.  Alternatively to retrieve only one character use System.Console.Read().

To read a string do this.
```vb.net
Dim s As String = Console.ReadLine()
```
This example will read all input until the user presses the Enter key.

If you want to read a different type such as as Integer or Decimal you will need to cast the value that is read.  Casting is converting a value from one type to another type.  To cast from one basic type to another in visual basic there are several helper functions.

* CDec - cast to decimal
* CDbl - cast to double
* CInt - cast to integer
* CDate - cast to date
* <a href="http://msdn.microsoft.com/en-us/library/4x2877xb(v=vs.100).aspx">CType</a>(value, type) - convert any value to any support type
* <a href="http://msdn.microsoft.com/en-us/library/7k6y2h6x(v=vs.100).aspx">DirectCast</a>(value, type) - convert any value to any supported type
* <a href="http://msdn.microsoft.com/en-us/library/system.convert(v=vs.90).aspx">Convert</a> - Class used to convert various types.

Read the provided links on CType and DirectCast for the differences between the two.  One important note is that when casting you need to make sure the value you are casting will be a valid type.  You should also browse the documentation on the convert  class to see all the provided casting functionality.

For example you can use CDec("5.33") and that will work because the string "5.33" can be converted to a decimal.  However doing CDec("Hello World") will throw an exception because the string "Hello World" cannot be converted to a decimal.

If we want to read an integer from the console do it like this.
```vb.net
Dim i As Integer = CInt(Console.ReadLine())
```

To read a decimal to this.
```vb.net
Dim d As Integer = CDec(Console.ReadLine())
```

You would do the same thing for any type that you wish to read in.  Be careful though because attempting to cast an invalid value will through an exception and crash the program.  Later in the lesson on [Error Handling](https://github.com/majorsilence/VB-Notes/wiki/Error-Handling) you will learn to handle errors.

# Screenshot

The screenshot below shows a prompt for an integer that was entered by the end user and is currently prompting for a decimal.
![Screenshot showing console input](images/UserInputApplication.png)