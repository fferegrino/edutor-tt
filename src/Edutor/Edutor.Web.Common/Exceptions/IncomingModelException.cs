using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Common.Exceptions
{
    public class IncomingModelException : Exception
    {
        public IncomingModelException(string message = "La información enviada en la solictud es inválida.")
            : base(message)
        {

        }
    }
}
