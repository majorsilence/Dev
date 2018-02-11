---
layout: post
title: Gtk# My-fyiReporting Widget
created: 1325514211
excerpt: !ruby/string:Sequel::SQL::Blob |-
  SSBoYXZlIGNyZWF0ZWQgYSBuZXcgZnlpUmVwb3J0aW5nIHZpZXdlciBmb3Ig
  TGludXggdXNpbmcgR3RrIy4gSXQgaXMgY3VycmVudGx5IHZlcnkgYmFzaWMg
  YnV0IHdpbGwgc2hvdyBhIHJlcG9ydC4gVGhlIGNvZGUgY2FuIGJlIHJldHJp
  ZXZlZCBmcm9tIGh0dHBzOi8vZ2l0aHViLmNvbS9tYWpvcnNpbGVuY2UvTXkt
  RnlpUmVwb3J0aW5nIGluIHRoZSBSZGxHdGtWaWV3ZXIgcHJvamVjdC4gSSBo
  YXZlIGN1cnJlbnRseSB0ZXN0ZWQgaXQgd2l0aCBVYnVudHUgMTEuMTAuDQoN
  CkFsbCBpc3N1ZXMgYW5kIGZlYXR1cmUgcmVxdWVzdHMgY2FuIGJlIHB1dCB0
  aHJvdWdoIHRoZSBwcm9qZWN0cyBnaXRodWIgaXNzdWVzIHBhZ2UuDQoNCkl0
  IGlzIHNpbXBsZSB0byB1c2UuIEFkZCBhIHJlZmVyZW5jZSB0byB0aGUgUmRs
  R3RrVmlld2VyIGFzc2VtYmx5IGluIHlvdXIgcHJvamVjdCBhbmQgdGhlbiBh
  ZGQgdGhlIFJkbEd0a1ZpZXdlciB3aWRnZXQgdG8gb25lIG9mIHlvdXIgZm9y
  bXMuDQoN
redirect_from:
  - /gtk_sharp_my_fyi_reporting_widget/
---
I have created a new fyiReporting viewer for Linux using Gtk#. It is currently very basic but will show a report. The code can be retrieved from https://github.com/majorsilence/My-FyiReporting in the RdlGtkViewer project. I have currently tested it with Ubuntu 11.10.

All issues and feature requests can be put through the projects github issues page.

It is simple to use. Add a reference to the RdlGtkViewer assembly in your project and then add the RdlGtkViewer widget to one of your forms.

Lets say I added a new instance called rdlgtkviewer1 to my project. I can load a report with parameters with the following line of code.
Code:

```c#
this.rdlgtkviewer1.LoadReport(
    new Uri(@"/home/peter/Projects/My-FyiReporting/Examples/SqliteExamples/SimpleTest3WithParameters.rdl"),
    "TestParam1=Hello and Goodbye&TestParam2=Testing parameter 2"); 
```
