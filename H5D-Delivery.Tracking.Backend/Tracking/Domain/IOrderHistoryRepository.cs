using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Tracking.Backend.Tracking.Domain
{
    public interface IOrderHistoryRepository
    {
        public List<OrderHistory>? GetAllForOrderId(Guid orderId);
        public bool? IsAuthorized(string customerName, Guid orderId);
    }
}
