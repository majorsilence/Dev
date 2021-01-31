---
layout: base
title: C# Usefule regular expressions
---

Usefule regular expressions.

``` C# 
// available wild cards:
//  . - any character  (one and only one)
//  .* - any characters(zero or more)
//  .*? - any characters(zero or more), non-greedy (lazy)
//  .+ - any characters(one or more)
//  .{3,7} any charcter min length 3, max length 7
//  \\d+ one or more digits
// \s+ one or more whitespace

public static string FindDigits(){

    var matches = Regex.Matches("hello world 123, the end", "world \\d+");
    // do your thing here
}
```

