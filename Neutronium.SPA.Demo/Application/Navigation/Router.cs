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
            return SolveRoute(viewModel.GetType());
        }

        public string SolveRoute<T>()
        {
            return SolveRoute(typeof(T));
        }

        private string SolveRoute(Type type)
        {
            return _TypeToRoute.GetOrDefault(type);
        }

        public Type SolveType(string route)
        {
            return _RouteToType.GetOrDefault(route);
        }
    }
}
