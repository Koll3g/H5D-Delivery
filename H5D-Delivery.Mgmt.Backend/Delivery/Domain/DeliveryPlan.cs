using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain
{
    public class DeliveryPlan : DbItem
    {
        public List<DeliveryStep> DeliverySteps { get; set; }

        public DeliveryPlan(Guid id) : base(id)
        {
            DeliverySteps = new List<DeliveryStep>();
        }
    }
}
