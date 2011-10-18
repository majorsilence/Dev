

Public Class Application
	
	Private Shared _filePath As String

	Public Shared Sub Main()
		Dim desktopDirectoryPath As String = _
			System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
	
		_filePath = System.IO.Path.Combine(desktopDirectoryPath, "testfile.txt")
		
		WriteMyFile()	
		ReadMyFileAtOnce()
		ProcessByLine()
		
	End Sub
	
	Private Shared Sub WriteMyFile()
		System.Console.WriteLine("First we will write a file.")
	
		System.IO.File.WriteAllText(_filePath, "The Contents", _
			System.Text.Encoding.UTF8)
		
		For count As Integer = 0 To 100
			System.IO.File.AppendAllText(_filePath, _
				"Add another line.  This is line " & count.ToString & _
				System.Environment.NewLine, _
				System.Text.Encoding.UTF8)
		Next
	End Sub
	
	Private Shared Sub ReadMyFileAtOnce()
		System.Console.WriteLine("Process full file at one time")
		
		Dim fileContent As String = System.IO.File.ReadAllText(_filePath)
		System.Console.WriteLine(fileContent)
	End Sub
	
	Private Shared Sub ProcessByLine()
		System.Console.WriteLine("Process each line one at a time")
	
		For Each line As String In System.IO.File.ReadAllLines(_filePath)
			System.Console.WriteLine(line)
			Threading.Thread.Sleep(1000)
		Next
	
	End Sub
	
End Class

