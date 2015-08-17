using System;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Cheetah.WebApi.Areas.HelpPage.ModelDescriptions;
using Cheetah.WebApi.Areas.HelpPage.Models;

namespace Cheetah.WebApi.Areas.HelpPage.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController()
            : this(Startup.HttpConfiguration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            Configuration = Startup.HttpConfiguration;
        }

        public HttpConfiguration Configuration { get; private set; }

        [System.Web.Mvc.Route("")]
        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
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

            throw new HttpResponseException(HttpStatusCode.InternalServerError);
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

            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}