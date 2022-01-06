using P01.CommandPattern.Core.Conntracs;
using System;

namespace P01.CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            string result = commandInterpreter.Read(input);

            Console.WriteLine(result);
        }
    }
}
