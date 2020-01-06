using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Brand;
using PetStore.Services.Models.Toy;

namespace PetStore.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly PetStoreDbContext data;

        public BrandService(PetStoreDbContext data)
        => this.data = new PetStoreDbContext();

        public int Create(string name)
        {
            if (name == null)
            {
                throw new InvalidOperationException($"Name cannot be null");
            }

            if (this.data.Brands.Any(br => br.Name == name))
            {
                throw new InvalidOperationException($"{name} already exists");
            }

            if (name.Length > DataValidation.NameMaxLength)
            {
                throw new InvalidOperationException($"Name cannot be more than {DataValidation.NameMaxLength} symbols.");
            }

            var brand = new Brand
            {
                Name = name
            };

            this.data.Brands.Add(brand);
            this.data.SaveChanges();

            return brand.Id;

        }

        public IEnumerable<BrandServiceListingModel> SearchByName(string name)
       => this.data
                .Brands
                .Where(br => br.Name.ToLower().Contains(name.ToLower()))
                .Select(br => new BrandServiceListingModel
                {
                    Id = br.Id,
                    Name = br.Name
                })
                .ToList();

        public BrandWithToysServiceModel FindByIdWithToys(int id)
            => this.data
                .Brands
                .Where(br => br.Id == id)
                .Select(br => new BrandWithToysServiceModel
                {
                    Name = br.Name,
                    Toys = br.Toys
                        .Select(t => new ToyListing
                        {
                            Id = t.Id,
                            Name = t.Name,
                            Price = t.Price,
                            TotalOrders = t.Orders.Count
                        })
                })
                .FirstOrDefault();
    }
}
