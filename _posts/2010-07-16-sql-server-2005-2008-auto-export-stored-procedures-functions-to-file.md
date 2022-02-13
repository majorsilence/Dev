---
layout: post
title: SQL Server 2005/2008 Auto Export Stored Procedures/Functions to File
created: 1279290962
excerpt: !ruby/string:Sequel::SQL::Blob |-
  U2FtcGxlIGNvZGUgZm9yIGV4cG9ydGluZyBzY3JpcHRzIHRvIGRyb3AgYW5k
  IHJlY3JlYXRlIGFsbCB1c2VyIGRlZmluZWQgU3RvcmVkIFByb2NlZHVyZXMg
  YW5kIEZ1bmN0aW9ucyBpbiBhIGRhdGFiYXNlLiANCg0KVGhlIGNvZGUgdXNl
  cyBTUUwgMjAwNS8yMDA4IFNlcnZlciBNYW5hZ2VtZW50IE9iamVjdHMgdG8g
  YWNjb21wbGlzaCB0aGlzIHRhc2suICBJdCBsb29wcyB0aHJvdWdoIGFsbCBm
  dW5jdGlvbnMgYW5kIFNQcyBhbmQgd3JpdGVzIGRyb3AgY29tbWFuZCBmb3Ig
  ZWFjaCBvZiB0aGVtIHRoZW4gbG9vcHMgdGhyb3VnaCBhbmQgYXBwZW5kcyB0
  aGUgY3JlYXRlIHNjcmlwdHMgZm9yIHRoZW0gdG8gdGhlIHNhbWUgZmlsZS4g
  IEFsbCBjb21tYW5kcyBhcmUgYXBwZW5kZWQgdG8gdGhlICJjOlxTb21lUGF0
  aFxTUEV4cG9ydC5zcWwiIGZpbGUuDQoNClVwZGF0ZSAoMjAxMC8wNy8yOSk6
  ICBBZGRlZCBJcm9uUHl0aG9uIGV4YW1wbGUuDQoNCg0KQyMgQ29kZQ0KPHBy
  ZT4NCnVzaW5nIE1pY3Jvc29mdC5WaXN1YWxCYXNpYzsNCnVzaW5nIFN5c3Rl
  bTsNCnVzaW5nIFN5c3RlbS5Db2xsZWN0aW9uczsN
redirect_from:
  - /node/414/
---
Sample code for exporting scripts to drop and recreate all user defined Stored Procedures and Functions in a database. 

The code uses SQL 2005/2008 Server Management Objects to accomplish this task.  It loops through all functions and SPs and writes drop command for each of them then loops through and appends the create scripts for them to the same file.  All commands are appended to the "c:\SomePath\SPExport.sql" file.

Update (2010/07/29):  Added IronPython example.


