using Edutor.Data.Exceptions;
using Edutor.Web.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Edutor.Web.Common.ErrorHandling
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;

            var httpException = exception as HttpException;
            if (httpException != null)
            {
                context.Result = new SimpleErrorResult(context.Request,
                    (HttpStatusCode)httpException.GetHttpCode(), httpException.Message);
                return;
            }
            
            if (exception is ObjectNotFoundException)
            {
                // En caso de que la exepción sea lanzada al no encotntrar un registro en la base de datos se debe
                // devolver un código 404
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.NotFound, exception.Message);
                return;
            }
            if (exception is CustomAuthorizationException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.Unauthorized, exception.Message);
                return;
            }
            if(exception is IncomingModelException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.BadRequest, exception.Message);
                return;
            }
            if (exception is DuplicateEntityException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.Conflict, exception.Message);
                return;
            }
            if (exception is ForeignKeyException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.Conflict, exception.Message);
                return;
            }
            if (exception is UnAuthorizedException)
            {
                context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.Conflict, exception.Message);
                return;
            }

            context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.InternalServerError, exception.Message);
        }
    }
}
