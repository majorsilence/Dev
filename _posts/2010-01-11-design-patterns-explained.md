---
layout: post
title: 'Design Patterns Explained '
created: 1263175184
excerpt: !ruby/string:Sequel::SQL::Blob |-
  UmVzdWx0cyBvZiByZWFkaW5nIERlc2lnbiBQYXR0ZXJucyBFeHBsYWluZWQu
  ICBNeSBkZWZpbml0aW9ucyBhcmUgdmVyeSBsb29zZS4gIEZvciBiZXR0ZXIg
  dW5kZXJzdGFuZGluZyByZWFkIHRoZSBib29rIG9yIHZpc2l0IFdpa2lwZWRp
  YS4NCg0KPHN0cm9uZz5GYWNhZGUgcGF0dGVybjwvc3Ryb25nPiAtIEJhc2lj
  YWxseSBDcmVhdGUgYSB3cmFwcGVyIGFyb3VuZCBtZXRob2RzL2NsYXNzZXMg
  dG8gdG8gZWFzZSB1c2UgKHNpbXBsaWZpZWQgaW50ZXJmYWNlKS4NCg0KPHN0
  cm9uZz5BZGFwdGVyIHBhdHRlcm48L3N0cm9uZz4gLSBCYXNpY2FsbHkgQ3Jl
  YXRlIGEgd3JhcHBlciBmb3IgYSBjbGFzcyB0byBtZWV0IGEgZGVmaW5lZCBp
  bnRlcmZhY2UuICBTaW1pbGFyIHRvIGEgRmFjYWRlLiAgDQoN
redirect_from:
  - /design_patterns_explained/
---
Results of reading Design Patterns Explained.  My definitions are very loose.  For better understanding read the book or visit Wikipedia.

<strong>Facade pattern</strong> - Basically Create a wrapper around methods/classes to to ease use (simplified interface).

<strong>Adapter pattern</strong> - Basically Create a wrapper for a class to meet a defined interface.  Similar to a Facade.  

<strong>Bridge pattern</strong> -  The abstraction/interface is separate from the implementation.   Create the interface.  Then program the implementation to the interface.  The interface is never a concrete implementation itself.

<strong>Abstract Factory pattern</strong>
Create an abstract class.  Create concrete classes from abstract class.  Have another class that.
Abstract/Interface A
Implementation B
Implementation C

Class D returns 

Class E calls D which returns either B or C.  Since both implement A they both have the same methods and properties and can be used interchangeably.  At least this is what I gathered from the chapter.

• First, identify the rules for instantiation and define an abstract
  class with an interface that has a method for each object that
  needs to be instantiated.
• Then, implement concrete classes from this class for each
  family.
• The client object uses this factory object to create the server
  objects that it needs.


<strong>Strategy Pattern</strong> -  Encapsulating an algorithm(s) in an abstract class  and using one of them at a time inter-changeably.
GOF: Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from the clients that use it.

<strong>Decorator Pattern</strong> - Attach additional responsibilities to a object dynamically.

<strong>Singleton pattern</strong> - used in single threaded applications.  Purpose is to make sure only one instance of a class is instantiated. 

<strong>Double-Checked Locking Pattern</strong> - like singleton but used in multi threaded application.  Purpose is to make sure only one instance of a class is instantiated.

Eg. Constructor is private so the only instance can be created with the Instance Property

```c#
  public sealed class Login
  {
         private static volatile Login instance;
         private static object syncRoot = new Object();

         private Login() { }

         public static Login Instance
         {
            get 
            {
               if (instance == null) 
               {
                  lock (syncRoot) 
                  {
                      if (instance == null)
                      {
                          instance = new Login();
                      }
                  }
               }

               return instance;
            }
         }
  }
```

<strong>Observer pattern</strong>  An object called the subject maintains a list of its dependants, called observers, and notifies them automatically of any state changes, by calling one of their methods. 

Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

<strong>The Template Method Pattern</strong> Define the skeleton of an algorithm in an operation, deferring some steps to subclasses. Redefine the steps in an algorithm without changing the algorithm's structure.

<strong>Factory Pattern Method</strong>
"When there is a method involved in making an object, the approach is
called a Factory Method."

According to the Gang of Four, the intent of the Factory Method is to:
Define an interface for creating an object, but let sub-classes decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses. 