C# Code
```c#
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Microsoft.SqlServer.Management.Smo;

// Requires the following references
// Microsoft.SqlServer.ConnectionInfo
// Microsoft.SqlServer.Smo
// Microsoft.SqlServer.SmoEnum
// Microsoft.SqlServer.SqlEnum

public class Sample
{
	public void GenerateScripts()
	{
		// Must be run 32-bit mode or BatchParser will fail.  This is because the server installed is 32bit

		Microsoft.SqlServer.Management.Smo.Server srv = new Microsoft.SqlServer.Management.Smo.Server("server\Instance");
		srv.ConnectionContext.LoginSecure = false;
		srv.ConnectionContext.Login = "User";
		srv.ConnectionContext.Password = "Password";
		Database db = srv.Databases["DatabaseName"];

		string filepath = @"c:\SomePath\SPExport.sql";
		if (System.IO.File.Exists(filepath)) {
			System.IO.File.Delete(filepath);
		}


		// Script out Drop all Current user defined SPs
		using (TextWriter tw = new StreamWriter(filepath, true, System.Text.Encoding.UTF8)) {

			foreach (Microsoft.SqlServer.Management.Smo.StoredProcedure sp in db.StoredProcedures) {
				if (sp.IsSystemObject == false) {
					// We do not want system SPs, only user defined SPs
					string drop = string.Format("IF OBJECTPROPERTY(object_id('dbo.{0}'), N'IsProcedure') = 1{1} DROP PROCEDURE [dbo].[{0}]", sp.Name, System.Environment.NewLine);
					tw.WriteLine(drop);
					tw.WriteLine("GO");
				}
			}
		}

		// Script out drop all current user defined functions
		using (TextWriter tw = new StreamWriter(filepath, true, System.Text.Encoding.UTF8)) {

			foreach (Microsoft.SqlServer.Management.Smo.UserDefinedFunction func in db.UserDefinedFunctions) {
				if (func.IsSystemObject == false) {
					// We do not want system functions, only user defined functions
					string drop = string.Format("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT')){1}DROP FUNCTION [dbo].[{0}]", func.Name, System.Environment.NewLine);
					tw.WriteLine(drop);
					tw.WriteLine("GO");
				}
			}
		}

		// Script out create all user defined functions
		using (TextWriter tw = new StreamWriter(filepath, true, System.Text.Encoding.UTF8)) {
			foreach (Microsoft.SqlServer.Management.Smo.UserDefinedFunction func in db.UserDefinedFunctions) {
				if (func.IsSystemObject == false) {
					// We do not want system functions, only user defined functions
					foreach (string sqlScript in func.Script()) {
						tw.WriteLine(sqlScript);
						tw.WriteLine("GO");
					}
				}
			}
		}


		// Script out create all user defined Sps
		using (TextWriter tw = new StreamWriter(filepath, true, System.Text.Encoding.UTF8)) {
			foreach (Microsoft.SqlServer.Management.Smo.StoredProcedure sp in db.StoredProcedures) {
				if (sp.IsSystemObject == false) {
					// We do not want system SPs, only user defined SPs
					foreach (string sqlScript in sp.Script()) {
						tw.WriteLine(sqlScript);
						tw.WriteLine("GO");
					}
				}
			}
		}


	}
}
```

VB.NET Code
```vb
Imports Microsoft.SqlServer.Management.Smo

' Requires the following references
' Microsoft.SqlServer.ConnectionInfo
' Microsoft.SqlServer.Smo
' Microsoft.SqlServer.SmoEnum
' Microsoft.SqlServer.SqlEnum

Public Class Sample
	Public Sub GenerateScripts()
		' Must be run 32-bit mode or BatchParser will fail.  This is because the server installed is 32bit

		Dim srv As New Microsoft.SqlServer.Management.Smo.Server("server\Instance")
		srv.ConnectionContext.LoginSecure = False
		srv.ConnectionContext.Login = "User"
		srv.ConnectionContext.Password = "Password"
		Dim db As Database = srv.Databases("DatabaseName")

		Dim filepath As String = "c:\SomePath\SPExport.sql"
		If System.IO.File.Exists(filepath) Then
			System.IO.File.Delete(filepath)
		End If


		' Script out Drop all Current user defined SPs
		Using tw As TextWriter = New StreamWriter(filepath, True, System.Text.Encoding.UTF8)
			For Each sp As Microsoft.SqlServer.Management.Smo.StoredProcedure In db.StoredProcedures

				If sp.IsSystemObject = False Then
					' We do not want system SPs, only user defined SPs
					Dim drop As String = String.Format("IF OBJECTPROPERTY(object_id('dbo.{0}'), N'IsProcedure') = 1{1} DROP PROCEDURE [dbo].[{0}]", sp.Name, System.Environment.NewLine)
					tw.WriteLine(drop)
					tw.WriteLine("GO")
				End If
			Next
		End Using

		' Script out drop all current user defined functions
		Using tw As TextWriter = New StreamWriter(filepath, True, System.Text.Encoding.UTF8)
			For Each func As Microsoft.SqlServer.Management.Smo.UserDefinedFunction In db.UserDefinedFunctions

				If func.IsSystemObject = False Then
					' We do not want system functions, only user defined functions
					Dim drop As String = String.Format("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT')){1}DROP FUNCTION [dbo].[{0}]", func.Name, System.Environment.NewLine)
					tw.WriteLine(drop)
					tw.WriteLine("GO")
				End If
			Next
		End Using

		' Script out create all user defined functions
		Using tw As TextWriter = New StreamWriter(filepath, True, System.Text.Encoding.UTF8)
			For Each func As Microsoft.SqlServer.Management.Smo.UserDefinedFunction In db.UserDefinedFunctions
				If func.IsSystemObject = False Then
					' We do not want system functions, only user defined functions
					For Each sqlScript As String In func.Script()
						tw.WriteLine(sqlScript)
						tw.WriteLine("GO")
					Next
				End If
			Next
		End Using


		' Script out create all user defined Sps
		Using tw As TextWriter = New StreamWriter(filepath, True, System.Text.Encoding.UTF8)
			For Each sp As Microsoft.SqlServer.Management.Smo.StoredProcedure In db.StoredProcedures
				If sp.IsSystemObject = False Then
					' We do not want system SPs, only user defined SPs
					For Each sqlScript As String In sp.Script()
						tw.WriteLine(sqlScript)
						tw.WriteLine("GO")
					Next
				End If
			Next
		End Using


	End Sub
End Class
```

