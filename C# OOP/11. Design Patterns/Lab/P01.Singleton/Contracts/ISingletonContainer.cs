using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Singleton.Contracts
{
    public interface ISingletonContainer
    {
        int GetPopulation(string name);
    }
}
