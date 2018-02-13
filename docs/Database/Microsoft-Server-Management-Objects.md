---
layout: base
title: SQL Management Objects (SMO)
---

Backup, Restore, Run Stored Procedures and table scripts, in transaction

## Setup
Make sure SMO is added to the project and on the target server.

For visual studio install nuget package Unofficial.Microsoft.SQLServer.SMO.2014.

```ps
Install-Package Unofficial.Microsoft.SQLServer.SMO.2014 -Version 12.0.2000.8 
```

On the server make sure SMO is installed.  An easy way is with chocolatey.

```ps
choco install sql2014.smo 
```

## Backup
Database backup only needs an SqlCommand.  SMO is not needed.


### SqlCommand backup example
```cs
public static void Backup(string server, string database, string saveFile,
    string sqlUser, string sqlPassword)
{
    using (var cn = new SqlConnection())
    {
        using (var cmd = new SqlCommand())
        {
            // 60 minutes
            cmd.CommandTimeout = (60 * 60);
            cn.ConnectionString = string.Format("server={0}; Database={1};User ID={2};Password={3};", server, database, sqlUser, sqlPassword);
            cn.Open();

            string sql = string.Format("BACKUP DATABASE [{0}]", database);
            sql += string.Format(" TO DISK = '{0}'", saveFile);
            sql += " WITH FORMAT,";
            sql += string.Format(" MEDIANAME = '{0}-Data',", database);
            sql += string.Format(" NAME = 'Full Backup of {0}';", database);

            cmd.CommandText = sql;
            cmd.Connection = cn;

            cmd.ExecuteNonQuery();
        }
    }

}
```
### SMO backup example

```cs
public void Backup(string server, string database, string saveFile,
    string sqlUser, string sqlPassword)
{
    var svr = new Microsoft.SqlServer.Management.Smo.Server(server);
    svr.ConnectionContext.LoginSecure = false;

    svr.ConnectionContext.Login = sqlUser;
    svr.ConnectionContext.Password = sqlPassword;

    // 60 minutes
    svr.ConnectionContext.StatementTimeout = 60 * 60;
    
    var bkp = new Microsoft.SqlServer.Management.Smo.Backup();
    bkp.Devices.AddDevice(saveFile, Microsoft.SqlServer.Management.Smo.DeviceType.File);
    bkp.Database = database;
    bkp.Action = Microsoft.SqlServer.Management.Smo.BackupActionType.Database;
    bkp.Initialize = true;
    bkp.PercentCompleteNotification = 1;

    // blocking process
    bkp.SqlBackup(svr);
}
```

## SMO Messages

## SMO Execute Non Query

Execute/update/run sql including stored procedures and functions.

```cs
public void Execute(string server, string database, string sqlUser, string sqlPassword,
    string sql)
{
    var svr = new Microsoft.SqlServer.Management.Smo.Server(server);
    svr.ConnectionContext.LoginSecure = false;

    svr.ConnectionContext.Login = sqlUser;
    svr.ConnectionContext.Password = sqlPassword;

    // 60 minutes
    svr.ConnectionContext.StatementTimeout = 60 * 60;
    
    Microsoft.SqlServer.Management.Smo.Database db = srv.Databases[database];

    // Initialize all data instead of doing round trips when dealing with stored procedures
    srv.SetDefaultInitFields(typeof(Microsoft.SqlServer.Management.Smo.StoredProcedure), true);
    srv.SetDefaultInitFields(typeof(Microsoft.SqlServer.Management.Smo.Column), true);

    try
    {
        srv.ConnectionContext.BeginTransaction();
        db.ExecuteNonQuery(sql);
    }
    catch (Exception ex)
    {
        srv.ConnectionContext.RollBackTransaction();
        throw;
    }
}
```

