using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Robot.Comm;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;
using H5D_Delivery.Mgmt.Backend.Shared;
using H5D_Delivery.Mgmt.Backend.Shared.IoC;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public class Robot : NotifyPropertyChangedBase
    {
        private readonly IRobotComm _robotComm;

        private BatteryCharge _batteryCharge;
        [NotMapped]
        public BatteryCharge BatteryCharge
        {
            get => _batteryCharge;
            private set => SetProperty(ref _batteryCharge, value);
        }

        private int _giveMeAnOrder;
        [NotMapped]
        public int GiveMeAnOrder
        {
            get => _giveMeAnOrder;
            private set => SetProperty(ref _giveMeAnOrder, value);
        }

        private Guid _currentDeliveryId;
        public Guid CurrentDeliveryId
        {
            get => _currentDeliveryId;
            private set => SetProperty(ref _currentDeliveryId, value);
        }

        private int _currentDeliveryStep;
        [NotMapped]
        public int CurrentDeliveryStep
        {
            get => _currentDeliveryStep;
            private set => SetProperty(ref _currentDeliveryStep, value);
        }

        private int _deliveryDone;
        [NotMapped]
        public int DeliveryDone
        {
            get => _deliveryDone;
            private set => SetProperty(ref _deliveryDone, value);
        }

        private ErrorMessage _errorMessage;
        [NotMapped]
        public ErrorMessage ErrorMessage
        {
            get => _errorMessage;
            private set => SetProperty(ref _errorMessage, value);
        }

        public string Name { get; set; }

        public DateTime LastContact { get; set; }

        //public Robot(Guid id) : base(id)
        //{
        //    _batteryCharge = BatteryCharge.Empty;
        //    _currentDeliveryId = Guid.Empty;
        //    LastContact = new DateTime(1, 1, 1);
        //    _errorMessage = ErrorMessage.Empty;

        //    var clientName = "Listener-" + id;
        //    _robotComm = new RobotComm(id, clientName);

        //    SubscribeToCommEvents();
        //}

        public Robot(Guid id, string name, DateTime lastContact, Guid currentDeliveryId) : base(id)
        {
            CurrentDeliveryId = currentDeliveryId;
            LastContact = lastContact;
            Name = name;

            _batteryCharge = BatteryCharge.Empty;
            _errorMessage = ErrorMessage.Empty;

            var clientName = "Listener-" + id.ToString() + new Guid().ToString();
            _robotComm = new RobotComm(id, clientName);

            SubscribeToCommEvents();
        }
        
        private void SubscribeToCommEvents()
        {
            _robotComm.BatteryChargePctReceivedEvent += BatteryChargePctUpdateHandler;
            _robotComm.GiveMeAnOrderReceivedEvent += GiveMeAnOrderUpdateHandler;
            _robotComm.CurrentDeliveryIdReceivedEvent += CurrentDeliveryIdUpdateHandler;
            _robotComm.CurrentDeliveryStepReceivedEvent += CurrentDeliveryStepUpdateHandler;
            _robotComm.DeliveryDoneReceivedEvent += DeliveryDoneUpdateHandler;
            _robotComm.ErrorMessageReceivedEvent += ErrorMessageUpdateHandler;
        }

        public void BatteryChargePctUpdateHandler(object? sender, BatteryCharge batteryCharge)
        {
            LastContact = DateTime.Now;
            BatteryCharge = batteryCharge;
 
            try
            {
                var ioc = IocSetup.Instance.Container;
                var batteryService = ioc.Resolve<BatteryService>();
                batteryService.Create(batteryCharge);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void GiveMeAnOrderUpdateHandler(object? sender, int giveMeAnOrder)
        {
            LastContact = DateTime.Now;
            GiveMeAnOrder = giveMeAnOrder;
        }

        public void CurrentDeliveryIdUpdateHandler(object? sender, Guid id)
        {
            LastContact = DateTime.Now;
            CurrentDeliveryId = id;
        }

        public void CurrentDeliveryStepUpdateHandler(object? sender, int step)
        {
            LastContact = DateTime.Now;
            CurrentDeliveryStep = step;
        }

        public void DeliveryDoneUpdateHandler(object? sender, int deliveryDone)
        {
            LastContact = DateTime.Now;
            DeliveryDone = deliveryDone;
        }

        public void ErrorMessageUpdateHandler(object? sender, ErrorMessage errorMessage)
        {
            LastContact = DateTime.Now;
            ErrorMessage = errorMessage;

            try
            {
                var ioc = IocSetup.Instance.Container;
                var errorMessageService = ioc.Resolve<ErrorService>();
                errorMessageService.Create(errorMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RequestStatusUpdate()
        {
            _robotComm.RequestStatusUpdate();
        }

        public void RequestReturnToBase()
        {
            _robotComm.RequestReturnToBase();
        }

        public void GiveDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            _robotComm.GiveDeliveryOrder(deliveryOrder);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Robot otherRobot)
            {
                return Id.Equals(otherRobot.Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
