using P07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; set; }

        public Status Status { get; set; }
    }
}
