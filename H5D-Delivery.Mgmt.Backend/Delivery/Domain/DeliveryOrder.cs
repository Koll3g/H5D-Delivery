using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain
{
    public class DeliveryOrder : DbItem
    {
        public List<Order.Domain.Order> Orders { get; set; } = new List<Order.Domain.Order>();

        public Guid DeliveryPlanId { get; set; }
        public DeliveryPlan DeliveryPlan { get; set; } = new DeliveryPlan(Guid.Empty);

        public Guid? AssignedRobotId { get; set; }

        public DeliveryOrder(Guid id) : base(id)
        {

        }
    }
}
