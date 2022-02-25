---
layout: post
title: Gtk# My-fyiReporting Widget
created: 1325514211
redirect_from:
  - /gtk_sharp_my_fyi_reporting_widget/
  - /news/2012/01/02/gtk-my-fyireporting-widget.html
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
