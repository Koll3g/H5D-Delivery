using H5D_Delivery.Mgmt.Backend.Customer.Exceptions;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryOrderFactory;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory
{
    public class DeliveryPlanFactoryZbw : DeliveryPlanFactory
    {
        public DeliveryPlanFactoryZbw(IDeliveryTimer deliveryTimer, IRouteOptimizer routeOptimizer, IWaypointGenerator waypointGenerator) : base(deliveryTimer, routeOptimizer, waypointGenerator) { }

        public override DeliveryPlan CreateDeliveryPlan(List<Order.Domain.Order> orders)
        {
            GenerateDeliverySteps(orders);
            
            RouteOptimizer.OptimizeRoute(DeliveryPlan);
            WaypointGenerator.GenerateWaypoints(DeliveryPlan);
            DeliveryTimer.GenerateDeliveryTimes(DeliveryPlan, orders);

            //ToDo: number all deliverySteps

            return DeliveryPlan;
        }

        private void GenerateDeliverySteps(List<Order.Domain.Order> orders)
        {
            foreach (var order in orders)
            {
                var deliveryStep = GenerateDeliveryStep(order);
                DeliveryPlan.DeliverySteps.Add(deliveryStep);
            }
        }

        private DeliveryStep GenerateDeliveryStep(Order.Domain.Order order)
        {
            var deliveryStep = new DeliveryStep(Guid.NewGuid())
            {
                DeliveryType = order.DeliveryType,
                ProductId = order.ProductId,
                Coordinates = GetCoordinatesFromAddress(order.Customer.Address)
            };
            return deliveryStep;
        }
        
        private Coordinates GetCoordinatesFromAddress(string address)
        {
            return address switch
            {
                "Zbw-Strasse 1" => WaypointCoordinates.ZbwStrasse1,
                "Zbw-Strasse 2" => WaypointCoordinates.ZbwStrasse2,
                "Zbw-Strasse 3" => WaypointCoordinates.ZbwStrasse3,
                "Zbw-Strasse 4" => WaypointCoordinates.ZbwStrasse4,
                _ => WaypointCoordinates.Empty
            };
        }
    }
}
