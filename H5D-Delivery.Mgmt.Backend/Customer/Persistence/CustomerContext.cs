using H5D_Delivery.Mgmt.Backend.Shared;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Customer.Persistence
{
    public sealed class CustomerContext : DbContextBase<Domain.Customer>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customer = modelBuilder.Entity<Domain.Customer>();
            customer.HasKey(x => x.Id);
            customer.Property(x => x.Name);
            customer.Property(x => x.Address);
            customer.Property(x => x.EMail);
            customer.Property(x => x.PhoneNumber);
            customer.ToTable("Customers");

            base.OnModelCreating(modelBuilder);
        }
    }
}
