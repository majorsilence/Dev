---
layout: base
title: Dapper Micro ORM
---

I love dapper.  It is an awesome micro orm that gets out of your way.

# Install Dapper

Add dapper to your c# project using nuget.

```powershell
Install-Package Dapper
```

Once dapper is installed you now have super simple database access.

# Dapper

Lets say we have the following sqlite connection

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

Now we want to query all the records in the user table.

```c#
using Dapper;

using(var cn=CnFactory)
{
	var users = cn.Query("SELECT * FROM Users;");
	foreach(var user in users){
		Console.WriteLine(user.FirstName);
		Console.WriteLine(user.LastName);
	}
}

```

That is a query using c# dynamic code.  For a nicer experience, including intellesense youcan also define and use POCOs.

This example declares a "Users" POCO class that is then used with dappers Query method.
```c#
using Dapper;
public class Users
{
	public string FirstName {get; set;}
	public string LastName {get; set;}
}

using(var cn=CnFactory)
{
	var users = cn.Query<Users>("SELECT * FROM Users;");
	foreach(var user in users){
		Console.WriteLine(user.FirstName);
		Console.WriteLine(user.LastName);
	}
}
```


# Dapper.Contrib.Extensions
write me ;)

# Examples
See https://github.com/majorsilence/DotNetDev/tree/master/ReportingAndDatabases/DapperExample for an example of dapper and custom object mappers.

# Official documentation
Please read the official [dapper docs](https://github.com/StackExchange/dapper-dot-net).  They are short and easy to read.