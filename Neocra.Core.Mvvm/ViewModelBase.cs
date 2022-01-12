using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Neocra.Core.Tasks;

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
        
        private readonly Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();
 
        protected AsyncCommand<T> CreateCommand<T>(
            Func<T, Task> method, Func<T, bool>? canExecute = null,
            ILoadingHandler? loadingHandler = null,
            [CallerMemberName] string name = null!)
        {
            if (this.commands.ContainsKey(name))
            {
                return (AsyncCommand<T>)this.commands[name];
            }
 
            var command = new AsyncCommand<T>(method, loadingHandler, canExecute);
            this.commands.Add(name, command);
 
            return command;
        }
  
        protected AsyncCommand CreateCommand(
            Func<Task> method, Func<bool>? canExecute = null,
            ILoadingHandler? loadingHandler = null,
            [CallerMemberName] string name = null!)
        {
            if (this.commands.ContainsKey(name))
            {
                return (AsyncCommand)this.commands[name];
            }
 
            var command = new AsyncCommand(method, loadingHandler, canExecute);
            this.commands.Add(name, command);
 
            return command;
        }
    }

}