Imports System.Collections.Generic


Public Class Application
    Public Shared Sub Main()
        System.Console.WriteLine("In this chapter we demonstrate for looping.")

        For i As Integer = 0 To 100
            System.Console.WriteLine("Loop Count: " & i.ToString)
        Next


        Dim a As New List(Of String)
        a.Add("A string in the list")
        a.Add("A second string in the list")
        a.Add("You can use as many items as you want to the list")

        For i As Integer = 0 To a.Count - 1
            System.Console.WriteLine(String.Format("Position {0} has value: {1}", i, a(i)))
        Next

    End Sub
End Class

