---
layout: base
title: Reading and Writing Files
---

There are a few easy to use function to read and write files: 

* System.IO.File.WiteAllText
* System.IO.File.AppendAllText
* System.IO.File.ReadAllText
* System.IO.File.ReadAllLines


With these files you can write a whole file, append to an existing file, read the full content of a file as a string or as an array of strings.  There are several other functions in the same namespace but those are the functions I use most.

Lets say that we want to write the contents of a string to a file.  The following would do this.

```vb.net
System.IO.File.WriteAllText(_filePath, "The Contents", System.Text.Encoding.UTF8)
```

To append text to a file you could do the following.

```vb.net
System.IO.File.AppendAllText(_filePath, _"Add another line.  This is line " & count.ToString & _System.Environment.NewLine, System.Text.Encoding.UTF8)
```

To read a full file into one string variable you could do.
Dim fileContent As String = System.IO.File.ReadAllText(_filePath)

If you want to read a file line by line you can do

```vb.net
For Each line As String In System.IO.File.ReadAllLines(_filePath)
    System.Console.WriteLine(line)
Next
```


# Streams
write me

See:  [https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/ReadingAndWritingFiles/Application.vb](https://github.com/majorsilence/VB-Notes/blob/master/VbBook1/ReadingAndWritingFiles/Application.vb)