using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public interface IRobotComm
    {
        public event EventHandler<int>? BatteryChargePctReceivedEvent;


    }
}
