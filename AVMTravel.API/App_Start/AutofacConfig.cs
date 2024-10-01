using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using AVMTravel.Services.Services;
using AVMTravel.Core.Interfaces;
using AVMTravel.Infrastructure.Repositories;
using AVMTravel.Core.Entities;

namespace AVMTravel.API
{
    public static class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();

            // Registrar controladores Web API
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Registrar servicios que implementan las interfaces correspondientes
            builder.RegisterType<TourService>().As<ITourService>();
            builder.RegisterType<ReservaService>().As<IReservaService>();
            builder.RegisterType<UsuarioService>().As<IUsuarioService>();

            // Registrar repositorios que implementan las interfaces correspondientes
            builder.RegisterType<ReservaRepository>().As<IReservaRepository>();
            builder.RegisterType<TourRepository>().As<ITourRepository>();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>();

            // Registrar GestorReservas como un servicio auto-registrado
            builder.RegisterType<GestorReservas>().AsSelf().InstancePerLifetimeScope();

            // Registrar GestorReservasService como un servicio que implementa la interfaz IGestorReservasService
            builder.RegisterType<GestorReservasService>().As<IGestorReservasService>().InstancePerLifetimeScope();

            var container = builder.Build();

            // Configurar Web API con Autofac como Dependency Resolver
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
