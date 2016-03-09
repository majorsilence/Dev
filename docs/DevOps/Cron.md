---
layout: base
title: Cron
---

Scripts in cron folders __must not have a file extension__ or they will not run.

Available folders
* /etc/cron.daily
* /etc/cron.hourly

Create a new script in one of these folders and the script will be run every hour or every day.

## Execute cron.daily

Execute (as root/sudo) 
```bash
run-parts /etc/cron.daily
```

## Execute cron.hourly
Execute (as root/sudo) 

```bash
run-parts /etc/cron.hourly
```
