Imports System
Imports System.Collections.Generic

Public Class Application
	Public Shared Sub Main()
		System.Console.WriteLine("Welcome to the object chapter!")
		System.Console.WriteLine("In this chapter we will be exploring basic object oriented programming")
	
		' First we will create a couple of tv channel object instances
		Dim a As New TvChannel()
		Dim b As New TvChannel()
		
		' Now we will set the tv channel values
		a.ShowName = "Dexter"
		a.ShowLength = 1380
		a.Summary = "Dexter kills again."
		a.Rating = 4.8D
		a.Episode = "10x01"
		
		b.ShowName = "Star Trek TNG"
		b.ShowLength = 2600
		b.Summary = "Captain Picard and crew meet a new alien race."
		b.Rating = 4.9D
		b.Episode = "15x12"
	
		' We will now pack these tv channels into a list
		' and pass them to a function to be used.
		Dim tvList As New List(Of TVChannel)
		tvList.Add(a)
		tvList.Add(b)
	
	End Sub
	
	Private Shared Sub DoStuffWithTvChannels(ByVal items As List(Of TVChannel))
		' The awesome action that we will be peforming
		' is to print the information about the channels
		' to a console window.
		For Each channel As TVChannel In items
			System.Console.WriteLine("Channel Name: " & channel.ShowName)
			
			System.Console.WriteLine("")
		Next
	End Sub
	
End Class

