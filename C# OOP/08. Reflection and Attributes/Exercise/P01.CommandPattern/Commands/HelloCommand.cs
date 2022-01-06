using System;
using System.Windows.Input;

namespace P01.CommandPattern.Commands
{
    public class HelloCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
