using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Order.Domain;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory
{
    public class WaypointGeneratorZbw : IWaypointGenerator
    {
        private List<DeliveryStep> _deliverySteps = new List<DeliveryStep>();
        private DeliveryPlan _deliveryPlan = new DeliveryPlan(Guid.Empty);

        public void GenerateWaypoints(DeliveryPlan deliveryPlan)
        {
            _deliverySteps.Clear();
            _deliveryPlan = deliveryPlan;

            AddStepsFromParkingPositionToDistributionCenter();

            foreach (DeliveryStep step in deliveryPlan.DeliverySteps)
            {
                AddWaypointsBeforeAndAfter(step);
            }

            NumberDeliverySteps();

            deliveryPlan.DeliverySteps = new List<DeliveryStep>(_deliverySteps);
            _deliverySteps.Clear();
        }

        private void NumberDeliverySteps()
        {
            var counter = 1;
            foreach (DeliveryStep step in _deliverySteps)
            {
                step.StepSequence = counter++;
            }
        }

        private void AddStepsFromParkingPositionToDistributionCenter()
        {
            AddDeliveryStep(WaypointCoordinates.Parkposition, DeliveryType.ParkPosition);
            AddDeliveryStep(WaypointCoordinates.WaypointParkposition, DeliveryType.Waypoint);
            AddDeliveryStep(WaypointCoordinates.WaypointStrasse1AndDistributionCenter, DeliveryType.Waypoint);
            AddDeliveryStep(WaypointCoordinates.DistributionCenter, DeliveryType.DistributionCenter);
        }

        private void AddWaypointsBeforeAndAfter(DeliveryStep step)
        {
            var coordinates = step.Coordinates;
            if (coordinates == WaypointCoordinates.ZbwStrasse1)
            {
                AddDeliveryStep(WaypointCoordinates.WaypointStrasse1AndDistributionCenter, DeliveryType.Waypoint);
                AddDeliveryStep(step);
                AddDeliveryStep(WaypointCoordinates.WaypointStrasse1AndDistributionCenter, DeliveryType.Waypoint);
            }
            else if (coordinates == WaypointCoordinates.ZbwStrasse2)
            {
                AddDeliveryStep(WaypointCoordinates.WaypointStrasse2, DeliveryType.Waypoint);
                AddDeliveryStep(step);
                AddDeliveryStep(WaypointCoordinates.WaypointStrasse2, DeliveryType.Waypoint);
            }
            else if (coordinates == WaypointCoordinates.ZbwStrasse3 || coordinates == WaypointCoordinates.ZbwStrasse4)
            {
                AddDeliveryStep(WaypointCoordinates.WaypointStrasse3And4, DeliveryType.Waypoint);
                AddDeliveryStep(step);
                AddDeliveryStep(WaypointCoordinates.WaypointStrasse3And4, DeliveryType.Waypoint);
            }
        }

        private void AddDeliveryStep(DeliveryStep step)
        {
            _deliverySteps.Add(step);
        }

        private void AddDeliveryStep(Coordinates coordinates, DeliveryType deliveryType)
        {
            if (_deliverySteps.Count > 0)
            {
                var previousStep = _deliverySteps.Last();
                if (previousStep.Coordinates == coordinates)
                {
                    return;
                }
            }

            _deliverySteps.Add(new DeliveryStep(Guid.NewGuid())
            {
                Coordinates = coordinates,
                DeliveryType = deliveryType,
                DeliveryPlanId = _deliveryPlan.Id,
            });
        }

    }
}
