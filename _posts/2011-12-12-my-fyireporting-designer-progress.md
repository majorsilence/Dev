---
layout: post
title: My-FyiReporting Designer Progress
created: 1323650451
excerpt: !ruby/string:Sequel::SQL::Blob |-
  VGhlIE15LUZ5aVJlcG9ydGluZyBmeWlSZXBvcnRpbmcgZm9yayBpcyBtYWtp
  bmcgZ29vZCBwcm9ncmVzcy4gICBJIGhhdmUgdGhlIGRlc2lnbmVyIGNsZWFu
  ZWQgdXAgZW5vdWdoIHRvIHdvcmsgd2l0aC4gIEl0IGlzIG5vdyBtb3N0bHkg
  ZG9uZSBpbiB0aGUgdmlzdWFsIHN0dWRpbyBkZXNpZ25lci4gIEl0IGlzIHBv
  c3NpYmxlIHRvIHVzZSB0aGUgTXktRnlpUmVwb3J0aW5nIGRlc2lnbmVyIGZy
  b20gb3RoZXIgYXBwbGljYXRpb25zLiAgQWxsIHlvdSBuZWVkIHRvIGRvIGlz
  IGFkZCBSZGxEZXNpZ25lci5leGUgYXMgYSByZWZlcmVuY2UgaW4geW91ciBw
  cm9qZWN0LiAgVGhlcmUgaXMgc3RpbGwgc29tZSB3b3JrIHRvIGRvIG9uIHRo
  aXMgYnV0IGl0IGlzIHBvc3NpYmxlIHRvIHVzZSBhcyBpcy4NCg0K
redirect_from:
  - /node/467/
---
The My-FyiReporting fyiReporting fork is making good progress.   I have the designer cleaned up enough to work with.  It is now mostly done in the visual studio designer.  It is possible to use the My-FyiReporting designer from other applications.  All you need to do is add RdlDesigner.exe as a reference in your project.  There is still some work to do on this but it is possible to use as is.

See https://github.com/majorsilence/My-FyiReporting/wiki/Embed-the-Designer for code examples of using the designer from vb.net or c#.  You should also be able to use it from any .net language such as IronPython or IronRuby.

I have also fixed a bug that would stop exports to excel.

The build scripts have been updated to package some files that were being missed.  The build scripts have also been updated to do 32bit and 64 bits for both .net 3.5 and .net 4.0.   Currently an installation package is only for .net 3.5.

The code is available from https://github.com/majorsilence/My-FyiReporting and the readme has links to binary packages.
