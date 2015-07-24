Imports System.Windows.Forms
Imports System

Public Class Program

    Public Shared Sub Main()
        Dim app As New MainForm
        Application.Run(app)
    End Sub

End Class

Public Class MainForm
    Inherits Form

    Private textOutput As New TextBox

    Public Sub New()
        ' Setup an initial winform to show how threads work
        Dim p As New Panel
        p.Dock = DockStyle.Fill
        textOutput.Multiline = True
        textOutput.Dock = DockStyle.Fill

        p.Controls.Add(textOutput)
        Me.Controls.Add(p)

        ' Call the function that will start the thread
        StartAsynchronousDelegate()
    End Sub

    Delegate Sub AsyncMethodCaller1()
    Private Sub StartAsynchronousDelegate()
        ' We will not be using threads directly.
        ' We will use asynchronous delegates
        ' AsyncMethodCaller1 is the delegate we will be using to run the 
        ' thread.  RunDelegate is the function we will be running in a background
        ' thread.
        Dim caller As New AsyncMethodCaller1(AddressOf RunDelegate)
        Dim result As IAsyncResult = caller.BeginInvoke(Nothing, Nothing)
    End Sub

    Private Sub RunDelegate()
        ' This function is running in a background thread.
        For i As Integer = 0 To 100
            Threading.Thread.Sleep(1000)

            ' Using beginInvoke on the control uses another delegate using Action function.
            ' This calls teh function UpdateTextBox on the gui thread passing the value i.
            Me.BeginInvoke(New Action(Of String)(AddressOf UpdateTextBox), i.ToString)
        Next
    End Sub

    Private Sub UpdateTextBox(ByVal appendValue As String)
        ' This function is run on the gui thread.
        textOutput.Text = appendValue & System.Environment.NewLine & textOutput.Text
    End Sub

End Class



