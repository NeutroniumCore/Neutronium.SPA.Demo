using System;

namespace Neutronium.SPA.Demo.Application.Navigation
{
    public interface IRouterBuilder
    {
        /// <summary>
        /// Register a file relative path to HTML file corresponding to a viewmodel type 
        /// </summary>
        /// <param name="type">
        /// Type of view model to register
        /// </param>
        /// <param name="routerName">
        /// router name
        /// </param>
        /// <param name="defaultType">
        /// true if the type should be considered as default 
        /// for the corresponding route name
        /// </param>
        /// <returns>
        /// the router builder instance
        /// </returns>
        IRouterBuilder Register(Type type, string routerName, bool defaultType = true);

        /// <summary>
        /// Register a file relative path to HTML file corresponding to a viewmodel type 
        /// </summary>
        /// <typeparam name="T">
        /// Type of view model to register
        /// </typeparam>
        /// <param name="routerName">
        /// router name
        /// </param>
        /// <param name="defaultType">
        ///  true if the type should be considered as default 
        /// for the corresponding route name
        /// </param>
        /// <returns>
        /// the navigation builder instance
        /// </returns>
        IRouterBuilder Register<T>(string routerName, bool defaultType = true);
    }
}
