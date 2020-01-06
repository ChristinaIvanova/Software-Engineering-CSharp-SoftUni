using System;
using PetStore.Data;
using PetStore.Services.Implementations;

namespace PetStore
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using var data = new PetStoreDbContext();

            var brandService = new BrandService(data);

            //brandService.Create("Whiskas");

            var foodService=new FoodService(data);

            foodService.BuyFromDistributor("Cat food", 0.350, 2.5m, 0.2, DateTime.Today, 1,1);
        }
    }
}
