using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Models;

namespace PetStore.Data.Configuration
{
  public  class BrandConfiguration:IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> brand)
        {
                brand
                    .HasMany(b => b.Food)
                    .WithOne(f => f.Brand)
                    .HasForeignKey(f => f.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);

                brand
                    .HasMany(b => b.Toys)
                    .WithOne(t => t.Brand)
                    .HasForeignKey(t => t.BrandId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
