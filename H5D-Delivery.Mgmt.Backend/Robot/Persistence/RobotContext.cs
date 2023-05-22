using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Robot.Persistence
{
    public class RobotContext : DbContextBase<Domain.Robot>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var item = modelBuilder.Entity<Domain.Robot>();
            item.HasKey(x => x.Id);
            item.Property(x => x.LastContact);
            item.Property(x => x.CurrentDeliveryId);
            item.Property(x => x.Name);
            item.ToTable("Robot");

            base.OnModelCreating(modelBuilder);
        }
    }
}
