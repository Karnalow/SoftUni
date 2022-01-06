using System;
using System.Windows.Input;

namespace P01.CommandPattern.Commands
{
    public class ExitCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public string Execute(string[] args)
        {
            Environment.Exit(0);
            return null;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
