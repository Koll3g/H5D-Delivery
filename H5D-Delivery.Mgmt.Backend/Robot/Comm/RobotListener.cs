using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Autofac;
using H5D_Delivery.Mgmt.Backend.Robot.Domain;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Shared.IoC;
using MQTTnet;
using MQTTnet.Client;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public class RobotListener : MqttComm
    {
        public List<Domain.Robot> ActiveRobots { get; set; } = new List<Domain.Robot>();

        private readonly RobotService _robotService;

        private readonly string _robotsTopic;
        private const string RobotIdPattern = @"Robots/(?<robotId>[\w-]+)/(\w*)";

        public RobotListener(RobotService robotService) : base("RobotListener-" + Guid.NewGuid())
        {
            _robotService = robotService;

            _robotsTopic = "Robots/#";
            SubscriptionTopics.Add(_robotsTopic);

            LoadRobotsFromDb();
            ConnectAndSubscribe();
        }

        private void LoadRobotsFromDb()
        {
            var robotsDb = _robotService.GetAll();
            if (robotsDb != null)
            {
                ActiveRobots = robotsDb.ToList();
            }
        }

        protected override Task MqttMessageHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                var payload = x.ApplicationMessage.ConvertPayloadToString();
                var topic = x.ApplicationMessage.Topic;

                Match match = Regex.Match(topic, RobotIdPattern);

                if (match.Success)
                {
                    var robotIdString = match.Groups["robotId"].Value;
                    var robotId = new Guid(robotIdString);
                    
                    foreach (var robot in ActiveRobots)
                    {
                        if (robot.Id == robotId)
                        {
                            return;
                        }
                    }

                    var newRobot = new Domain.Robot(robotId, string.Empty, DateTime.Now, Guid.Empty);
                    _robotService.Create(newRobot);
                }

                LoadRobotsFromDb();
            });
        }
    }
}
