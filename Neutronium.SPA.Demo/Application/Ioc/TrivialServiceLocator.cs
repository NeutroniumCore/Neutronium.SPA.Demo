using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;

namespace Neutronium.SPA.Demo.Application.Ioc
{
    public class TrivialServiceLocator : ServiceLocatorImplBase
    {
        private readonly Dictionary<Type, object> _Objects = new Dictionary<Type, object>();

        public TrivialServiceLocator Add<T>(T item)
        {
            _Objects[typeof(T)] = item;
            return this;
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            object result;
            return _Objects.TryGetValue(serviceType, out result) ? result : Activator.CreateInstance(serviceType);
        }
    }
}
