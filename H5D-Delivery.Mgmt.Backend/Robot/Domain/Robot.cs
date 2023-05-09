using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public class Robot
    {
        private readonly IRobotComm _robotComm;
        public IRobotComm RobotComm => _robotComm;

        public int BatteryCharge { get; private set; }

        public Robot(IRobotComm robotComm)
        {
            _robotComm = robotComm;
            _robotComm.BatteryChargePctReceivedEvent += BatteryChargePctUpdateHandler;
        }

        public void BatteryChargePctUpdateHandler(object? sender, int batteryCharge)
        {
            BatteryCharge = batteryCharge;
        }

        public void RequestStatusUpdate()
        {
            _robotComm.RequestStatusUpdate();
        }
    }
}
