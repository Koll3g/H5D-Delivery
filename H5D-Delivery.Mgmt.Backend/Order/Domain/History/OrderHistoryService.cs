using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Order.Domain.History
{
    public class OrderHistoryService
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;

        public OrderHistoryService(IOrderHistoryRepository orderHistoryRepository)
        {
            _orderHistoryRepository = orderHistoryRepository;
        }

        public IEnumerable<OrderHistory>? GetAll()
        {
            return _orderHistoryRepository.GetAll();
        }

        public IEnumerable<OrderHistory>? GetAllForSpecificOrder(Guid orderId)
        {
            return _orderHistoryRepository.GetAllForSpecificOrder(orderId);
        }

        public OrderHistory? Get(Guid id)
        {
            return _orderHistoryRepository.Get(id);
        }
        
        public void Delete(Guid id)
        {
            _orderHistoryRepository.Delete(id);
        }

        public void Create(OrderHistory orderHistory)
        {
            _orderHistoryRepository.Create(orderHistory);
        }

        public void Create(Order order)
        {
            var orderHistory = new OrderHistory(Guid.NewGuid())
            {
                DateTime = DateTime.Now,
                OrderId = order.Id,
                Status = order.Status,
            };
            Create(orderHistory);
        }
    }
}
