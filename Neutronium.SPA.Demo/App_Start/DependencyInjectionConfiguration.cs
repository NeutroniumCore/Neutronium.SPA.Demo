using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Vm.Tools.Application;

namespace Neutronium.SPA.Demo 
{
    public class DependencyInjectionConfiguration: IDependencyInjectionConfiguration
    {
        private StandardKernel _Kernel;

        public DependencyInjectionConfiguration() 
        {
            var kernel = new StandardKernel(new NinjectSettings { UseReflectionBasedInjection = true });
            RegisterDependency(kernel);
            _Kernel = kernel;
        }

        public IServiceLocator GetServiceLocator() => new NinjectServiceLocator(_Kernel);

        public void Register<T>(T implementation) => _Kernel.Bind<T>().ToConstant(implementation);

        public static void RegisterDependency(IKernel kernel)
        {
            var window = System.Windows.Application.Current.MainWindow;
            var application = new WpfApplication(window);
            kernel.Bind<IApplication>().ToConstant(application);
        }
    }
}
