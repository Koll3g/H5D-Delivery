using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Order.Domain.History
{
    public interface IOrderHistoryRepository : IRepositoryBase<OrderHistory>
    {
        public IEnumerable<OrderHistory>? GetAllForSpecificOrder(Guid orderId);
    }
}
