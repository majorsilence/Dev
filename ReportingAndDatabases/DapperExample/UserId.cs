using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample
{
    public class UserId
    {
        private readonly string internalValue = "";


        public UserId(object value)
            : this(value.ToString())
        {
        }
        
        public UserId(string value)
        {
            internalValue = value;
        }

        public override string ToString()
        {
            return internalValue;
        }

        public bool Equals(UserId c1)
        {
            if (c1 == null)
            {
                return false;
            }
            return this.ToString() == c1.ToString();
        }

    }
}
