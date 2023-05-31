using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Delivery.Comm;
using H5D_Delivery.Mgmt.Backend.Robot.Comm;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public interface IRobotComm
    {
        public event EventHandler<BatteryCharge>? BatteryChargePctReceivedEvent;
        public event EventHandler<int> GiveMeAnOrderReceivedEvent;
        public event EventHandler<Guid> CurrentDeliveryIdReceivedEvent;
        public event EventHandler<CurrentDeliveryStep>? CurrentDeliveryStepReceivedEvent;
        public event EventHandler<int>? DeliveryDoneReceivedEvent;
        public event EventHandler<ErrorMessage>? ErrorMessageReceivedEvent;
        public event EventHandler<Coordinates>? CurrentPositionReceivedEvent; 

        public void RequestStatusUpdate();
        public void RequestReturnToBase();
        public void GiveDeliveryOrder(DeliveryOrderDto deliveryOrder);

    }
}