IronPython
```python
import clr
import shutil
import glob
import os
import sys
import System
from System.Diagnostics import Process
clr.AddReference("System.Data")
import System.Data
import System.Data.SqlClient



if System.IO.Directory.Exists(r"C:\Program Files\Microsoft SQL Server\90\SDK\Assemblies"):
	sys.path.append(r"C:\Program Files\Microsoft SQL Server\90\SDK\Assemblies")
else:
	sys.path.append(r"C:\Program Files (x86)\Microsoft SQL Server\90\SDK\Assemblies")
clr.AddReferenceToFile('Microsoft.SqlServer.Smo.dll')
clr.AddReferenceToFile('Microsoft.SqlServer.SmoEnum.dll')
clr.AddReferenceToFile('Microsoft.SqlServer.SqlEnum.dll')
clr.AddReferenceToFile('Microsoft.SqlServer.ConnectionInfo.dll')

import Microsoft.SqlServer.Management.Smo as SMO
import Microsoft.SqlServer.Management.Common as Common

class ScriptGenerator(object):
	def __init__(self):
		pass
	
	def Generate(self, server, databaseName, savePath):
		srv = SMO.Server(server)
		srv.ConnectionContext.LoginSecure = False
		srv.ConnectionContext.Login = "UserName"
		srv.ConnectionContext.Password = "Password"
		db = srv.Databases[databaseName]
		#db = SMO.Database(srv, databaseName)
		
		if System.IO.File.Exists(savePath):
			System.IO.File.Delete(savePath)
		
		tw = System.IO.StreamWriter(savePath, True, System.Text.Encoding.UTF8)

		# Drop SPs
		for sp in db.StoredProcedures:
			if (sp.IsSystemObject == False):
				print "Appending Drop Script for SP " + sp.Name
				# We do not want system SPs, only user defined SPs
				drop = System.String.Format("IF OBJECTPROPERTY(object_id('dbo.{0}'), N'IsProcedure') = 1{1} DROP PROCEDURE [dbo].[{0}]", sp.Name, System.Environment.NewLine)
				tw.WriteLine(drop)
				tw.WriteLine("GO")

		#Drop Functions
		for func in db.UserDefinedFunctions:
			if (func.IsSystemObject == False):
				print "Appending Drop Script for function " + func.Name
				# We do not want system SPs, only user defined SPs
				drop = System.String.Format("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT')){1}DROP FUNCTION [dbo].[{0}]", func.Name, System.Environment.NewLine)
				tw.WriteLine(drop)
				tw.WriteLine("GO")
		
		#script out and save all user defined functions
		for func in db.UserDefinedFunctions:
			if (func.IsSystemObject == False):
				print "Appending Create Script for function " + func.Name
				# We do not want system SPs, only user defined SPs
				for sqlScript in func.Script():
					tw.WriteLine(sqlScript)
					tw.WriteLine("GO")
				
		#script out and save all user defined SPs
		for sp in db.StoredProcedures:
			if (sp.IsSystemObject == False):
				print "Appending Create Script for SP " + sp.Name
				# We do not want system SPs, only user defined SPs
				for sqlScript in sp.Script():
					tw.WriteLine(sqlScript)
					tw.WriteLine("GO")
				
		tw.Close()
	
if __name__ == "__main__":
	g = ScriptGenerator()
	g.Generate(r"server\instance", r"TheDatabase", r"C:\SomePlace\SPExport.sql")
```
