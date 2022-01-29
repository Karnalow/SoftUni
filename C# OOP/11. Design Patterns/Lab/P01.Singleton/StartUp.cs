using P01.Singleton.Models;
using System;

namespace P01.Singleton
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;

            Console.WriteLine(db.GetPopulation("Washington, D.C"));

            var db2 = SingletonDataContainer.Instance;

            Console.WriteLine(db2.GetPopulation("London"));

            var db3 = SingletonDataContainer.Instance;
            var db4 = SingletonDataContainer.Instance;
        }
    }
}
