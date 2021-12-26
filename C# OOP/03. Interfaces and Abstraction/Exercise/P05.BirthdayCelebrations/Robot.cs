using System;
using System.Collections.Generic;
using System.Text;

namespace P05.BirthdayCelebrations
{
    public class Robot : IIdentifiable
    {
        public string Model { get; set; }

        public string Id { get; set; }

        public List<string> Robots { get; set; }
    }
}
