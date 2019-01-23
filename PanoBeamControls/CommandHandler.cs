using System;
using System.Windows.Input;

namespace PanoBeam.Controls
{
    public class CommandHandler : ICommand
    {
        private readonly Action _action;
        private readonly Predicate<object> _canExecute;

        public CommandHandler(Action action, Predicate<object> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute != null && _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}