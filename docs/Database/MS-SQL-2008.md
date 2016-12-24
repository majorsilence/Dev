---
layout: base
title: Microsoft SQL
---

SqlCommand, SqlConnection, SqlDataAdapter, SqlTransaction, Parametrized Queries, DataTable, DataSet, Stored Procedure Calls

# Command Line
If you want to run any sql from the command line you can do it like this.

```bat
sqlcmd -E -S TheSql Server -d master -Q "THE SQL GOES HERE"
```

# Backup Database
```powershell
BACKUP DATABASE DatabaseName TO DISK = 'D:\DatabaseNameBackupName.bak';
```

# Restore Database From Bak

Basic

```powershell
RESTORE DATABASE DatabaseName FROM DISK = 'd:\DatabaseNameBackupName.bak' WITH REPLACE;
```

If you want to move the internal files

```powershell
RESTORE DATABASE DatabaseName FROM DISK = 'c:\DatabaseNameBackupNamebak' WITH MOVE 'DatabaseName_Data' TO 'c:\data\DatabaseName_data.mdf', MOVE 'DatabaseName_Log' TO 'c:\data\DatabaseName_log.ldf', REPLACE;
```

# Mix Legacy ADO.net with Entity Framework 6
How to mix entity framework with ado.net.  Lets say you have existing code using SqlConnection and SqlTransaction.  You are now modifying it but want to start using entity framework without rewriting all of the database access to use entity framework.  You want to do it peace by peace.  You can use a regular SqlConnection with entity framework.  You can create a EntityConnection from SqlConnection.

## Create Connection

```c#
public static System.Data.Common.DbConnection EntityFromSqlConnection(SqlConnection cn)
{
	var wrkspace = new System.Data.Entity.Core.Metadata.Edm.MetadataWorkspace(new string[] {
		"res://*/YourModelName.csdl",
		"res://*/YourModelName.ssdl",
		"res://*/YourModelName.msl"
	}, new System.Reflection.Assembly[] { System.Reflection.Assembly.GetAssembly(typeof(YourModelAssembly)) });

	return new EntityConnection(wrkspace, cn);
}

```

## Use Transaction

If you have a entity connection context and want the connection to use an existing transaction use context.Database.UseTransaction(your transaction).

```c#
context.Database.UseTransaction(txn);
```

