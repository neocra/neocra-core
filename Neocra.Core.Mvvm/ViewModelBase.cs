using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Neocra.Core.Mvvm
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public void RaisePropertyChanged([CallerMemberName]string propertyName = null!)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Set<T>(ref T field, T newValue, [CallerMemberName]string propertyName = null!)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;

                this.RaisePropertyChanged(propertyName);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}