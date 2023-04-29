using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain.DeliveryOrderFactory;
using H5D_Delivery.Mgmt.Backend.Order.Domain;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Domain
{
    public class DeliveryService
    {
        private readonly DeliveryOrderFactory.DeliveryOrderFactory _deliveryOrderFactory;
        private readonly IOrderRepository _orderRepository;

        public DeliveryService(DeliveryOrderFactory.DeliveryOrderFactory deliveryOrderFactory, IOrderRepository orderRepository)
        {
            _deliveryOrderFactory = deliveryOrderFactory;
            _orderRepository = orderRepository;
        }

        public void GenerateDeliveryOrder()
        {
            var orders = _orderRepository.GetAll();

            var deliveryOrder = _deliveryOrderFactory.GenerateDeliveryOrder(orders);
            var test = deliveryOrder;
        }
    }
}
