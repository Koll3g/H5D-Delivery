using H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryOrderFactory;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory
{
    public abstract class DeliveryPlanFactory
    {
        protected DeliveryPlan DeliveryPlan;

        protected IDeliveryTimer DeliveryTimer;
        protected IRouteOptimizer RouteOptimizer;
        protected IWaypointGenerator WaypointGenerator;

        protected DeliveryPlanFactory(IDeliveryTimer deliveryTimer, IRouteOptimizer routeOptimizer, IWaypointGenerator waypointGenerator)
        {
            DeliveryTimer = deliveryTimer;
            RouteOptimizer = routeOptimizer;
            WaypointGenerator = waypointGenerator;

            DeliveryPlan = new DeliveryPlan(Guid.NewGuid());
        }

        public virtual DeliveryPlan CreateDeliveryPlan(List<Order.Domain.Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
