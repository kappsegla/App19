﻿using System.Net.Http;
using App1.Models;
using App1.Services;
using App1.Utils;
using App1.ViewModels;
using Autofac;
using Xamarin.Forms;

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
            cb.RegisterType<ItemsViewModel>().SingleInstance();
            cb.RegisterType<ItemDetailViewModel>().SingleInstance();
            cb.RegisterType<FirstPageViewModel>().SingleInstance();
            cb.RegisterType<CatFactApi>().SingleInstance();
            cb.RegisterType<HttpClient>().SingleInstance();
            cb.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            cb.RegisterType<XamarinEssentials>().As<IXamarinEssentials>().SingleInstance();
        }
    }
}