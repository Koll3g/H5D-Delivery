using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryOrderFactory;
using H5D_Delivery.Mgmt.Backend.Order.Domain;
using H5D_Delivery.Mgmt.Backend.Order.Domain.History;
using H5D_Delivery.Mgmt.Backend.Shared.IoC;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain
{
    public class DeliveryService
    {
        private readonly DeliveryOrderFactory.DeliveryOrderFactory _deliveryOrderFactory;
        private readonly OrderService _orderService;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly OrderHistoryService _orderHistoryService;

        public DeliveryService(DeliveryOrderFactory.DeliveryOrderFactory deliveryOrderFactory, IDeliveryRepository deliveryRepository, OrderService orderService, OrderHistoryService orderHistoryService)
        {
            _deliveryOrderFactory = deliveryOrderFactory;
            _deliveryRepository = deliveryRepository;
            _orderService = orderService;
            _orderHistoryService = orderHistoryService;
        }

        public void GenerateDeliveryOrder()
        {
            var orders = _orderService.GetAll()?.ToList();
            if (orders == null)
            {
                return;
            }

            var activeOrders = orders.Where(o => o.Status == OrderStatus.Active).ToList();
            if (activeOrders.Count == 0)
            {
                return;
            }

            var deliveryOrder = _deliveryOrderFactory.GenerateDeliveryOrder(activeOrders);

            foreach (var order in deliveryOrder.Orders)
            {
                _orderService.UpdateOrderStatus(order, OrderStatus.PlannedForDelivery);
            }

            _deliveryRepository.CreateWithContext(deliveryOrder);
        }

        public IEnumerable<DeliveryOrder>? GetAll()
        {
            return _deliveryRepository.GetAll();
        }

        public void Delete(Guid id)
        {
            _deliveryRepository.Delete(id);
        }
    }
}
