using Autofac.Integration.Mvc;
using Autofac;
using AVMTravel.Core.Entities;
using AVMTravel.Core.Interfaces;
using AVMTravel.Infrastructure;
using AVMTravel.Infrastructure.Data;
using AVMTravel.Infrastructure.Repositories;
using AVMTravel.Services.Services;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace AVMTravel.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Registrar Autofac
            AutofacConfig.RegisterComponents();
            // Configuración de Autofac
            var builder = new ContainerBuilder();

            // Registro de controladores
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Registro de servicios
            builder.RegisterType<GestorReservas>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<GestorReservasService>().As<IGestorReservasService>().InstancePerLifetimeScope();
            builder.RegisterType<UsuarioService>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UsuarioService>().As<IUsuarioService>().InstancePerLifetimeScope();
            // Registro de servicios
            builder.RegisterType<TourRepository>().As<ITourRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ReservaRepository>().As<IReservaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>().InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Inicializar tours
            var gestorReservasService = container.Resolve<IGestorReservasService>();
            gestorReservasService.InicializarTours();
        }
    }
}
