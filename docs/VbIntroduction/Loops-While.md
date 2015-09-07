For loops are not the only loops available in visual basic.  The while loop is another type.

To see the example code that goes along with lesson go to https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/WhileLoops/Application.vb

The while loop is used to continue looping while some condition is true.

The basic syntax is:
```vb.net
While True
    ' Do stuff
End While
```

Generally you will have a boolean variable declared and while it is true the loop will continue.  Inside the loop will test for some condition or maybe user input and if the correct input or condition is meet the loop will exit.

The following example declares the variable keepRunning and while its value true the while loop will continue.  Inside the while loop will prompt for user input on each iteration.  As soon as the user enters the letter "q" the variable keepRunning will equal true, finish the loop and then when it check if keepRunning is true on the next iteration exit the loop.
```vb.net
Dim keepRunning As Boolean = True

While keepRunning = True

    System.Console.WriteLine("Enter a String and press enter.")
    Dim input As String = Console.ReadLine()
    If input = "q" Then
        keepRunning = False ' The loop will exit 
        System.Console.WriteLine("The loop finishes before exiting.")
    End If
        
End While
```

The condition inside could be testing anything.  In a later lesson conditionals, if statements, will be covered.  The above code using an if statement to test if the input is the letter q.

You should review the sample code that is linked above.

