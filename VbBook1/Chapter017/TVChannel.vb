
Option Explicit On
Option Strict On

Imports System


' To use a class you must declare one as you would any other variable type.
' I will be using the word class and object interchangeably.
'
' For example you declare an integer like this
' Dim i As Integer = 0
'
' Below we create our own data type using the keyword Class. The
' best way to use a class is to think of it as an object.
' For the purpose of this example our object is going to
' be a tv channel.  Tv channels have many different aspects to them
' so we create an object that represent them.
' 
' You create a new instance of a class the same way you would
' with an Integer. You create a new instance like this
' Dim i As New TvChannel()
' i.ShowName = "Dexter"
'
' If you want a second object you just declare another one
' Dim k As New TvChannel
' k.ShowName = "Star Trek TNG"
Public Class TVChannel
	
	Public Sub New()
		MyBase.New
	End Sub
	
	' Here we create a new class property (ShowName) as Public
	' and a Private variable (_showName) that the property works
	' with.  Never declare a class variable as public.  Always
	' use a property or a function.
	' I will not explain it here but I do encourage you
	' to read some books on object oriented design.  
	' 
	
	' Private variables are accessible from any function in the class 
	' but cannot be accessed from other classes.
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
	
	' This property will hold the length of the show in seconds.
	Private _showLength As Integer
	Public Property ShowLength() As Integer
		Get
			Return _showLength
		End Get
		Set(ByVal value As Integer)
			_showLength = value
		End Set
	End Property

	' This property will hold a summary of the show
	Private _summary As String
	Public Property Summary() As String
		Get
			Return _summary
		End Get
		Set(ByVal value As String)
			_summary = value
		End Set
	End Property
	
	' A property to hold the user rating
	Private _rating As Decimal
	Public Property Rating() As Decimal
		Get
			Return _rating
		End Get
		Set (ByVal value As Decimal)
			If value < 0D Then
				Throw New Exception("Rating must be >= 0")
			ElseIf value > 5D Then
				Throw New Exception("Rating must be <= 5")
			End If
			
			_rating = value
		End Set
	End Property
	
	' A property to hold the episode season and number
	Private _episode As String
	Public Property Episode() As String
		Get
			Return _episode
		End Get
		Set(ByVal value As String)
			_episode = value
		End Set
	End Property
	
	' This function will format the show length
	' in an easy to read human format
	' HH:MM:SS
	Public Function ShowLengthFormated() As String
		Dim timeInSeconds As Integer = Me.ShowLength
		If timeInSeconds < 0 Then
			Throw New Exception("Invalid time. Seconds must be greated then >= 0. Seconds passed in was: " & timeInSeconds.ToString())
		End If
		
		Dim hours As Integer = 0
		Dim minutes As Integer = 0
		Dim seconds As Integer = 0
		Dim time_string As String = ""
		
		If timeInSeconds >= 3600 Then
			hours = CInt(timeInSeconds / 3600)
			timeInSeconds = timeInSeconds - (hours * 3600)
		End If
		
		If timeInSeconds >= 60 Then
			minutes = CInt(timeInSeconds / 60)
			timeInSeconds = timeInSeconds - (minutes * 60)
		End If
		
		'remaining time is seconds
		seconds = timeInSeconds
		
		time_string = time_string & hours.ToString().PadLeft(2, "0"C) & ":" & minutes.ToString().PadLeft(2, "0"C) & ":" & seconds.ToString().PadLeft(2, "0"C)
		
		'return time in Hours:Minutes:Seconds format
		Return time_string
			
	End Function
	
End Class

