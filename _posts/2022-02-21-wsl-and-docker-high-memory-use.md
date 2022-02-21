---
layout: post
title: WSL and docker high memory use
date: 2022-02-21
last_modified: 2022-02-21
---


If repeated docker builds cause WSL (windows subsystem for linux) to trash your system memory you can force linux to drop the page cache.

```bash
sudo su -
echo 1 > /proc/sys/vm/drop_caches
```
