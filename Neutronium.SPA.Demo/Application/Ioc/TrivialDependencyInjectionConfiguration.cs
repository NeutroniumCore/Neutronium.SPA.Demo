using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;

namespace Neutronium.SPA.Demo.Application.Ioc
{
    public class TrivialDependencyInjectionConfiguration : IDependencyInjectionConfiguration 
    {
        public IServiceLocator GetServiceLocator() => new TrivialServiceLocator();

        public void Register<T>(T implementation) {}
    }
}
