namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory
{
    public interface IDeliveryTimer
    {
        public void GenerateDeliveryTimes(DeliveryPlan deliveryPlan, List<Order.Domain.Order> orders);
    }
}
