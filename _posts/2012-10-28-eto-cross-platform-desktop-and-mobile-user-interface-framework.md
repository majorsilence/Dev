---
layout: post
title: Eto - cross platform desktop and mobile user interface framework
created: 1351459631
redirect_from:
  - /eto_crossplatform_desktop_mobile/
---
I ran across a great .net project called <a href="https://github.com/picoe/Eto">Eto</a>. It is basically "a cross platform desktop and mobile user interface framework" that is similar to <a href="https://github.com/mono/xwt">xwt</a> but more mature and supporting more platforms.

I have been testing the winforms and wpf back ends and they seem to work great. It also has a mac and iOS back end that appear to be fully functional. An android back end is planned for the future and I am currently investigating this. 

It would be great if I can write the majority of my .net user interface code using one library and have it run on desktops and mobile. The only thing that would be lacking is windows rt support. 

To start developing with Eto download the binaries from https://github.com/picoe/Eto/downloads. Add the reference to your project and start programming. See https://github.com/picoe/Eto/wiki/Preparing-your-solution for more details to setup your project.


Screen Shot: <img src="http://majorsilence.com/sites/default/files/EtoFirstApp.png" /> 


VB.NET First App Example

```vb.net
Imports Eto.Forms
Imports Eto.Drawing

Class MyForm
    Inherits Form

    Public Sub New()
        Me.Title = &quot;My Cross-Platform App&quot;
        Me.Size = New Size(200, 200)

        Dim label = New Label()
        label.Text = &quot;Hello World!&quot;

        Me.AddDockedControl(label)
    End Sub

    <stathread> _
    Public Shared Sub Main()
        Dim app = New Application()
        AddHandler app.Initialized, Sub()
                                        app.MainForm = New MyForm()
                                        app.MainForm.Show()
                                    End Sub

        app.Run()
    End Sub

End Class
```


C# First Example App

```c#
using Eto.Forms;
using Eto.Drawing;

class MyForm : Form
{
	public MyForm()
	{
		this.Title = &quot;My Cross-Platform App&quot;;
		this.Size = new Size(200, 200);

		dynamic label = new Label();
		label.Text = &quot;Hello World!&quot;;

		this.AddDockedControl(label);
	}

	[STAThread()]
	public static void Main()
	{
		dynamic app = new Application();
		app.Initialized += delegate 
		{
			app.MainForm = new MyForm();
			app.MainForm.Show();
		};

		app.Run();
	}

}
```

https://github.com/picoe/Eto 
https://github.com/mono/xwt
