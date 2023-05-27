using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Order.Domain.History;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Order.Persistence.History
{
    public class OrderHistoryRepository : RepositoryBase<OrderHistory>, IOrderHistoryRepository
    {
        public OrderHistoryRepository(OrderHistoryContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<OrderHistory>? GetAllForSpecificOrder(Guid orderId)
        {
            return _dbContext.DbSet?
                .Where(bc => bc.OrderId == orderId);
        }
    }
}
