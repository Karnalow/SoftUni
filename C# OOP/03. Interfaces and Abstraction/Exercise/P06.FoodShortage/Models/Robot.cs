using P06.FoodShortage.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P06.FoodShortage.Models
{
    public class Robot : IIdentifiable
    {
        private string model;

        public Robot(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}
