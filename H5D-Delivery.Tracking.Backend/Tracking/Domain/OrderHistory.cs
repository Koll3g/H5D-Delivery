using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Tracking.Backend.Shared.Persistence;

namespace H5D_Delivery.Tracking.Backend.Tracking.Domain
{
    public class OrderHistory : DbItem
    {
        public DateTime DateTime { get; set; }
        public OrderStatus Status { get; set; }

        public OrderHistory(Guid id) : base(id)
        {
        }


    }
}
