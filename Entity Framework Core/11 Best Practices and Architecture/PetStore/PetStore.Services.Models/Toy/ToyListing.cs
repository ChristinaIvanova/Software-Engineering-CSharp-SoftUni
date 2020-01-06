﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Services.Models.Toy
{
    public class ToyListing
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public  int TotalOrders { get; set; }
    }
}
