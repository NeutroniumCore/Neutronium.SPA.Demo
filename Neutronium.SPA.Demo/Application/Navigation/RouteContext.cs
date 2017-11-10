using System.Threading.Tasks;

namespace Neutronium.SPA.Demo.Application.Navigation
{
    public class RouteContext
    {
        public object ViewModel { get; }
        public string Route { get; }
        public Task Task => _TaskCompletionSource.Task;

        private readonly TaskCompletionSource<int> _TaskCompletionSource = new TaskCompletionSource<int>();

        public RouteContext(object viewModel, string route)
        {
            ViewModel = viewModel;
            Route = route;
        }

        public void Complete()
        {
            _TaskCompletionSource.TrySetResult(0);
        }
    }
}
