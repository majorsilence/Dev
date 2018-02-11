---
layout: post
title: My-FyiReporting Progress Update
created: 1344719846
excerpt: !ruby/string:Sequel::SQL::Blob |-
  VGhlcmUgaGFzIGJlZW4gYSBsaXR0bGUgcHJvZ3Jlc3Mgc2luY2UgdGhlIGxh
  c3QgdXBkYXRlIG9uIE15LUZ5aVJlcG9ydGluZy4NCg0KQSBmaXggZm9yIDxh
  IGhyZWY9Imh0dHBzOi8vZ2l0aHViLmNvbS9tYWpvcnNpbGVuY2UvTXktRnlp
  UmVwb3J0aW5nL2lzc3Vlcy8xNSI+SXNzdWUgIzE1PC9hPiwgc3RhcnQgdGhl
  IHJlYWRlciBwcm9ncmFtIG1heGltaXplZCBoYXMgYmVlbiBjb21taXR0ZWQu
  DQoNCkEgZml4IGZvciA8YSBocmVmPSJodHRwczovL2dpdGh1Yi5jb20vbWFq
  b3JzaWxlbmNlL015LUZ5aVJlcG9ydGluZy9pc3N1ZXMvMTQiPmlzc3VlICMx
  NDwvYT4gaGFzIGJlZW4gY29tbWl0dGVkLiBpZiB0aGUgcmVhZGVyIGlzIHBh
  c3NlZCBhIHJlcG9ydCBmaWxlIGFzIGl0cyBmaXJzdCBzdGFydCB1cCBwYXJh
  bWV0ZXIgd2lsbCBhdXRvbWF0aWNhbGx5IG9wZW4gdGhhdCByZXBvcnQgaGFz
  IGFsc28gYmVlbiBjb21taXR0ZWQuICANCg0=
redirect_from:
  - /node/531/
---
There has been a little progress since the last update on My-FyiReporting.

A fix for <a href="https://github.com/majorsilence/My-FyiReporting/issues/15">Issue #15</a>, start the reader program maximized has been committed.

A fix for <a href="https://github.com/majorsilence/My-FyiReporting/issues/14">issue #14</a> has been committed. if the reader is passed a report file as its first start up parameter will automatically open that report has also been committed.  

In addition to these issues I noticed that rdlreader.exe would crash on start up if there were any files in list from the previous session.  This has been fixed.  I have also added a missing reference to rdlcri.dll t the rdlreader project.

Everyone that is interested in adding features or fixing bugs are encouraged to go to https://github.com/majorsilence/My-FyiReporting and create a fork and start sending in pull requests with your features and fixes.
