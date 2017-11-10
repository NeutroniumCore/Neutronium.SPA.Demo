using System;

namespace Neutronium.SPA.Demo.Application.Navigation
{
    public interface IRouterSolver
    {
        string SolveRoute(object viewModel);

        Type SolveType(string route);
    }
}