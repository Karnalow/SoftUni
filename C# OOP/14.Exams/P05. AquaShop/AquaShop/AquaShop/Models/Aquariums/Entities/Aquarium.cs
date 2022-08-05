using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums.Entities
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int comfort;
        private IList<IDecoration> decorations;
        private IList<IFish> fish;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort 
        {
            get
            {
                foreach (var decoration in this.decorations)
                {
                    this.comfort += decoration.Comfort;
                }

                return this.comfort;
            }
        }

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity < 1)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.fish)
            {
                fish.Eat();
            }
        }

        public bool RemoveFish(IFish fish)
        {
            if (this.fish.Contains(fish))
            {
                this.fish.Remove(fish);

                return true;
            }

            return false;
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.fish.Count < 1)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                List<string> fishNames = new List<string>();

                foreach (var fish in this.fish)
                {
                    fishNames.Add(fish.Name);
                }

                sb.AppendLine($"Fish: {string.Join(", ", fishNames)}");
            }

            sb.AppendLine($"Decorations: {this.Decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
