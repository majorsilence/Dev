---
layout: post
title: Dotnet Development
date: 2023-04-07
last_modified: 2023-04-07
---


**DRAFT**

## C# and VB Basics

All examples assume the [target framework](https://learn.microsoft.com/en-us/dotnet/standard/frameworks) .NET 6(net6.0).

### Variables

Variables are the basic working blocks in code.  You use variables to hold values.  There are several different variable types but in this lesson we will cover only four of them.


To declare a variable you use the language keyword "Dim" used with a name and "As".  So if you want a string called "Hello World" named TestVariable you would declare it like this.

```vb
Dim TestVariable As String = "Hello World"
```

```cs
string TestVariable = "Hello World";
```

This example declares a variable and assigns a value at the same time.  However you can declare a variable without assigning value.  The value can always be assigned later.  A good general rule is only declare a variable when it is ready to be used (assigned) when possible.

* Integer - are like whole numbers but can contain negatives
* String - contain multiple characters
* Decimal - numbers with decimals
* Boolean - is true or false

#### Integers
Integers are like whole numbers but can contain negatives.  So they have negatives, zero, or positives.

For example -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 are all integer values.  

To declare an integer you can do this.

```vb
Dim i As Integer
```

```cs
int i;
```

This example creates a new variable of type Integer name i.  It does not assign any value to i.  To assign a value to i you can do it like this.

```vb
i=1
```

```cs
i=1;
```

Now the value of i is 1.

```vb
i=2
```

```cs
i=2;
```

Now the value of i is 2.

#### Strings
Strings can hold any value.  They can have letters, numbers, special characters.  They can be long or short

To declare a string you can do this.

```vb
Dim s As String
```

```cs
string s;
```

This example creates an empty string called s.  This string has no value

To assign the value "hello world" to the variable s we would do.

```vb
s = "hello world"
```

```cs
s = "hello world";
```


The value of the variable can be reassigned at any time so if we want to change the value to "purple monkey dishwasher" just do the same as above put with the new string.

```vb
s = "purple monkey dishwasher"
```

```cs
s = "purple monkey dishwasher";
```

If we want to see the value of a variable printed to the console we can write.

```vb
System.Console.WriteLine("The value of s is: " & s)
```

```cs
System.Console.WriteLine($"The value of s is: {s}");
```

We see here that s is value is append to the string "The value of s is: " and then printed to the console as "The value of s is: purple monkey dishwasher".  You can append any string to any other string at any time using the & symbol.

##### StringBuilder
If you are appending to a string again and again or changing it value over and over again this can become very slow.  String operations like this can be speed up using the StringBuilder class. 

To use a string builder you need to initialize System.Text.StringBuilder.

```vb
Dim builder As New System.Text.StringBuilder
builder.Append("Hello World ")
builder.Append("Peter.  ")
builder.Append("Have a good day.")

System.Console.WriteLine(builder.ToString)
```

```cs
var builder = new System.Text.StringBuilder();
builder.Append("Hello World ");
builder.Append("Peter.  ");
builder.Append("Have a good day.");

System.Console.WriteLine(builder.ToString());
```

This will print "Hello World Peter.  Have a good day.".

What this does is keep adding to a buffer and when you call the ToString method it finally creates a string.   This is much faster then concatenating the string together like the following.

```vb
System.Console.WriteLine("Hello World " & "Peter.  " & "Have a good day.")
```

```cs
System.Console.WriteLine("Hello World " + "Peter.  " + "Have a good day.");
```

This example probably is not faster since it is so tiny but if you did this with 100 000 strings the string builder would be much faster.

#### Decimals

Decimals are used when you need numeric values that contain decimals places.  It is essential if you are doing financial calculations that you use decimals and no other data type.  Do not use doubles.

For example -5.32, -4.76, -3.7654, -2.1, -1.343, 0.13, 1.786555, 2.2, 3.765, 4.22, 5.3446 are all decimal values.  

To declare a decimal you can do this.

```vb
Dim d As Decimal = 4.444D
```

```cs
decimal d = 4.444m;
```

This example creates a new variable of type Decimal with the name d and a value of 4.444d

To assign a new value to d you can do it like this.

```vb
d=5.437D
```

```cs
d = 5.437m;
```

Now the value of d is 5.437.

```vb
d=2.55
```

```cs
d = 2.55m;
```

Now the value of d is 2.55.  As shown above variables in function can always be reassigned new values

#### Booleans

Booleans are variables that can be either True or False.  That is all they hold.  Booleans default to false.

To declare a boolean you can do this.

```vb
Dim b As Boolean = False
```

```cs
bool b = false;
```

This example creates a new variable of type Boolean named b.  It does not assign any value to b.  To assign a value to b you can do it like this.

```vb
b=True
```

```cs
b=true;
```

Now the value of b is True.

```vb
b=False
```

```cs
b=false;
```

Now the value of b is False.

There is no other value that a boolean can hold.  If you do not set a value a boolean will default to False.

#### Chars
Chars are variables that can hold one character and only one character.  It can be any character available but only one character at a time.

To declare a char you do this.

```vb
Dim c As Char
```

```cs
char c;
```

This example creates a new variable of type Char named c.  It does not assign any value to c.  To assign a value to c you can do it like this.

```vb
c="A"c
```

```cs
c='A';
```

Now the value of c is A.

```vb
c="~"c
```

```cs
c='~';
```

Now the value of c is ~.

As is written above any character can be held in a char variable but only one character at a time.  Like any other variable type you can print the variable to the console using like this.

```vb
System.Console.WriteLine(c)
```

```cs
System.Console.WriteLine(c);
```


#### DateTime
DateTime variables can hold a date and time value.  If you just want a date you can also use Date instead of DateTime.

To declare a DateTime you do this.

```vb
Dim t As DateTime
```

```cs
DateTime t;
```

This example creates a new variable of type DateTime named t.  It does not assign any value to t.  To assign a value to t you can do it like this.

```vb
t = DateTime.Now
```

```cs
t = DateTime.Now;
```

This assigns the current date and time to the variable t.

If you want to assign a specific date such as 01 may 2012, do it like this.

```vb
t = New DateTime(2012, 5, 1)
```

```cs
t = new DateTime(2012, 5, 1);
```

Now the date of t would now be 01 May 2012 with a time of 00:00:00.

If you want to print the date to the console you can use several of its functions to print in different formats.

```vb
System.Console.WriteLine(t.ToString)
System.Console.WriteLine(t.ToShortDateString)
```

```cs
System.Console.WriteLine(t.ToString());
System.Console.WriteLine(t.ToShortDateString());
```

There are several other functions that can be looked up and used but generally I find these are the two that I use most often.

#### Doubles
Doubles are variables that hold numeric values with decimal places.  They are similar to the decimal variable type but are less accurate and accumulate rounding errors when calculations are performed.

To declare a double you do this.

```vb
Dim d As Double
```

```cs
double d;
```


This example creates a new variable of type Double named d.  It does not assign any value to d.  To assign a value to d you can do it like this.

```vb
d = 5.555567
```

```cs
d = 5.555567;
```

Now the value of d is 5.555567.

```vb
d = 2.1
```

```cs
d = 2.1;
```

Now the value of d is 2.1.

Like any other variable type you can print the variable to the console using like this.

```vb
System.Console.WriteLine(d)
```

```cs
System.Console.WriteLine(d);
```

#### Objects
Objects are a base type that all other objects are derived from.  This means that any other variable no matter the type can be assigned to an object.

To declare an object you do this.

```vb
Dim o As Object
```

```cs
Object o;
```

This example creates a new variable of type Object named o.  It does not assign any value to o.  To assign a value to o you can do it like this.

```vb
o = "A"c
```

```cs
o = 'A';
```

Now the value of o is A.  The type is Char stored in the object.  If we assign an integer.

```vb
o = 120
```

```cs
o = 120;
```

Now the value of o is 120 and the type of the stored value is an Integer

We can do the same by assigning strings, decimals, doubles, or any other type or object into an object of type Object.

If we print the object when assigned an integer it will print the integer.  If we print when it is assigned char it will print the char and so on with the other variable types.

```vb
System.Console.WriteLine(o)
```

```cs
System.Console.WriteLine(o);
```

Generally I suggest avoiding the Object type as it defeats type checking that a compiler does and in my experience causes a lot of run time errors.  The runtime errors are caused when code attempts to do an operation on the object that is not supported by the stored variable type.  If we declare the type we want to use in code the compiler can do all the checks that are needed when the program is complied.


### Objects

VB and c# have built in types such as int, bool, string, and others.  Now it is time to create types that is more specific to your application

For example if you are writing an application about tv channels/stations you probably do not want to use strings and integers.  It will be easier to think about stations and channels.  In VB, c#, and other object oriented languages we can define our own types and use them just like the built in types.


To use a class you must declare one as you would any other variable type.
I will be using the word class and object interchangeably.

For example you declare an integer like this

```vb
Dim i As Integer = 0
```

```cs
int i = 0;
```

Below we create our own data type using the keyword Class. The
best way to use a class is to think of it as an object.
For the purpose of this example our object is going to
be a tv show.  Tv shows have many different aspects to them
so we create an object that represent them.

Included in the class are a new class property (ShowName) as Public
and a Private variable (_showName) that the property works
with. Never declare a class variable as public. Always
use a property or a function.
I will not explain it here but I do encourage you
to read some books on object oriented design.

Private variables are accessible from any function in the class
but cannot be accessed from other classes.

```vb
Public Class TVShow
    Public Sub New()
        ' constructor
    End Sub

    Private _showName As String
    ' Public properties can be accessed from any function inside the
    ' class as well as other classes
    Public Property ShowName() As String
        Get
            ' Inside the get part the private variable is returned.
            ' You can do anything you want here such as data validation
            ' before returning the data if you need or want.
            Return _showName
        End Get
        Set(ByVal value As String)
            ' Inside the set part the private variable is set.
            ' You can do anything you want here such as data validation
            ' before the data is set.
            If value.Trim = "" Then
                Throw New Exception("ShowName cannot be empty")
            End If
            _showName = value
        End Set
    End Property

    ' The above property is long form.  A shorter form can be done as seen below
    Public ReadOnly Property ShowLength As Integer
    Public ReadOnly Property Summary As String
    Public ReadOnly Property Rating As Decimal
    Public ReadOnly Property Episode As String
End Class
```

```cs
public class TVShow
{
    public TVShow()
    {
    }

    private string _showName;
    // Public properties can be accessed from any function inside the
    // class as well as other classes
    public string ShowName
    {
        get
        {
            // Inside the get part the private variable is returned.
            // You can do anything you want here such as data validation
            // before returning the data if you need or want.
            return _showName;
        }
        set
        {
            // Inside the set part the private variable is set.
            // You can do anything you want here such as data validation
            // before the data is set.
            if (value.Trim() == "")
                throw new Exception("ShowName cannot be empty");
            _showName = value;
        }
    }

    // The above property is long form.  A shorter form can be done as seen below
    public int ShowLength {get; init;}
    public string Summary {get; init;}
    public decimal Rating {get; init;}
    public string Episode {get; init;}
}
```


You create a new instance of a class the same way you would
with an Integer. You create a new instance like this

```vb
Dim starTrek As New TVShow With {
    .ShowName = "Star Trek"
    .ShowLength = 1380
    .Summary = "Teleport Disaster"
    .Rating = 5.0D
    .Episode = "1x12"
}
```

```cs
var starTrek = new TVShow() {
    ShowName = "Star Trek",
    ShowLength = 1380,
    Summary = "Teleport Disaster",
    Rating = 5.0m,
    Episode = "1x12"
};
```

If you want a second object you just declare another one.

```vb
Dim dexter As New TVShow With {
    .ShowName = "Dexter"
    .ShowLength = 1380
    .Summary = "Dexter kills again."
    .Rating = 4.8D
    .Episode = "10x01"
}
```

```cs
var dexter = new TVShow() {
    ShowName = "Dexter",
    ShowLength = 1380,
    Summary = "Dexter kills again.",
    Rating = 4.8D,
    Episode = "10x01"
};
```

#### Methods

Methods, also known as functions, are used to break code apartment into smaller chunks.  Functions should do one task and do it well.  Functions can be called again and again.  They are used to keep duplicate code from building up.  This makes things easier to understand.  They can be chained/used together to perform complex tasks.

Functions can return a value or return no value.  In vb functions that return a value use the key word **Function** and ones that do not return a value use the keyword **Sub**.  In c# functions that return a value have a **type** such as a built-in type or object and functions that do not return a value use the keyword ***void**.

```cs
public class TVShow
{
    public string ShowName {get; init;}
    public int ShowLength {get; init;}
    public string Summary {get; init;}
    public decimal Rating {get; init;}
    public string Episode {get; init;}

    // includeSummary is a method parameter
    public void PrettyPrint(bool includeSummary){
        if (includeSummary)
        {
            Console.WriteLine($"{ShowName} {Episode} {Rating} {ShowLength} {Summary}");
        }
        else
        {
            Console.WriteLine($"{ShowName} {Episode} {Rating} {ShowLength}");
        }
    }

    public bool IsGoodRating(){
        return Rating >= 3.0m;
    }
}

var dexter = new TVShow() {
    ShowName = "Dexter",
    ShowLength = 1380,
    Summary = "Dexter kills again.",
    Rating = 4.8D,
    Episode = "10x01"
};

dexter.PrettyPrint(includeSummary: true);

if(dexter.IsGoodRatting()){
    Console.WriteLine("Let's watch this episode.");
}
```

Method and function parameters are passed by reference for objects and by value for simple types.

### Interfaces

> [Interfaces - define behavior for multiple types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/interfaces).  An interface contains definitions for a group of related functionalities that a non-abstract class or a struct must implement. 

Interfaces in c# and vb is a way to specify what an object implements.  It provides the ability to have different concrete class implementations and choose different ones at runtime.

A good example for further self study is the [Microsoft ILogger](https://learn.microsoft.com/en-us/dotnet/core/extensions/custom-logging-provider).


We will build upon the TVShows class.   We will define an interface.  We will include a new property ParentalGuide.

Much of this will not make sense until the IOC and Depednacy injection sections later in this guide.   

The following code example defines an interface named TVShow.  It is not necessary or necessarily recommended to prepend the name with an I but it is very common to see such interfaces in the c# and vb world.   In code bases that do prepend an I the name would be ITVShow.   The following code examples will not follow that pattern.

Imagine we have a large program involving tv shows.   We could pass around the instances of TVShow but that will make our program brittle if and when we need to make changes.  


```cs
public interface TVShow
{
    string ShowName {get; init;}
    int ShowLength {get; init;}
    string Summary {get; init;}
    decimal Rating {get; init;}
    string Episode {get; init;}
    string ParentalGuide {get; init;}

    void PrettyPrint(bool includeSummary);
    bool IsGoodRating();
}
```

An interface is not initalizeable.   If we were to try to do so it would be a compile time error.

```cs
// Will not compile. 
var inst = new TVShow();
```


Below a new class called ComedyShow implments TVShow.  Notice line one with **: TVShow** after the class name.    ComedyShow is a type of TVShow.  Next notice that AdventureShow also implements TVShow.
```cs
public class ComedyShow : TVShow
{
    public string ShowName {get; init;}
    public int ShowLength {get; init;}
    public string Summary {get; init;}
    public decimal Rating {get; init;}
    public string Episode {get; init;}
    public string ParentalGuide {get; init;}

    // includeSummary is a method parameter
    public void PrettyPrint(bool includeSummary){
        if (includeSummary)
        {
            Console.WriteLine($"Comedy: {ShowName} {Episode} {Rating} {ShowLength} {Summary}");
        }
        else
        {
            Console.WriteLine($"Comedy: {ShowName} {Episode} {Rating} {ShowLength}");
        }
    }

    public bool IsGoodRating(){
        return Rating >= 3.0m;
    }
}

public class AdventureShow : TVShow
{
    public string ShowName {get; init;}
    public int ShowLength {get; init;}
    public string Summary {get; init;}
    public decimal Rating {get; init;}
    public string Episode {get; init;}
    public string ParentalGuide {get; init;}

    // includeSummary is a method parameter
    public void PrettyPrint(bool includeSummary){
        if (includeSummary)
        {
            Console.WriteLine($"Adventure: {ShowName} {Episode} {Rating} {ShowLength} {Summary}");
        }
        else
        {
            Console.WriteLine($"Adventure: {ShowName} {Episode} {Rating} {ShowLength}");
        }
    }

    public bool IsGoodRating(){
        return Rating >= 3.5m;
    }
}
```

Reviewing the code we can see that while both the ComedyShow and AdventureShow classes are similar but they have different implementations of PrettyPrint and IsGoodRating.   In addtion to different internals to the interface methods they each could have different private helper methods or even other public methods.

Lets assume our application permits users to enter tv show information and as part of that entry they can add the show as commedy or an adventure show.  Let's store that information in a list.   Notice how InsertShow has a parameter TVShow but lower in the code when calling the method all objects that implement the TVShow interface can be added and worked on.

```cs

public static class Shows
{
    static List<TVShow> _tvShows = new List<TVShow>();

    public static void InsertShow(TVShow show)
    {
        _tvShows.Add(show);
    }

    public static void PrintShows()
    {
        foreach (var show in _tvShows)
        {
            show.PrettyPrint(includeSummary: true);
        }
    }
}

public static void Main()
{
    Shows.InsertShow(new ComedyShow() {
        ShowName = "Friends",
        ShowLength = 1380,
        Summary = "The friends get coffee.",
        Rating = 4.8m,
        Episode = "4x05",
        ParentalGuide = "PG13"
    });
    Shows.InsertShow(new AdventureShow() {
            ShowName = "Rick and morty",
            ShowLength = 760,
            Summary = "A quick 20 minute in and out adventure.",
            Rating = 3.8m,
            Episode = "3x14",
            ParentalGuide = "18A"
        });

    Shows.PrintShows();
}
```

The output is 

> Comedy: Friends 4x05 4.8 1380 The friends get coffee.
> Adventure: Rick and morty 3x14 3.8 760 A quick 20 minute in and out adventure.


For simplicity the example above is using a static Shows class. I almost always recommend against using static classes.   I've shown their use in the above example as it is simple but in general I have found their use often coincides with global variables and long term they cause a maintenance quagmire.   Static classes and variables have their place but try to avoid them.

Note: Read up about base classes and abstract bases classes as they are an alternative to using interfaces.   Read about [SOLID](https://en.wikipedia.org/wiki/SOLID) development.



### Async/Await

> [Asynchronous programming](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios)
. The core of async programming is the Task and Task<T> objects, which model asynchronous operations. They are supported by the async and await keywords. The model is fairly simple in most cases:
> For I/O-bound code, you await an operation that returns a Task or Task<T> inside of an async method.
> For CPU-bound code, you await an operation that is started on a background thread with the Task.Run method.

Async and await provides a way for more efficient use of threads.   When a task is run it can be awaited later while doing more work while waiting.  

Simple async/await example:

```vb
Private Async Function LoadPreviousSettings() As Task
	Threading.Thread.Sleep(5000)
End Function

Dim loadTask As Task = LoadPreviousSettings()

' Do some other crazy stuff

Await loadTask
```

```cs
private async Task LoadPreviousSettings()
{
	await Task.Delay(5000);
}

var loadTask = LoadPreviousSettings();

// Do some other crazy stuff

await loadTask
```


The async and await pattern makes asynchronous programming easiser and feels more like sequential development.   Good places for async/await is I/O bound work such as when making network calls.  Much of the time is spent waiting for a response and the thread could be doing other work while waiting.    Network calls such as database connections, commands, updates, inserts, selects, deletes, and stored procedure and functions executions should be run with async and await pattern.  

Another place async/await should be used is when making http calls.   The example below demonstrates using async/await when using HttpClient to download a web site front page.

```cs
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;

public static async Task Main()
{
    // normally disposable objects should be disposed.  
    // HttpClient is a special case and its norm is 
    // that it should not be exposed until the program terminates
	using var client = new HttpClient();
    // add all tasks to a list and later await them.
    var tasks = new List<Task<string>>();
     Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    for(int i=0; i<9; i++)
    {
        var instDownloader = new Downloader();
        tasks.Add(instDownloader.DownloadSiteAsync(client, "https://majorsilence.com"));
    }
    Console.WriteLine("majorsilence.com is being downloaded 10 times.  Waiting...");
    foreach(var t in tasks)
    {
        string html = await t;
        Console.WriteLine(html.Substring(0, 100));
    }
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    Console.WriteLine($"Code Downloaded in {ts.Milliseconds} Milliseconds");

    // sequential async calls
    Console.WriteLine("start sequential async calls to download majorsilence.com.  Waiting...");
    stopWatch.Start();
    for(int i=0; i<9; i++)
    {
        var instDownloader = new Downloader();
        string html = await instDownloader.DownloadSiteAsync(client, "https://majorsilence.com");
        Console.WriteLine(html.Substring(0, 100));
    }
    stopWatch.Stop();
    TimeSpan ts2 = stopWatch.Elapsed;
    Console.WriteLine($"Sequential Code Downloaded in {ts2.Milliseconds} Milliseconds");
}

public class Downloader{
    public async Task<string> DownloadSiteAsync(HttpClient httpClient,
        string url,
        System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
    {
        var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

        // proceed past user agent sniffing
        request.Headers.Add("User-Agent", "Mozilla/5.0 (X11; CrOS x86_64 14541.0.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/111.0.0.0 Safari/537.36");

        HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync().ConfigureAwait(false); 
    }
}
```

### Threads

> [In computer science, a thread of execution is the smallest sequence of programmed instructions that can be managed independently by a scheduler, which is typically a part of the operating system](https://en.wikipedia.org/wiki/Thread_(computing)).

Dot net provides the [Thread](https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread?view=net-6.0) class.


Here is an example that starts a background tasks and checks every 500 millisecond if it is complete using the IsAlive property.   If the background thread is still working it continues its work inside a while loop.

```cs
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        var t = new Thread(ThreadMethod);
        t.Start();

        Console.WriteLine("Do other things while waiting for the background thread to finish");

        while(t.IsAlive){
            Console.WriteLine("Alive");
            await Task.Delay(500);
        }

        Console.WriteLine("job completed");
    }

    static void ThreadMethod(){
        Console.WriteLine("The code in this method is running in its own thread.");
        Console.WriteLine("Sleep the thread 5000 milliseconds to demonstrate the main thread keeps working.");
        Thread.Sleep(5000);
    }
}
```

This exaple starts a thread and does no work.  The main thread stops work and waits for the background thread to complete using the Join method.

```cs
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        var t = new Thread(ThreadMethod);
        t.Start();
        Console.WriteLine("Wait for the background thread to complete");
        t.Join();
        Console.WriteLine("job completed");
    }

    static void ThreadMethod(){
        Console.WriteLine("The code in this method is running in its own thread.");
        for(int i = 1; i< 6; i++){
            Console.WriteLine($"background loop count {i}");
            Thread.Sleep(500);
        }
    }
}
```

#### Locks

If more then one thread or task is updating a variable you should lock the variable as necessary.

The example below create multiple tasks that all update the same "count" variable.
As you can see it locks the variable before updating it.

```vb
Dim tasks As New List(of Task)
Dim lockObject As New Object()

int count=0;

For i As Integer = 0 To 10
	tasks.Add(Task.Factory.StartNew(Function() 
		For j As Integer = 0 To 999
			SyncLock lockObject
				count = count + 1
			End SyncLock
		Next

	End Function))
Next
```

```cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        var tasks = new List<Task>();
		var lockObject = new object();

		int count = 0;
		for (int i = 0; i < 10; i++)
		{
			tasks.Add(Task.Factory.StartNew(() =>
			{
				for (int j = 0; j <= 999; j++)
				{
					lock (lockObject)
                    {
						count = count + 1;
					}        
				}
			}));
		}
		
		foreach(var t in tasks)
		{
			await t;
		}
		
		Console.WriteLine(count);
    }
}
```


### Winforms

### IOC

### Repository Pattern


Use the repository pattern to seperate your business and data access layers.  Makes
it easy to test your business and data layer code seperatly.

There are different ways to do this.  Here are a couple ways.

#### Use a base abstract class that is passed a connection

```cs
using System;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace MajorSilence.DataAccess
{
    public abstract class BaseRepo
    {
        private readonly string cnStr;

        protected BaseRepo(string cnStr)
        {
            this.cnStr = cnStr;
        }

        protected T WithConnection<T>(Func<IDbConnection, T> sqlTransaction)
        {
            using (var connection = new SQLiteConnection(cnStr))
            {
                connection.Open();
                return sqlTransaction(connection);
            }
        }

        protected void WithConnection(Action<IDbConnection> sqlTransaction)
        {
            using (var connection = new SQLiteConnection(cnStr))
            {
                connection.Open();
                sqlTransaction(connection);
            }
        }

        protected async Task<T> WithConnectionAsync<T>(Func<IDbConnection, Task<T>> sqlTransaction)
        {
            using (var connection = new SQLiteConnection(cnStr))
            {
                await connection.OpenAsync();
                return await sqlTransaction(connection);
            }
        }

        protected async Task WithConnectionAsync<T>(Func<IDbConnection, Task> sqlTransaction)
        {
            using (var connection = new SQLiteConnection(cnStr))
            {
                await connection.OpenAsync();
                await sqlTransaction(connection);
            }
        }
    }
}
```


And here is the repo class

```cs
using System;
using System.Linq;
using Dapper;

namespace MajorSilence.DataAccess
{
    public interface ITestRepo
    {
        string GetName();
        void InsertData(string name);
    }

    public class TestRepo : BaseRepo, ITestRepo
    {
        public TestRepo(string cnStr) : base(cnStr) { }

        public string GetName()
        {
            return this.WithConnection(cn =>
            {
                return cn.Query<string>("SELECT Name From TheTable LIMIT 1;").FirstOrDefault();
            });
        }

        public void InsertData(string name)
        {
            this.WithConnection(cn =>
            {
                cn.Execute("INSERT INTO TheTable (Name) VALUES (@Name);",
                    new { Name = name });
            });
        }
    }
}
```


#### No base abstract.  Let individual repository classes do as they please

I generally prefer this way.   It is simple.

```cs
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace MajorSilence.DataAccess
{

    public class TestRepoNobase : ITestRepo
    {
        readonly string cnStr;
        public TestRepoNobase(string cnStr)
        {
            this.cnStr = cnStr;
        }

        public string GetName()
        {
            using (var cn = new SQLiteConnection(cnStr))
            {
                return cn.Query<string>("SELECT Name From TheTable LIMIT 1;").FirstOrDefault();
            };
        }

        public void InsertData(string name)
        {
            using (var cn = new SQLiteConnection(cnStr))
            {
                cn.Execute("INSERT INTO TheTable (Name) VALUES (@Name);",
                    new { Name = name });
            };
        }
    }
}
```


# Do something with the repository classes

A business class

```cs
using System;
namespace MajorSilence.BusinessStuff
{
    public class TestStuff
    {
        readonly DataAccess.ITestRepo repo;
        public TestStuff(DataAccess.ITestRepo repo)
        {
            this.repo = repo;
        }

        public void DoStuff()
        {
            repo.InsertData("The Name");
            string name = repo.GetName();

            // Do stuff with the name
        }
    }
}
```


Combine everything.  Manualy initialize our two repository classes and initialize two copies
of our TestStuff class. Our TestStuff never knows what or where the actual data layer is.

TestStuff is now easily tested with tools such as as [moq](/docs/VbIntroduction/Mocking.html).

```cs
using System;

namespace MajorSilence.TestStuff
{
    class Program
    {
        static void Main(string[] args)
        {

            // Our repository layer that will talk to the data source.
            // This could be inject with a dependency injection framework
            var repo = new MajorSilence.DataAccess.TestRepo("Data Source=:memory:;Version=3;New=True;");
            var repo2 = new MajorSilence.DataAccess.TestRepoNobase("Data Source=:memory:;Version=3;New=True;");


            // Our business class.  Takes an interface and does not care
            // what the actual data source is.
            var inst = new MajorSilence.BusinessStuff.TestStuff(repo);
            inst.DoStuff();

            var inst2 = new MajorSilence.BusinessStuff.TestStuff(repo2);
            inst2.DoStuff();
            
        }
    }
}

```


### Events 

Custom Event and Event Handlers

#### Use built in EventHandler
```cs
public class TheExample
{
    public event System.EventHandler DoSomething;

    public void TheTest(){
        // option 1 to raise event
        this.DoSomething?.Invoke(this, new System.EventArgs());

        // option 2 to raise event
        if (DoSomething != null)
        {
            DoSomething(this, new System.EventArgs());
        }
    }
}
```


#### Use custom delegate as event hander

```cs
public class TheExample
{
    public delegate void MyCustomEventHandler(object sender, System.EventArgs e);
    public event MyCustomEventHandler DoSomething;

    public void TheTest(){
        // option 1 to raise event
        this.DoSomething?.Invoke(this, new System.EventArgs());

        // option 2 to raise event
        if (DoSomething != null)
        {
            DoSomething(this, new System.EventArgs());
        }
    }
}
```

#### Susbscribe to the event

```cs
// subscribe using lamba expression

var x = new TheExample();

x.DoSomething += (s,e) => { 
    Console.WriteLine("hi, the event has been raised");
};  
x.TheTest

```

#### VB example of basic custom events

```vb
Public Class TheExample
    Public Delegate Sub MyCustomEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Shared Event MyCustomEventHandler As DoSomething

    Public Sub TheTest
        RaiseEvent DoSomething(Me, New EventArgs())
    End Sub
End Class
```

Subscribe to the event
```vb
dim x As New TheExample
AddHandler x.DoSomething, AddressOf
x.TheTest()

RemoveHandler x.DoSomething, AddressOf EventCallback

Sub EventCallback(ByVal sender As Object, ByVal e As System.EventArgs)
    Console.WriteLine("Hi, the event has been raised")
End sub

```

#### Create a custom event

Setup a new custom event class inherting from EventArgs and setup a new delegate.

```cs
public delegate void MyCustomEventHandler(object sender, MyCustomEvent e);

public class MyCustomEvent : System.EventArgs
{
        private string _msg;
        private float _value;

    public MyCustomEvent(string m)
    {
        _msg = m;
        _value = 0;
    }

    public MyCustomEvent(float v)
    {
        _msg = "";
        _value = v;
    }

    public string Message
    {
        get { return _msg; }
    }

    public float Value
    {
        get { return _value; }
    }
}
```

#### Use the custom event

```cs
public event MyCustomEventHandler DoSomething;

this.DoSomething?.Invoke(this, new MyCustomEvent(123.95f));
```




### Nuget

Generally using nuget is very simple.  Using Visual Studio right click your solution or project and select "Add Nuget Package".  Find your package and add it.  It is auto added.  Any time you now clone your project on a new computer the first time you build your project it will restore your nuget references.

#### Create a NuGet Package

write me


#### Add NuGet source

The following command will add a nuget source to your computer other than the default.  This is good for self hosted nuget servers.


```powershell
dotnet nuget add source "https://your.source.url/v3/index.json" -n [Feed Name] -u YourUserName -p YourPassword --store-password-in-clear-text
```

#### Check if NuGet Source already Exists

The following powershell script will check if a nuget source already exists on your computer. 

```powershell
dotnet nuget list source
```


#### Start fresh with just nuget.org

```powershell
dotnet new nugetconfig
```




### Testing

#### NNnit

#### xUnit

#### MSTest

### In Memory Work Queue

#### Task Queue

#### Thread Queue


## Git

### Git Visual Studio

### Git cli

### Git Rider

### Tortoise Git

### Github Desktop


## Databases - Microsoft SQL

### SELECT

### INSERT

### UPDATE

### DELETE

### JOIN

### CTE

### Stored Procedures

### Stored Functions

### Views

### Reference - Install

### Reference - Admin

spBlitz, https://ola.hallengren.com/ sql server maintenance solution

### SQL Profiler

### SQL Query Store

### SQL Watch


## Databases - Redis

### Session 

### Cache

### Publish and Subscribe

### Work and Message Queue


## Database and DotNet

### SqlConnection

### SqlCommand

### DataAdapters

### Dapper

### Entity Framework

### Fluentmigrator

### Transactions and Isolation Levels




## ASP.Net Core

### Dependency Injection



### MVC

### Blazor

### Docker

### nginx


## Javascript and Typescript

### fetch

### JQuery

### Kendo


## Microsoft Maui


## Monitoring

### Prometheus

### Grafana


## Kubernetes





