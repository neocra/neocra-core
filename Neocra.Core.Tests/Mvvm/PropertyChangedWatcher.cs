using System.ComponentModel;

namespace Neocra.Core.Tests.Mvvm
{
    internal class PropertyChangedWatcher
    {
        public PropertyChangedWatcher()
        {
        }

        public bool IsRaised { get; private set; }
        public string PropertyName { get; private set; }

        internal void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyName = e.PropertyName;
            this.IsRaised = true;
        }
    }
}