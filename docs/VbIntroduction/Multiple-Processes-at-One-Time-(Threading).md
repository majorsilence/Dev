---
layout: base
title: Threading and Asynchrounous
---

Show how to use asynchronous delegates to run more then one thread at a time.

.net 3.5
```vb
```

.net 4.5
```vb
      Dim t As Task = Task.Run(Sub()
                                  Console.WriteLine("Task thread ID: {0}",
                                                    Thread.CurrentThread.ManagedThreadId)
                               End Sub)
      t.Wait()
```
