---
layout: post
title: GTK# MessageDialog
created: 1259364190
redirect_from:
  - /node/302/
---

```c#
MessageDialog m = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.YesNo, false, 
    "Should the textbox be set to Hello World");
ResponseType result = (ResponseType)m.Run();
m.Destroy();
		
if (result == ResponseType.Yes)
{
	entry1.Text = "Hello World";
}
```
