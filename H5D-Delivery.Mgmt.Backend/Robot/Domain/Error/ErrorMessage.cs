using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using Newtonsoft.Json;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain.Error
{
    public class ErrorMessage : DbItem
    {
        public Guid DeliveryId { get; set; }
        public int DeliveryStep { get; set; }
        public ErrorType ErrorType { get; set; }
        public DateTime DateTime { get; set; }
        public Guid RobotId { get; set; }

        public ErrorMessage(Guid id, Guid deliveryId, int deliveryStep, ErrorType errorType, DateTime dateTime, Guid robotId) : base(id)
        {
            DeliveryId = deliveryId;
            DeliveryStep = deliveryStep;
            ErrorType = errorType;
            DateTime = dateTime;
            RobotId = robotId;
        }

        [JsonConstructor]
        public ErrorMessage(Guid id, Guid deliveryId, int deliveryStep, ErrorType errorType, DateTime dateTime) : base(id)
        {
            DeliveryId = deliveryId;
            DeliveryStep = deliveryStep;
            ErrorType = errorType;
            DateTime = dateTime;
            RobotId = Guid.Empty;
        }


        public override string ToString()
        {
            if (ErrorType == ErrorType.NoError)
            {
                return "No Error";
            }
            else
            {
                return $"{DateTime}: Step {DeliveryStep}, {ErrorType}";
            }
        }

        public static ErrorMessage Empty => new ErrorMessage(Guid.Empty, Guid.Empty, -1, ErrorType.NoError, new DateTime(1, 1, 1), Guid.Empty);
    }
}
