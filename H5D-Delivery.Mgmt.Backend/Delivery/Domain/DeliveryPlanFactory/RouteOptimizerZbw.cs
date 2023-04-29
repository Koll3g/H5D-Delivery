using H5D_Delivery.Mgmt.Backend.Customer.Exceptions;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory
{
    public class RouteOptimizerZbw : IRouteOptimizer
    {
        public void OptimizeRoute(DeliveryPlan deliveryPlan)
        {
            OptimizeForDistance(deliveryPlan);

            //ToDo: What to do when timing does not allow for distance optimized route? 
        }

        private void OptimizeForDistance(DeliveryPlan deliveryPlan)
        {
            deliveryPlan.DeliverySteps = new List<DeliveryStep>(deliveryPlan.DeliverySteps.OrderByDescending(s => s.Coordinates?.X));
        }
    }
}
