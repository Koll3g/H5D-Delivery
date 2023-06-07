using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryOrderFactory
{
    public class DeliveryOrderFactoryZbw : DeliveryOrderFactory
    {
        public DeliveryOrderFactoryZbw(DeliveryPlanFactory.DeliveryPlanFactory deliveryPlanFactory, IOrderPrioritizer orderPrioritizer) : base(deliveryPlanFactory, orderPrioritizer) { }

        public override DeliveryOrder GenerateDeliveryOrder(IEnumerable<Order.Domain.Order> orders)
        {
            DeliveryOrder = new DeliveryOrder(Guid.NewGuid());

            var topOrders = OrderPrioritizer.PrioritizeOrders(orders);
            DeliveryOrder.Orders = topOrders.ToList();

            var deliveryPlan = DeliveryPlanFactory.CreateDeliveryPlan(DeliveryOrder.Orders);
            DeliveryOrder.DeliveryPlan = deliveryPlan;
            DeliveryOrder.DeliveryPlanId = deliveryPlan.Id;

            return DeliveryOrder;
        }
    }
}
