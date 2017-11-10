//using System;
//using System.Threading.Tasks;
//using Microsoft.Practices.ServiceLocation;
//using Neutronium.Core.Navigation;
//using Neutronium.SPA.Demo.Application.Ioc;

//namespace Neutronium.SPA.Demo.Application.Navigation
//{
//    public class Navigator : INavigator
//    {
//        private readonly IServiceLocator _ServiceLocator;

//        public Navigator(Func<INavigator, IServiceLocator> locatorBuilder)
//        {
//            _ServiceLocator = locatorBuilder(this) ?? new TrivialServiceLocator().Add(this);
//        }

//        public Task Navigate(object viewModel, string routerName = null)
//        {
//            throw new NotImplementedException();
//        }

//        public Task Navigate<T>(NavigationContext<T> navigate = null)
//        {
//            throw new NotImplementedException();
//        }

//        public Task Navigate(Type type, NavigationContext context = null)
//        {
//            throw new NotImplementedException();
//        }

//        public event EventHandler<NavigationEvent> OnNavigate;
//    }
//}
