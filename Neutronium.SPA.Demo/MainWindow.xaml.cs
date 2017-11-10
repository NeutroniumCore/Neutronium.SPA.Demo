using Neutronium.SPA.Demo.ViewModel;
using System.Windows;
using System;
using Neutronium.SPA.Demo.Application.Navigation;
using Neutronium.WPF.ViewModel;

namespace Neutronium.SPA.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitApplication();
            DataContext = BuildApplicationViewModel();
        }

        private void InitApplication()
        {
            RoutingConfiguration.Register();
        }

        private ApplicationViewModel BuildApplicationViewModel()
        {
            var window = new WindowViewModel(this);
            var serviceLocator = DependencyInjcetionConfiguration.Register(null);
            var routeSolver = new Router();
            return new ApplicationViewModel(window, serviceLocator, routeSolver);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.HtmlView.Dispose();
        }
    }
}
