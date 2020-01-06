using System;
using System.Collections.Generic;
using System.Text;
using PetStore.Services.Models;
using PetStore.Services.Models.Brand;

namespace PetStore.Services
{
    public interface IBrandService
    {
        int Create(string name);

        IEnumerable<BrandServiceListingModel> SearchByName(string name);

        BrandWithToysServiceModel FindByIdWithToys(int id);
    }
}
