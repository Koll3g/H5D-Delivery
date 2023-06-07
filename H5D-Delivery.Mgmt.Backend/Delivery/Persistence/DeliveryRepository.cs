using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using Microsoft.Identity.Client;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Persistence
{
    public class DeliveryRepository : RepositoryBase<DeliveryOrder>, IDeliveryRepository
    {
        public DeliveryRepository(DeliveryContext dbContext) : base(dbContext)
        {
        }

        public void CreateWithContext(DeliveryOrder deliveryOrder)
        {
            foreach (var existingOrder in deliveryOrder.Orders)
            {
                _dbContext.Attach(existingOrder);
            }
            Create(deliveryOrder);
        }
    }
}
