﻿using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums.Entities
{
    public class SaltwaterAquarium : Aquarium
    {
        public SaltwaterAquarium(string name) 
            : base(name, 25)
        {
        }
    }
}
