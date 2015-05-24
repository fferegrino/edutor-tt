using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Data.Exceptions
{
    public class ForeignKeyException : Exception
    {
        public ForeignKeyException(string msg)
            : base(msg)
        {

        }
    }
}
