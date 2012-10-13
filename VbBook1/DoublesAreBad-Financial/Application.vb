

Public Class Application
  	Public Shared Sub Main()   
  		System.Console.WriteLine("Demonstrate why doubles are bad.  At least when dealing with money.")
  		System.Console.WriteLine("")
  	
        DoubleCalc()
        System.Console.WriteLine("")
        DecimalCalc()

        System.Console.WriteLine("")
        System.Console.WriteLine("Press any key to exit...")
        System.Console.ReadKey()
    End Sub
   
    ' Outputs correct values
    Public Shared Sub DecimalCalc()
        System.Console.WriteLine("Calculations with Decimals:")
        Dim t1 as Decimal = 10.266D
        Dim t2 as Decimal = 10.0D
   
        ' Outputs 0.266
        System.Console.WriteLine(t1-t2)
       
        Dim h1 as Decimal = 100.266D
        Dim h2 as Decimal = 100.0D
        'Outputs 0.266
        'Over time these errors accumlate and rounding is wrong.
        System.Console.WriteLine(h1-h2)
    End Sub
   
   ' Outputs incorrect calculation that overtime can build up in a long running calculation
    Public Shared Sub DoubleCalc()
        System.Console.WriteLine("Calculations with Doubles:")
        Dim t1 as Double = 10.266
        Dim t2 as Double = 10.0
   
        ' Outputs 0.266
        System.Console.WriteLine(t1-t2)
       
        Dim h1 as Double = 100.266
        Dim h2 as Double = 100.0
        'Outputs 0.266000000000005
        'Over time these errors accumlate and rounding is wrong.
        System.Console.WriteLine(h1-h2)
    End Sub
End Class

