---
layout: post
title: Download Example
created: 1259629709
excerpt: !ruby/string:Sequel::SQL::Blob |-
  U2ltcGxlIGRvd25sb2FkIGZpbGUgZXhhbXBsZS4gIFdvcmtzIHdpdGggaHR0
  cCwgaHR0cHMsIGFuZCBmdHAuICBJZiB1c2VybmFtZSBhbmQgcGFzc3dvcmQg
  YXJlIHJlcXVpcmVkIGFkZCB0aGVtIHRvIHRoZSBjbGllbnQgdXNpbmcgU3lz
  dGVtLk5ldC5OZXR3b3JrQ3JlZGVudGlhbCgidXNlcm5hbWUiLCAicGFzc3dv
  cmQiKS4NCg0KVXNlIHRoZSBXZWJDbGllbnQgRG93bmxvYWRQcm9ncmVzc0No
  YW5nZWQgYW5kIERvd25sb2FkRmlsZUNvbXBsZXRlZCBldmVudHMgdG8gZGlz
  cGxheSBwZXJjZW50IGFuZCBzdGFydCBvbiBmaW5pc2ggYWN0aW9uLg0KDQpU
  aGVzZSBleGFtcGxlcyB3aWxsIG5vdCB3b3JrIHVubGVzcyB5b3UgY3JlYXRl
  IGEgd2luZm9ybSB0byBnbyBhbG9uZyB3aXRoIHRoZW0uDQoNClZCLm5ldA0K
  PHByZT4NCkltcG9ydHMgU3lzdGVtLklPDQpJbXBvcnRzIFN5c3RlbS5OZXQN
  CkltcG9ydHMgU3lzdGVtLlRocmVhZGluZw0KSW1wb3J0cyBTeXN0ZW0uVGV4
  dA0KDQpQdWJsaWMgQ2xhc3MgRm9ybTEN
redirect_from:
  - /node/305/
---
Simple download file example.  Works with http, https, and ftp.  If username and password are required add them to the client using System.Net.NetworkCredential("username", "password").

Use the WebClient DownloadProgressChanged and DownloadFileCompleted events to display percent and start on finish action.

These examples will not work unless you create a winform to go along with them.

VB.net
```v.net
Imports System.IO
Imports System.Net
Imports System.Threading
Imports System.Text

Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        download(txtDownloadPath.Text.Trim, txtSavePath.Text.Trim)
    End Sub

    Private Shared percent As Integer = 0

    Public Sub Download(ByVal urlPath As String, ByVal savePath As String)
        Dim client As WebClient = New WebClient()
        'client.Credentials = New System.Net.NetworkCredential("username", "password")

        AddHandler client.DownloadProgressChanged, AddressOf ClientDownloadProgressChanged
        AddHandler client.DownloadFileCompleted, AddressOf ClientDownloadFileCompleted

        client.DownloadFileAsync(New Uri(urlPath), savePath)

    End Sub

    Private Sub ClientDownloadProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)

        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100

        ProgressBar1.Value = Integer.Parse(Math.Truncate(percentage).ToString())
        PaintProgressBarPercent(ProgressBar1)
    End Sub

    Private Sub ClientDownloadFileCompleted(ByVal sender As Object, ByVal e As EventArgs)
        'AsyncCompletedEventArgs
        MessageBox.Show("Download Completed")
    End Sub

    Private Sub PaintProgressBarPercent(ByRef a As ProgressBar)
        Dim percent As Integer = CInt(((CDbl((ProgressBar1.Value - ProgressBar1.Minimum)) / CDbl((ProgressBar1.Maximum - ProgressBar1.Minimum))) * 100))

        Using gr As Graphics = ProgressBar1.CreateGraphics()
            Dim p1 As New PointF(CType(a.Width / 2 - (gr.MeasureString(percent & "%", SystemFonts.DefaultFont).Width / 2.0F), Single), CType(a.Height / 2 - (gr.MeasureString(percent & "%", SystemFonts.DefaultFont).Height / 2.0F), Single))
            Try
                gr.DrawString(percent & "%", SystemFonts.DefaultFont, Brushes.Black, p1)
            Catch ex As Exception
            End Try

        End Using

    End Sub

End Class
```


C# Example

```c#
using System.IO;
using System.Net;
using System.Threading;
using System.Text;

public class Form1
{
    private void Button1_Click(System.Object sender, System.EventArgs e)
    {
        download(txtDownloadPath.Text.Trim, txtSavePath.Text.Trim);
    }
    
    private static int percent = 0;
    
    public void Download(string urlPath, string savePath)
    {
        WebClient client = new WebClient();
        //client.Credentials = New System.Net.NetworkCredential("username", "password")
        
        client.DownloadProgressChanged += ClientDownloadProgressChanged;
        client.DownloadFileCompleted += ClientDownloadFileCompleted;
        
            
        client.DownloadFileAsync(new Uri(urlPath), savePath);
    }
    
    
    private void ClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        
        double bytesIn = double.Parse(e.BytesReceived.ToString());
        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
        double percentage = bytesIn / totalBytes * 100;
        
        ProgressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            
        PaintProgressBarPercent(ProgressBar1);
    }
    
    
    private void ClientDownloadFileCompleted(object sender, EventArgs e)
    {
        //AsyncCompletedEventArgs
        MessageBox.Show("Download Completed");
    }
    
    
    
    private void PaintProgressBarPercent(ref ProgressBar a)
    {
        int percent = (int)(((double)(ProgressBar1.Value - ProgressBar1.Minimum) / (double)(ProgressBar1.Maximum - ProgressBar1.Minimum)) * 100);
        
        using (Graphics gr = ProgressBar1.CreateGraphics()) {
            PointF p1 = new PointF((float)a.Width / 2 - (gr.MeasureString(percent + "%", SystemFonts.DefaultFont).Width / 2f), (float)a.Height / 2 - (gr.MeasureString(percent + "%", SystemFonts.DefaultFont).Height / 2f));
            try {
                gr.DrawString(percent + "%", SystemFonts.DefaultFont, Brushes.Black, p1);
            }
            catch (Exception ex) {
                
            }
            
        }
    }
}

```
