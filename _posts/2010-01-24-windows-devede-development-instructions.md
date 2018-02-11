---
layout: post
title: Windows DeVeDe Development Instructions
created: 1264300170
excerpt: !ruby/string:Sequel::SQL::Blob |-
  VGhpcyBpcyBhIGNoZWNrbGlzdCBvZiBpdGVtcyBhbmQgYWN0aW9ucyB0aGF0
  IG11c3QgYmUgcGVyZm9ybWVkIHRvIGJ1aWxkL2RldmVsb3AgRGVWZURlIG9u
  IFdpbmRvd3MuDQoNCkZpcnN0IHRoZXJlIGFyZSBzZXZlcmFsIHBhY2thZ2Vz
  IHRoYXQgbXVzdCBiZSBpbnN0YWxsZWQuICBBbGwgcGFja2FnZXMgYXJlIGZv
  ciB4ODYgYW5kIG5vdCA2NGJpdCBhbmQgYWxsIHB5dGhvbiBwYWNrYWdlcyBh
  cmUgZm9yIHZlcnNpb24gMi42LiouDQoNCjx1bD4NCjxsaT5JbnN0YWxsIFB5
  dGhvbiAyLjcgKG1ha2Ugc3VyZSBpdCBpcyAgMi43IG5vdCAzLiopIC0gaHR0
  cDovL3B5dGhvbi5vcmcvZG93bmxvYWQvPC9saT4NCg0KPGxpPkluc3RhbGwg
  UHl0aG9uIGZvciBXaW4zMiBFeHRlbnNpb25zIC0gaHR0cDovL3NvdXJjZWZv
  cmdlLm5ldC9wcm9qZWN0cy9weXdpbjMyLyAoZGlyZWN0IGh0dHA6Ly9zb3Vy
  Y2Vmb3JnZS5uZXQvcHJvamVjdHMvcHl3aW4zMi9maWxlcy9weXdpbjMyL0J1
  aWxkJTIwMjE0L3B5d2luMzItMjE0LndpbjMyLXB5Mi43LmV4ZS9kb3dubG9h
  ZCkuIDwvbGk+DQoN
redirect_from:
  - /windows_devede_development_instructions/
---
This is a checklist of items and actions that must be performed to build/develop DeVeDe on Windows.

First there are several packages that must be installed.  All packages are for x86 and not 64bit and all python packages are for version 2.6.*.

<ul>
<li>Install Python 2.7 (make sure it is  2.7 not 3.*) - http://python.org/download/</li>

<li>Install Python for Win32 Extensions - http://sourceforge.net/projects/pywin32/ (direct http://sourceforge.net/projects/pywin32/files/pywin32/Build%20214/pywin32-214.win32-py2.7.exe/download). </li>

<li>Install <a href="http://ftp.gnome.org/pub/GNOME/binaries/win32/pygtk/2.22/">PyGTK 2.22</a> all in one installer - http://ftp.gnome.org/pub/GNOME/binaries/win32/pygtk/2.22/pygtk-all-in-one-2.22.5.win32-py2.7.msi</li>

<li>Check out DeVeDe master from github https://github.com/majorsilence/Devede (new url) - to setup git on windows see http://help.github.com/win-set-up-git/
<li>From an install of devede (http://files.majorsilence.com/devede/downloads/316-9/devede-setup-3.16.9-build7.msi) copy the bin folder into the "src" folder.  This provides the executables that DeVeDe requires to do its work.</li>
<li>Double click devede.py to start devede.</li>
</ul>

<h1>Optional</h1>

<h2>ImgBurn Support</h2>
<ul>
<li>Install ImgBurn - http://www.imgburn.com/</li>
<li>ImgBurn is used when it is detected to create the ISO files.  Otherwise mkisofs.exe is used and it has major problems on Vista and Windows 7.
<li>ImgBurn must be run once after install to add its location to the registry path.</li>
</ul>

<h2>Building Packages</h2>
If you plan on building windows executables for distribution you will also want to follow these steps.
<ul>
<li>Install py2exe - http://sourceforge.net/projects/py2exe/files/ - direct link (http://sourceforge.net/projects/py2exe/files/py2exe/0.6.9/py2exe-0.6.9.win32-py2.7.exe/download)<li>
<li>Install wix - http://sourceforge.net/projects/wix/files/.  As of this posting this is not currently integrated in devede win32 build but it will be soon.
<li>From the GTK install directory copy the "etc", "lib", and "share" folders to the devede trunk folders.  These are used when building devede.exe</li>
<li>Create zipped source package (trunk-src.zip), devede.exe (trunk\dist\devede.exe, you need the entire "dist" folder), and msi installers by running devede_build.py (You may have to edit this file to point to the correct location of python).</li>
</ul>

You may also want to download the GTK+ Preference Tool.  You should be able to find it at http://sourceforge.net/projects/gtk-win/files/.  This tool will allow you to set the GTK theme on your Windows user account.
At this point DeVeDe should be running in a development environment on your computer.
