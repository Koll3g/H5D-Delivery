using H5D_Delivery.Mgmt.Backend.Order.Domain;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryOrderFactory
{
    public class OrderPrioritizerRobotInvoked : IOrderPrioritizer
    {
        private const int StoragePerRobot = 4;

        public IEnumerable<Order.Domain.Order> PrioritizeOrders(IEnumerable<Order.Domain.Order> orders)
        {
            var top4ActiveOrders = orders
                .Where(o => o.Status == OrderStatus.Active)
                .OrderBy(o => o.LatestDeliveryTime)
                .ThenBy(o => o.Priority)
                .Take(StoragePerRobot);
            return top4ActiveOrders;
        }
    }
}
