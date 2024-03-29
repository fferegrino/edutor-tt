using System;
using System.Web.Http;
using System.Web.Mvc;
using Edutor.Web.Api.Areas.HelpPage.ModelDescriptions;
using Edutor.Web.Api.Areas.HelpPage.Models;

namespace Edutor.Web.Api.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class PrintController : Controller
    {
        private const string ErrorViewName = "Error";

        public PrintController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public PrintController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            ViewBag.Conf = Configuration;
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Auth()
        {
            return View();
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}