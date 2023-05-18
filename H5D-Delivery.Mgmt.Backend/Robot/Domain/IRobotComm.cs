using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public interface IRobotComm
    {
        public event EventHandler<BatteryCharge>? BatteryChargePctReceivedEvent;
        public event EventHandler<int> GiveMeAnOrderReceivedEvent;
        public event EventHandler<Guid> CurrentDeliveryIdReceivedEvent;
        public event EventHandler<int>? CurrentDeliveryStepReceivedEvent;
        public event EventHandler<int>? DeliveryDoneReceivedEvent;
        public event EventHandler<ErrorMessage>? ErrorMessageReceivedEvent;

        public void RequestStatusUpdate();
        public void RequestReturnToBase();
        public void GiveDeliveryOrder(DeliveryOrder deliveryOrder);

    }
}
