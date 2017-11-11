using System;
using System.Threading.Tasks;
using Neutronium.Core.Navigation;

namespace Neutronium.SPA.Demo.Application.Navigation
{
    public interface INavigator
    {
        Task Navigate(object viewModel, string routeName = null);

        Task Navigate(string routeName);

        Task Navigate<T>(NavigationContext<T> contet = null);

        Task Navigate(Type type, NavigationContext context = null);

        event EventHandler<NavigationEvent> OnNavigate;
    }
}