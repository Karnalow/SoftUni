using System;
using System.Linq;

namespace P02.TheBattleOfTheFiveArmies
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                field[i] = chars;
            }

            int armyRow = 0;
            int armyCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;

                        break;
                    }
                }
            }

            while (armyArmor > 0)
            {
                string[] command = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = command[0];
                int OrcRow = int.Parse(command[1]);
                int OrcCol = int.Parse(command[2]);

                field[OrcRow][OrcCol] = 'O';
                field[armyRow][armyCol] = '-';

                armyArmor--;

                if (direction == "up" && armyRow - 1 >= 0)
                {
                    armyRow--;
                }
                else if (direction == "down" && armyRow + 1 < rows)
                {
                    armyRow++;
                }
                else if (direction == "left" && armyCol - 1 >= 0)
                {
                    armyCol--;
                }
                else if (direction == "right" && armyCol + 1 < field[armyRow].Length)
                {
                    armyCol++;
                }

                if (field[armyRow][armyCol] == 'O')
                {
                    armyArmor -= 2;
                }

                if (field[armyRow][armyCol] == 'M')
                {
                    field[armyRow][armyCol] = '-';

                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");

                    break;
                }

                if (armyArmor < 1)
                {
                    field[armyRow][armyCol] = 'X';

                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");

                    break;
                }

                field[armyRow][armyCol] = 'A';
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    Console.Write(field[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}
