using PetStore.Data;
using PetStore.Data.Models;
using PetStore.Services.Models.Food;
using System;

namespace PetStore.Services.Implementations
{
    public class FoodService : IFoodService
    {
        private readonly PetStoreDbContext data;

        public FoodService(PetStoreDbContext data)
            => this.data = new PetStoreDbContext();
        public void BuyFromDistributor(string name, double weight, decimal price,
            double profitRate, DateTime expirationDate, int brandId, int categoryId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or white space");
            }

            if (profitRate < 0 || profitRate > 5)
            {
                throw new ArgumentException("Profit must be higher than 0 and lower than 500%");
            }

            var food = new Food
            {
                Name = name,
                Weight = weight,
                DistributorPrice = price,
                Price = price * (decimal)(1 + profitRate),
                ExpirationDate = expirationDate,
                BrandId = brandId,
                CategoryId = categoryId
            };

            this.data.Foods.Add(food);
            this.data.SaveChanges();
        }

        public void BuyFromDistributor(AddingFoodServiceModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentException("Name cannot be null or white space");
            }

            if (model.ProfitRate < 0 || model.ProfitRate > 5)
            {
                throw new ArgumentException("Profit must be higher than 0 and lower than 500%");
            }

            var food = new Food
            {
                Name = model.Name,
                Weight = model.Weight,
                DistributorPrice = model.Price,
                Price = model.Price * (decimal)(1 + model.ProfitRate),
                ExpirationDate = model.ExpirationDate,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId
            };

            this.data.Foods.Add(food);
            this.data.SaveChanges();
        }
    }
}
