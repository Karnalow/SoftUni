using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger biggestValue = 0;
            int biggestSnowballSnow = 0;
            int biggestSnowballTime = 0;
            int biggestSnowballQuality = 0;

            for (int i = 1; i <= n; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                int snowDividedByTime = snowballSnow / snowballTime;
                
                BigInteger snowballValue = BigInteger.Pow(snowDividedByTime, snowballQuality);
                
                if (snowballValue > biggestValue)
                {
                    biggestValue = snowballValue;
                    biggestSnowballTime = snowballTime;
                    biggestSnowballQuality = snowballQuality;
                    biggestSnowballSnow = snowballSnow;
                }
            }

            Console.WriteLine($"{biggestSnowballSnow} : {biggestSnowballTime} = {biggestValue} ({biggestSnowballQuality})");
        }
    }
}
