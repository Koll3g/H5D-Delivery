using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public class CurrentDeliveryStepDto
    {
        public Guid deliveryId { get; set; }
        public int deliveryStep { get; set; }

        public CurrentDeliveryStepDto(Guid deliveryId, int deliveryStep)
        {
            this.deliveryId = deliveryId;
            this.deliveryStep = deliveryStep;
        }

        public CurrentDeliveryStep ConvertToCurrentDeliveryStep()
        {
            return new CurrentDeliveryStep(this.deliveryId, this.deliveryStep);
        }
    }
}
