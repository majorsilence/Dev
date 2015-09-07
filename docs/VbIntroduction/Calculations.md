Using visual basic you can perform any type of calculation that is needed.  The four types that will be covered here are:
* Addition ``` + ```
* Subtration ``` - ```
* Multiplication ``` * ```
* Division ``` / ```

To see the example code that goes along with lesson go [https://github.com/majorsilence/VB-Notes/tree/master/VbBook1/Calculations/Application.vb](https://github.com/majorsilence/VB-Notes/tree/master/VbBook1/Calculations/Application.vb)

This example is going to use the variable a which is an Integer.  For an example using decimals see the code example linked above.
```vb.net
Dim a As Integer = 2
System.Console.WriteLine("A is: " & a.ToString)
```

The first example will cover addition.  You can add a number like so
```
1 + 1
```
In visual basic we will add 2 to the integer a we declared above.  This will make the variable a equal 4.

```vb.net
a = (a + 2) ' Addition
System.Console.WriteLine("A + 2 is: " & a.ToString)
```

To subtract a number from a, in this case 1, we will end up with 3.
```vb.net
a = (a - 1) ' Subtraction
System.Console.WriteLine("A - 1 is: " & a.ToString)
```

Next if we want to multiple we can do it like this.
```vb.net
a = (a * 3) ' Multiplication
System.Console.WriteLine("A * 3 is: " & a.ToString)
```
Now a is equal to 9.

The final action that we will perform is division.  We will divide 9 by 2 and it will equal 4.  You need to remember that we are doing integer calculations so any decimal places will be rounded up or down.  
```vb.net
a = CInt(a / 2) ' Division
System.Console.WriteLine("A / 2 is: " & a.ToString)
```  

You should have also noted the use of the function CInt.  When compiling vb in strict mode when the result will result in a decimal we cannot assign to an integer unless we cast the value.  CInt is a visual basic function to cast values.  For more details on casting or converting values see the [Convert](http://msdn.microsoft.com/en-us/library/system.convert.aspx) class in the .NET library.

If you want precise values you should use Decimals instead of Integers.