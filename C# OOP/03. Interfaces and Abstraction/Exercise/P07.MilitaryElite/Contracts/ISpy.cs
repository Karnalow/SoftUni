﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P07.MilitaryElite.Contracts
{
    public interface ISpy : ISoldier
    {
        public int CodeNumber { get; set; }
    }
}
