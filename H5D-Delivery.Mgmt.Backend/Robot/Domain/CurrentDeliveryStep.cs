using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public class CurrentDeliveryStep
    {
        public Guid DeliveryId { get; set; }
        public int DeliveryStep { get; set; }

        public CurrentDeliveryStep(Guid deliveryId, int deliveryStep)
        {
            DeliveryId = deliveryId;
            DeliveryStep = deliveryStep;
        }
    }
}
