---
layout: post
title: WarSetup Forked as WarPackager
created: 1344980617
excerpt: !ruby/string:Sequel::SQL::Blob |-
  SSBoYXZlIGRlY2lkZWQgdG8gZm9yayBXYXJTZXR1cC4gICBUaGlzIGlzIGJl
  Y2F1c2UgaXQgaGFzIG5vdCBiZWVuIHVwZGF0ZWQgaW4gc2V2ZXJhbCB5ZWFy
  cyBhbmQgd2FzIGxhY2tpbmcgc29tZSBmZWF0dXJlcyB0aGF0IEkgbmVlZGVk
  Lg0KDQpJIGNvdWxkIHN3aXRjaCB0byBvdGhlciBzb2Z0d2FyZSBidXQgSSBs
  aWtlIHdhcnNldHVwIGFuZCB3b3VsZCBwcmVmZXIgdG8gY29udGludWUgdXNp
  bmcgaXQuICBTbyB1bnRpbCB0aGUgbWFpbiBwcm9qZWN0IHN0YXJ0cyByZWxl
  YXNpbmcgdXBkYXRlcyBhZ2FpbiBJIHdpbGwgYmUga2VlcGluZyBteSBmb3Jr
  IGF0IGh0dHBzOi8vZ2l0aHViLmNvbS9tYWpvcnNpbGVuY2UvV2FyU2V0dXAt
  Rm9yay4gIA0KDQpJIGhhdmUgcmVuYW1lZCB0aGUgZXhlY3V0YWJsZSB0byBX
  YXJQYWNrYWdlciBzbyB0aGVyZSBpcyBubyBjb25mdXNpb24gYmV0d2VlbiB0
  aGUgbWFpbiBXYXJTZXR1cCBhbmQgbXkgZm9yay4gIA0KDQpDdXJyZW50IGFk
  ZGVkIGZlYXR1cmVzIFdhclBhY2thZ2VyIGhhcyBvdmVyIHRoZSBtYWluIFdh
  clNldHVwIGFyZToNCjx1bD4NCjxsaT5XaXggMy42IHN1cHBvcnQ8L2xpPg0=
redirect_from:
  - /node/532/
---
I have decided to fork WarSetup.   This is because it has not been updated in several years and was lacking some features that I needed.

I could switch to other software but I like warsetup and would prefer to continue using it.  So until the main project starts releasing updates again I will be keeping my fork at https://github.com/majorsilence/WarSetup-Fork.  

I have renamed the executable to WarPackager so there is no confusion between the main WarSetup and my fork.  

Current added features WarPackager has over the main WarSetup are:
<ul>
<li>Wix 3.6 support</li>
<li>Wix 3.5 support</li>
<li>OS requirements detection XP SP3, Vista SP1 and SP2, Windows 7 and SP1, Windows 8</li>
<li>Option to require minimum .NET version (2.0, 3.0, 3.5, 4.0 full or client)</li>
<li>Command line arguments</li>
<li>
<ul>
<li>-i "warsetup file to use.warsetup"</li>
<li>-c - compile msi automatically</li>
<li>-v "new product version number in format 1.1.1"</li>
<li>-a - auto increment version number before build and save</li>
<li>-e - auto exit after build</li>
</ul>
</li>
</ul>


Download page: https://github.com/majorsilence/WarSetup-Fork/downloads
