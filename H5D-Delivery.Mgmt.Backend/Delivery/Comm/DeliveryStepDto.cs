using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Order.Domain;

namespace H5D_Delivery.Mgmt.Backend.Delivery.Comm
{
    public class DeliveryStepDto
    {
        public int id { get; set; }
        public string type { get; set; }
        public string authorizationKey { get; set; } = string.Empty;
        public string productId { get; set; } = string.Empty;
        public CoordinateDto coordinates { get; set; } = new CoordinateDto(new Coordinates(0, 0));

        public DeliveryStepDto(DeliveryStep deliveryStep)
        {
            id = deliveryStep.StepSequence;
            type = GetType(deliveryStep.DeliveryType);
            if (deliveryStep.AuthorizationKey != null) authorizationKey = deliveryStep.AuthorizationKey;
            if (deliveryStep.ProductId != null) productId = deliveryStep.ProductId.ToString() ?? string.Empty;
            if (deliveryStep.Coordinates != null)
                coordinates = new CoordinateDto(deliveryStep.Coordinates);
        }

        private static string GetType(DeliveryType? deliveryType)
        {
            return deliveryType switch
            {
                DeliveryType.Deposit => "deposit",
                DeliveryType.HandOver => "handOver",
                DeliveryType.Waypoint => "waypoint",
                DeliveryType.DistributionCenter => "distributionCenter",
                DeliveryType.ParkPosition => "parkPosition",
                _ => string.Empty,
            };
        }
    }
}
