using System.Web.Http;
using System.Web.Mvc;
using Cheetah.WebApi;
using Microsoft.Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Cheetah.WebApi
{
    public class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration = new HttpConfiguration();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(HttpConfiguration);
            
            app.UseNinjectMiddleware(() => NinjectConfig.CreateKernel.Value);
            app.UseNinjectWebApi(HttpConfiguration);
        }
    }
}