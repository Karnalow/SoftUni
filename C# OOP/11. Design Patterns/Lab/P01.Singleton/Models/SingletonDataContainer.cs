using P01.Singleton.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P01.Singleton.Models
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            string[] elements = File.ReadAllLines("capitals.txt");

            for (int i = 0; i < elements.Length; i += 2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        private static SingletonDataContainer instance = new SingletonDataContainer();

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }
}
