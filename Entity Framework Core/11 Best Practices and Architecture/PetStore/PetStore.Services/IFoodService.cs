using System;
using System.Collections.Generic;
using System.Text;
using PetStore.Services.Models.Food;

namespace PetStore.Services
{
    public interface IFoodService
    {
        void BuyFromDistributor(string name, double weight, decimal price,
            double profitRate, DateTime expirationDate, int brandId, int categoryId);

        void BuyFromDistributor(AddingFoodServiceModel model);
    }
}
