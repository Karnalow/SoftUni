using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class RequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}