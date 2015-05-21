using Edutor.Web.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Edutor.Web.Common.Filters
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;

            if (!modelState.IsValid)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var s in modelState)
                {
                    sb.Append(s.Key).Append(": ");
                    foreach (var error in s.Value.Errors)
                    {
                        sb.Append(error.ErrorMessage).Append("  ");
                    }
                    sb.Append(";");
                }
                throw new IncomingModelException(sb.ToString());
            }
        }
    }
}
