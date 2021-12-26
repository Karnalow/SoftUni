using System;
using System.Collections.Generic;
using System.Text;

namespace P05.BirthdayCelebrations
{
    public class Pet : IMamal
    {
        public string Name { get; set; }

        public string Birthdate { get; set; }

        public List<string> Pets { get; set; }
    }
}
