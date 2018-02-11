---
layout: post
title: DreamHostAPI Nearing First Release
created: 1243438497
excerpt: !ruby/string:Sequel::SQL::Blob |-
  TG9va2luZyB0aHJvdWdoIHRoZSBjb2RlIEkgaGF2ZSBmb3IgdGhlIC5ORVQg
  ZHJlYW1ob3N0IGxpYnJhcnkgSSBjYW4gbm93IHNheSB0aGF0IEkgaGF2ZSAx
  MDAlIG9mIHRoZSBwcml2YXRlIHNlcnZlciBBUEkgY292ZXJlZC4gIFVubGVz
  cyBJIGhhdmUgb3Zlcmxvb2tlZCBzb21ldGhpbmcsIGFzIGZhciBhcyBJIGNh
  biB0ZWxsIEkgb25seSBoYXZlIHRoZSBBbm5vdW5jZW1lbnQgbGlzdCBsZWZ0
  IHRvIGRvLiANCg0KVGhpcyBoYXMgYmVlbiBhbiBpbnRlcmVzdGluZyBwcm9q
  ZWN0IGFuZCBhIG5pY2UgaW50cm9kdWN0aW9uIHRvIGEgZmV3IHNpbXBsZSBh
  c3BlY3RzIG9mIC5ORVQgcHJvZ3JhbW1pbmcuICBPbmNlIHRoZSBhbm5vdW5j
  ZW1lbnQgQVBJIGlzIGZpbmlzaGVkIEkgYW0gbm90IHN1cmUgaWYgSSB3aWxs
  IGNvbnRpbnVlIHdpdGggdGhpcyBwcm9qZWN0LiAgSWYgSSBkbyBjb250aW51
  ZSBJIHdpbGwgY2xlYW4gdXAgdGhlIGNvZGUgc29tZXdoYXQgYW5kIG1ha2Ug
  dGhlIGVycm9yIHJlcG9ydGluZyBtb3JlIHVzZWZ1bC4NCg0=
redirect_from:
  - /node/98/
---
Looking through the code I have for the .NET dreamhost library I can now say that I have 100% of the private server API covered.  Unless I have overlooked something, as far as I can tell I only have the Announcement list left to do. 

This has been an interesting project and a nice introduction to a few simple aspects of .NET programming.  Once the announcement API is finished I am not sure if I will continue with this project.  If I do continue I will clean up the code somewhat and make the error reporting more useful.

The example user interface that I have been programming along with the library is also coming along.  It does not implement all the library features yet but you can adjust your memory usage, list private server history and stats, list: users, domains, dns information.

Still to be done with the GUI is to is: save user information in a configuration file and load it when the program opens, setting most of the private server settings, announcements, and adding and removing DNS.
