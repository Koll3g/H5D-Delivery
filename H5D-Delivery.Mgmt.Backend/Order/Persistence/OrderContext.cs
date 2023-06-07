using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Order.Persistence
{
    public sealed class OrderContext : DbContextBase<Domain.Order>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var order = modelBuilder.Entity<Domain.Order>();
            order.HasKey(x => x.Id);
            order.Property(x => x.Amount);
            order.Property(x => x.DeliveryType);
            order.Property(x => x.EarliestDeliveryTime);
            order.Property(x => x.LatestDeliveryTime);
            order.Property(x => x.Priority);
            order.Property(x => x.Status);

            order.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId);
            order.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId);

            order.Navigation(x => x.Product).AutoInclude();
            order.Navigation(x => x.Customer).AutoInclude();

            var step = modelBuilder.Entity<DeliveryStep>();
            step.OwnsOne(x => x.Coordinates);

            order.ToTable("Order");

            base.OnModelCreating(modelBuilder);

            //var deliveryOrder = modelBuilder.Entity<DeliveryOrder>();
            //deliveryOrder.HasKey(x => x.Id);
            //deliveryOrder.Property(x => x.AssignedRobotId);

            //deliveryOrder.HasMany(x => x.Orders).WithOne().HasForeignKey(x => x.DeliveryOrderId);
            //deliveryOrder.HasOne(x => x.DeliveryPlan).WithMany().HasForeignKey(x => x.Id);

            //var plan = modelBuilder.Entity<DeliveryPlan>();
            //plan.HasMany(x => x.DeliverySteps).WithOne().HasForeignKey(x => x.DeliveryPlanId);

            //deliveryOrder.Navigation(x => x.DeliveryPlan).AutoInclude();
            //deliveryOrder.Navigation(x => x.Orders).AutoInclude();
            //plan.Navigation(x => x.DeliverySteps).AutoInclude();

            //deliveryOrder.ToTable("DeliveryOrder");
            //plan.ToTable("DeliveryPlan");
            //step.ToTable("DeliveryStep");
        }
    }
}
