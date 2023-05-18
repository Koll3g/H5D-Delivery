using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Shared.Persistence;

namespace H5D_Delivery.Mgmt.Backend.Robot.Persistence.Battery
{
    public class BatteryChargeRepository : RepositoryBase<BatteryCharge>, IBatteryChargeRepository
    {
        public BatteryChargeRepository(BatteryChargeContext dbContext) : base(dbContext) { }

        public IEnumerable<BatteryCharge>? GetAllForSpecificRobot(Guid robotId)
        {
            return _dbContext.DbSet?
                .Where(bc => bc.RobotId == robotId);
        }

        public IEnumerable<BatteryCharge>? Get100NewestForSpecificRobot(Guid robotId)
        {
            return _dbContext.DbSet?
                .Where(bc => bc.RobotId == robotId)
                .OrderByDescending(bc => bc.DateTime)
                .Take(100)
                .ToList();
        }
    }
}
