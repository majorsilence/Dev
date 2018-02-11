---
layout: post
title: Windows Filename Length Checker
created: 1284226420
excerpt: !ruby/string:Sequel::SQL::Blob |-
  QSBzbWFsbCBJcm9uUHl0aG9uIHNjcmlwdCB0aGF0IEkgdXNlZCB0byBmaW5k
  IGZpbGVzIHRoYXQgbmFtZXMgd2VyZSB0byBsb25nIHRvIGNvcHkgdG8gbXkg
  V2luZG93cyBYUCBjb21wdXRlci4NCg0KPHByZT4NCmltcG9ydCBjbHINCmlt
  cG9ydCBTeXN0ZW0NCmltcG9ydCBTeXN0ZW0uSU8NCg0KIyBBIHNtYWxsIEly
  b25QeXRob24gc2NyaXB0IHRvIGNvcHkgZmlsZXMgYW5kIGNoZWNrIGZvciBm
  aWxlbmFtZSBsZW5ndGggdmlvbGF0aW9ucyBvbiB3aW5kb3dzIHhwLg0KDQpk
  ZWYgQ2hlY2tGaWxlc1JlY3Vyc2l2ZWx5KHRhcmdldCk6DQogICAgIiIiDQog
  ICAgRGlyZWN0b3J5SW5mbyB0YXJnZXQNCiAgICAiIiINCiAgICANCiAgICAj
  ZGlyZWN0b3J5IGluZm8NCiAgICBmb3IgeCBpbiB0YXJnZXQuR2V0RGlyZWN0
  b3JpZXMoKToNCiAgICAgICAgQ2hlY2tGaWxlc1JlY3Vyc2l2ZWx5KHgpDQog
  ICAgICAgIGlmIGxlbih4LkZ1bGxOYW1lKSA+IDIwMDoNCiAgICAgICAgICAg
  IHByaW50IHguRnVsbE5hbWUsICJsZW50aDoiLCBsZW4oeC5GdWxsTmFtZSkN
  CiAgICANCiAgICAjRmlsZUluZm8NCiAgICBmb3IgeCBpbiB0YXJnZXQuR2V0
  RmlsZXMoKToN
redirect_from:
  - /node/431/
---
A small IronPython script that I used to find files that names were to long to copy to my Windows XP computer.

```python
import clr
import System
import System.IO

# A small IronPython script to copy files and check for filename length violations on windows xp.

def CheckFilesRecursively(target):
    """
    DirectoryInfo target
    """
    
    #directory info
    for x in target.GetDirectories():
        CheckFilesRecursively(x)
        if len(x.FullName) > 200:
            print x.FullName, "lenth:", len(x.FullName)
    
    #FileInfo
    for x in target.GetFiles():
        print x.FullName, "lenth:", len(x.FullName)
        if len(x.FullName) > 255:
            print x.FullName, "lenth:", len(x.FullName)
    

def CopyFilesRecursively(source, target):
    """
    DirectoryInfo source, DirectoryInfo target
    """
    for x in source.GetDirectories():
        print "Creatig Directory:", target.FullName + x.Name
        CopyFilesRecursively(x, target.CreateSubdirectory(x.Name));
    
    for x in source.GetFiles():
        print "Copying:", x.FullName
        try:
            x.CopyTo(System.IO.Path.Combine(target.FullName, x.Name), True); #overwrite
        except System.Exception as ex:
            WriteLine(ex)


def WriteLine(msg):
    filePath = System.IO.Path.Combine("MajorSilence-Debug.txt")
    
    System.IO.File.AppendAllText(filePath, System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString() + System.Environment.NewLine)
    System.IO.File.AppendAllText(filePath, msg.Message + System.Environment.NewLine + msg.StackTrace + System.Environment.NewLine)
    System.IO.File.AppendAllText(filePath, System.Environment.NewLine + System.Environment.NewLine)


if __name__ == "__main__":
    help_msg="""
    -s source directory to copy files
    -t target directory to copy files
    -c if found it will copy the -s to the -t if not found -s and -t will have filename length check run
    -h Display Help
    """
    source_path=""
    target_path=""
    copy_source=False
    help=False
    for i, x in enumerate(System.Environment.GetCommandLineArgs()):
        if x == "-s": # source
            source_path = System.Environment.GetCommandLineArgs()[i+1]
        elif x == "-t": # target
            target_path = System.Environment.GetCommandLineArgs()[i+1]
        elif x == "-c": # Copy source to target
            copy_source = True
        elif x == "-h" or x == "--help":
            help=True


    e_length = len(System.Environment.GetCommandLineArgs())
    if help or System.Environment.GetCommandLineArgs()[e_length-1] == "check-filename-length.py":
        print help_msg
        System.Environment.Exit(0)

    print "source path:",source_path
    print "target path:",target_path
    
    if copy_source:
        CopyFilesRecursively(System.IO.DirectoryInfo(source_path), System.IO.DirectoryInfo(target_path))
    else:
        if source_path != "":
            CheckFilesRecursively(System.IO.DirectoryInfo(source_path))
        if target_path != "":
            CheckFilesRecursively(System.IO.DirectoryInfo(target_path))

```
