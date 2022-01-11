using System;
using System.Windows.Input;

namespace Neocra.Core.Mvvm
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> action;
        private readonly Func<T, bool>? canExecute;

        public RelayCommand(Action<T> action, Func<T, bool>? canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecute()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            _ = parameter ?? throw new ArgumentException("Parameter is null", nameof(parameter));
            return this.canExecute?.Invoke((T) parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            _ = parameter ?? throw new ArgumentException("Parameter is null", nameof(parameter));
            if (this.CanExecute(parameter))
            {
                this.action((T)parameter);
            }   
        }
    }
    
    public class RelayCommand : ICommand
    {
        private readonly Action action;
        private readonly Func<bool>? canExecute;

        public RelayCommand(Action action, Func<bool>? canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecute()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            return this.canExecute?.Invoke() ?? true;
        }

        public void Execute(object? parameter)
        {
            if (this.CanExecute(parameter))
            {
                this.action();
            }
        }
    }
}