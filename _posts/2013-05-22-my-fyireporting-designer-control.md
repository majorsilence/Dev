---
layout: post
title: My-FyiReporting Designer Control
created: 1369190233
redirect_from:
  - /node/546/
---
I have recently pushed a new My-FyiReporting designer control to master.

It is a winform designer and includes examples of how to host in WPF.

Simple winform example

```c#
[STAThread]
static void Main()
{
	Application.EnableVisualStyles();
	Application.SetCompatibleTextRenderingDefault(false);
	Form frm = new Form();
	fyiReporting.RdlDesign.RdlUserControl ctl = new fyiReporting.RdlDesign.RdlUserControl();
	ctl.OpenFile(@"The path to the rdl file.rdl");
	ctl.Dock = DockStyle.Fill;
	frm.Controls.Add(ctl);

	Application.Run(frm);
}
```

For more details and wpf examples see https://github.com/majorsilence/My-FyiReporting/wiki/Designer-Control
