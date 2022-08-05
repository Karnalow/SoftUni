using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums.Entities
{
    public class FreshwaterAquarium : Aquarium
    {
        public FreshwaterAquarium(string name) 
            : base(name, 50)
        {
        }
    }
}
