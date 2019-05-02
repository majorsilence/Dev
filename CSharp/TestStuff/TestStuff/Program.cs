using System;

namespace MajorSilence.TestStuff
{
    class Program
    {
        static void Main(string[] args)
        {

            var dapperExtTest = new DapperExt.DapperExtensionTest();
            dapperExtTest.Test1();


            // Our repository layer that will talk to the data source.
            // This could be inject with a dependency injection framework
            var repo = new MajorSilence.Repo.DataAccess.TestRepo("Data Source=:memory:;Version=3;New=True;");
            var repo2 = new MajorSilence.Repo.DataAccess.TestRepoNobase("Data Source=:memory:;Version=3;New=True;");


            // Our business class.  Takes an interface and does not care
            // what the actual data source is.
            var inst = new MajorSilence.Repo.BusinessStuff.TestStuff(repo);
            inst.DoStuff();

            var inst2 = new MajorSilence.Repo.BusinessStuff.TestStuff(repo2);
            inst2.DoStuff();

        }
    }
}
