using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample.Handlers
{
    internal class UserIdHandler : Dapper.SqlMapper.TypeHandler<UserId>
    {
        public override void SetValue(IDbDataParameter parameter, UserId value)
        {
            parameter.Value = value.ToString();
        }

        public override UserId Parse(object value)
        {
            return new UserId(value);
        }
    }
}
