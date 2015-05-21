using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Common.Exceptions
{
    public class CustomAuthorizationException : Exception
    {
        public CustomAuthorizationException(string message = "Autorización denegada para esta solicitud")
            : base(message)
        {

        }
    }
}
