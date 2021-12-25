using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private const string DoughExceptionMessage = "Invalid type of dough.";
        private const string WeightExceptionMessage = "Dough weight should be in the range[1..200].";


        //White - 1.5
        //Wholegrain - 1.0
        //Crispy - 0.9
        //Chewy - 1.1
        //Homemade - 1.0

        private Dictionary<string, double> flourTypeCalories =
        new Dictionary<string, double>
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 },
        };

        private Dictionary<string, double> bakingTechniqueCalories =
        new Dictionary<string, double>
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType // white or wholegrain
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughExceptionMessage);
                }

                flourType = value;
            }
        }


        public string BakingTechnique // crispy, chewy, or homemade
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (!bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(DoughExceptionMessage);
                }

                bakingTechnique = value;
            }
        }


        public double Weight
        {
            get 
            { 
                return weight; 
            }
            private set 
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(WeightExceptionMessage);
                }

                weight = value; 
            }
        }

        public double Calories
            => 2 * this.Weight * flourTypeCalories[this.FlourType.ToLower()] 
            * bakingTechniqueCalories[this.bakingTechnique.ToLower()];
    }
}
