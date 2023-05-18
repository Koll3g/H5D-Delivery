using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Comm;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;
using Newtonsoft.Json;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public class RobotService
    {
        private readonly IRobotRepository _robotRepository;

        public RobotService(IRobotRepository robotRepository)
        {
            _robotRepository = robotRepository;
        }
        
        public IEnumerable<Robot>? GetAll()
        {
            return _robotRepository.GetAll();
        }

        public Robot? Get(Guid id)
        {
            return _robotRepository.Get(id);
        }

        public void Create(Robot robot)
        {
            _robotRepository.Create(robot);
        }

        public void Update(Robot robot)
        {
            _robotRepository.Update(robot);
        }

    }
}
