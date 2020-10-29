using System.Net.Http;
using App1.Models;
using App1.ViewModels;
using Autofac;

namespace App1.Bootstrap
{
    public class AppSetup
    {
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder cb)
        {
            cb.RegisterType<MainPageViewModel>().SingleInstance();
            cb.RegisterType<CatFactApi>().SingleInstance();
            cb.RegisterType<HttpClient>().SingleInstance();
        }
    }
}