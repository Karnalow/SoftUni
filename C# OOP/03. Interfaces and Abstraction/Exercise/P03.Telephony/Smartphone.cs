using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browsing()
        {
            return $"Browsing:";
        }

        public string Call()
        {
            return $"Calling...";
        }
    }
}
