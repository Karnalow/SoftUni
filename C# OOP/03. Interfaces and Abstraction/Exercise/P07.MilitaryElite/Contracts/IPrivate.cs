using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
    public interface IPrivate : ISoldier
    {
        public decimal Salary { get; set; }
    }
}
