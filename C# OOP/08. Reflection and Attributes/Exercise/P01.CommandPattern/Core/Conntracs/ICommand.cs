namespace P01.CommandPattern.Core.Conntracs
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
