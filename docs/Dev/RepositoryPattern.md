---
layout: base
title: Repository Pattern in c#
---

Use the repository pattern to seperate your business and data access layers.  Makes
it easy to test your business and data layer code seperatly.

There are different ways to do this.  Here are a couple ways.

# C# examples


## Use a base abstract class that is passed a connectoin
```cs
using System;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace MajorSilence.DataAccess
{

    public abstract class BaseRepo
    {
        private readonly string cnStr;

        protected BaseRepo(string cnStr)
        {
            this.cnStr = cnStr;
        }

        protected T WithConnection<T>(Func<IDbConnection, T> sqlTransaction)
        {
            using (var connection = new SQLiteConnection(cnStr))
            {
                connection.Open();
                return sqlTransaction(connection);
            }
        }

        protected void WithConnection(Action<IDbConnection> sqlTransaction)
        {
            using (var connection = new SQLiteConnection(cnStr))
            {
                connection.Open();
                sqlTransaction(connection);
            }
        }

        protected async Task<T> WithConnectionAsync<T>(Func<IDbConnection, Task<T>> sqlTransaction)
        {
            using (var connection = new SQLiteConnection(cnStr))
            {
                await connection.OpenAsync();
                return await sqlTransaction(connection);
            }
        }

        protected async Task WithConnectionAsync<T>(Func<IDbConnection, Task> sqlTransaction)
        {
            using (var connection = new SQLiteConnection(cnStr))
            {
                await connection.OpenAsync();
                await sqlTransaction(connection);
            }
        }

    }

}


```


And here is the repo class

```cs
using System;
using System.Linq;
using Dapper;

namespace MajorSilence.DataAccess
{
    public interface ITestRepo
    {
        string GetName();
        void InsertData(string name);
    }

    public class TestRepo : BaseRepo, ITestRepo
    {
        public TestRepo(string cnStr) : base(cnStr) { }

        public string GetName()
        {
            return this.WithConnection(cn =>
            {
                return cn.Query<string>("SELECT Name From TheTable LIMIT 1;").FirstOrDefault();
            });
        }

        public void InsertData(string name)
        {
            this.WithConnection(cn =>
            {
                cn.Execute("INSERT INTO TheTable (Name) VALUES (@Name);",
                    new { Name = name });
            });
        }
    }
}
```


## No base abstract.  Let individual repository classes do as they please

```cs
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace MajorSilence.DataAccess
{

    public class TestRepoNobase : ITestRepo
    {
        readonly string cnStr;
        public TestRepoNobase(string cnStr)
        {
            this.cnStr = cnStr;
        }

        public string GetName()
        {
            using (var cn = new SQLiteConnection(cnStr))
            {
                return cn.Query<string>("SELECT Name From TheTable LIMIT 1;").FirstOrDefault();
            };
        }

        public void InsertData(string name)
        {
            using (var cn = new SQLiteConnection(cnStr))
            {
                cn.Execute("INSERT INTO TheTable (Name) VALUES (@Name);",
                    new { Name = name });
            };
        }
    }
}
```


# Do something with the repository classes

A business class

```cs
using System;
namespace MajorSilence.BusinessStuff
{
    public class TestStuff
    {
        readonly DataAccess.ITestRepo repo;
        public TestStuff(DataAccess.ITestRepo repo)
        {
            this.repo = repo;
        }

        public void DoStuff()
        {
            repo.InsertData("The Name");
            string name = repo.GetName();

            // Do stuff with the name
        }
    }
}
```


Combine everything.  Manualy initialize our two repository classes and initialize two copies
of our TestStuff class. Our TestStuff never knows what or where the actual data layer is.

TestStuff is now easily tested with tools such as as [moq](/docs/VbIntroduction/Mocking.html).

```cs
using System;

namespace MajorSilence.TestStuff
{
    class Program
    {
        static void Main(string[] args)
        {

            // Our repository layer that will talk to the data source.
            // This could be inject with a dependency injection framework
            var repo = new MajorSilence.DataAccess.TestRepo("Data Source=:memory:;Version=3;New=True;");
            var repo2 = new MajorSilence.DataAccess.TestRepoNobase("Data Source=:memory:;Version=3;New=True;");


            // Our business class.  Takes an interface and does not care
            // what the actual data source is.
            var inst = new MajorSilence.BusinessStuff.TestStuff(repo);
            inst.DoStuff();

            var inst2 = new MajorSilence.BusinessStuff.TestStuff(repo2);
            inst2.DoStuff();
            
        }
    }
}

```

