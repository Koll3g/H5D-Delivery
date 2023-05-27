using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Order.Domain;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain
{
    public class DeliveryStep : DbItem
    {
        public int StepSequence { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string AuthorizationKey { get; set; } = string.Empty;
        public Guid? ProductId { get; set; }
        public Coordinates Coordinates { get; set; } = Coordinates.Empty;

        public DeliveryStep(Guid id) : base(id)
        {

        }
    }
}
