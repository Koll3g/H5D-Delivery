using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain
{
    public class DeliveryOrder : DbItem
    {
        public List<Order.Domain.Order> Orders { get; set; } = new List<Order.Domain.Order>();

        public DeliveryPlan DeliveryPlan { get; set; } = new DeliveryPlan(Guid.Empty);

        public DeliveryOrder(Guid id) : base(id)
        {

        }
    }
}
