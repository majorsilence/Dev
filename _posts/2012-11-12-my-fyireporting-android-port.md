---
layout: post
title: My-FyiReporting Android Port
created: 1352737240
redirect_from:
  - /node/541/
---
I have been working on porting the core of My-FyiReporting to Android.  I am making good progress.  I do not believe there is much at all that needs to be removed or changed in RdlEngine, DataProviders, or RdlCri.   This is because instead of rewritting the drawing code I am using a compatibility layer to imitate System.Drawing. 

Where the actual work comes in is writing a compatibility layer over androids drawing functions.  To do this I have forked https://github.com/mattleibow/System.Drawing.Wrappers to https://github.com/majorsilence/System.Drawing.Wrappers and have started adding method stubs, enums, classes, etc... for the functionality that is missing.  Once My-FyiReporting is able to compile I will start the work on implementing the System.Drawing function internals.

You can see the initial My-FyiReporting changes in the <a href="https://github.com/majorsilence/My-FyiReporting/tree/android">android branch</a>.

Once this is all completed I will start work on winrt and monotouch.
