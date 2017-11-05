using Neutronium.SPA.Demo.ViewModel;
using System.Windows;
using System;
using Neutronium.WPF.ViewModel;

namespace Neutronium.SPA.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var window = new WindowViewModel(this);
            DataContext = new MainViewModel(window);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.HtmlView.Dispose();
        }
    }
}
