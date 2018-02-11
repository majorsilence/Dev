---
layout: post
title: MyFyiReporting Update - Barcodes, Bug Fixes, Reporting Server
created: 1347147695
redirect_from:
  - /myfyireporting_update_barcodes_bug_fixes_reporting_server/
---
I have been working on MyFyiReporting lately.  There is a new wiki page describing how to use barcodes and qr codes (https://github.com/majorsilence/My-FyiReporting/wiki/Barcodes-and-QR-Codes).

I have also spent some time working on the reporting server.  See https://github.com/majorsilence/My-FyiReporting/wiki/Reporting-Server for a more detailed info.  Basically it is a site where users can view reports online.

If you check out the <a href="https://github.com/majorsilence/My-FyiReporting/tree/Issue11PdfUnicodeCharacters">Issue11PdfUnicodeCharacters</a> branch you will see I have finally merged in the iTextSharp fixes that allow cyrillic character support.
