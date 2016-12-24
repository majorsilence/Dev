---
layout: base
title: Arrays and Lists
---

Visual basic supports arrays, ArrayLists, and Generic Lists.  In any but the most simple case will recommend using Generic lists as they provide much functionality without the limitations of regular arrays or type problems that come with ArrayLists.

All three hold lists contain values.  Arrays are generally a set size but you can re-size them.  ArrayLists and Generic list both provide much of the same functionality.  They both have functions to Add, Remove, and Search contents of the list and you never need to work about re-sizing.

The difference is ArrayLists can store multiple types while Generic lists will only contain one type.

For the most part normal arrays can be completely avoided.  Generally ArrayList can be avoided and a generic list can be used instead.  But if you need an array of multiple types an ArrayList works well.

To see the example code that goes along with lesson go [https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/ArrayList/Application.vb](https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/ArrayList/Application.vb) and see 
[https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/GenericLists-Arrays/Application.vb](https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/GenericLists-Arrays/Application.vb).

Note: Arrays and lists always start at position 0.  This means if there are 10 items in the list to access them you will go from 0 - 9.

```
0, 1, 2, 3, 4, 5, 6, 7, 8, 9
```


# ArrayList
Before using ArrayLists the the System.Collections namespace must be imported.
```vb.net
imports System.Collections
```

Do use an ArrayList you declare a new instance and then you can add variables.

The following examples declares an ArrayList named a and then adds a string, integer, char, and decimal value.  To add values to an ArrayList you use the Add method.  To remove values you use the Remove method.

```vb.net
Dim a As New ArrayList()
a.Add("A String")
a.Add(1)
a.Add("a"c)
a.Add(343.32D)
```

As you can see ArrayLists can be used with multiple types in the same list.  To access a value from a specific location you use the lists name and the location of the value you wish to retrieve.  For example if you want to see the value of the first position you would use a(0).

This example will display the value of a(0) and then display the value type of a(0).

```vb.net
System.Console.WriteLine("a(0) " & a(0).ToString)
System.Console.WriteLine("a(0) type " & a(0).GetType().ToString)
```
The type that will be printed from this is "System.String"

This example will display the value of a(1) and then display the value type of a(1).

```vb.net
System.Console.WriteLine("a(1) " & a(1).ToString)
System.Console.WriteLine("a(1) type " & a(1).GetType().ToString)
```
The type that will be printed from this is "System.Int32"

This example will display the value of a(2) and then display the value type of a(2)

```vb.net
System.Console.WriteLine("a(2) " & a(2).ToString)
System.Console.WriteLine("a(2) type " & a(2).GetType().ToString)
```
The type that will be printed from this is "System.Char"

This example will display the value of a(3) and then display the value type of a(3).
System.Console.WriteLine("a(3) " & a(3).ToString)
System.Console.WriteLine("a(3) type " & a(3).GetType().ToString)
The type that will be printed from this is "System.Decimal"

# Generic List
Before using Generic lists the following namespace must be imported.

```vb.net
Imports System.Collections.Generic
```

To use a generic list you declare a new instance of List and specify the type.  For example if to create to create a list of strings the following code is used.

```vb.net
Dim a As New List(Of String)
```
What this does is create a new list.  The only values that can be added are string values.  If you try to add any other value it will not compile.  This ensures we have type safety.

Following example will add three strings to the list.

```vb.net
a.Add("A string in the list")
a.Add("A second string in the list")
a.Add("You can use as many items as you want to the list")
```

Like with Array Lists to access a generic list you will use the variable name and position.  So if we want to access position 0 of list a we would use a(0).

The following example will access each position in the list and print them to the console.

```vb.net
System.Console.WriteLine("a(0) " & a(0))
System.Console.WriteLine("a(1) " & a(1))
System.Console.WriteLine("a(2) " & a(2))
```

As stated above you cannot assign a type other then the one specify.  Since this list is list of string if the code tried to add an Integer or any other value type the code will not compile.

**This example will not compile**

```vb.net
a.Add(1)
```
Since 1 is an integer it cannot be added to the list and the code will not compile.

# Arrays
Arrays is a basic type in the language, fixed length but can be re-sized (ReDim), and if declared with a type can only hold one type.

The following example will declare an array with a length of 3 of type string.  Only three positions will be availble and they must all hold string.

```vb.net
Dim b(3) As String
b(0) = "String One"
b(1) = "String Two"
b(2) = "String Three"
```

To print the values to the console can be done like this:

```vb.net
System.Console.WriteLine("b(0) " & b(0))
System.Console.WriteLine("b(1) " & b(1))
System.Console.WriteLine("b(2) " & b(2))
```

As can be seen arrays are access like list, the array name and the position such as a(0).