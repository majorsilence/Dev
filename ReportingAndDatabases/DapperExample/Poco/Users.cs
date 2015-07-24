using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Poco
{
    [Dapper.Contrib.Extensions.Table("Users")]
    public class Users
    {
        public UserId Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
