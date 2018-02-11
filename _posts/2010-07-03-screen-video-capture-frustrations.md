---
layout: post
title: Screen Video Capture Frustrations
created: 1278194948
excerpt: !ruby/string:Sequel::SQL::Blob |-
  TXkgU2NyZWVuIFZpZGVvIENhcHR1cmUgc29mdHdhcmUgd29ya3MgcGVyZmVj
  dCBvbiBteSBob21lIGNvbXB1dGVyICg2NC1iaXQgV2luZG93cyBWaXN0YSkg
  YnV0IGNyYXNoZXMgYWxtb3N0IGltbWVkaWF0ZWx5IG9uIG15IHdvcmsgY29t
  cHV0ZXIgKDY0LWJpdCBXaW5kb3dzIDcpLg0KDQpJIGhhdmUgYmVlbiBydW5u
  aW5nIGl0IGluIHRoZSBkZWJ1Z2dlciBmb3IgYSB3aGlsZSBub3cgYW5kIGhh
  dmUgZml4ZWQgb25lIGVycm9yLiAgSSBhbSBhbHNvIGxvZ2dpbmcgYWxsIGV4
  Y2VwdGlvbnMgcHJvcGVybHkgbm93IHNvIHRoYXQgc2hvdWxkIGhlbHAgaWYg
  SSBnZXQgYW55IGVycm9ycyBvbiBhbm90aGVyIGNvbXB1dGVyLiANCg0KV2F0
  Y2hpbmcgdGhlIHRhc2sgbWFuYWdlciBpdCBhcHBlYXJzIHRoYXQgSSBhbHNv
  IGhhdmUgYSBHREkgbGVhayB0aGF0IGNvdWxkIGJlIGNhdXNpbmcgbnVtZXJv
  dXMgcHJvYmxlbXMuICBJbiBmYWN0IGFmdGVyIHdhdGNoaW5nIGl0IGhpdCB0
  aGUgZGVmYXVsdCBsaW1pdCAoMTAwMDApIGl0IGRvZXMgaW5kZWVkIGNhdXNl
  IGJhZCB0aGluZ3MgdG8gaGFwcGVuLg0KDQ==
redirect_from:
  - /node/402/
---
My Screen Video Capture software works perfect on my home computer (64-bit Windows Vista) but crashes almost immediately on my work computer (64-bit Windows 7).

I have been running it in the debugger for a while now and have fixed one error.  I am also logging all exceptions properly now so that should help if I get any errors on another computer. 

Watching the task manager it appears that I also have a GDI leak that could be causing numerous problems.  In fact after watching it hit the default limit (10000) it does indeed cause bad things to happen.

I have tracked the error to the following code.  It is almost certainly the CaptureCursor method that is causing the problems.

```c#
Bitmap cursorBMP = mspos.CaptureCursor(ref x, ref y);
if (cursorBMP != null)
{
    Rectangle r = new Rectangle(x, y, cursorBMP.Width, cursorBMP.Height);
    g.DrawImage(cursorBMP, r);
}
```

Thanks to a helpful comment on http://www.codeproject.com/KB/cs/DesktopCaptureWithMouse.aspx the problem should now be fixed and it was in CaptureCursor.  So I should soon have a new package uploaded to http://majorsilence.com/screen_video_capture.
