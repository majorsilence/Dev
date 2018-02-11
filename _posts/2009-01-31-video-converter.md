---
layout: post
title: Video Converter
created: 1233368314
excerpt: !ruby/string:Sequel::SQL::Blob |-
  QSBjb3VwbGUgb2YgbW9udGhzIGFnbyBJIHNvcnQgb2YgZm9ya2VkIG9mZiBh
  IHZlcnNpb24gb2YgPGEgaHJlZj0iaHR0cDovL29nZ2NvbnZlcnQudHJpc3Rh
  bmIubmV0LyI+b2dnY29udmVydDwvYT4gYW5kIGNhbGxlZCBpdCA8YSBocmVm
  PSJ2aWRlbzJ0aGVvcmEiPnZpZGVvMnRoZW9yYTwvYT4uICBCYXNpY2FsbHkg
  d2hhdCBJIGRpZCB3YXMgdGFrZSB0aGUgb2dnY29udmVydHMgcHJvamVjdHMg
  Z2xhZGUgZmlsZSBhcyBhIGJhc2UgYW5kIGluc3RlYWQgb2YgdXNpbmcgZ3N0
  cmVhbWVyIEkgdXNlZCBmZm1wZWcgdG8gY3JlYXRlIGEgcHJvZ3JhbSB0aGF0
  IHdvdWxkIGFsbG93IGNvbnZlcnRpbmcgdmlkZW8gZmlsZXMgdG8gdGhlb3Jh
  IHZpZGVvcyBmb3IgdXNlIHdpdGggdGhlIG5ldyBmaXJlZm94IGFuZCA8YSBo
  cmVmPSJodHRwOi8vd3d3Lm9wZXJhLmNvbS8iPm9wZXJhPC9hPiB2aWRlbyB0
  YWdzLg0KDQ==
redirect_from:
  - /blog_video2theora/
---
A couple of months ago I sort of forked off a version of <a href="http://oggconvert.tristanb.net/">oggconvert</a> and called it <a href="video2theora">video2theora</a>.  Basically what I did was take the oggconverts projects glade file as a base and instead of using gstreamer I used ffmpeg to create a program that would allow converting video files to theora videos for use with the new firefox and <a href="http://www.opera.com/">opera</a> video tags.

I hope this is only a temporary situation until gstreamer codecs on windows is in better shape.  I attempted to get oggconvert to work on windows following the instructions on the website but gstreamer kept crashing.  Hopefully this will improve in the future.  Until then I will be using the gui based on ffmpeg.
