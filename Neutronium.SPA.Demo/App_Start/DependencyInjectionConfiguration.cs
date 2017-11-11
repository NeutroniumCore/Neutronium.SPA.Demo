using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Neutronium.SPA.Demo.Application.Navigation;
using Ninject;

namespace Neutronium.SPA.Demo 
{
    public class DependencyInjectionConfiguration
    {
        public static IServiceLocator Register(INavigator navigator)
        {
            var kernel = new StandardKernel(new NinjectSettings { UseReflectionBasedInjection = true });
            kernel.Bind<INavigator>().ToConstant(navigator);
            RegisterDependency(kernel);
            return new NinjectServiceLocator(kernel);
        }

        public static void RegisterDependency(IKernel kernel)
        {
        }
    }
}
