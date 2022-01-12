using System;

 namespace Neocra.Core.Mvvm.Forms
{
    public class NavigationConfig
    {
        public NavigationConfig(Type rootPage)
        {
            this.RootPage = rootPage;
        }

        public Type RootPage { get; }
    }
}