using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Order.Domain
{
    public enum OrderStatus
    {
        Active = 0,
        PlannedForDelivery = 1,
        BeingDelivered = 2,
        Delivered = 3,
        FailedToDeliver = 4,
        Canceled = 5,
    }
}
