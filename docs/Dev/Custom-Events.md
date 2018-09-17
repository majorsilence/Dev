---
layout: base
title: Events and Event Handlers
---

Custom Event and Event Handlers

# C# examples

## Use built in EventHandler
```cs
public class TheExample
{
    public event System.EventHandler DoSomething;

    public void TheTest(){
        // option 1 to raise event
        this.DoSomething?.Invoke(this, new System.EventArgs());

        // option 2 to raise event
        if (DoSomething != null)
        {
            DoSomething(this, new System.EventArgs());
        }
    }
}
```


## Use custom delegate as event hander

```cs
public class TheExample
{
    public delegate void MyCustomEventHandler(object sender, System.EventArgs e);
    public event MyCustomEventHandler DoSomething;

    public void TheTest(){
        // option 1 to raise event
        this.DoSomething?.Invoke(this, new System.EventArgs());

        // option 2 to raise event
        if (DoSomething != null)
        {
            DoSomething(this, new System.EventArgs());
        }
    }
}
```

## Susbscribe to the event

```cs
// subscribe using lamba expression

var x = new TheExample();

x.DoSomething += (s,e) => { 
    Console.WriteLine("hi, the event has been raised");
};  
x.TheTest


```

# VB example of basic custom events

```vb
Public Class TheExample
    Public Delegate Sub MyCustomEventHandler(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Shared Event MyCustomEventHandler As DoSomething

    Public Sub TheTest
        RaiseEvent DoSomething(Me, New EventArgs())
    End Sub
End Class
```

Subscribe to the event
```vb
dim x As New TheExample
AddHandler x.DoSomething, AddressOf
x.TheTest()

RemoveHandler x.DoSomething, AddressOf EventCallback

Sub EventCallback(ByVal sender As Object, ByVal e As System.EventArgs)
    Console.WriteLine("Hi, the event has been raised")
End sub

```

# Custom event

## Create

Setup a new custom event class inherting from EventArgs and setup a new delegate.

```cs
public delegate void MyCustomEventHandler(object sender, MyCustomEvent e);

public class MyCustomEvent : System.EventArgs
{
        private string _msg;
        private float _value;

    public MyCustomEvent(string m)
    {
        _msg = m;
        _value = 0;
    }

    public MyCustomEvent(float v)
    {
        _msg = "";
        _value = v;
    }

    public string Message
    {
        get { return _msg; }
    }

    public float Value
    {
        get { return _value; }
    }
}
```

## Use the custom event

```cs
public event MyCustomEventHandler DoSomething;

this.DoSomething?.Invoke(this, new MyCustomEvent(123.95f));
```
