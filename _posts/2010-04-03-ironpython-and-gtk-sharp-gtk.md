---
layout: post
title: IronPython and Gtk-Sharp/GTK#
created: 1270259752
excerpt: !ruby/string:Sequel::SQL::Blob |-
  VGhpcyBleGFtcGxlIG9mIHVzaW5nIElyb25QeXRob24gYW5kIEd0ayBTaGFy
  cCB3aWxsIHNob3cgaG93IHRvIGRvIHRoZSBmb2xsb3dpbmc6DQo8dWw+DQo8
  bGk+TGF5b3V0cyB3aXRoIEd0ay5WQm94PC9saT4NCjxsaT5HdGsuQnV0dG9u
  czwvbGk+DQo8bGk+R3RrLkVudHJ5PC9saT4NCjxsaT5XaWRnZXQgRXZlbnRz
  IChDYWxsYmFja3MpPC9saT4NCjxsaT5NZXNzYWdlIERpYWxvZ3M8L2xpPg0K
  PC91bD4NCg0KRm9yIHRoZSBsYXRlc3QgdXBkYXRlcyBjaGVjayBodHRwOi8v
  bWFqb3JzaWxlbmNlLmNvbS9QeUdUS19Cb29rLg0KDQ==
redirect_from:
  - /ironpython_gtksharp/
---
This example of using IronPython and Gtk Sharp will show how to do the following:
<ul>
<li>Layouts with Gtk.VBox</li>
<li>Gtk.Buttons</li>
<li>Gtk.Entry</li>
<li>Widget Events (Callbacks)</li>
<li>Message Dialogs</li>
</ul>

For the latest updates check http://majorsilence.com/PyGTK_Book.

To use Gtk Sharp from IronPython first you need to import the clr and add a reference to the gtk-sharp. Once this is finished you can import Gtk. The example below creates one window, adds a Gtk.Entry and Gtk.Button. The button has one event which is the self.HelloWorld function. The self.HelloWorld function displays a MessageDialog that will change the gtk.Entry default value to “Hello World!” if Yes is clicked. A Gtk.VBox is created and added to the window. This vbox is used to pack the self.textentry1 and button vertically. You can also use a Gtk.HBox instead or a combination of Gtk.VBox and Gtk.HBox.

Gtk.Application.Init() must be called before using Gtk and Gtk.Application.Run() starts the Gtk main event loop. The window has the DeleteEvent attached to call the self.DeleteEvent function. The self.DeleteEvent function alls Gtk.Application.Quite() which exits the application.

```python
import clr
clr.AddReference('gtk-sharp')
import Gtk

class GtkExample(object):
	def __init__(self):
		Gtk.Application.Init()
		
		self.window = Gtk.Window("Hello World")
		self.window.DeleteEvent += self.DeleteEvent
		
		vbox = Gtk.VBox() 
		
		button = Gtk.Button("Show Message")
		button.Clicked += self.HelloWorld
		
		self.textentry1 = Gtk.Entry("Default Text")
		
		vbox.PackStart(self.textentry1)
		vbox.PackStart(button)
		
		self.window.Add(vbox)
		self.window.ShowAll()
		Gtk.Application.Run()

	def DeleteEvent(self, widget, event):
		Gtk.Application.Quit()
		
	def HelloWorld(self, widget, event):
		m = Gtk.MessageDialog(None, Gtk.DialogFlags.Modal, Gtk.MessageType.Info, \
			Gtk.ButtonsType.YesNo, False, 'Change the text entry to "Hello World?"')

		result = m.Run()
		m.Destroy()
		if result == int(Gtk.ResponseType.Yes):
			self.textentry1.Text = "Hello World!"
		
	
if __name__ == "__main__":
	GtkExample()
```
