using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Persistence
{
    public class DeliveryRepository : RepositoryBase<DeliveryOrder>, IDeliveryRepository
    {
        public DeliveryRepository(DeliveryContext dbContext) : base(dbContext)
        {
        }
    }
}
