using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace H5D_Delivery.Mgmt.Backend.Robot.Persistence.Error
{
    public class ErrorMessageContext : DbContextBase<ErrorMessage>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var item = modelBuilder.Entity<ErrorMessage>();
            item.HasKey(x => x.Id);
            item.Property(x => x.ErrorType);
            item.Property(x => x.DeliveryStep);
            item.Property(x => x.DeliveryId);
            item.Property(x => x.RobotId);
            item.Property(x => x.DateTime);
            item.ToTable("ErrorMessage");

            base.OnModelCreating(modelBuilder);
        }
    }
}
