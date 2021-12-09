using System;
using System.Numerics;

namespace MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
            BigInteger secoundNum = BigInteger.Parse(Console.ReadLine());

            BigInteger sum = firstNum * secoundNum;

            Console.WriteLine(sum);
        }
    }
}
