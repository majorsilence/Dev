VB has built in types such as int, bool, string, and others.  Now it is time to create types that is more specific to your application

For example if you are writing an application about tv channels/stations you probably do not want to use strings and integers.  It will be easier to think about stations and channels.  In VB and other object oriented languages we can define our own types and use them just like the built in types.


To use a class you must declare one as you would any other variable type.
I will be using the word class and object interchangeably.

For example you declare an integer like this
```vb.net
Dim i As Integer = 0
```

Below we create our own data type using the keyword Class. The
best way to use a class is to think of it as an object.
For the purpose of this example our object is going to
be a tv show.  Tv shows have many different aspects to them
so we create an object that represent them.

```vb.net
Public Class TVShow
    Public Sub New()
        MyBase.New
    End Sub

    ' All your code goes here

End Class
```
Here we create a new class property (ShowName) as Public
and a Private variable (_showName) that the property works
with. Never declare a class variable as public. Always
use a property or a function.
I will not explain it here but I do encourage you
to read some books on object oriented design.

Private variables are accessible from any function in the class
but cannot be accessed from other classes.

``` vb.net
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
```


You create a new instance of a class the same way you would
with an Integer. You create a new instance like this
```vb.net
Dim i As New TVShow()
i.ShowName = "Dexter"
```

If you want a second object you just declare another one
```vb.net
Dim a As New TVShow
a.ShowName = "Star Trek TNG"
' Now we will set the tv channel values
a.ShowName = "Dexter"
a.ShowLength = 1380
a.Summary = "Dexter kills again."
a.Rating = 4.8D
a.Episode = "10x01"
```

See https://github.com/majorsilence/VB-Notes/tree/master/VbBook1/Objects.