using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AVMTravel.Services.Services;
using AVMTravel.Core.Interfaces;
using Autofac.Integration.Mvc;
using Autofac;
using System.Reflection;
using System.Web.Mvc;
using AVMTravel.Core.Entities;
using AVMTravel.Infrastructure.Repositories;

namespace AVMTravel.Web
{
    public static class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();

            // Registrar controladores MVC
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Registrar repositorios
            builder.RegisterType<TourRepository>().As<ITourRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ReservaRepository>().As<IReservaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UsuarioRepository>().As<IUsuarioRepository>().InstancePerLifetimeScope();

            // Registrar servicios
            builder.RegisterType<UsuarioService>().As<IUsuarioService>().InstancePerLifetimeScope();
            builder.RegisterType<TourService>().As<ITourService>().InstancePerLifetimeScope();
            builder.RegisterType<ReservaService>().As<IReservaService>().InstancePerLifetimeScope();
            builder.RegisterType<GestorReservasService>().As<IGestorReservasService>().InstancePerLifetimeScope();

            var container = builder.Build();

            // Configurar MVC con Autofac como Dependency Resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}