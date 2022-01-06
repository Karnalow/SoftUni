﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class RangeAttribute : MyValidationAttribute
    {
        private int min;
        private int max;

        public RangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException();
            }

            int value = (int)obj;

            if (value >= min && value <= max)
            {
                return true;
            }

            return false;
        }
    }
}