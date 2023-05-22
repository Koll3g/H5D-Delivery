using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Robot.Persistence.Battery
{
    public class BatteryChargeContext : DbContextBase<BatteryCharge>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var product = modelBuilder.Entity<BatteryCharge>();
            product.HasKey(x => x.Id);
            product.Property(x => x.RobotId);
            product.Property(x => x.DateTime);
            product.Property(x => x.BatteryChargePct);
            product.ToTable("BatteryCharge");

            base.OnModelCreating(modelBuilder);
        }
    }
}
