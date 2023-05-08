using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

namespace H5D_Delivery.RoboSim
{
    public class RobotComm
    {
        private readonly IMqttClient _mqttClient;

        private readonly Guid _robotId;

        private readonly string _batteryChargeTopic;
        private readonly string _statusUpdateRequestTopic;

        public RobotComm(Guid robotId, Func<MqttApplicationMessageReceivedEventArgs, Task> statusUpdateRequestHandler)
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            _robotId = robotId;

            //Define all Topics
            _batteryChargeTopic = $"Robots/{_robotId}/From/Status/BatteryChargePct";
            _statusUpdateRequestTopic = $"Robots/{_robotId}/To/Requests/StatusUpdate";


            ConnectAndSubscribe(statusUpdateRequestHandler);
        }

        private async void ConnectAndSubscribe(Func<MqttApplicationMessageReceivedEventArgs, Task> statusUpdateRequestHandler)
        {
            await ConnectAsync("localhost", 1883, "RoboSim");

            SubscribeToAllTopics(statusUpdateRequestHandler);
        }

        private async void SubscribeToAllTopics(Func<MqttApplicationMessageReceivedEventArgs, Task> statusUpdateRequestHandler)
        {
            await SubscribeAsync(_statusUpdateRequestTopic, statusUpdateRequestHandler);
        }

        public async void PublishBatteryChargePct(int batteryChargeInPercent)
        {
            await PublishAsync(_batteryChargeTopic, batteryChargeInPercent.ToString());
        }
        
        private async Task ConnectAsync(string brokerHostName, int brokerPort, string clientId)
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(brokerHostName, brokerPort)
                .WithClientId(clientId)
                .Build();

            await _mqttClient.ConnectAsync(options);
        }

        private async Task SubscribeAsync(string topic, Func<MqttApplicationMessageReceivedEventArgs, Task> handler)
        {
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
            _mqttClient.ApplicationMessageReceivedAsync += handler;

        }

        private async Task PublishAsync(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .Build();

            await _mqttClient.PublishAsync(message);
        }
    }
}
