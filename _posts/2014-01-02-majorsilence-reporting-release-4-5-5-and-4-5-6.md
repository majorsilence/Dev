---
layout: post
title: Majorsilence Reporting Release 4.5.5 and 4.5.6
created: 1388625781
redirect_from:
  - /node/556/
---
Majorsilence Reporting is a report and charting system based on Microsoft's Report Definition Language (RDL). Tabular, free form, matrix, charts are fully supported. HTML, PDF, XML, .Net Control, and printing supported.  An experimental Gtk/WPF/Cocoa viewer also exist.  There are also language wrappers available for php, python, and ruby that make it easy to generate reports.  The WYSIWYG designer allows you to create reports without knowledge of RDL. Wizards are available for creating new reports and for inserting new tables, matrixes, charts, and barcodes into existing reports.

Majorsilence reporting started as My-FyiReporting which was a fork of fyiReporting after it died. It has been re-branded as Majorsilence Reporting to make it clearer that it is a separate forked project.  Its purpose is to keep the project alive and useful.

## Release 4.5.5

* https://github.com/majorsilence/My-FyiReporting/issues/44 added examples of using hyperlink actions.
* https://github.com/majorsilence/My-FyiReporting/issues/53 new page change event in winform viewer.  See https://github.com/majorsilence/My-FyiReporting/wiki/Report-Viewer-Events.
* https://github.com/majorsilence/My-FyiReporting/issues/75 no longer generate pdf with errors.
* https://github.com/majorsilence/My-FyiReporting/issues/45 initial php, python, and ruby support.  Can be used to generate reports and export as pdf, html, doc, excel and any other format that is supported.
* https://github.com/majorsilence/My-FyiReporting/issues/69 multiple changes to php language support.  Still a work in progress but some work is in master.
* https://github.com/majorsilence/My-FyiReporting/pull/73 and https://github.com/majorsilence/My-FyiReporting/pull/72 localization support.  Includes Russian translation of everything in designer and reviewer.  See https://github.com/majorsilence/My-FyiReporting/wiki/Localization.
* https://github.com/majorsilence/My-FyiReporting/issues/64 add Microsoft sql Compact Edition support to RdlEngineConfig.xml.
* https://github.com/majorsilence/My-FyiReporting/issues/65 fix functions next and previous sometimes not working.
* https://github.com/majorsilence/My-FyiReporting/pull/61 fix bug of Validate RDL enable and Start Desktop caption on clicking Tools menu.
* https://github.com/majorsilence/My-FyiReporting/issues/42 new designer control that can be used in .net applications.  See https://github.com/majorsilence/My-FyiReporting/wiki/Designer-Control.  Works in winform or wpf.  Still need bugs fixed.

## Other Changes
* Update to latest version of xwt in LibRdlCrossPlatformViewer (Windows: WPF engine, Gtk engine (using Gtk#), MacOS X: Cocoa engine (using MonoMac) and Gtk engine (using Gtk#), Linux: Gtk engine (using Gtk#)).
* Include initial nunit test.
* Setup travis-ci to build project and run unit tests on every push to github.
* Fix lost events in dataset and report parameter controls.
* Switch name to Majorsilence Reporting.  See https://github.com/majorsilence/My-FyiReporting/commit/5e4a42a0ea4bbab43b5ea10d274342a889205d75.
* Sort dataproviders when creating a new report.  See https://github.com/majorsilence/My-FyiReporting/commit/109d656926a8f0d4f73dd3a7920ec876921cec9c.
* RdlCmd support exporting to pdf using itextsharp or the builtin code.  See https://github.com/majorsilence/My-FyiReporting/commit/3978d37ef8ebc89a87c4e308e1a9fbb748fa3091.
* RdlReader will can open previous reports if in the startup file
* Other minor changes


## Release 4.5.6

https://github.com/majorsilence/My-FyiReporting/issues/76 fix broken expression functions from 4.5.5 release.


## Downloads
http://files.majorsilence.com/myfyireporting/
https://github.com/majorsilence/My-FyiReporting/wiki/Downloads
