using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using H5D_Delivery.Mgmt.Backend.Delivery.Comm;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using H5D_Delivery.Mgmt.Backend.Order.Domain;
using H5D_Delivery.Mgmt.Backend.Robot.Comm;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;
using H5D_Delivery.Mgmt.Backend.Robot.Persistence;
using H5D_Delivery.Mgmt.Backend.Shared;
using H5D_Delivery.Mgmt.Backend.Shared.IoC;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;
using H5D_Delivery.Mgmt.Backend.Stock.Domain;

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

        private Coordinates _currentPosition;

        [NotMapped]
        public Coordinates CurrentPosition
        {
            get => _currentPosition;
            private set => SetProperty(ref _currentPosition, value);
        }

        [NotMapped]
        public bool VisualizePosition { get; set; } = false;

        public string Name { get; set; }

        public DateTime LastContact { get; set; }

        public Robot(Guid id, string name, DateTime lastContact, Guid currentDeliveryId) : base(id)
        {
            CurrentDeliveryId = currentDeliveryId;
            LastContact = lastContact;
            Name = name;

            _batteryCharge = BatteryCharge.Empty;
            _errorMessage = ErrorMessage.Empty;
            _currentPosition = Coordinates.Empty;

            var clientName = "RobotBackend-" + Guid.NewGuid();
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
            _robotComm.CurrentPositionReceivedEvent += CurrentPositionReceivedUpdateHandler;
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

            //ToDo: if a deliveryorder is already existing for specific robot which is not done yet, send this one

            var deliveryService = IocSetup.Instance.Container.Resolve<DeliveryService>();
            var deliveryOrder = deliveryService.GenerateDeliveryOrder();
            if (deliveryOrder == null)
            {
                return;
            }
            deliveryOrder.AssignedRobotId = Id;
            deliveryService.Update(deliveryOrder);

            var stockItems = IocSetup.Instance.Container.Resolve<StockService>().GetAll();
            if (stockItems != null)
            {
                var stockItemsList = stockItems.ToList();
                GiveDeliveryOrder(new DeliveryOrderDto(deliveryOrder, stockItemsList));
            }
        }

        public void CurrentDeliveryIdUpdateHandler(object? sender, Guid id)
        {
            LastContact = DateTime.Now;
            CurrentDeliveryId = id;

            //ToDo: Mark orders as being delivered
            var orderService = IocSetup.Instance.Container.Resolve<OrderService>();
            var ordersBeingDelivered = orderService.GetAllOrdersForDeliveryId(id);
            if (ordersBeingDelivered == null)
            {
                return;
            }
            foreach (var order in ordersBeingDelivered)
            {
                orderService.UpdateOrderStatus(order.Id, OrderStatus.BeingDelivered);
            }
        }

        public void CurrentDeliveryStepUpdateHandler(object? sender, CurrentDeliveryStep step)
        {
            LastContact = DateTime.Now;
            CurrentDeliveryStep = step.DeliveryStep;

            var deliveryService = IocSetup.Instance.Container.Resolve<DeliveryService>();
            var deliveryOrder = deliveryService.Get(step.DeliveryId);
            if (deliveryOrder == null)
            {
                return;
            }
            UpdateDeliveryStatus(deliveryOrder, step, deliveryService);
        }

        private void UpdateDeliveryStatus(DeliveryOrder deliveryOrder, CurrentDeliveryStep currentDeliveryStep, DeliveryService deliveryService)
        {
            if (currentDeliveryStep.DeliveryStep == 0)
            {
                return;
            }
            var previousDeliveryStep = deliveryOrder.DeliveryPlan.DeliverySteps.First(x => x.StepSequence == currentDeliveryStep.DeliveryStep - 1);
            previousDeliveryStep.RealDeliveryTime = DateTime.Now;
            deliveryService.Update(deliveryOrder);

            if (previousDeliveryStep.DeliveryType is DeliveryType.Deposit or DeliveryType.HandOver)
            {
                var orderId = deliveryOrder.Orders.First(x => x.ProductId == previousDeliveryStep.ProductId).Id;
                var orderService = IocSetup.Instance.Container.Resolve<OrderService>();
                orderService.UpdateOrderStatus(orderId, OrderStatus.Delivered);
            }
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

        public void CurrentPositionReceivedUpdateHandler(object? sender, Coordinates position)
        {
            LastContact = DateTime.Now;
            CurrentPosition = position;
        }

        public void RequestStatusUpdate()
        {
            _robotComm.RequestStatusUpdate();
        }

        public void RequestReturnToBase()
        {
            _robotComm.RequestReturnToBase();
        }

        public void GiveDeliveryOrder(DeliveryOrderDto deliveryOrder)
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

        public void UpdateDb()
        {
            var ioc = IocSetup.Instance.Container;
            var service = ioc.Resolve<RobotService>();
            service.Update(this);
        }
    }
}
