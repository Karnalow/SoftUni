using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            CollectionOfPokemon = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> CollectionOfPokemon { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Badges} {this.CollectionOfPokemon.Count}";
        }
    }
}
