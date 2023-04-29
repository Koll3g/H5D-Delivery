using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryPlanFactory
{
    public class DeliveryTimerZbw : IDeliveryTimer
    {
        public void GenerateDeliveryTimes(DeliveryPlan deliveryPlan)
        {
            //ToDo: Based on plan, estimate times for start and for each deliveryStep
        }
    }
}
