---
layout: post
title: 
date: 2023-02-22
last_modified: 2023-02-22
---

WARNING.  Do not use.   This is one big experiment.

crystalcmd is a:
> Java and c# program to load json files into crystal reports and produce PDFs.

* [https://github.com/majorsilence/CrystalCmd](https://github.com/majorsilence/CrystalCmd)


# Server side hosting

IIS

* Download a .net [crystal reports 13 runtime](https://wiki.scn.sap.com/wiki/display/BOBJ/Crystal+Reports%2C+Developer+for+Visual+Studio+Downloads).  SP 33 or newer.  Ensure it is 64 bit.
* Download a release from [https://github.com/majorsilence/CrystalCmd/releases](https://github.com/majorsilence/CrystalCmd/releases).  
    * Majorsilence.CrystalCmd.NetFrameworkServer 
* Create an 64 bit IIS Site
* Copy in the crystalcmd zip contents
* Edit the web.config and set the username and password you wish to use.


# Client side

## Curl example

```bash
curl https://c.majorsilence.com/status

curl -F "reportdata=@test.json" -F "reporttemplate=@report.rpt" https://{{YOUR SITE}}/export --output testout.pdf

# test localhost
curl -F "reportdata=@test.json" -F "reporttemplate=@report.rpt" https://{{YOUR SITE}}/export --output testout.pdf
```


## C# example

