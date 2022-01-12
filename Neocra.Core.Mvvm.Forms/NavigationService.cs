using System;
using System.Linq;
using System.Threading.Tasks;
using Neocra.Core.Tasks;
using Pattern.Core.Interfaces;
using Xamarin.Forms;

namespace Neocra.Core.Mvvm.Forms
{
    public class NavigationService : INavigationService
    {
        private readonly IKernel kernel;

        private readonly NavigationPage navigationPage;
        private readonly INavigationHandler navigationHandler;
        
        public NavigationService(IKernel kernel, NavigationPage navigationPage, INavigationHandler navigationHandler)
        {
            this.kernel = kernel;
            this.navigationPage = navigationPage;
            this.navigationHandler = navigationHandler;
        }

        public Task Navigate(Type pageType,
            bool animated = true)
        {
            return this.Navigate<object>(pageType, null, animated);
        }

        public async Task Navigate<TParameter>(
            Type pageType,
            TParameter? parameterToNextViewModel,
            bool animated = true)
        {
            if (this.navigationPage.CurrentPage is INavigateFrom pageNavigateFrom)
            {
                animated = false;
                await pageNavigateFrom.NavigateFrom(pageType);
            }

            var (page, viewmodel) = this.ResolveView(pageType);

            viewmodel.InitOrResumeAsync(parameterToNextViewModel).Fire(viewmodel);
       
            this.navigationHandler?.Navigate(pageType.Name, page);
            await this.navigationPage.PushAsync(page, animated);
            await viewmodel.AfterNavigationAsync();
        }
        

        public async Task NavigateBack(bool animated = true)
        {
            this.navigationHandler?.NavigateBack();
            await this.navigationPage.PopAsync(animated);
            var viewModel = this.navigationPage.CurrentPage.BindingContext as ViewModelBase;
            viewModel?.InitOrResumeAsync(viewModel.Parameter);
        }

        private (Page, ViewModelBase) ResolveView(Type pageType)
        {
            var page = (Page)(this.kernel.Get(pageType) ?? throw new ArgumentException($"Not found page {pageType.Name}"));
            return (page, (ViewModelBase)page.BindingContext);
        }
 
        public Task NavigateRoot(Type pageType, bool animated = false)
        {
            return this.NavigateRoot<object>(pageType, null, animated);
        }
        
        public async Task NavigateRoot<TParameter>(Type pageType, TParameter? parameterToNextViewModel, bool animated = false)
        {
            if (this.navigationPage.CurrentPage is INavigateFrom pageNavigateFrom)
            {
                animated = false;
                await pageNavigateFrom.NavigateFrom(pageType);
            }

            var (page, viewmodel) = this.ResolveView(pageType);

            viewmodel.InitOrResumeAsync(parameterToNextViewModel).Fire(viewmodel);
       
            this.navigationHandler?.Navigate(pageType.Name, page);
            this.navigationPage.Navigation.InsertPageBefore(page,
                this.navigationPage.Navigation.NavigationStack.First());
            await this.navigationPage.PopToRootAsync(animated);
            await viewmodel.AfterNavigationAsync();
        }
    }
}