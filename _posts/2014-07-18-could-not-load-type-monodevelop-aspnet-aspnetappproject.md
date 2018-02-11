---
layout: post
title: Could not load type 'MonoDevelop.AspNet.AspNetAppProject'
created: 1405686338
redirect_from:
  - /could_not_load_type_monodevelop_aspnet_aspnetappproject/
---
After upgrading to monodevelop 5.3 from git I could no longer load asp projects.  I always received the following error.

Could not load type 'MonoDevelop.AspNet.AspNetAppProject' from assembly 'MonoDevelop.AspNet

There is a quick fix.  Disable and renable the monodevelop asp add-ins.

Tools -> Add-in Manager ->Web Development
Disable and enable all web add-ins.  Reload your solution and it should work.
