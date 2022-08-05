using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Aquariums.Entities;
using AquaShop.Models.Decorations.Entities;
using AquaShop.Models.Fish.Entities;
using AquaShop.Repositories.Entities;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorationsRepository;
        private IList<IAquarium> aquariums;

        public Controller()
        {
            this.decorationsRepository = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                var freshwaterAquarium = new FreshwaterAquarium(aquariumName);
                this.aquariums.Add(freshwaterAquarium);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                var saltwaterAquarium = new SaltwaterAquarium(aquariumName);
                this.aquariums.Add(saltwaterAquarium);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                var ornament = new Ornament();
                this.decorationsRepository.Add(ornament);
            }
            else if (decorationType == "Plant")
            {
                var plant = new Plant();
                this.decorationsRepository.Add(plant);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = FindAquariumByName(aquariumName);

            if (fishType == "FreshwaterFish")
            {
                var fish = new FreshwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name == "FreshwaterAquarium")
                {
                    aquarium.AddFish(fish);
                }
                else
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                var fish = new SaltwaterFish(fishName, fishSpecies, price);

                if (aquarium.GetType().Name == "SaltwaterAquarium")
                {
                    aquarium.AddFish(fish);
                }
                else
                {
                    return OutputMessages.UnsuitableWater;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = FindAquariumByName(aquariumName);

            decimal value = 0;

            foreach (var fish in aquarium.Fish)
            {
                value += fish.Price;
            }
            foreach (var decoration in aquarium.Decorations)
            {
                value += decoration.Price;
            }

            return $"The value of Aquarium {aquariumName} is {value:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = FindAquariumByName(aquariumName);

            aquarium.Feed();

            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorationsRepository.FindByType(decorationType);
            var aquarium = FindAquariumByName(aquariumName);

            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            this.decorationsRepository.Remove(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this.aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        private IAquarium FindAquariumByName(string aquariumName)
        {
            IAquarium searchedAquarium = null;

            foreach (var aquarium in this.aquariums)
            {
                if (aquariumName == aquarium.Name)
                {
                    searchedAquarium = aquarium;
                }
            }

            return searchedAquarium;
        }
    }
}
