using App1.Bootstrap;
using App1.iOS.Services;
using App1.Services;
using Autofac;

namespace App1.iOS.Bootstrap
{
    public class IOSSetup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            base.RegisterDependencies(cb);
            cb.RegisterType<HelloService>().As<IHelloService>();
        }
    }
}