using H5D_Delivery.Mgmt.Backend.Robot.Domain;
using MQTTnet;
using MQTTnet.Client;
using System.ComponentModel;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public class RobotComm : MqttComm, IRobotComm
    {
        private readonly Guid _robotId;

        public event EventHandler<BatteryCharge>? BatteryChargePctReceivedEvent;

        private readonly string _batteryChargePctTopic;
        private readonly string _statusUpdateRequestTopic;

        public RobotComm(Guid robotId, string clientId) : base(clientId)
        {
            _robotId = robotId;

            //Define all Topics
            _batteryChargePctTopic = $"Robots/{_robotId}/From/Status/BatteryChargePct";
            _statusUpdateRequestTopic = $"Robots/{_robotId}/To/Requests/StatusUpdate";

            SubscriptionTopics.Add(_batteryChargePctTopic);

            ConnectAndSubscribe();
        }

        public async void RequestStatusUpdate()
        {
            await PublishAsync(_statusUpdateRequestTopic, "1");
        }
        
        protected override Task MqttMessageHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            var topic = x.ApplicationMessage.Topic;

            if(topic == _batteryChargePctTopic)
            {
                return BatteryChargePctReceivedHandler(x);
            }

            return Task.CompletedTask;
        }

        private Task BatteryChargePctReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                var payload = x.ApplicationMessage.ConvertPayloadToString();
                var value = Convert.ToInt32(payload);
                var batteryCharge = new BatteryCharge(new Guid(), _robotId, value, DateTime.Now);
                BatteryChargePctReceivedEvent?.Invoke(this, batteryCharge);
            });
        }
    }
}
