---
layout: post
title: My-FyiReporting Progress Update
created: 1344719846
redirect_from:
  - /node/531/
  - /news/2012/08/11/my-fyireporting-progress-update.html
---
There has been a little progress since the last update on My-FyiReporting.

A fix for <a href="https://github.com/majorsilence/My-FyiReporting/issues/15">Issue #15</a>, start the reader program maximized has been committed.

A fix for <a href="https://github.com/majorsilence/My-FyiReporting/issues/14">issue #14</a> has been committed. if the reader is passed a report file as its first start up parameter will automatically open that report has also been committed.  

In addition to these issues I noticed that rdlreader.exe would crash on start up if there were any files in list from the previous session.  This has been fixed.  I have also added a missing reference to rdlcri.dll t the rdlreader project.

Everyone that is interested in adding features or fixing bugs are encouraged to go to https://github.com/majorsilence/My-FyiReporting and create a fork and start sending in pull requests with your features and fixes.
