---
layout: base
title: Threading and Asynchrounous
---

Show how to use asynchronous delegates to run more then one thread at a time.

Both examples will run asynchronous code and wait.  Waiting is optional.

### .net 3.5
```vb
Dim caller As New Action(Sub()
            Console.WriteLine("Task thread ID: {0}",
            Thread.CurrentThread.ManagedThreadId)
      End Sub)
Dim result As IAsyncResult = caller.BeginInvoke(Nothing, Nothing)
result.AsyncWaitHandle.WaitOne()
```

### .net 4.5
```vb
Dim t As Task = Task.Run(Sub()
            Console.WriteLine("Task thread ID: {0}",
            Thread.CurrentThread.ManagedThreadId)
      End Sub)
t.Wait()
```

# Async Await
write me