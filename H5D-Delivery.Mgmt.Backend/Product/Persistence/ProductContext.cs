using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Product.Persistence
{
    public sealed class ProductContext : DbContextBase<Domain.Product>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var product = modelBuilder.Entity<Domain.Product>();
            product.HasKey(x => x.Id);
            product.Property(x => x.Name);


            base.OnModelCreating(modelBuilder);
        }
    }
}
