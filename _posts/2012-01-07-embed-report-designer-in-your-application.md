---
layout: post
title: Embed Report Designer in your Application
created: 1325976636
redirect_from:
  - /myfyireporting_embed_report_designer/
  - /news/2012/01/07/embed-report-designer-in-your-application.html
---
This is something I have wanted to do and have been experimenting with.  I have modified fyiReporting in my fork called My-FyiReporting to allow using the designer inside my own application.

My-fyiReporting is a .net report designer and viewer that is written in c#.  The designer and viewer are programmed with c# and winforms.  There is also a new gtk# viewer available for those that need a report viewer on Linux.

See http://files.majorsilence.com/myfyireporting/ for binary packages of My-FyiReporting.   See https://github.com/majorsilence/My-FyiReporting/ for the project details and source code.

<h1>Open a Report</h1>
The simplest way to use the designer is to create an instance of the designer form and then load the report that you wish to use.  If you do not have a report to open then just create an instance of the form and show it.

First add a reference to RdlDesigner.exe in your project.  Then add the following code where you need to use a designer.  It is as easy as that.

```c#
fyiReporting.RdlDesign.RdlDesigner designer = new fyiReporting.RdlDesign.RdlDesigner("myFyiChannel", false);
designer.Show();
designer.OpenFile(@"Path\to\a\report.rdl");
```

Where it is passing in myFyiChannel as a parameter is the IPC name that is being used in the designer.  This must be unique or it will through an exception.  You will need to handle this.  I would suggest creating only one instance of the designer and show it when it is needed.

<h1>Create a new Report</h1>
If you want to create to prompt a user to create a new report you can do it like this.

```c#
DialogDatabase dlgDB = new fyiReporting.RdlDesign.DialogDatabase(this)
dlgDB.SetConnection("The Connection String", false, DialogDatabase.ConnectionType.SQLITE);
dlgDB.ShowDialog();
if (dlgDB.DialogResult == DialogResult.OK)
{
    string rdl = dlgDB.ResultReport;
    System.IO.File.WriteAllText("Path\to\new\report.rdl", dlgDB.ResultReport);
}
```

You can then open the new report using method described above.

See https://github.com/majorsilence/My-FyiReporting/wiki/Embed-the-Designer for more details about embedding the designer.
