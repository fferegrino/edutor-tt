using Edutor.Common.Logging;
using Edutor.Web.Common;
using Edutor.Web.Common.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Edutor.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // TODO: Enable tracing page 88

            config.Services.Add(typeof(IExceptionLogger), new SimpleExceptionLogger(WebContainerManager.Get<ILogManager>()));
        }
    }
}
