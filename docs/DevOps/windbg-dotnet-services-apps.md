---
layout: base
title: windbg and .net dump files
---

Using windbg with c# dump files.

# Setup

Setup symbol server source.  Run the following two commands in powershell.

```ps
Install-Module -Name WintellectPowerShell -Scope CurrentUser
Set-SymbolServer -Pubilc
```

At this point I had to restart my computer before windbg would pick up the symbol servers.  Restarting windbg was not enough.

# windbg x86

If loading 64bit dump of 32 bit .net process use [soswow64](https://github.com/poizan42/soswow64).

Open windbg x86 -> Load dump file

Make sure correct sos symbols are loaded.  You can accomplish this by running the analyze command.
```
!analyze -v
```


Run commands

```
.load soswow64
#.cordll -ve -u -l
.loadby sos clr
!wow64exts.sw
.load soswow64
!threads

# list all threads, high counts list threads that are running a lot
!runaway 

# replace X with the thread number
~Xs 

# Can only be called after calling ~Xs
!CLRStack

# Check method parameters
!CLRStack -p
```


# References
* http://improve.dk/debugging-in-production-part-1-analyzing-100-cpu-usage-using-windbg/
* https://github.com/poizan42/soswow64
* https://www.wintellect.com/automatically-load-the-right-sos-for-the-minidump