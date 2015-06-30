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
                var modelList = modelState.ToList();
                
                for (int i = 0; i < modelList.Count; i++)
                {
                    var s = modelList[i];
                    
                    for (int j = 0; j < s.Value.Errors.Count; j++ )
                    {
                        var error = s.Value.Errors[j];
                        sb.Append(error.ErrorMessage);

                        if (i < s.Value.Errors.Count - 1)
                            sb.Append(" ");
                    }
                    if (i < modelList.Count - 1)
                    sb.Append(" ");

                }
                throw new IncomingModelException(sb.ToString());
            }
        }
    }
}
