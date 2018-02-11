---
layout: post
title: MPlayer .NET Wrapper
created: 1294357567
excerpt: !ruby/string:Sequel::SQL::Blob |-
  VVBEQVRFOiAwOS8wMy8yMDExDQpTb3VyY2UgY29kZSBpcyBub3cgaG9zdGVk
  IGF0IGdpdGh1YjoNCmh0dHBzOi8vZ2l0aHViLmNvbS9tYWpvcnNpbGVuY2Uv
  TVBsYXllckNvbnRyb2wNCg0KVVBEQVRFOiAwNC8wMy8yMDExDQpVcGxvYWRl
  ZCBuZXcgcGFja2FnZSB3aXRoIGJ1ZyBmaXhlcy4NCg0KSSBoYXZlIHdyaXR0
  ZW4gYSBzbWFsbCAuTkVUIHdyYXBwZXIgbGlicmFyeSBmb3IgTVBsYXllciAu
  ICBUaGlzIGhhcyBiZWVuIHRlc3RlZCBvbiBXaW5kb3dzIFhQLzcgYW5kIFVi
  dW50dSBMaW51eCAxMC4xMC4gIEl0IHNob3VsZCB3b3JrIGZpbmUgb24gT1Mg
  WCBhbmQgYW55d2hlcmUgZWxzZSB0aGF0IG1vbm8gcnVucy4NCg0=
redirect_from:
  - /node/443/
---
UPDATE: 09/03/2011
Source code is now hosted at github:
https://github.com/majorsilence/MPlayerControl

UPDATE: 04/03/2011
Uploaded new package with bug fixes.

I have written a small .NET wrapper library for MPlayer .  This has been tested on Windows XP/7 and Ubuntu Linux 10.10.  It should work fine on OS X and anywhere else that mono runs.

On windows it requires that there be a directory and file "backend\mplayer.exe" in it in the same folder as the dll.  On all other system it requires that mplayer be installed and in the path.  It may require some tweaks to getting working on some systems.

It can play both audio and video files.  It includes a sample user interface.

It currently supports play, pause, stop. seek and some other basic functionality.  I only add new features as I require them or people send in patches.  

