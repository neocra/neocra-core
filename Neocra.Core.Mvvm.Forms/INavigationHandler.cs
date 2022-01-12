 using Xamarin.Forms;

 namespace Neocra.Core.Mvvm.Forms
{
    public interface INavigationHandler
    {
        void Navigate(string path, Page page);

        void NavigateBack();
    }
}