Public Class TestingClass

    <NUnit.Framework.Test()> _
    Public Sub Test1()
        ' The first thing we do is declare a new instance of TVChannel that was
        ' created in chapter 17.
        Dim a As New Chapter017.TVChannel()

        ' Now we will set the tv channel values
        a.ShowName = "Dexter"
        a.ShowLength = 1380
        a.Summary = "Dexter kills again."
        a.Rating = 4.8D
        a.Episode = "10x01"


        ' We will now validate that all values are correct
        ' using the NUnit framework.
        ' You can use the Nunit testing GUI to test this function.
        NUnit.Framework.Assert.True(a.ShowName = "Dexter")
        NUnit.Framework.Assert.True(a.ShowLength = 1380)
        NUnit.Framework.Assert.True(a.Summary = "Dexter kills again.")
        NUnit.Framework.Assert.True(a.Rating = 4.8D)
        NUnit.Framework.Assert.True(a.Episode = "10x01")

    End Sub

End Class
