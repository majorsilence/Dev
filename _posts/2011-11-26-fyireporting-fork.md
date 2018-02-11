---
layout: post
title: FyiReporting Fork
created: 1322340599
excerpt: !ruby/string:Sequel::SQL::Blob |-
  QXMgaXQgc2VlbXMgdGhhdCBmeWlSZXBvcnRpbmcgaGFzIGRpZWQgSSBoYXZl
  IG1hZGUgYSBmb3JrIChodHRwczovL2dpdGh1Yi5jb20vbWFqb3JzaWxlbmNl
  L015LUZ5aVJlcG9ydGluZykuICBJIGhhdmUgbWVyZ2VkIGluIHBhdGNoZXMg
  ZnJvbSB0aGUgZnlpUmVwb3J0aW5nIGZvcnVtLiAgSSBoYXZlIG1hZGUgYnVp
  bGQgc2NyaXB0cyB0byBjcmVhdGUgLm5ldCAyIGFuZCAubmV0IDQgcGFja2Fn
  ZXMuICBJIGFsc28gc2xvd2x5IGZpeGluZyBidWdzIGFzIEkgY29tZSBhY3Jv
  c3MgdGhlbS4gIEkgaGF2ZSBjb252ZXJ0ZWQgdGhlIHNvbHV0aW9ucyB0byB2
  aXN1YWwgc3R1ZGlvIDIwMDggZm9ybWF0IGFuZCBmaXhlZCB0aGUgcmVmZXJl
  bmNlcyBzbyB0aGUgc291cmNlIGNvZGUgd2lsbCBidWlsZC4NCg0KVGhlIHBy
  b2plY3RzIHNob3VsZCBhbHNvIGJ1aWxkIHdpdGggbm8gcHJvYmxlbXMgdXNp
  bmcgdmlzdWFsIHN0dWRpbyBleHByZXNzIDIwMDggb3IgMjAxMC4NCg0KSSBo
  YXZlIGEgY291cGxlIHJlYXNvbnMgZm9yIHRoaXM6DQ==
redirect_from:
  - /node/466/
---

As it seems that fyiReporting has died I have made a fork (https://github.com/majorsilence/My-FyiReporting).  I have merged in patches from the fyiReporting forum.  I have made build scripts to create .net 2 and .net 4 packages.  I also slowly fixing bugs as I come across them.  I have converted the solutions to visual studio 2008 format and fixed the references so the source code will build.

The projects should also build with no problems using visual studio express 2008 or 2010.

I have a couple reasons for this:
1. I want to have a free reporting solution that I can use in my own projects
2. I want a reporting solution I can run on mono/asp.net
3. I want that reporting solution to be somewhat compatible with Microsoft reporting
4. I need to know it is not going to disappear
5. I want to make it easy for others to use

I currently have two bugs that I am slowly working on.  The first is the RdlEngineConfig.xml file points to non-existent dlls so database support is not loaded in the designer.  I think I will fix the postgresql and sqlite problem by including the required dlls in the project.  For the other databases I will probably need to include any option to let users edit the paths to the dlls.  The only problem with this is that it means the project will be 32bit instead of AnyCPU since sqlite is 32bit only on windows.

The second bug is that I want an designer user control that can be embedded in other applications.  This means I will probably turn the current designer form into a user control and replace the current designer with a form with the new designer control added to the form.

Hopefully this will be useful to others besides myself.

Other free reporting solutions for .net:
https://github.com/tomaszkubacki/monoreports
https://sourceforge.net/projects/reportingcloud - this is another fork of fyiReporting but it also seems to have died
