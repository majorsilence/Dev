Bankers vs Arithmetic

* Bankers rounding:  MidpointRounding.ToEven - VB Defaults to this.  Good for statistical calculation.  Not exactly sure why this is called bankers rounding as it does not appear to be much used in most financial applications.
* Arithmetic Rounding: MidpointRounding.AwayFromZero - However most financial calutions should be using Arithmetic rounding.


## Arithmetic Rounding
0.5 and above always round up to 1 and any number below 0.5 rounds down to 0.  So if we have Math.Round(5.245D, 2, MidpointRounding.AwayFromZero) what this means is since this number end in 5 it founds up 1 which ends with the number 5.25.  If the number was 5.244 it would round down to 5.24.
## Bankers Rounding
“0.5 rounds to the nearest even number. What this means is that both 1.5 and 2.5 round to 2, and 3.5 and 4.5 both round to 4.”  Or if you look at our code example Math.Round(5.245D, 2) rounds to 5.24.

http://vbnotebookfor.net/2007/07/31/what-you-should-know-about-rounding-in-vbnet/