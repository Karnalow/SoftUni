using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> pieces =
            new Dictionary<string, Dictionary<string,string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

                string piece = input[0];
                string composer = input[1];
                string key = input[2];

                pieces[piece] = new Dictionary<string, string>();

                pieces[piece].Add(composer, key);
            }

            string[] command = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Stop")
            {

                string piece = command[1];

                if (command[0] == "Add")
                {
                    string composer = command[2];
                    string key = command[3];

                    if (!pieces.ContainsKey(piece))
                    {
                        pieces[piece] = new Dictionary<string, string>();

                        pieces[piece].Add(composer, key);

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);

                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command[0] == "ChangeKey")
                {
                    string newKey = command[2];

                    if (pieces.ContainsKey(piece))
                    {
                        var compositors = pieces[piece].Keys.ToList();

                        pieces[piece][compositors[0]] = newKey;

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }

                command = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var piece in pieces.OrderBy(p => p.Key).ThenBy(c => c.Value.Keys))
            {
                var compositor = piece.Value.Keys.ToList();
                var key = piece.Value.Values.ToList();

                Console.WriteLine($"{piece.Key} -> Composer: {compositor[0]}, Key: {key[0]}");
            }
        }
    }
}
