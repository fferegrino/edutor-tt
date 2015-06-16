using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Linq;
using Edutor.Web.Api.Areas.HelpPage.ModelDescriptions;
using Edutor.Web.Api.Areas.HelpPage.Models;

namespace Edutor.Web.Api.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
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
                    if (modelDescription.Name.StartsWith("PagedDataResponseOf"))
                    {
                        var t = modelDescription as ComplexTypeModelDescription;

                        ParameterDescription param = t.Properties.Where(prp => prp.Name.Equals("Links")).FirstOrDefault();
                        param.Documentation = "Enlaces HTTP a recursos relacionados con la consulta";

                        param = t.Properties.Where(prp => prp.Name.Equals("Items")).FirstOrDefault();
                        param.Documentation = "Colección de objetos pertenecientes a la consulta realizada";


                        param = t.Properties.Where(prp => prp.Name.Equals("PageSize")).FirstOrDefault();
                        param.Documentation = "Tamaño de la página en la que se encuentra actualmente";


                        param = t.Properties.Where(prp => prp.Name.Equals("PageNumber")).FirstOrDefault();
                        param.Documentation = "Número de página en la que se encuentra actualmente";


                        param = t.Properties.Where(prp => prp.Name.Equals("PageCount")).FirstOrDefault();
                        param.Documentation = "Cantidad de páginas en total de la respuesta";
                    }
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }
    }
}