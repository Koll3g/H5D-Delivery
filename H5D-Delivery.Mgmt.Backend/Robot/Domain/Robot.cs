using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Comm;
using H5D_Delivery.Mgmt.Backend.Shared;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public class Robot : NotifyPropertyChangedBase
    {
        private readonly IRobotComm _robotComm;

        public Guid Id { get; set; }

        public IRobotComm RobotComm => _robotComm;

        private BatteryCharge _batteryCharge;
        public BatteryCharge BatteryCharge
        {
            get => _batteryCharge;
            private set => SetProperty(ref _batteryCharge, value);
        }


        private int test;

        public int Test
        {
            get => test;
            set => SetProperty(ref test, value);
        }
        public string Name { get; set; } = string.Empty;

        public DateTime? LastContact { get; set; }

        public Robot(Guid id)
        {
            Id = id;
            BatteryCharge = new BatteryCharge(new Guid(), id, -1, DateTime.Now);
            var clientName = "Listener-" + id.ToString();
            _robotComm = new RobotComm(id, clientName);
            _robotComm.BatteryChargePctReceivedEvent += BatteryChargePctUpdateHandler;

        }

        public void BatteryChargePctUpdateHandler(object? sender, BatteryCharge batteryCharge)
        {
            BatteryCharge = batteryCharge;
            Test += 1;
        }

        public void RequestStatusUpdate()
        {
            _robotComm.RequestStatusUpdate();
        }
    }
}
