---
layout: post
title: Backgroundworker ReportProgress / Tooltip balloon Messages
created: 1259629572
excerpt: !ruby/string:Sequel::SQL::Blob |-
  VGhlIGZvbGxvd2luZyBjb2RlIGlzIGEgcGFydGlhbCBleGFtcGxlIG9mIHVz
  aW5nIGJhY2tncm91bmR3b3JrZXIgUmVwb3J0UHJvZ3Jlc3MgbWV0aG9kIHRv
  IGFjY2VzcyBjb250cm9scyBmcm9tIHRoZSBiYWNrZ3JvdW5kd29ya2VyIHRo
  cmVhZC4NCg0KVGhlIGZvcm0gaGFzIG9uZSBidXR0b24gY2FsbGVkIEJ1dHRv
  bjIuICBXaGVuIHRoZSBmb3JtIGlzIGFjdGl2YXRlZCBpdCBjcmVhdGVzIGEg
  YmFsbG9vbiB0b29sdGlwIG1lc3NhZ2UgZm9yIDUgc2Vjb25kcyBvbiBpdC4g
  DQoNClRoZXNlIGV4YW1wbGVzIHdpbGwgbm90IHdvcmsgdW5sZXNzIHlvdSBj
  cmVhdGUgYSB3aW5mb3JtIHRvIGdvIGFsb25nIHdpdGggdGhlbS4NCg0KVkIu
  TkVUIEV4YW1wbGUNCg0KPHByZT4NCkltcG9ydHMgU3lzdGVtLkNvbXBvbmVu
  dE1vZGVsDQpQdWJsaWMgQ2xhc3MgRm9ybTENCg0KICAgIERpbSBid0NoZWNr
  Rm9yVXBkYXRlcyBBcyBCYWNrZ3JvdW5kV29ya2VyDQoNCiAgICBQcml2YXRl
  IFN1YiBGb3JtMV9Mb2FkKEJ5VmFsIHNlbmRlciBBcyBTeXN0ZW0uT2JqZWN0
  LCBCeVZhbCBlIEFzIFN5c3RlbS5FdmVudEFyZ3MpIEhhbmRsZXMgTXlCYXNl
  LkxvYWQN
redirect_from:
  - /node/304/
---
The following code is a partial example of using backgroundworker ReportProgress method to access controls from the backgroundworker thread.

The form has one button called Button2.  When the form is activated it creates a balloon tooltip message for 5 seconds on it. 

These examples will not work unless you create a winform to go along with them.

VB.NET Example

```vb.net
Imports System.ComponentModel
Public Class Form1

    Dim bwCheckForUpdates As BackgroundWorker

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(Button2, "An update is available.")
    End Sub

    Private Sub Form1_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        bwCheckForUpdates = New BackgroundWorker()
        bwCheckForUpdates.WorkerReportsProgress = True
        AddHandler bwCheckForUpdates.ProgressChanged, AddressOf bwCheckForUpdates_ProgressChanged
        AddHandler bwCheckForUpdates.DoWork, AddressOf bwCheckForUpdates_DoWork
        bwCheckForUpdates.RunWorkerAsync()

    End Sub

    Private Sub bwCheckForUpdates_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ' Check for update
        ' if available call bwCheckForUpdates.ReportProgress(100, True) with value of true
        bwCheckForUpdates.ReportProgress(100, True)

    End Sub
    Private Sub bwCheckForUpdates_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If CType(e.UserState, Boolean) = True Then
            ToolTip1.Show("An update is available.", Button2, 5000)
        End If
    End Sub


End Class
```

C# Example

```c#
using System.ComponentModel;

public class Form1
{
    BackgroundWorker bwCheckForUpdates;
    
    private void  Button1_Click(System.Object sender, System.EventArgs e)
    {
        Balloon b = new Balloon();
        b.Show();
    }
    
    private void Form1_Load(System.Object sender, System.EventArgs e)
    {
        ToolTip1.SetToolTip(Button2, "An update is available.");
    }
    
    private void  Form1_Activated(System.Object sender, System.EventArgs e)
    {
        
        bwCheckForUpdates = new BackgroundWorker();
        bwCheckForUpdates.WorkerReportsProgress = true;
        bwCheckForUpdates.ProgressChanged += bwCheckForUpdates_ProgressChanged;
        bwCheckForUpdates.DoWork += bwCheckForUpdates_DoWork;
            
        bwCheckForUpdates.RunWorkerAsync();
    }
    
    private void bwCheckForUpdates_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        // Check for update
        // if available call bwCheckForUpdates.ReportProgress(100, True) with value of true
            
        bwCheckForUpdates.ReportProgress(100, true);
    }
    private void  bwCheckForUpdates_ProgressChanged(System.Object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        if ((bool)e.UserState == true) {
            ToolTip1.Show("An update is available.", Button2, 5000);
        }
    }
   
}

```
