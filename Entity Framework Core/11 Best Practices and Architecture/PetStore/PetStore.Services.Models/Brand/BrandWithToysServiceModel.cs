using System;
using System.Collections.Generic;
using System.Text;
using PetStore.Services.Models.Toy;

namespace PetStore.Services.Models.Brand
{
    public class BrandWithToysServiceModel
    {
        public string Name { get; set; }

        public IEnumerable<ToyListing> Toys { get; set; }

    }
}
