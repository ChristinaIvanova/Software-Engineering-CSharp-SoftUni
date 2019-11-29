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

            var brandService=new BrandService()
        }
    }
}
