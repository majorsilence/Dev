---
layout: base
title: Globalization
---

Setting Culture program wide and the implications of dealing with multiple cultures.  With the example below the current thread culture is set but how does this affect threads.

Dim DateFormat As String = "MM/dd/yyyy"

```vb
Dim info As New Globalization.CultureInfo("en-CA")
info.DateTimeFormat.ShortDatePattern = DateFormat
'info.NumberFormat =
Threading.Thread.CurrentThread.CurrentCulture = info
```