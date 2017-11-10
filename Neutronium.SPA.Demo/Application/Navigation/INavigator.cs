using System;
using System.Threading.Tasks;
using Neutronium.Core.Navigation;

namespace Neutronium.SPA.Demo.Application.Navigation
{
    public interface INavigator
    {
        Task Navigate(object viewModel, string routerName = null);

        Task Navigate<T>(NavigationContext<T> navigate = null);

        Task Navigate(Type type, NavigationContext context = null);

        event EventHandler<NavigationEvent> OnNavigate;
    }
}