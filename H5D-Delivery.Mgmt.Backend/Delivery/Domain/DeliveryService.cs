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

        public DeliveryOrder? GenerateDeliveryOrder()
        {
            var orders = _orderService.GetAll()?.ToList();
            if (orders == null)
            {
                return null;
            }

            var activeOrders = orders.Where(o => o.Status == OrderStatus.Active).ToList();
            if (activeOrders.Count == 0)
            {
                return null;
            }

            var deliveryOrder = _deliveryOrderFactory.GenerateDeliveryOrder(activeOrders);

            foreach (var order in deliveryOrder.Orders)
            {
                order.DeliveryOrderId = deliveryOrder.Id;
                order.Status = OrderStatus.PlannedForDelivery;
            }

            _deliveryRepository.Create(deliveryOrder);

            foreach (var order in deliveryOrder.Orders)
            {
                _orderService.AddDeliveryId(order.Id, deliveryOrder.Id);
                _orderService.UpdateOrderStatus(order.Id, OrderStatus.PlannedForDelivery);
            }

            return deliveryOrder;
        }

        public void Update(DeliveryOrder deliveryOrder)
        {
            _deliveryRepository.Update(deliveryOrder);
        }

        public DeliveryOrder? Get(Guid id)
        {
            var deliveryOrder = _deliveryRepository.Get(id);
            try
            {
                deliveryOrder.Orders = _orderService.GetAllOrdersForDeliveryId(deliveryOrder.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return deliveryOrder;
        }

        public IEnumerable<DeliveryOrder>? GetAll()
        {
            var deliveryOrders = _deliveryRepository.GetAll();
            if (deliveryOrders != null)
            {
                foreach (var deliveryOrder in deliveryOrders)
                {
                    try
                    {
                        deliveryOrder.Orders = _orderService.GetAllOrdersForDeliveryId(deliveryOrder.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return deliveryOrders;
        }

        public void Delete(Guid id)
        {
            _deliveryRepository.Delete(id);
        }
    }
}
