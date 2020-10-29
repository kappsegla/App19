using App1.Android.Services;
using App1.Bootstrap;
using App1.Services;
using Autofac;

namespace App1.Android.Bootstrap
{
    public class AndroidSetup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            base.RegisterDependencies(cb);
            cb.RegisterType<HelloService>().As<IHelloService>();
        }
    }
}