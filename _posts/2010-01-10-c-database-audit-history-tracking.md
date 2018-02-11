---
layout: post
title: C# Database Audit/History Tracking
created: 1263165504
excerpt: !ruby/string:Sequel::SQL::Blob |-
  VGhpcyBpcyBhIHNpbXBsZSBtZXRob2Qgb2YgaGlzdG9yeSB0cmFja2luZyBv
  ZiBkYXRhYmFzZSBjaGFuZ2VzIHRoYXQgaW4gZG9uZSB3aXRoaW4gaW4gdGhl
  IGFwcGxpY2F0aW9uLiAgVGhlcmUgYXJlIG90aGVyIG1ldGhvZHMgdG8gZG8g
  dGhpcyBpbmNsdWRpbmcgY3JlYXRpbmcgdHJpZ2dlcnMgd2l0aGluIHRoZSBk
  YXRhYmFzZSBpdHNlbGYuDQoNCkJhc2ljYWxseSB0aGlzIGlzIG9uZSBzbWFs
  bCBmdW5jdGlvbiB0aGF0IHlvdSBwYXNzIGluIGEgZGF0YXNldCBhbmQgdHJh
  bnNhY3Rpb24uICBJdCBsb29wcyB0aHJvdWdoIGVhY2ggdGFibGUgYW5kIGVh
  Y2ggcm93IGFuZCBjb2x1bW4gaW4gdGhlIHRhYmxlIGFuZCBkZXRlY3RzIHRo
  ZSBjdXJyZW50IHN0YXRlIG9mIHRoZSByb3cgYW5kIHJlY29yZHMgaXQgaW4g
  YW4gYXVkaXQgdGFibGUuIA0KDQ==
redirect_from:
  - /database_audit_history_tracking_dot_net/
---
This is a simple method of history tracking of database changes that in done within in the application.  There are other methods to do this including creating triggers within the database itself.

Basically this is one small function that you pass in a dataset and transaction.  It loops through each table and each row and column in the table and detects the current state of the row and records it in an audit table. 

First lets take a look at the audit table.   The audit table tracks the tablename, field that was changed, the original and new value of the changed column, the action taken (insert, modified, delete), the user that did the action and the date.  The tablename and code (primary key) field can be used to search the history of a row.  Also included is orig_binary and new_binary for storing values for binary columns instead of original and new.

SQL (SQLite) 

```sql
CREATE TABLE [audit] (
[id] INTEGER  PRIMARY KEY,
[tablename] VARCHAR(50)  NOT NULL,
[field] NVARCHAR(50)  NOT NULL,
[original] NVARCHAR(4000)  NOT NULL,
[new] NVARCHAR(4000)  NOT NULL,
[action] NVARCHAR(10)  NOT NULL,
[user] NVARCHAR(50)  NOT NULL,
[date] DATE  NOT NULL,
[code] INTEGER  NOT NULL,
[orig_binary] BLOB  NULL,
[new_binary] BLOB  NULL
);


CREATE TABLE [actor] (
[id] INTEGER  PRIMARY KEY,
[first_name] VARCHAR(50)  NOT NULL,
[last_name] NVARCHAR(50)  NOT NULL,
[date_of_birth] NVARCHAR(25)  NOT NULL
);

```

So it should be obvious that this approach is to use one table for tracking all changes in every table.  Another option would be to create an audit table for each table and every time a row is changed copy it to the audit table first.  You would then have to scan the audit table and check each column to see what the change that was made.

I would like to point out that I do not particularly like the code shown below.  I would prefer to use a RowUpdated event handler but since I am SQLiteDataAdapters with sql text instead of stored procedures with return row I am settling for this.  In another post I will show using the updated event with Microsoft SQL server and Stored procedures.

Here is the code that set ups the transactions and calls the audit function.  The audit function must be called before the DataAdapter update.  This is all done within one transaction so that nothing is recorded in the audit table unless records are saved in the main table.

You should notice that the DoAudit function takes as parameters a DataSet that is to be tracked in the audit, a code (if empty it will use the primary key column as the code) and a SQLiteTransaction. 

Please excuse the incompleteness of the class Program as I am in the middle of rewritting this article.

