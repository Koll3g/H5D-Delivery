using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Stock.Persistence
{
    public sealed class StockContext : DbContextBase<Domain.StockItem>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var stockItem = modelBuilder.Entity<Domain.StockItem>();
            stockItem.HasKey(x => x.Id);
            stockItem.Property(x => x.StorageLocation);
            stockItem.Property(x => x.Amount);
            stockItem.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            stockItem.Navigation(x => x.Product).AutoInclude();
            stockItem.ToTable("StockItem");

            base.OnModelCreating(modelBuilder);
        }
    }
}
