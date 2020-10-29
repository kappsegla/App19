using App1.Android.Services;
using App1.Services;
using Autofac;

namespace App1.Android
{
    public class Setup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            base.RegisterDependencies(cb);

            cb.RegisterType<HelloFormsService>().As<IHelloFormsService>();
        }
    }
}