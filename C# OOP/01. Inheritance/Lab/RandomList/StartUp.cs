using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList randomList = new RandomList();

            randomList.Add("1");
            randomList.Add("2");
            randomList.Add("2");
            randomList.Add("23");
            randomList.Add("69");
        }
    }
}
