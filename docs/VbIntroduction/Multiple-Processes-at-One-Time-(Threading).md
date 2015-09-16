---
layout: base
title: Threading and Asynchrounous
---

Show how to use asynchronous delegates to run more then one thread at a time.

Both examples will run asynchronous code and wait.  Waiting is optional.

### .net 3.5
```vbnet
Dim caller As New Action(Sub()
            Console.WriteLine("Task thread ID: {0}",
            Thread.CurrentThread.ManagedThreadId)
      End Sub)
Dim result As IAsyncResult = caller.BeginInvoke(Nothing, Nothing)
result.AsyncWaitHandle.WaitOne()
```

### .net 4.5
```vbnet
Dim t As Task = Task.Run(Sub()
            Console.WriteLine("Task thread ID: {0}",
            Thread.CurrentThread.ManagedThreadId)
      End Sub)
t.Wait()
```

# Async Await

An async task function.

```vbnet
Private Async Function LoadPreviousSettings() As Task
	Threading.Thread.Sleep(5000)
End Function

```

Can be called in the following way

```vbnet
Dim loadTask As Task = LoadPreviousSettings()

// Do some other crazy stuff

Await loadTask

```

# Locks
If more then one thread is updating a variable you need to lock the variable first.

The example below create multiple threads that all update the same "count" variable.
As you can see it locks the variable before updating it.

```vbnet
Dim lockObject As New Object()

int count=0;

For i As Integer = 0 To 10
	tasks.Add(Task.Factory.StartNew(Function() 
		For j As Integer = 0 To 999
			SyncLock lockObject
				count = count + 1
			End SyncLock
		Next

	End Function))
Next
```
