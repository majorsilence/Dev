---
layout: post
title: DeVeDe ImgBurn ISO bug Fix
created: 1290730520
redirect_from:
  - /node/438/
---
There is a bug in devede when using imgburn to create an ISO file; it would prompt you for the files system type..  I just committed a fix to my subversion repository to fix this.  It was basically a typo.  The code had /FILESYSTEM "ISO9960 + Joliet" when it should of been /FILESYSTEM "ISO9660 + Joliet".

Once it has been built and tested I will be uploading a new build of devede for windows.
