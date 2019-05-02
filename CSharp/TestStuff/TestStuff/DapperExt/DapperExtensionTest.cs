using System;
using NUnit.Framework;

namespace MajorSilence.DapperExt
{
    public class DapperExtensionTest
    {
        public DapperExtensionTest()
        {
        }

        const string expectedOutputSql = @"MERGE INTO 
GroupInfo
AS tgt 
USING
(SELECT @Id_1 Id, @Id2_1 Id2) AS src 
ON tgt.Id=src.Id AND tgt.Id2=src.Id2
WHEN MATCHED THEN
UPDATE SET [Id]=@Id_2, [Id2]=@Id2_2, [App]=@App_2, [DB]=@DB_2
WHEN NOT MATCHED THEN 
INSERT (
[Id], [Id2], [App], [DB]) VALUES (
@Id_2, @Id2_2, @App_2, @DB_2
);";

        [Test]
        public void Test1()
        {
            var poco = new GroupInfo()
            {
                Id = 1,
                Id2 = 2,
                App = "Test 123",
                DB = false
            };

            string sql = DapperExtensions.UpSertSqlGeneration<GroupInfo>(poco, new { Id = 1, Id2 = 2 });

            Assert.That(sql, Is.EqualTo(expectedOutputSql));
        }

    }
}
