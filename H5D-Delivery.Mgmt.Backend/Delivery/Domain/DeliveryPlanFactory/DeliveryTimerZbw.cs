using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory
{
    public class DeliveryTimerZbw : IDeliveryTimer
    {
        private readonly int _robotSpeed = 50; // mm/s
        private readonly TimeSpan _timeToHandover = new TimeSpan(0, 0, 60);
        private readonly TimeSpan _timeToDeposit = new TimeSpan(0, 0, 60);
        private readonly TimeSpan _timeToPickupProducts = new TimeSpan(0, 2, 0);
        
        private List<DeliveryStep> _deliverySteps = new List<DeliveryStep>();
        public void GenerateDeliveryTimes(DeliveryPlan deliveryPlan, List<Order.Domain.Order> orders)
        {
            _deliverySteps = deliveryPlan.DeliverySteps;
            
            //first delivery, get earliest time

            
            //do pickup timing
            //proceed making timings until next delivery
            //if earlier than earliest delivery time, move that to earliest
            //continue as before
        }

        private void FindFirstDeliveryAndDefinePreviousStepTimes(List<Order.Domain.Order> orders)
        {
            var firstDeliveryIndex = _deliverySteps.FindIndex(x => x.ProductId != null);
            var firstOrder = orders.Find(x => x.ProductId == _deliverySteps[firstDeliveryIndex].ProductId);
            _deliverySteps[firstDeliveryIndex].PlannedDeliveryTime = firstOrder!.EarliestDeliveryTime;
        }
    }
}
