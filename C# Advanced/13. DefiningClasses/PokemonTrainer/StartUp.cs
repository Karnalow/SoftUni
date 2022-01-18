using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] cmdArg = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Trainer> trainers = new List<Trainer>();

            cmdArg = RegisterTrainerWithPokemons(cmdArg, trainers);

            while (cmdArg[0] != "End")
            {
                string element = cmdArg[0];

                foreach (var trainer in trainers)
                {
                    foreach (var pokemon in trainer.CollectionOfPokemon)
                    {
                        if (pokemon.Element == element)
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            pokemon.Health -= 10;
                        }
                    }
                }

                cmdArg = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var trainer in trainers)
            {
                for (int i = 0; i < trainer.CollectionOfPokemon.Count; i++)
                {
                    if (trainer.CollectionOfPokemon[i].Health <= 0)
                    {
                        trainer.CollectionOfPokemon.RemoveAt(i);

                        i--;
                    }
                }
            }

            List<Trainer> trainersLeaderboard = trainers.OrderByDescending(b => b.Badges).ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine(trainer);
            }
        }

        private static string[] RegisterTrainerWithPokemons(string[] cmdArg, List<Trainer> trainers)
        {
            while (cmdArg[0] != "Tournament")
            {
                string trainerName = cmdArg[0];
                string pokemonName = cmdArg[1];
                string pokemonElement = cmdArg[2];
                int pokemonHealth = int.Parse(cmdArg[3]);

                Trainer trainerUnique = trainers.FirstOrDefault(n => n.Name == trainerName);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainerUnique != null)
                {
                    trainerUnique.CollectionOfPokemon.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);

                    trainer.CollectionOfPokemon.Add(pokemon);
                    trainers.Add(trainer);
                }

                cmdArg = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            return cmdArg;
        }
    }
}
