﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Composite.Models
{
    public abstract class GiftBase
    {
        protected string name;
        protected int price;

        protected GiftBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract int CalculateTotalPrice();
    }
}
