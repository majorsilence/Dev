---
layout: base
title: Program the First
---

The first application you will write will print a few sentences to the console.

To see the example code that goes along with lesson go to [https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/ProgramTheFirst/Application.vb](https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/ProgramTheFirst/Application.vb).

The first thing you need to know is that visual basic applications need to have a Main function.  There should only be one main function in an application.  The main function tells the compiler where the program should start.  The main function needs to be declared as "Shared".  A shared function can be called directly without creating an instance of the class that it is in.   It is the equivalent of a static function in c, c++, or c#. There will be more on that when we get to the chapter on [Objects](https://github.com/majorsilence/VB-Notes/wiki/Objects).  For now I assume you know what objects are but you will not need to know until after the Objects lesson.

To declare the main function create a new file called Application.vb and write the following inside the class declartion.

```vb.net
Public Shared Sub Main()
End Sub
```

To print information to the console you use the System.Console.WriteLine function.  If you want to write "Hello World" to the console you would do it like this.

```vb.net
System.Console.WriteLine("Hello World")
```

See the screenshot below for how this should look or see the example code with link above.


# Enable Option Script
To enable option strict right click the project in MonoDevelop/Xamarin Studio and select "Options"
![Menu](Chapter001-Application-001.png)

Once the options are opened go to the Build -> General tab.  Find "Option Strict" and make sure it is set to "On".  This will help catch a lot of errors and help enforce good coding habits.  It is also a requirement to make sure your code can compile using mono (means Mac and Linux support).
![Properties](Chapter001-Application-002.png)
