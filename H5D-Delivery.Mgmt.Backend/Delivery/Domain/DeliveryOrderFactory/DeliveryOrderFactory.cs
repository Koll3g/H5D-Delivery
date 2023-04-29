using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryOrderFactory
{
    public abstract class DeliveryOrderFactory
    {
        protected List<Order.Domain.Order> Orders = new List<Order.Domain.Order>();
        protected readonly DeliveryPlanFactory.DeliveryPlanFactory DeliveryPlanFactory;
        protected readonly IOrderPrioritizer OrderPrioritizer;
        protected DeliveryOrder? DeliveryOrder;

        protected DeliveryOrderFactory(DeliveryPlanFactory.DeliveryPlanFactory deliveryPlanFactory, IOrderPrioritizer orderPrioritizer)
        {
            DeliveryPlanFactory = deliveryPlanFactory;
            OrderPrioritizer = orderPrioritizer;
        }

        public abstract DeliveryOrder GenerateDeliveryOrder(IEnumerable<Order.Domain.Order> orders);
    }
}
