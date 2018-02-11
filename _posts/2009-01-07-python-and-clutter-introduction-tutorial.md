---
layout: post
title: Python and Clutter Introduction/Tutorial
created: 1231368695
excerpt: !ruby/string:Sequel::SQL::Blob |-
  Q2hlY2sgb3V0IGh0dHA6Ly9tYWpvcnNpbGVuY2UuY29tL3B5Z3RrX2Jvb2sg
  Zm9yIHRoZSBtb3N0IHVwIHRvIGRhdGUgdmVyc2lvbi4NCg0KVGhlIGJlc3Qg
  d2F5IHRvIGRlc2NyaWJlIGNsdXR0ZXIgaXMgdG8gcXVvdGUgaXRzIGhvbWUg
  cGFnZSB3aGljaCBzdGF0ZXM6DQoNCkNsdXR0ZXIgaXMgYW4gb3BlbiBzb3Vy
  Y2Ugc29mdHdhcmUgbGlicmFyeSBmb3IgY3JlYXRpbmcgZmFzdCwgdmlzdWFs
  bHkgcmljaCBhbmQgYW5pbWF0ZSBncmFwaGljYWwgdXNlciBpbnRlcmZhY2Vz
  Lg0KDQpDbHV0dGVyIGNhbiBiZSBpbnRlZ3JhdGVkIHdpdGggbWFueSBMaW51
  eCB0ZWNobm9sb2dpZXMgaW5jbHVkaW5nIEdTdHJlYW1lciwgQ2Fpcm8gYSBH
  VEsrLiAgSXQgYWxzbyBpcyBwb3J0YWJsZSBhbmQgcnVucyBvbiBXaW5kb3dz
  IGFuZCBPU1gsIHdoaWNoIGFsbG93cyBmb3IgY3Jvc3MgcGxhdGZvcm0gZ29v
  ZG5lc3MuDQoN
redirect_from:
  - /blog_python_clutter_introduction/
---
Check out http://majorsilence.com/pygtk_book for the most up to date version.

The best way to describe clutter is to quote its home page which states:

Clutter is an open source software library for creating fast, visually rich and animate graphical user interfaces.

Clutter can be integrated with many Linux technologies including GStreamer, Cairo a GTK+.  It also is portable and runs on Windows and OSX, which allows for cross platform goodness.

But how is clutter used? This is actually very simple. Instead of creating a gtk.Window as in using PyGTK, with clutter, a clutter.Stage is created. And instead of using widgets, Actors are used. This is actually rather neat. We have Stages to do the work on with Actors that perform.

Some base Actors included with clutter are:
<ul>
<li>Label - displaying Labels</li>
<li>Rectangle - For creating Rectangles</li>
<li>Entry - For entering text</li>
</ul>

A stage is created by using the clutter.Stage object like so:
&nbsp;&nbsp;&nbsp;&nbsp;stage = clutter.Stage()

The size of stage can be set:
&nbsp;&nbsp;&nbsp;&nbsp;stage.set_size(800, 400)

The title of the stage can be set using the stage.set_title() method:
&nbsp;&nbsp;&nbsp;&nbsp;stage.set_title("Hey Hey, My First Clutter App")

<h1>Colors</h1>
The colour of a stage can be set using set_color() method and using the clutter.color_parse()
method.   The clutter parse method can take several different colour inputs including the colours
as Text or HTML Notation.

The colour of a stage can be set:

&nbsp;&nbsp;&nbsp;&nbsp;stage.set_color(clutter.color_parse("red"))
&nbsp;&nbsp;&nbsp;&nbsp;stage.set_color(clutter.color("#FF0000"))

Or the colour may be set directly using the clutter.Color() using RGB colors.
&nbsp;&nbsp;&nbsp;&nbsp;stage.set_color(clutter.Color(255, 0, 0))

Colours can not just be applied to a stage as has been shown here but may also be applied to all the Actors that will be shown in the next section.

<h1>Your First Actor</h1>
The clutter.Label Actor allows the programmer to put text labels anywhere on the stage. These are useful to display information to the user of the program.  A small example of labels changing the font type and size of the letters. If no position is set it will default to placing the labels in the upper most left corner.

```python
import clutter

stage = clutter.Stage()
stage.set_size(400, 400)

label = clutter.Label()
label.set_text("Clutter Label Text")
# If no position is given it defaults to the upper most left corner.

stage.add(label)
stage.show_all()

clutter.main()
```

Thats it for now.  In the next installment I will cover basic animations.
