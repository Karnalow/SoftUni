using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public List<IMission> Missions { get; set; }

        void ComplateMission(string codeName);
    }
}
