---
layout: post
title: DeVeDe Win32 Release Process
created: 1285374818
excerpt: !ruby/string:Sequel::SQL::Blob |-
  VGhpcyBpcyBhIHNob3J0IGxpc3Qgb2YgdGhlIHN0ZXBzIG5lY2Vzc2FyeSB0
  byBidWlsZCBhIERlVmVEZSByZWxlYXNlIGZvciBXaW5kb3dzLg0KDQpTZWUg
  YWxzbyBodHRwOi8vbWFqb3JzaWxlbmNlLmNvbS93aW5kb3dzX2RldmVkZV9k
  ZXZlbG9wbWVudF9pbnN0cnVjdGlvbnMgZm9yIGluc3RydWN0aW9ucyBvbiBz
  ZXR0aW5nIHVwIERlVmVEZSBlbnZpcm9ubWVudCBvbiBXaW5kb3dzLg0KDQo8
  dWw+DQo8bGk+VXBkYXRlIFNldHVwLnB5IC0gdmVyc2lvbjwvbGk+DQo8bGk+
  VXBkYXRlIHZlcnNpb24udHh0PC9saT4NCjxsaT5VcGxvYWQgdmVyc2lvbi50
  eHQgdG8gd2Vic2l0ZTwvbGk+DQo8bGk+UnVuIEJ1aWxkLVRydW5rLnB5IHRv
  IHppcCBzb3VyY2UgY29kZSBhbmQgY3JlYXRlIGV4ZTwvbGk+DQo8bGk+UnVu
  IGRldmVkZS1zZXR1cC53YXJzZXR1cCAtIHVwZGF0ZSB2ZXJzaW9uIG51bWJl
  ciAtIGNyZWF0ZXMgbXNpIHBhY2thZ2U8L2xpPg0KPGxpPlVwbG9hZCBzb3Vy
  Y2UgdG8gd2Vic2l0ZTwvbGk+DQo8bGk+VXBsb2FkIG1zaSBwYWNrYWdlIHRv
  IHdlYnNpdGU8L2xpPg0=
redirect_from:
  - /node/433/
---
This is a short list of the steps necessary to build a DeVeDe release for Windows.

See also http://majorsilence.com/windows_devede_development_instructions for instructions on setting up DeVeDe environment on Windows.

<ul>
<li>Update Setup.py - version</li>
<li>Update version.txt</li>
<li>Upload version.txt to website</li>
<li>Run Build-Trunk.py to zip source code and create exe</li>
<li>Run devede-setup.warsetup - update version number - creates msi package</li>
<li>Upload source to website</li>
<li>Upload msi package to website</li>
<li>Create torrent of msi package an upload to website</li>
<li>Update website with link to torrent and date uploaded</li>
</ul>
