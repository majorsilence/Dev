---
layout: post
title: fyiReporting AsynchronousThreadAbort
created: 1259442448
redirect_from:
  - /blog_fyireporting_asynchronousthreadabort/
---
I finally figured out what was causing the AsynchronousThreadAbort in MajorSilence2257 when using fyiReporting.  Apparently it is caused by setting rdlView.ShowWaitDialog = true.  You must set it to false as soon as you create a new instance of the rdlviewer.

```c#
rdlView = new fyiReporting.RdlViewer.RdlViewer();
rdlView.ShowWaitDialog = false; 
```

I am assuming this is a bug as I found mention of it on their forums.
