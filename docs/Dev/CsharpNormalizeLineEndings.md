---
layout: base
title: C# Normalize Line Endings
---

A small simple function for normalizing  to windows end of line characters.

``` C# 
   private static string ConvertToWindowsEOL(string readData)
        {
            // see https://stackoverflow.com/questions/31053/regex-c-replace-n-with-r-n for regex explanation
            readData = Regex.Replace(readData, "(?<!\r)\n", "\r\n");
            return readData;
        }

```

See see https://stackoverflow.com/questions/31053/regex-c-replace-n-with-r-n for regex explanation for original source.

