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
            if (parameter == null)
            {
                return this.canExecute?.Invoke(default!) ?? true;
            }

            return this.canExecute?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            if (this.CanExecute(parameter))
            {
                if (parameter == null)
                {
                    this.action(default!);
                }
                else
                {
                    this.action((T)parameter);
                }
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