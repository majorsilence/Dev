---
layout: base
title: SQLite
---

SQLiteCommand, SQLiteConnection, SQLiteDataAdapter, SQLiteTransaction, Parametrized Queries, DataTable, DataSet

# Install sqlite
Install the nuget package System.Data.SQLite.  Please note this package only works on windows.  If on linux or mac use the sqlite dll provided by mono.

```powershell
Install-Package System.Data.SQLite 
```

# Create new Sqlite Connection

```c#
public static IDbConnection CnFactory
{
    get
    {
    	var path = @"The\Path\To\Your\Sqlite\file"
        if (!System.IO.File.Exists(path))
        {
            System.Data.SQLite.SQLiteConnection.CreateFile(path);
        }

        var cnString = "Data Source=" + path + "; Version=3";
        return new System.Data.SQLite.SQLiteConnection(cnString);
    }
}
```

Now to use the connection string

```c#
using(var cn = CnFactory)
{
	cn.Open();
	// Now do whatever with the connection. It will be auto closed in the using statement.
}
```

# SQLiteCommand and Transaction
Create a new connection, initialize a transaction and command.  Run said command.

```c#
using(var cn = CnFactory)
{
	cn.Open();
	// Now do whatever with the connection. It will be auto closed in the using statement.

	using(var txn = cn.BeginTransaction())
	{
		// Now do whatever with the transaction. It will be auto closed in the using statement.

		// create and execute a command using the connection and transaction
		var cmd = cn.CreateCommand();
		cmd.CommandType = CommandType.Text;
		cmd.CommandText = "UPDATE Users Set FirstName='Peter'";
		cmd.Connection = cn;
		cmd.CommandTimeout = DefaultTime;
		cmd.Transaction = txn;
		cmd.ExecuteNonQuery();
	}
}
```



# Dapper

In all seriousness; avoid SQLiteDataAdapter, SQLiteTransaction, DataTable, and DataSet if you can and use 
[Dapper]({{site.baseurl}}/docs/Database/Dapper-Micro-ORM.html) instead.

