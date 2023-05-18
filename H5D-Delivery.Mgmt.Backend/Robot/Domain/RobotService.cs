using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Comm;
using Newtonsoft.Json;

namespace H5D_Delivery.Mgmt.Backend.Robot.Domain
{
    public class RobotService
    {
        private Robot _robot;

        public RobotService()
        {
            _robot = new Robot(new Guid("6ee9c6c6-09f0-4c06-a17c-e0ecbcbeb09f"));
            _robot.Name = "RobotSim";
        }

        public List<Robot> GetRobots()
        {
            var list = new List<Robot>();
            list.Add(_robot);
            return list;
        }

        public string Test()
        {
            var errorMessage = ErrorMessage.Empty;
            return JsonConvert.SerializeObject(errorMessage);
        }

    }
}
