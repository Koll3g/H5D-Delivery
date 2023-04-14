using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
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
            product.ToTable("Product");

            base.OnModelCreating(modelBuilder);
        }
    }
}
