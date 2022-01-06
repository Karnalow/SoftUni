using P01.CommandPattern;
using P01.CommandPattern.Core;
using P01.CommandPattern.Core.Conntracs;

namespace CommandPattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);
            engine.Run();
        }
    }
}
