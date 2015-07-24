using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DapperExample
{
    class Program
    {
        private static string cnStr;

        static void Main(string[] args)
        {
            Setup();
            Dapper.SqlMapper.AddTypeHandler(new Handlers.UserIdHandler());
            var id = InsertData();
            SelectData(id);

            var id2 = ContribInsertData();
            ContribSelectData(id2);
        }


        private static UserId InsertData()
        {
            var id = new UserId("Abc12c");
            using (var connection = new System.Data.SQLite.SQLiteConnection(cnStr))
            {
                connection.Open();
                connection.Execute("INSERT INTO Users (Id, Age, Name) VALUES (@Id, @Age, @Name)",
                    new {
                        Age = 31,
                        Id = id,
                        Name = "Peter Gill"
                    });
            }

            return id;
        }

        public static void SelectData(UserId id)
        {
            using (var connection = new System.Data.SQLite.SQLiteConnection(cnStr))
            {
                connection.Open();
                var data = connection.Query<Poco.Users>("SELECT * FROM Users WHERE Id = @Id",
                    new  { Id = id }).FirstOrDefault();

                System.Diagnostics.Debug.Assert(id.Equals(data.Id));
            }
        }


        private static UserId ContribInsertData()
        {
            var id = new UserId("Abc12c");
            using (var connection = new System.Data.SQLite.SQLiteConnection(cnStr))
            {
                connection.Open();
                connection.Insert(new Poco.Users()
                    {
                        Age = 31,
                        Id = id,
                        Name = "Peter Gill"
                    });
            }

            return id;
        }

        public static void ContribSelectData(UserId id)
        {
            using (var connection = new System.Data.SQLite.SQLiteConnection(cnStr))
            {
                connection.Open();
                var data = connection.Get<Poco.Users>(id);

                System.Diagnostics.Debug.Assert(id.Equals(data.Id));
            }
        }

        private static void Setup()
        {
            var projLoc = Assembly.GetAssembly(typeof(Program)).Location;
            var projFolder = Path.GetDirectoryName(projLoc);

            if (File.Exists(projFolder + "\\Test.sqlite"))
            {
                File.Delete(projFolder + "\\Test.sqlite");
            }
            var connectionString = "Data Source = " + projFolder + "\\Test.sqlite;";
            using (var connection = new System.Data.SQLite.SQLiteConnection(connectionString))
            {
                connection.Open();
                connection.Execute(@" create table Users (Id int IDENTITY(1,1) not null, Name nvarchar(100) not null, Age int not null) ");
            }

            cnStr = connectionString;
            Console.WriteLine("Created database");
        }

    }
}
