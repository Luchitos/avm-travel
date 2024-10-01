using AVMTravel.API;
using AVMTravel.Core.Interfaces;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AVMTravel.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Configuraciones existentes
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var gestorReservasService = DependencyResolver.Current.GetService<IGestorReservasService>();

            // Registrar Autofac
            AutofacConfig.RegisterComponents();
        }
    }
}
