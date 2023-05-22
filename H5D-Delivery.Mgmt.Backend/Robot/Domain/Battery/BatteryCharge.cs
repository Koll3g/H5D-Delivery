using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery
{
    public class BatteryCharge : DbItem
    {
        public Guid RobotId { get; set; }
        public int BatteryChargePct { get; set; }
        public DateTime DateTime { get; set; }

        public BatteryCharge(Guid id, Guid robotId, int batteryChargePct, DateTime dateTime) : base(id)
        {
            RobotId = robotId;
            BatteryChargePct = batteryChargePct;
            DateTime = dateTime;
        }

        public static BatteryCharge Empty => new BatteryCharge(Guid.Empty, Guid.Empty, -1, new DateTime(1, 1, 1));
    }
}
