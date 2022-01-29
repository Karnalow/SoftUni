using P02.Facade.Models;
using System;

namespace P02.Facade
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                  .WithType("BMW")
                  .WithColor("red")
                  .WithNumberOfDoors(4)
                .Built
                  .InCity("Bracigovo")
                  .InAddress("Hristo Smirnenski #3")
                .Build();

            Console.WriteLine(car);
        }
    }
}
