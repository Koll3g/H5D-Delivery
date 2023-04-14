using H5D_Delivery.Mgmt.Backend.Order.Exceptions;

namespace H5D_Delivery.Mgmt.Backend.Order.Domain
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order>? GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order? Get(Guid id)
        {
            return _orderRepository.Get(id);
        }

        public void Update(Order order)
        {
            _orderRepository.Update(order);
        }

        public void Delete(Guid id)
        {
            _orderRepository.Delete(id);
        }

        public void Create(Order order)
        {
            if (!IsOrderValid(order))
            {
                return;
            }
            _orderRepository.Create(order);
        }

        private static bool IsOrderValid(Order order)
        {
            if (!IsTimeFrameValid(order))
            {
                throw new TimeFrameInvalidException("Earliest and latest delivery time must be at least 15 minutes apart!");
            }
            else if (!IsAmountValid(order))
            {
                throw new AmountInvalidException("Amount must be 1");
            }

            return true;
        }

        private static bool IsTimeFrameValid(Order order)
        {
            TimeSpan timeSpan = order.LatestDeliveryTime - order.EarliestDeliveryTime;

            if (timeSpan.TotalMinutes >= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsAmountValid(Order order)
        {
            if (order.Amount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
