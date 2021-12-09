using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public Engine(string model, int power, int displacement)
            : this(model, power)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency)
            :this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency)
            :this(model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string displacementString = this.Displacement.HasValue ? this.Displacement.ToString() : "n/a";
            string efficiencyString = String.IsNullOrEmpty(this.Efficiency) ? "n/a" : this.Efficiency;

            sb
                .AppendLine($"{this.Model}:")
                .AppendLine($"    Power: {this.Power}")
                .AppendLine($"    Displacement: {displacementString}")
                .AppendLine($"    Efficiency: {efficiencyString}");

            return sb.ToString().TrimEnd();
        }
    }
}
