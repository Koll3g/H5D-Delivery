namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryOrderFactory
{
    public interface IOrderPrioritizer
    {
        public IEnumerable<Order.Domain.Order> PrioritizeOrders(IEnumerable<Order.Domain.Order> orders);
    }
}