```c#
class Program
{
    private static SQLiteDataAdapter daActor;
    private static DataSet dsActor;
    private static Audit auditTracking;

    static void Main(string[] args)
    {
        auditTracking = new Audit();
        dsActor = new DataSet();

        SQLiteConnection cn = HelperFunctions.CreateConnection();
        daActor = new SQLiteDataAdapter("SELECT * FROM actor;", cn);
        if (System.IO.File.Exists("hello.db"))
        {
            daActor.Fill(dsActor);
        }

        bool exit = false;
        Console.WriteLine("h - for help");
        while (exit == false)
        {
            Console.Write("Command: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "q":
                    exit = true;
                    break;
                case "0":
                    HelperFunctions.CreateDatabase();
                    daActor.Fill(dsActor);
                    break;
                case "n":
                    NewActor();
                    break;
                case "p":
                    PrintAllActors();
                    break;
                case "pa":
                    PrintAuditTable();
                    break;
                case "h":
                    Console.WriteLine("q - quite program");
                    Console.WriteLine("0 - Create Database");
                    Console.WriteLine("n - Add new actor");
                    Console.WriteLine("p - Print all actors");
                    Console.WriteLine("pa - Print audit table");
                    Console.WriteLine("h - Print Help");
                    Console.WriteLine("");
                    break;
            }
        }

    }

    private static void PrintAuditTable()
    {
        DataTable dt = new DataTable();
        SQLiteConnection cn = HelperFunctions.CreateConnection();
        SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM audit;", cn);
        cn.Open();
        SQLiteDataReader reader = cmd.ExecuteReader();
        dt.Load(reader);
        reader.Close();

        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine("ID: " + row["id"]);
            Console.WriteLine("tablename: " + row["tablename"]);
            Console.WriteLine("field: " + row["field"]);
            Console.WriteLine("original: " + row["original"]);
            Console.WriteLine("new: " + row["new"]);
            Console.WriteLine("action: " + row["action"]);
            Console.WriteLine("user: " + row["user"]);
            Console.WriteLine("date: " + row["date"]);
            Console.WriteLine("code: " + row["code"]);
            Console.WriteLine("orig_binary: " + row["orig_binary"]);
            Console.WriteLine("new_binary: " + row["new_binary"]);
            Console.WriteLine("");
        }
    }

    private static void PrintAllActors()
    {
        foreach (DataRow row in dsActor.Tables[0].Rows)
        {
            Console.WriteLine("Actor: " + row["first_name"] + " " + row["last_name"]);
            Console.WriteLine("DOB: " + row["date_of_birth"]);
            Console.WriteLine("");
        }
    }
    private static void NewActor()
    {
        DataRow row = dsActor.Tables[0].NewRow();

        row["id"] = DBNull.Value;

        Console.Write("First Name: ");
        row["first_name"] = Console.ReadLine();

        Console.Write("Last Name: ");
        row["last_name"] = Console.ReadLine();

        Console.Write("Date of Birth: ");
        row["date_of_birth"] = Console.ReadLine();

        dsActor.Tables[0].Rows.Add(row);

        UpdateDatabase();
    }

    private static void UpdateDatabase()
    {
        SQLiteConnection cn = HelperFunctions.CreateConnection();

        cn.Open();
        daActor.SelectCommand.Connection = cn;
        SQLiteTransaction txn = cn.BeginTransaction();
        try
        {
            SQLiteCommandBuilder cmd = new SQLiteCommandBuilder(daActor);
            daActor.InsertCommand = cmd.GetInsertCommand();
            daActor.UpdateCommand = cmd.GetUpdateCommand();
            daActor.DeleteCommand = cmd.GetDeleteCommand();

            daActor.InsertCommand.Transaction = txn;
            daActor.UpdateCommand.Transaction = txn;
            daActor.DeleteCommand.Transaction = txn;

            // call the audit function.  If the daActor.Update command succeeds then
            // there will be an audit trail.  If it fails the audit will be rolled back.
            auditTracking.DoAudit(dsActor, "", txn);
            daActor.Update(dsActor);
            txn.Commit();
        }
        catch (Exception ex)
        {
            // rollback action and audit trail.
            txn.Rollback();
            TrapErrors(ex, true);
        }
        finally
        {
            cn.Close();
        }
    }

    public static void TrapErrors(Exception ex, bool showMessage)
    {
        if (showMessage)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```

The Main function runs the code that lets the user enter new actors and then calls the UpdateDatabase function to update the actor and audit table.

Here is the audit class that does the actual work.

The DoAudit function is passed a DataSet and a Transaction.  It will loop through each row in each table that is in the DataSet.  If there are any changes to the values such as an Insert, Update, or Delete it will record this change in the audit table.  It will attempt to identify the primary key and use that as the code column in the audit table.


