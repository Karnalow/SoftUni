using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());

            int battles = 0;
            int wins = 0;
            int currentWins = 0;

            string command = Console.ReadLine();

            while (command != "End of battle")
            {
                battles++;

                int distance = int.Parse(command);

                if (energy >= distance)
                {
                    wins++;

                    currentWins++;

                    energy -= distance;

                    if (currentWins == 3)
                    {
                        currentWins = 0;

                        energy += wins;
                    }
                }
                else if (energy < distance)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");

                    break;
                }

                command = Console.ReadLine();
            }

            if (command == "End of battle")
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");
            }
        }
    }
}
