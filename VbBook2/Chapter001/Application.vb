

Public Class Application
	Public Shared Sub Main()
		'TODO: Needs more work.
	
		Dim DateFormat As String = "MM/dd/yyyy"

		Dim info As New Globalization.CultureInfo("en-CA")
		info.DateTimeFormat.ShortDatePattern = DateFormat
		Threading.Thread.CurrentThread.CurrentCulture = info
	End Sub
End Class

