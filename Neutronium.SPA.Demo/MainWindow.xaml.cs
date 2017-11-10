using System;
using Neutronium.SPA.Demo.ViewModel;
using Neutronium.WPF.ViewModel;
using Neutronium.SPA.Demo.ViewModel.Menu;

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
            DataContext = BuildApplicationViewModel();
        }

        private ApplicationViewModel BuildApplicationViewModel()
        {
            var window = new WindowViewModel(this);
            var routeSolver = RoutingConfiguration.Register();
            return ApplicationViewModel.CreateApplicationViewModel<MainViewModel>(window, routeSolver, DependencyInjectionConfiguration.Register);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.HtmlView.Dispose();
        }
    }
}
