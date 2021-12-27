using P07.MilitaryElite.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Models
{
    public class Missione : IMission
    {
        public Missione(string codeName, Status status)
        {
            this.CodeName = codeName;
            this.Status = status;
        }

        public string CodeName { get; set; }
        public Status Status { get; set; }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {Status}";
        }
    }
}
