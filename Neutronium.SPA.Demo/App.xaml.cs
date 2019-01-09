using System.Diagnostics;
using System.Windows;
using Chromium;
using Neutronium.BuildingBlocks.SetUp;
using Neutronium.Core.JavascriptFramework;
using Neutronium.JavascriptFramework.Vue;
using Neutronium.WebBrowserEngine.ChromiumFx;
using Neutronium.WPF;
using Chromium.Event;

namespace Neutronium.SPA.Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : ChromiumFxWebBrowserApp
    {
        public static SetUpViewModel SetUp => (Current as App)?.SetUpViewModel;

        private SetUpViewModel SetUpViewModel { get; }
        private readonly ApplicationSetUpBuilder _ApplicationSetUpBuilder;

        public App()
        {
            _ApplicationSetUpBuilder = new ApplicationSetUpBuilder("View");
            SetUpViewModel = new SetUpViewModel(_ApplicationSetUpBuilder);
        }

        protected override IJavascriptFrameworkManager GetJavascriptUIFrameworkManager()
        {
            return new VueSessionInjector();
        }

        protected override void UpdateChromiumBrowserSettings(CfxBrowserSettings browserSettings)
        {
            var black = new CfxColor(255, 0, 0, 0);
            browserSettings.BackgroundColor = black;
        }

        protected override void OnStartUp(IHTMLEngineFactory factory)
        {
#if DEBUG
            SetUpForDeveloppment();
#else
            SetUpViewModel.InitForProduction();
#endif
            factory.RegisterJavaScriptFrameworkAsDefault(new VueSessionInjectorV2 { RunTimeOnly = true });
            base.OnStartUp(factory);
        }

        private void SetUpForDeveloppment()
        {
            _ApplicationSetUpBuilder.OnRunnerMessageReceived += OnRunnerMessageReceived;
            _ApplicationSetUpBuilder.OnArgumentParsingError += OnArgumentParsingError;
            SetUpViewModel.InitFromArgs(Args).Wait();
            Trace.WriteLine($"Starting with set-up: {SetUpViewModel}");
        }

        private void OnRunnerMessageReceived(object sender, MessageEventArgs e)
        {
            Trace.WriteLine($"Npm runner log: {e.Message}");
        }

        private void OnArgumentParsingError(object sender, MessageEventArgs e)
        {
            Trace.WriteLine($"Error parsing arguments, unexpected item: {e.Message}");
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _ApplicationSetUpBuilder.Dispose();
            base.OnExit(e);
        }
    }
}
