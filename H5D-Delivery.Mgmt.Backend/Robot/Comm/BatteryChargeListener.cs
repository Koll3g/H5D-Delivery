using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using MQTTnet;
using MQTTnet.Client;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public class BatteryChargeListener : MqttComm
    {
        private readonly string _batteryChargePctTopic;
        private readonly IBatteryChargeRepository _batteryChargeRepository;
        private const string RobotIdPattern = @"Robots/(?<robotId>[\w-]+)/From/Status/BatteryChargePct";

        public BatteryChargeListener(IBatteryChargeRepository batteryChargeRepository) : base("BatteryListener-" + new Guid())
        {
            _batteryChargeRepository = batteryChargeRepository;
            
            _batteryChargePctTopic = $"Robots/+/From/Status/BatteryChargePct";
            SubscriptionTopics.Add(_batteryChargePctTopic);

            ConnectAndSubscribe();
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
                    string robotId = match.Groups["robotId"].Value;
                    var value = Convert.ToInt32(payload);
                    var batteryCharge = new BatteryCharge(new Guid(), new Guid(robotId), value, DateTime.Now);
                    _batteryChargeRepository.Create(batteryCharge);
                }
            });
        }
    }
}
