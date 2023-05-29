using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Order.Domain;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory
{
    public class DeliveryTimerZbw : IDeliveryTimer
    {
        private readonly int _robotSpeed = 50; // mm/s
        private readonly TimeSpan _timeToHandover = new TimeSpan(0, 0, 60);
        private readonly TimeSpan _timeToDeposit = new TimeSpan(0, 0, 60);
        private readonly TimeSpan _timeToPickupProducts = new TimeSpan(0, 2, 0);
        private readonly TimeSpan _buffer = new TimeSpan(0, 2, 0);
        
        private List<DeliveryStep> _deliverySteps = new List<DeliveryStep>();
        private List<Order.Domain.Order> _orders = new List<Order.Domain.Order>();

        public void GenerateDeliveryTimes(DeliveryPlan deliveryPlan, List<Order.Domain.Order> orders)
        {
            _deliverySteps = deliveryPlan.DeliverySteps;
            _orders = orders;
            
            FindFirstDeliveryAndDefinePreviousStepTimes();

            //check if start is not in the past
            if (_deliverySteps[0].PlannedDeliveryTime < DateTime.Now)
            {
                DefineStepTimesStartingNow();
            }
            else
            {
                DefineStepTimesFromFirstDelivery();
            }
        }

        private void DefineStepTimesStartingNow()
        {
            //Define start 30 sec in the future
            _deliverySteps[0].PlannedDeliveryTime = DateTime.Now + new TimeSpan(0,0,30);
            CalculateStepTimes(1);
        }

        private void DefineStepTimesFromFirstDelivery()
        {
            var firstDeliveryIndex = _deliverySteps.FindIndex(x => x.ProductId != null);
            CalculateStepTimes(firstDeliveryIndex + 1);
        }

        private void CalculateStepTimes(int startingIndex)
        {
            //Go through all steps and add times
            for (int i = startingIndex; i < _deliverySteps.Count; i++)
            {
                var currentDeliveryStep = _deliverySteps[i];
                var lastDeliveryStep = _deliverySteps[i - 1];

                //travel time
                var distance = Coordinates.CalculateDistance(currentDeliveryStep.Coordinates,
                    lastDeliveryStep.Coordinates);
                var timeToTravel = new TimeSpan(0, 0, distance / _robotSpeed);
                currentDeliveryStep.PlannedDeliveryTime = lastDeliveryStep.PlannedDeliveryTime + timeToTravel;

                //Add times (if necessary) for other actions
                if (currentDeliveryStep.DeliveryType == DeliveryType.Deposit)
                {
                    currentDeliveryStep.PlannedDeliveryTime += _timeToDeposit;
                    CheckAgainstEarliestDeliveryTime(currentDeliveryStep);
                }
                else if (currentDeliveryStep.DeliveryType == DeliveryType.HandOver)
                {
                    currentDeliveryStep.PlannedDeliveryTime += _timeToHandover;
                    CheckAgainstEarliestDeliveryTime(currentDeliveryStep);
                }
                else if (currentDeliveryStep.DeliveryType == DeliveryType.DistributionCenter)
                {
                    currentDeliveryStep.PlannedDeliveryTime += _timeToPickupProducts;
                }
            }
        }



        private void CheckAgainstEarliestDeliveryTime(DeliveryStep currentDeliveryStep)
        {
            var order = _orders.Find(x => x.ProductId == currentDeliveryStep.ProductId);
            if (currentDeliveryStep.PlannedDeliveryTime < order!.EarliestDeliveryTime)
            {
                currentDeliveryStep.PlannedDeliveryTime = order!.EarliestDeliveryTime + _buffer;
            }
        }

        private void FindFirstDeliveryAndDefinePreviousStepTimes()
        {
            //Find first delivery, set time
            var firstDeliveryIndex = _deliverySteps.FindIndex(x => x.ProductId != null);
            var firstOrder = _orders.Find(x => x.ProductId == _deliverySteps[firstDeliveryIndex].ProductId);
            _deliverySteps[firstDeliveryIndex].PlannedDeliveryTime = firstOrder!.EarliestDeliveryTime + _buffer;

            //Go through all previous steps and define times
            for (int i = firstDeliveryIndex - 1; i >= 0; i--)
            {
                var currentDeliveryStep = _deliverySteps[i];
                var nextDeliveryStep = _deliverySteps[i + 1];
                
                //Calculate travel time based on previous step
                var distance = Coordinates.CalculateDistance(currentDeliveryStep.Coordinates,
                    nextDeliveryStep.Coordinates);
                var timeToTravel = new TimeSpan(0, 0, distance / _robotSpeed);
                currentDeliveryStep.PlannedDeliveryTime = nextDeliveryStep.PlannedDeliveryTime - timeToTravel;

                //Add times (if necessary) for other actions
                if (nextDeliveryStep.DeliveryType == DeliveryType.Deposit)
                {
                    currentDeliveryStep.PlannedDeliveryTime -= _timeToDeposit;
                }
                else if (nextDeliveryStep.DeliveryType == DeliveryType.HandOver)
                {
                    currentDeliveryStep.PlannedDeliveryTime -= _timeToHandover;
                }
                else if (nextDeliveryStep.DeliveryType == DeliveryType.DistributionCenter)
                {
                    currentDeliveryStep.PlannedDeliveryTime -= _timeToPickupProducts;
                }
            }
        }
    }
}