```c#
public class Audit
{
    private SQLiteDataAdapter daAudit;


    /// <summary>
    /// Check the specfied table in the dataset and record them in the audit table.
    /// Currently is only an example and does not work
    /// </summary>
    /// <param name="ds">DataSet</param>
    /// <param name="code">string - generally the primary key of the table</param>
    /// <param name="txn">IDbTransaction</param>
    /// <remarks>Requires a table with columns: tablename, action, user, date, new, original, field, code.
    /// The "code" field is the one that is to be searched.</remarks>
    public void DoAudit(DataSet ds, string code, SQLiteTransaction txn)
    {
        if (ds.Tables.Count <= 0)
        {
            return;
        }

        DataSet dsAudit = new DataSet();
        DataRow row_Audit;
        daAudit = new SQLiteDataAdapter("Select * from audit WHERE 1=2;", txn.Connection);
        daAudit.Fill(dsAudit);

        dsAudit.Tables[0].Columns["id"].AllowDBNull = true;
        dsAudit.Tables[0].Columns["orig_binary"].AllowDBNull = true;
        dsAudit.Tables[0].Columns["new_binary"].AllowDBNull = true;

        SQLiteCommandBuilder cmd = new SQLiteCommandBuilder(daAudit);
        daAudit.InsertCommand = cmd.GetInsertCommand();
        daAudit.InsertCommand.Transaction = txn;


        daAudit.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
        daAudit.InsertCommand.Transaction = txn;

        string tableName = "";
        string primaryKey = "";


        foreach (DataTable tbl in ds.Tables)
        {
            tableName = tbl.TableName;

            if (ds.Tables[tableName].PrimaryKey.Length > 0)
            {
                primaryKey = ds.Tables[tableName].PrimaryKey[0].ColumnName.Trim();
            }

            foreach (DataRow x in tbl.Rows)
            {
                int codeID = -1;

                for (int i = 0; i <= tbl.Columns.Count - 1; i++)
                {
                    row_Audit = dsAudit.Tables[0].NewRow();
                    row_Audit["id"] = DBNull.Value;
                    row_Audit["tablename"] = tableName;
                    row_Audit["date"] = DateTime.Now;
                    row_Audit["action"] = x.RowState.ToString();
                    row_Audit["code"] = codeID;
                    row_Audit["user"] = System.Environment.UserName; //Login.LoggedInUser;
                    row_Audit["new_binary"] = null;
                    row_Audit["orig_binary"] = null;


                    string original = "";
                    string current = "";

                    // deletes should have blank current values
                    if (x.RowState != DataRowState.Deleted)
                    {
                        current = x[i, DataRowVersion.Current].ToString().Trim();
                    }

                    // Insert should have blank original values.
                    if (x.RowState != DataRowState.Added)
                    {
                        original = x[i, DataRowVersion.Original].ToString().Trim();
                    }


                    if (tbl.Columns[i].ColumnName == primaryKey)
                    {
                        try
                        {
                            if (HelperFunctions.IsNumeric(current, System.Globalization.NumberStyles.Integer))
                            {
                                codeID = int.Parse(current);
                            }
                            else
                            {
                                codeID = -1;
                            }
                        }
                        catch
                        {
                            codeID = -1;
                        }
                        row_Audit["code"] = codeID;
                    }

                    if (current != original)
                    {

                        row_Audit["field"] = ds.Tables[tableName].Columns[i].ColumnName;
                        row_Audit["new"] = current;
                        row_Audit["original"] = original;

                        dsAudit.Tables[0].Rows.Add(row_Audit);
                    }
                }

            }

            daAudit.Update(dsAudit);
        }
    }
}

```

As can be seen in this code it will also work on fields that are binary blobs.  

New HelperFunctions class:  This class has functions for creating a new sample database named hello.db, returning a connection to the sample database and testing if a field is numeric.

```c#

class HelperFunctions
{

    public static void CreateDatabase()
    {

        SQLiteConnection.CreateFile("hello.db");
        SQLiteConnection cn = CreateConnection();
        String.Format(CultureInfo.InvariantCulture, "Data Source = {0}; Version = 3", "database.sql");

        string sql = System.IO.File.ReadAllText("database.sql", System.Text.Encoding.UTF8);
        SQLiteCommand cmd = new SQLiteCommand(sql, cn);
        cmd.ExecuteNonQuery();
    }

    public static SQLiteConnection CreateConnection()
    {
        return new SQLiteConnection("Data Source = 'hello.db'; Version = 3");
    }

    static public bool IsNumeric(string val, System.Globalization.NumberStyles NumberStyle)
    {
        Double result;
        return Double.TryParse(val, NumberStyle, System.Globalization.CultureInfo.CurrentCulture, out result);
    }
}
```






