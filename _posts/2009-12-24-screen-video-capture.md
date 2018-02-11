---
layout: post
title: Screen Video Capture
created: 1261622908
excerpt: !ruby/string:Sequel::SQL::Blob |-
  SSBuZWVkZWQgYSBzY3JlZW4gdmlkZW8gY2FwdHVyZSBzb2Z0d2FyZSB0aGF0
  IHdhcyBmcmVlIGFuZCBvcGVuIHNvdXJjZSBhbmQgd29ya2VkIHdpdGggc2V2
  ZXJhbCBkaWZmZXJlbnQgdmlkZW8gdHlwZXMuICBJIGFsc28gd2FudGVkIHRo
  ZSBwcm9ncmFtIHRvIHJlY29yZCB0aGUgcHJvcGVyIHNjcmVlbiBjb2xvdXJz
  LiAgU28gSSB3cm90ZSBhIHNtYWxsIHByb2dyYW0gdG8gZG8gdGhpcy4gIEl0
  IHVzZXMgbWVuY29kZXIgdG8gZG8gdGhlIHZpZGVvIHByb2Nlc3Npbmcgc28g
  SSB3aWxsIGJlIGFibGUgdG8gYWRkIGFsbW9zdCBhbnkgdmlkZW8gZm9ybWF0
  IGFzIHRoZSBvdXRwdXQuICBDdXJyZW50IGl0IG91dHB1dHMgbXBlZy9tcDMg
  aW4gYW4gYXZpIGNvbnRhaW5lci4NCg0=
redirect_from:
  - /node/313/
---
I needed a screen video capture software that was free and open source and worked with several different video types.  I also wanted the program to record the proper screen colours.  So I wrote a small program to do this.  It uses mencoder to do the video processing so I will be able to add almost any video format as the output.  Current it outputs mpeg/mp3 in an avi container.

See the two attached files.  Warning, this is very alpha quality software.  When doing a new recording always make sure it is in a new empty folder.  It should not harm any other files but I would not take the chance.  Tested on 64 bit Vista.  Not sure how well it will work on Windows XP or 7.

It currently uses a lot of memory.   Can only record from the primary screen.  Only does full screen recordings.   Which is fine for my needs. 

It also currently highlights the mouse location and records from the computer mic.

UPDATE: Get the latest release and news from http://majorsilence.com/screen_video_capture
