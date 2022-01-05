using P01.Logger.Models.Enumerations;
using System;

namespace P01.Logger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
