namespace Neutronium.SPA.Demo.Application.Navigation
{
    public struct BeforeRouterResult
    {
        public BeforeRouterResult(string redirect)
        {
            Redirect = redirect;
            Continue = true;
        }

        public BeforeRouterResult(bool continueRoute)
        {
            Redirect = null;
            Continue = continueRoute;
        }

        public string Redirect { get; }
        public bool Continue { get; }
    }
}
