using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Models;

namespace PetStore.Data.Configuration
{
   public class FoodOrderConfiguration:IEntityTypeConfiguration<FoodOrder>
    {
        public void Configure(EntityTypeBuilder<FoodOrder> foodOrder)
        {
            foodOrder
                .HasKey(of => new {of.FoodId, of.OrderId});

            foodOrder
                .HasOne(fo => fo.Food)
                .WithMany(f => f.Orders)
                .HasForeignKey(fo => fo.FoodId)
                .OnDelete(DeleteBehavior.Restrict);

            foodOrder
                .HasOne(fo => fo.Order)
                .WithMany(o => o.Food)
                .HasForeignKey(fo => fo.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
