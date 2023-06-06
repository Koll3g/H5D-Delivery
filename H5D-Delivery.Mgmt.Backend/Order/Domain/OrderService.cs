using H5D_Delivery.Mgmt.Backend.Order.Domain.History;
using H5D_Delivery.Mgmt.Backend.Order.Exceptions;

namespace H5D_Delivery.Mgmt.Backend.Order.Domain
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderHistoryService _orderHistoryService;

        public OrderService(IOrderRepository orderRepository, OrderHistoryService orderHistoryService)
        {
            _orderRepository = orderRepository;
            _orderHistoryService = orderHistoryService;
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
            if (!IsOrderValid(order))
            {
                return;
            }
            _orderRepository.Update(order);
            try
            {
                _orderHistoryService.Create(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Delete(Guid id)
        {
            _orderRepository.Delete(id);
        }

        public void UpdateOrderStatus(Guid orderId, OrderStatus orderStatus)
        {
            try
            {
                var order = Get(orderId);
                if (order != null)
                {
                    order.Status = orderStatus;
                    Update(order);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void AddDeliveryId(Guid orderId, Guid deliveryOrderId)
        {
            try
            {
                var order = Get(orderId);
                if (order != null)
                {
                    order.DeliveryOrderId = deliveryOrderId;
                    Update(order);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Order>? GetAllOrdersForDeliveryId(Guid deliveryOrderId)
        {
            try
            {
                var orders = _orderRepository.GetAll()?
                    .Where(o => o.DeliveryOrderId == deliveryOrderId)
                    .ToList();

                return orders;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void Create(Order order)
        {
            if (!IsOrderValid(order))
            {
                return;
            }
            _orderRepository.Create(order);

            try
            {
                _orderHistoryService.Create(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static bool IsOrderValid(Order order)
        {
            if (!IsTimeFrameValid(order))
            {
                string errorMessage = "Earliest and latest delivery time must be at least 15 minutes apart!";
                throw new TimeFrameInvalidException(errorMessage);
            }
            else if (!IsAmountValid(order))
            {
                string errorMessage = "Amount must be 1.";
                throw new AmountInvalidException(errorMessage);
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
