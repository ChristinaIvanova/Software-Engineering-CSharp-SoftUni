﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public abstract class GiftBase
    {
        protected string name;
        protected decimal price;

        protected GiftBase(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract decimal CalculateTotalPrice();
    }
}
