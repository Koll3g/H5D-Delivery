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
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryService(DeliveryOrderFactory.DeliveryOrderFactory deliveryOrderFactory, IDeliveryRepository deliveryRepository, IOrderRepository orderRepository)
        {
            _deliveryOrderFactory = deliveryOrderFactory;
            _deliveryRepository = deliveryRepository;
            _orderRepository = orderRepository;
        }

        public void GenerateDeliveryOrder()
        {
            var orders = _orderRepository.GetAll();
            if (orders == null)
            {
                return;
            }

            var deliveryOrder = _deliveryOrderFactory.GenerateDeliveryOrder(orders);
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
