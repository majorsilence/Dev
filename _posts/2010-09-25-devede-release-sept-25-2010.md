---
layout: post
title: DeVeDe Release Sept 25 2010
created: 1285451990
excerpt: !ruby/string:Sequel::SQL::Blob |-
  SSBhbSByZWxlYXNpbmcgRGVWZURlIHdpbjMyIDMuMTYuOSBidWlsZCA2IGFz
  IG9mIHRoaXMgbW9tZW50LiAgRG93bmxvYWQgZnJvbSBodHRwOi8vd3d3Lm1h
  am9yc2lsZW5jZS5jb20vZGV2ZWRlDQoNCldpdGggdGhpcyByZWxlYXNlIGFs
  bCBkZWFkbG9jayBpc3N1ZXMgd2hpbGUgcmVhZGluZyBwcm9ncmVzcyBmcm9t
  IHRoZSBiYWNrZW5kIHByb2dyYW1zIHNob3VsZCBiZSBmaXhlZCBvbiBXaW5k
  b3dzLg0KDQpJIGhhdmUgcmUtZW5hYmxlZCBwcm9ncmVzcyBwZXJjZW50IG9u
  IHRoZSB2aWRlbyBjb252ZXJzaW9uIHN0YWdlLCBtcGcgdG8gdm9iIHN0YWdl
  IGFuZCB0aGUgbWtpc29mcyBzdGFnZSAoZm9yIHRob3NlIHRoYXQgYXJlIHVz
  aW5nIG1raXNvZnMgaW5zdGVhZCBvZiBpbWdidXJuKQ0KDQpJdCBoYXMgdGhl
  IHNhbWUgc3BlZWQgYXMgdGhlIGN1cnJlbnQgZGV2ZWRlIHdpdGggdGhlIHBy
  b2dyZXNzIHBlcmNlbnQgdHVybmVkIG9mZiBidXQgYWJvdXQgYSAyNSUgc3Bl
  ZWQgaW1wcm92ZW1lbnQgZnJvbSBwcmV2aW91cyB2ZXJzaW9ucyB0aGF0IGRp
  c3BsYXllZCB0aGUgcGVyY2VudCBmaW5pc2hlZC4NCg0=
redirect_from:
  - /node/434/
---
I am releasing DeVeDe win32 3.16.9 build 6 as of this moment.  Download from http://www.majorsilence.com/devede

With this release all deadlock issues while reading progress from the backend programs should be fixed on Windows.

I have re-enabled progress percent on the video conversion stage, mpg to vob stage and the mkisofs stage (for those that are using mkisofs instead of imgburn)

It has the same speed as the current devede with the progress percent turned off but about a 25% speed improvement from previous versions that displayed the percent finished.

I have also added a new program option so you can choose if you are using <a href="http://imgburn.com/">imgburn</a> or mkisofs.

devede.exe -imgburn will use imgburn if present.  If this option or if imgburn is not present devede will fall back to mkisofs.  By default the -imgburn option is being set.

Also included is the newest version of imburn at the moment and a newer version of mencoder and mplayer.
