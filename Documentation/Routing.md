<p align="center"><img width="100" src="https://raw.githubusercontent.com/NeutroniumCore/neutronium-vue/master/template/src/assets/logo.png"></p>
<h1 align="center">Neutronium.SPA.Demo</h1>

## Routing

Neutronium.SPA.Demo integrates with [vue-router](https://router.vuejs.org/en/).

The main concept is that application is represented by an application ViewModel:

```CSharp
public class ApplicationViewModel : Vm.Tools.ViewModel, IMessageBox 
{
    public IWindowViewModel Window { get; }
    public NavigationViewModel Router { get; }

    private object _CurrentViewModel;
    public object CurrentViewModel 
    {
        get { return _CurrentViewModel; }
        private set { Set(ref _CurrentViewModel, value); }
    }
    //...
```
The `CurrentViewModel` represents the ViewModel underlying the current page, it will be updated during navigation.
Navigation API allows to associate viewModels to route, updating ViewModel when route is changing.<br>
Dependency Injection container is used to instanciate the page ViewModel.

### On the javascript side:
Routing is provided via an integration with [vue-router](https://router.vuejs.org/en/).

Only named route are used in this integration. Routes are declared in the javascript file [routeDefinitions.js](./Neutronium.SPA.Demo/View/Main/src/routeDefinitions.js) :


```javascript
import main from './pages/main.vue'
import about from './pages/about.vue'

const routeDefinitions = [
    {name:'main', component: main, menu: {icon: 'fa-television'}},
    {name:'about', component: about,  menu: {icon: 'info'}}
]
```
This file associates route identified by their names with theit corresponding Vue component.<br>

Note that when route appears in the side menu, it should have a menu property with a icon value indicating which icon to display.

It is possible to use router-link to navigate to a given route providing its name. In this case, the viewModel to be display will be instanciated by the C# API described below.

## On the C# side

Navigation API provided in the `Neutronium.SPA.Demo.Application.Navigation` namespace allows to associate ViewModel type to specific route via the [`IRouterBuilder`](../Neutronium.SPA.Demo/Application/Navigation/IRouterBuilder.cs) interface.
```cSharp
public interface IRouterBuilder
{
    /// <summary>
    /// Register a file relative path to HTML file corresponding to a   viewmodel type 
    /// </summary>
    /// <param name="type">
    /// Type of view model to register
    /// </param>
    /// <param name="routerName">
    /// router name
    /// </param>
    /// <param name="defaultType">
    /// true if the type should be considered as default 
    /// for the corresponding route name
    /// </param>
    /// <returns>
    /// the router builder instance
    /// </returns>
    IRouterBuilder Register(Type type, string routerName, bool defaultType = true);

    /// <summary>
    /// Register a file relative path to HTML file corresponding to a viewmodel type 
    /// </summary>
    /// <typeparam name="T">
    /// Type of view model to register
    /// </typeparam>
    /// <param name="routerName">
    /// router name
    /// </param>
    /// <param name="defaultType">
    ///  true if the type should be considered as default 
    /// for the corresponding route name
    /// </param>
    /// <returns>
    /// the navigation builder instance
    /// </returns>
    IRouterBuilder Register<T>(string routerName, bool defaultType = true);
}
```

It is possible to register route manually but you can also use convention to avoid repetitive code see below `RoutingConfiguration`.

This information is used by [`INavigator`](../Neutronium.SPA.Demo/Application/Navigation/INavigator.cs) interface implementation that allows to programmatically navigate.

```CSharp
    public interface INavigator
    {
        Task Navigate(object viewModel, string routeName = null);

        Task Navigate(string routeName);

        Task Navigate<T>(NavigationContext<T> context = null);

        Task Navigate(Type type, NavigationContext context = null);

        event EventHandler<RoutingEventArgs> OnNavigating;

        event EventHandler<RoutedEventArgs> OnNavigated;
    }
```

When navigation is done without providing a ViewModel instance, the ViewModel type (given as an argument, or inferred from the route name) is used by dependency injection mechanism to instanciate the corresponding ViewModel.<br>

[RoutingConfiguration](../Neutronium.SPA.Demo/App_start/RoutingConfiguration.cs) defines the convention for navigation: <br>
 all the types in the `Neutronium.SPA.Demo.ViewModel.Pages` namespace are associated with a route with name is the type without ViewModel postfix:

VM: `AboutViewModel` => route: `about`<br>
VM: `MainViewModel` => route: `main`

Finally:<br>
[ApplicationLifeCycle](../Neutronium.SPA.Demo/App_start/ApplicationLifeCycle.cs) is called during navigation on these two methods:

```CSharp
  public void OnNavigating(RoutingEventArgs routingEvent)
  
  public void OnNavigated(RoutedEventArgs routedEvent)
```
This allows application potentially to cancel a navigation or to reroute application.

Back to [README](../README.md)
