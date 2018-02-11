---
layout: post
title: DeVeDe News
created: 1233807837
excerpt: !ruby/string:Sequel::SQL::Blob |-
  SSBzcGVudCBzb21lIHRpbWUgdG9kYXkgYW5kIHVwZGF0ZWQgdGhlIHNvdXJj
  ZSBjb2RlIGZvciBEZVZlRGUgV2luZG93cyB0byB1c2UgZ3RrLkJ1aWxkZXIg
  aW5zdGVhZCBvZiBnbGFkZS4gIFNlZW1zIHRvIHdvcmsgb2theSwgYWx0aG91
  Z2ggSSB3aWxsIHNwZW5kIHNvbWUgbW9yZSB0aW1lIHRlc3RpbmcgYW5kIGZp
  eGluZyBhIGZldyBidWdzLiAgTXkgcHJpbWFyeSByZWFzb24gZm9yIHRoaXMg
  aXMgdGhhdCBpdCB3b3VsZCBhbGxvdyBtZSB0byB1c2UgdGhlIHZlcnNpb24g
  b2YgR1RLIGRpc3RyaWJ1dGVkIGZyb20gd3d3Lmd0ay5vcmcgd2l0aG91dCBo
  YXZpbmcgdG8gYm90aGVyIGdldHRpbmcgZ2xhZGUgdG8gd29yayB3aXRoIGl0
  IG9uIFdpbmRvd3MuICBTbyBwZXJoYXBzIHNvbWVkYXkgc29vbiBEZVZlRGUg
  d2lsbCBzd2l0Y2ggb3ZlciB0byB1c2luZyB0aGUgbmV3IGJ1aWxkZXIgdGVj
  aG5vbG9neS4NCg0=
redirect_from:
  - /node/48/
---
I spent some time today and updated the source code for DeVeDe Windows to use gtk.Builder instead of glade.  Seems to work okay, although I will spend some more time testing and fixing a few bugs.  My primary reason for this is that it would allow me to use the version of GTK distributed from www.gtk.org without having to bother getting glade to work with it on Windows.  So perhaps someday soon DeVeDe will switch over to using the new builder technology.

Besides the hour I spent converting DeVeDe to builder, I spent a few minutes to fix a bug that kept DeVeDe from working on Windows 2000.  So updated installation packages will be uploaded within a few days.  I plan on moving to msi packages, so whenever that is completed is when the installers will be uploaded.
