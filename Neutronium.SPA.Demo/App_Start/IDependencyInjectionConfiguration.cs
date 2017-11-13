using Microsoft.Practices.ServiceLocation;

namespace Neutronium.SPA.Demo 
{
    public interface IDependencyInjectionConfiguration 
    {
        IServiceLocator GetServiceLocator();

        void Register<T>(T implementation);
    }
}