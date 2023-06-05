using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Persistence
{
    public class DeliveryContext : DbContextBase<DeliveryOrder>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var deliveryOrder = modelBuilder.Entity<DeliveryOrder>();
            deliveryOrder.ToTable("DeliveryOrder");
            deliveryOrder.HasKey(x => x.Id);
            deliveryOrder.Property(x => x.AssignedRobotId);

            deliveryOrder.HasMany(x => x.Orders).WithOne().HasForeignKey(x => x.DeliveryOrderId);
            deliveryOrder.HasOne(x => x.DeliveryPlan).WithMany().HasForeignKey(x => x.Id);

            var plan = modelBuilder.Entity<DeliveryPlan>();
            plan.HasMany(x => x.DeliverySteps).WithOne().HasForeignKey(x => x.DeliveryPlanId);

            var step = modelBuilder.Entity<DeliveryStep>();
            step.OwnsOne(x => x.Coordinates);

            deliveryOrder.Navigation(x => x.DeliveryPlan).AutoInclude();
            deliveryOrder.Navigation(x => x.Orders).AutoInclude();
            plan.Navigation(x => x.DeliverySteps).AutoInclude();

            deliveryOrder.ToTable("DeliveryOrder");
            plan.ToTable("DeliveryPlan");
            step.ToTable("DeliveryStep");
        }
    }
}
