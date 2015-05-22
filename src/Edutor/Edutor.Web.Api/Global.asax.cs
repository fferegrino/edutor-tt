using Edutor.Common.Logging;
using Edutor.Common.TypeMapping;
using Edutor.Web.Api.Securitiy;
using Edutor.Web.Common;
using System.Web.Http;
using System.Web.Mvc;

namespace Edutor.Web.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RegisterHandlers();
            new AutoMapperConfigurator().Configure(
                WebContainerManager.GetAll<IAutoMapperTypeConfigurator>());
        }

        private void RegisterHandlers()
        {
            var lmanager = WebContainerManager.Get<ILogManager>();

            GlobalConfiguration.Configuration.MessageHandlers.Add(
                new BasicAuthenticationMessageHandler(lmanager, WebContainerManager.Get<IBasicSecurityService>()));
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception != null)
            {
                var log = WebContainerManager.Get<ILogManager>().GetLog(typeof(WebApiApplication));
                log.Error("Unhandled exception", exception);
            }
        }
    }
}
