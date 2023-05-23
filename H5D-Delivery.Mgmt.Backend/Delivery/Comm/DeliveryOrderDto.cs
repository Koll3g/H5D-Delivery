using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Product.Domain;
using H5D_Delivery.Mgmt.Backend.Stock.Domain;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Comm
{
    public class DeliveryOrderDto
    {
        public Guid deliveryId { get; set; }
        public List<ProductDto> productsToPickUp { get; set; } = new List<ProductDto>();
        public List<DeliveryStepDto> deliverySteps { get; set; } = new List<DeliveryStepDto>();

        public DeliveryOrderDto(DeliveryOrder deliveryOrder, List<StockItem> stockItems)
        {
            deliveryId = deliveryOrder.Id;

            if (deliveryOrder.Orders != null)
            {
                ExtractProductsToPickup(deliveryOrder.Orders, stockItems);
            }

            if (deliveryOrder.DeliveryPlan?.DeliverySteps != null)
            {
                ExtractDeliverySteps(deliveryOrder.DeliveryPlan.DeliverySteps);
            }
        }

        private void ExtractProductsToPickup(List<Order.Domain.Order> orders, List<StockItem> stockItems)
        {
            foreach (var order in orders)
            {
                var stockItem = stockItems.First(item => item.ProductId == order.ProductId);
                var productDto = new ProductDto()
                {
                    productId = order.ProductId,
                    quantity = order.Amount,
                    storageLocation = (int)stockItem.StorageLocation,
                };
                productsToPickUp.Add(productDto);
            }
        }

        private void ExtractDeliverySteps(List<DeliveryStep> deliverySteps)
        {
            foreach (var step in deliverySteps)
            {
                var convertedStep = new DeliveryStepDto(step);
                this.deliverySteps.Add(convertedStep);
            }
        }

    }
}
