using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Neutronium.SPA.Demo.Application.Navigation;
using Ninject;

namespace Neutronium.SPA.Demo
{
    public class DependencyInjcetionConfiguration
    {
        public static IServiceLocator Register(INavigator navigator)
        {
            IKernel kernel = new StandardKernel();
            RegisterDependency(kernel, navigator);
            return new NinjectServiceLocator(kernel);
        }

        public static void RegisterDependency(IKernel kernel, INavigator navigator)
        {
            kernel.Bind<INavigator>().ToConstant(navigator);
        }
    }
}
