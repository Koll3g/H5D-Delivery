using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Order.Domain.History;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Order.Persistence.History
{
    public class OrderHistoryContext : DbContextBase<OrderHistory>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var item = modelBuilder.Entity<OrderHistory>();
            item.HasKey(x => x.Id);
            item.Property(x => x.DateTime);
            item.Property(x => x.Status);

            item.ToTable("OrderHistory");

            base.OnModelCreating(modelBuilder);
        }
    }
}
