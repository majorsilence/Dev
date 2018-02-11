---
layout: post
title: Gtk# Pdf Viewer
created: 1324428512
excerpt: !ruby/string:Sequel::SQL::Blob |-
  SXQgdHVybnMgb3V0IHRoYXQgY3JlYXRpbmcgYSBwZGYgdmlld2VyIG9uIExp
  bnV4IHVzaW5nIGMjIG9yIHZiLm5ldCBpcyB2ZXJ5IGVhc3kuICBZb3Ugd2ls
  bCBuZWVkIGEgcmVmZXJlbmNlIHRvIHBvcHBsZXItc2hhcnAuZGxsLiAgDQoN
  Ck9uIHVidW50dSBpbnN0YWxsIHRoZSBwYWNrYWdlIGxpYnBvcHBsaWVyLWNp
  bC4gIFRoZXJlIGlzIG9uZSBwcm9ibGVtIHdpdGggdGhpcyBwYWNrYWdlOyBp
  dCBkb2VzIG5vdCBzaG93IHVwIGluIHRoZSByZWZlcmVuY2UgbGlzdCBpbiBN
  b25vRGV2ZWxvcC4gIFNvIHlvdSB3aWxsIG5lZWQgdG8gYnJvd3NlIHRvIHRo
  ZSBkbGwuICBPbiBteSBzeXN0ZW0gaXQgd2FzIGluXHVzclxsaWJccG9wcGxl
  ci1zaGFycFxwb3BwbGVyLXNoYXJwLmRsbC4NCg0KRm9yIGEgZnVsbHkgd29y
  a2luZyBjb2RlIGV4YW1wbGUgc2VlIGh0dHBzOi8vZ2l0aHViLmNvbS9tYWpv
  cnNpbGVuY2UvZ3RrLXNoYXJwLXBkZi13aWRnZXQuDQoNCkZpcnN0IHRoaW5n
  IHlvdSB3aWxsIG5lZWQgdG8gZG8gaXMgZGVjbGFyZSBhIHBvcHBsZXIgZG9j
  dW1lbnQgYW5kIGEgdmFyaWFibGUgdG8ga2VlcCB0cmFjayBvZiB5b3VyIGN1
  cnJlbnQgcGFnZS4N
redirect_from:
  - /node/468/
---
It turns out that creating a pdf viewer on Linux using c# or vb.net is very easy.  You will need a reference to poppler-sharp.dll.  

On ubuntu install the package libpopplier-cil.  There is one problem with this package; it does not show up in the reference list in MonoDevelop.  So you will need to browse to the dll.  On my system it was in\usr\lib\poppler-sharp\poppler-sharp.dll.

For a fully working code example see https://github.com/majorsilence/gtk-sharp-pdf-widget.

First thing you will need to do is declare a poppler document and a variable to keep track of your current page.

```c#
private Poppler.Document pdf;
private int pageIndex = 0;
```

The SetContinuousPageMode function will loop through everypage in the pdf, create a new gtk image to draw on then call the RenderPage function to render the page to the image and draw it to the gtk window.

```c#
private void SetContinuousPageMode()
{
	foreach (Gtk.Widget w in vboxImages.AllChildren)
	{
		vboxImages.Remove(w);
	}

	for (this.pageIndex = 0; this.pageIndex < pdf.NPages; this.pageIndex++)
	{
		Gdk.Pixbuf pixbuf = new Gdk.Pixbuf (Gdk.Colorspace.Rgb, false, 8, 0, 0);
		Gtk.Image img = new Gtk.Image();
		img.Pixbuf = pixbuf;
		img.Name = "image1";

		//vboxImages.Add (img);
		RenderPage(ref img);
	}

	this.ShowAll();
}
```

The RenderPage function is the function that actually draws the pdf page to the screen. It will retrieve the page you want and set the size of image being drawn to the size of the pdf page.   

```c#
private void RenderPage (ref Gtk.Image img) 
{

	Poppler.Page page = this.pdf.GetPage(this.pageIndex);
	double width=0D;
	double height=0D;
	page.GetSize(out width, out height);

	// It is important to set the image to have the correct size
	img.Pixbuf  = new  Gdk.Pixbuf (Gdk.Colorspace.Rgb, false, 8, (int)width, (int)height);
	Gdk.Pixbuf pixbuf = img.Pixbuf;
	
	page.RenderToPixbuf(0, 0, (int)width, (int)height, 1.0, 0, pixbuf);
	img.Pixbuf = pixbuf;
	vboxImages.Add (img);		
}
```

I plan on using this to do an initial and very basic Gtk# report viewer for <a href="https://github.com/majorsilence/My-FyiReporting">My-FyiReporting</a>.

See https://github.com/majorsilence/gtk-sharp-pdf-widget for a working example.
