using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery
{
    public class BatteryService
    {
        private readonly IBatteryChargeRepository _batteryChargeRepository;

        public BatteryService(IBatteryChargeRepository batteryChargeRepository)
        {
            _batteryChargeRepository = batteryChargeRepository;
        }
        
        public IEnumerable<BatteryCharge>? GetAllForSpecificRobot(Guid robotId)
        {
            return _batteryChargeRepository.GetAllForSpecificRobot(robotId);
        }

        public IEnumerable<BatteryCharge>? GetAll()
        {
            return _batteryChargeRepository.GetAll();
        }

        public void Create(BatteryCharge batteryCharge)
        {
            _batteryChargeRepository.Create(batteryCharge);
        }
    }
}
