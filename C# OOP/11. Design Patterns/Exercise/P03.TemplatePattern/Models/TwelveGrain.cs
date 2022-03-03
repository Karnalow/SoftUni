﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P03.TemplatePattern.Models
{
    public class TwelveGrain : Bread
    {
        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for 12-Grain Bread.");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking the 12-Grain Bread. (25minutes)");
        }
    }
}