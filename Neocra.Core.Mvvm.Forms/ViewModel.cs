using System;
using Pattern.Config;
using Pattern.Core.Interfaces;
using Xamarin.Forms;

namespace Neocra.Core.Mvvm.Forms
{
    public static class ViewModel
    {
        public static void BindViewModel<TView, TViewModel>(this IKernel syntax)
            where TView : Page
            where TViewModel : ViewModelBase
        {
            syntax.Bind(typeof(TView), new PageFactory(typeof(TView), typeof(TViewModel), syntax));
        }
        
        public static NavigationPage LoadNavigationPage(this IKernel kernel, NavigationConfig config)
        {
            kernel.Bind<NavigationConfig>().ToMethod(() => config);
            kernel.Bind<INavigationService>().To<NavigationService>().InSingletonScope();

            kernel.Bind<NavigationPage>()
                .ToMethod(() => new NavigationPage((Page)(kernel.Get(config.RootPage)
                    ?? throw new ArgumentException("NavigationPage not found"))))
                .InSingletonScope();

            return kernel.Get<NavigationPage>() ?? throw new ArgumentException("NavigationPage not found");
        }
    }
}