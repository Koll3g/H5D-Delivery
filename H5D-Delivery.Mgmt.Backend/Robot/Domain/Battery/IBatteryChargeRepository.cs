using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery
{
    public interface IBatteryChargeRepository : IRepositoryBase<BatteryCharge>
    {
        public IEnumerable<BatteryCharge>? GetAllForSpecificRobot(Guid robotId);

        public IEnumerable<BatteryCharge>? GetXNewest(uint amount);

        public IEnumerable<BatteryCharge>? GetXNewestForSpecificRobot(Guid robotId, uint amount);
    }
}
