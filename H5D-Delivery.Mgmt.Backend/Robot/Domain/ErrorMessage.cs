using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public class ErrorMessage : DbItem
    {
        public Guid DeliveryId { get; set; }
        public int DeliveryStep { get; set; }
        public ErrorType ErrorType { get; set; }
        public DateTime DateTime { get; set; }

        public ErrorMessage(Guid id, Guid deliveryId, int deliveryStep, ErrorType errorType, DateTime dateTime) : base(id)
        {
            DeliveryId = deliveryId;
            DeliveryStep = deliveryStep;
            ErrorType = errorType;
            DateTime = dateTime;
        }

        public override string ToString()
        {
            if (ErrorType == ErrorType.noError)
            {
                return "No Error";
            }
            else
            {
                return $"{DateTime}: Step {DeliveryStep}, {ErrorType}";
            }
        }

        public static ErrorMessage Empty => new ErrorMessage(Guid.Empty, Guid.Empty, -1, ErrorType.noError, new DateTime(1,1,1));
    }
}
