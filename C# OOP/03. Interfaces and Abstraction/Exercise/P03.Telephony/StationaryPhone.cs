using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call()
        {
            return $"Dialing...";
        }
    }
}
