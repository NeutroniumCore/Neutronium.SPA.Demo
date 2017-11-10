using System;
using System.Collections.Generic;
using MoreCollection.Extensions;

namespace Neutronium.SPA.Demo.Application.Navigation
{
    internal class Router : IRouterBuilder, IRouterSolver
    {
        private readonly Dictionary<string, Type> _RouteToType = new Dictionary<string, Type>();
        private readonly Dictionary<Type, string> _TypeToRoute = new Dictionary<Type, string>();

        public IRouterBuilder Register(Type type, string routerName, bool defaultType = true)
        {
            _TypeToRoute.Add(type, routerName);

            if (!defaultType && _RouteToType.ContainsKey(routerName))
                return this;

            _RouteToType[routerName] = type;
            return this;
        }

        public IRouterBuilder Register<T>(string routerName, bool defaultType = true)
        {
            return Register(typeof(T), routerName, defaultType);
        }

        public string SolveRoute(object viewModel)
        {
            return _TypeToRoute.GetOrDefault(viewModel.GetType());
        }

        public Type SolveType(string route)
        {
            return _RouteToType.GetOrDefault(route);
        }
    }
}
