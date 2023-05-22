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

        Func<MqttApplicationMessageReceivedEventArgs, Task> _statusUpdateRequestHandler;
        Func<MqttApplicationMessageReceivedEventArgs, Task> _returnToBaseHandler;

        private readonly Guid _robotId;

        private readonly string _batteryChargeTopic;
        private readonly string _statusUpdateRequestTopic;
        private readonly string _currentDeliveryStepTopic;
        private readonly string _returnToBaseTopic;

        public RobotComm(Guid robotId, Func<MqttApplicationMessageReceivedEventArgs, Task> statusUpdateRequestHandler, Func<MqttApplicationMessageReceivedEventArgs, Task> returnToBaseHandler)
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            _robotId = robotId;

            //Define all Topics
            _batteryChargeTopic = $"Robots/{_robotId}/From/Status/BatteryChargePct";
            _statusUpdateRequestTopic = $"Robots/{_robotId}/To/Requests/StatusUpdate";
            _currentDeliveryStepTopic = $"Robots/{_robotId}/From/Status/CurrentDeliveryStep";
            _returnToBaseTopic = $"Robots/{_robotId}/To/Requests/ReturnToBase";

            _statusUpdateRequestHandler = statusUpdateRequestHandler;
            _returnToBaseHandler = returnToBaseHandler;
            ConnectAndSubscribe();
        }

        private async void ConnectAndSubscribe()
        {
            await ConnectAsync("localhost", 1883, "RoboSim");

            SubscribeToAllTopics();
        }

        private async void SubscribeToAllTopics()
        {
            await SubscribeAsync(_statusUpdateRequestTopic);
            await SubscribeAsync(_returnToBaseTopic);
            _mqttClient.ApplicationMessageReceivedAsync += MessageHandler;
        }

        public async void PublishBatteryChargePct(int batteryChargeInPercent)
        {
            await PublishAsync(_batteryChargeTopic, batteryChargeInPercent.ToString());
        }

        public async void PublishCurrentDeliveryStep(int currentDeliveryStep)
        {
            await PublishAsync(_currentDeliveryStepTopic, currentDeliveryStep.ToString());
        }

        private async Task ConnectAsync(string brokerHostName, int brokerPort, string clientId)
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(brokerHostName, brokerPort)
                .WithClientId(clientId)
                .Build();

            await _mqttClient.ConnectAsync(options);
        }

        private async Task SubscribeAsync(string topic)
        {
            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
        }

        private Task MessageHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            if(x.ApplicationMessage.Topic == _statusUpdateRequestTopic)
            {
                return _statusUpdateRequestHandler.Invoke(x);
            }
            else if(x.ApplicationMessage.Topic == _returnToBaseTopic)
            {
                return _returnToBaseHandler.Invoke(x);
            }
            return Task.CompletedTask;
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
