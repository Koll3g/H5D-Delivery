using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Tracking.Backend.Tracking.Domain;

namespace H5D_Delivery.Tracking.Backend.Tracking.Persistence
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly OrderHistoryContext _orderHistoryContext;

        public OrderHistoryRepository(OrderHistoryContext orderHistoryContext)
        {
            _orderHistoryContext = orderHistoryContext;
        }

        public List<OrderHistory>? GetAllForOrderId(Guid orderId)
        {
            var allOrderHistories = _orderHistoryContext.OrderHistory?.ToList();
            var filteredOrderHistory = allOrderHistories?.Where(x => x.OrderId == orderId).ToList();
            return filteredOrderHistory;
        }

        public bool? IsAuthorized(string customerName, Guid orderId)
        {
            var test = _orderHistoryContext.OrderHistory?.ToList();
            return _orderHistoryContext.OrderHistory?.Any(x => x.CustomerName == customerName && x.OrderId == orderId);
        }
    }
}
