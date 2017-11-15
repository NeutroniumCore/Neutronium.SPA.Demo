using Neutronium.SPA.Demo.Application.Navigation;
using Vm.Tools.Application;

namespace Neutronium.SPA.Demo.Application.LifeCycleHook
{
    internal class LifeCycleEventsRegistror
    {
        private readonly IApplicationLifeCycle _ApplicationLifeCycle;
        private readonly IApplication _Application;
        private readonly INavigator _Navigator;

        public LifeCycleEventsRegistror(IApplicationLifeCycle applicationLifeCycle, IApplication application, INavigator navigator)
        {
            _ApplicationLifeCycle = applicationLifeCycle;
            _Application = application;
            _Navigator = navigator;
        }

        public LifeCycleEventsRegistror Register()
        {
            _Navigator.OnNavigated += Router_OnNavigated;
            _Navigator.OnNavigating += Router_OnNavigating;
            _Application.MainWindowClosing += _Application_MainWindowClosing;
            _Application.SessionEnding += _Application_SessionEnding;
            _Application.Closed += _Application_Closed;
            return this;
        }

        private void Router_OnNavigating(object sender, RoutingEventArgs e)
        {
            _ApplicationLifeCycle.OnNavigating(e);
        }

        private void _Application_Closed(object sender, System.EventArgs e)
        {
            _ApplicationLifeCycle.OnClosed();
        }

        private void _Application_SessionEnding(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ApplicationLifeCycle.OnSessionEnding(e);
        }

        private void _Application_MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _ApplicationLifeCycle.OnClosing(e);
        }

        private void Router_OnNavigated(object sender, RoutedEventArgs e)
        {
            _ApplicationLifeCycle.OnNavigated(e);
        }
    }
}