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
            DeliveryTimer.GenerateDeliveryTimes(DeliveryPlan);

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
            var deliveryStep = new DeliveryStep(new Guid())
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
                "Zbw-Strasse 1" => new Coordinates(500, 600),
                "Zbw-Strasse 2" => new Coordinates(1000, 600),
                "Zbw-Strasse 3" => new Coordinates(1500, 600),
                "Zbw-Strasse 4" => new Coordinates(2000, 0),
                _ => throw new AddressInvalidException("Address not found"),
            };
        }
    }
}
