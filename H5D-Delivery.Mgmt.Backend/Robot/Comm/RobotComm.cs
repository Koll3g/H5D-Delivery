using H5D_Delivery.Mgmt.Backend.Robot.Domain;
using MQTTnet;
using MQTTnet.Client;
using System.ComponentModel;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public class RobotComm : IRobotComm
    {
        private readonly IMqttClient _mqttClient;
        private Guid _robotId;

        public event EventHandler<int>? BatteryChargePctReceivedEvent;

        private readonly string _batteryChargePctTopic;
        private readonly string _statusUpdateRequestTopic;

        public RobotComm(Guid robotId)
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            _robotId = robotId;

            //Define all Topics
            _batteryChargePctTopic = $"Robots/{_robotId}/From/Status/BatteryChargePct";
            _statusUpdateRequestTopic = $"Robots/{_robotId}/To/Requests/StatusUpdate";

            ConnectAndSubscribe();
        }

        public async void RequestStatusUpdate()
        {
            await PublishAsync(_statusUpdateRequestTopic, "1");
        }

        private async void ConnectAndSubscribe()
        {
            await ConnectAsync("localhost", 1883, "H5D-Delivery");

            SubscribeToAllTopics();
        }

        private async void SubscribeToAllTopics()
        {
            await SubscribeAsync(_batteryChargePctTopic);
        }

        private async Task ConnectAsync(string brokerHostName, int brokerPort, string clientId)
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(brokerHostName, brokerPort)
                .WithClientId(clientId)
                .Build();

            await _mqttClient.ConnectAsync(options);
        }

        private Task MqttMessageHandler(MqttApplicationMessageReceivedEventArgs x)
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
                BatteryChargePctReceivedEvent?.Invoke(this, value);
            });
        }

        private async Task PublishAsync(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .Build();

            await _mqttClient.PublishAsync(message);
        }

        private async Task SubscribeAsync(string topic)
        {
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
            _mqttClient.ApplicationMessageReceivedAsync += MqttMessageHandler;
        }
    }
}
