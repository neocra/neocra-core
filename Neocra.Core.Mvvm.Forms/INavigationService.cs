using System;
using System.Threading.Tasks;

namespace Neocra.Core.Mvvm.Forms
{
    public interface INavigationService
    {
        Task Navigate(Type pageType, bool animated = true);

        Task Navigate<T>(Type pageType, T parameterToNextViewModel, bool animated = true);

        Task NavigateBack(bool animated = true);

        Task NavigateRoot(Type pageType, bool animated = false);
        
        Task NavigateRoot<TParameter>(Type pageType, TParameter parameterToNextViewModel, bool animated = false);
    }
}