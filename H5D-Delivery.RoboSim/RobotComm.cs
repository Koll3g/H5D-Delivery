using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using Newtonsoft.Json;

namespace H5D_Delivery.RoboSim
{
    public class RobotComm
    {
        private readonly IMqttClient _mqttClient;

        Func<MqttApplicationMessageReceivedEventArgs, Task> _statusUpdateRequestHandler;
        Func<MqttApplicationMessageReceivedEventArgs, Task> _returnToBaseHandler;
        Func<MqttApplicationMessageReceivedEventArgs, Task> _deliveryOrderReceivedHandler;

        private readonly Guid _robotId;

        private readonly string _batteryChargeTopic;
        private readonly string _statusUpdateRequestTopic;
        private readonly string _currentDeliveryStepTopic;
        private readonly string _returnToBaseTopic;
        private readonly string _giveMeAnOrderTopic;
        private readonly string _deliveryDoneTopic;
        private readonly string _errorMessageTopic;
        private readonly string _deliveryOrderTopic;
        private readonly string _deliveryIdTopic;
        private readonly string _currentPositionTopic;

        public RobotComm(Guid robotId, Func<MqttApplicationMessageReceivedEventArgs, Task> statusUpdateRequestHandler, Func<MqttApplicationMessageReceivedEventArgs, Task> returnToBaseHandler, Func<MqttApplicationMessageReceivedEventArgs, Task> deliveryOrderReceivedHandler)
        {
            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            _robotId = robotId;

            //Define all Topics
            _batteryChargeTopic = $"Robots/{_robotId}/From/Status/BatteryChargePct";
            _currentDeliveryStepTopic = $"Robots/{_robotId}/From/Status/CurrentDeliveryStep";
            _deliveryDoneTopic = $"Robots/{_robotId}/From/Status/DeliveryDone";
            _giveMeAnOrderTopic = $"Robots/{_robotId}/From/Requests/GiveMeAnOrder";
            _errorMessageTopic = $"Robots/{_robotId}/From/ErrorMessage";
            _deliveryIdTopic = $"Robots/{_robotId}/From/Status/CurrentDeliveryId";

            _statusUpdateRequestTopic = $"Robots/{_robotId}/To/Requests/StatusUpdate";
            _returnToBaseTopic = $"Robots/{_robotId}/To/Requests/ReturnToBase";
            _deliveryOrderTopic = $"Robots/{_robotId}/To/DeliveryOrder";
            _currentPositionTopic = $"Robots/{_robotId}/From/Status/CurrentPosition";

            _statusUpdateRequestHandler = statusUpdateRequestHandler;
            _returnToBaseHandler = returnToBaseHandler;
            _deliveryOrderReceivedHandler = deliveryOrderReceivedHandler;

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
            await SubscribeAsync(_deliveryOrderTopic);
            _mqttClient.ApplicationMessageReceivedAsync += MessageHandler;
        }

        public async void PublishBatteryChargePct(int batteryChargeInPercent)
        {
            await PublishAsync(_batteryChargeTopic, batteryChargeInPercent.ToString());
        }

        public async void PublishCurrentDeliveryStep(int currentDeliveryStep, Guid currentDeliveryId)
        {
            var message = new
            {
                deliveryId = currentDeliveryId,
                deliveryStep = currentDeliveryStep
            };

            var json = JsonConvert.SerializeObject(message);
            await PublishAsync(_currentDeliveryStepTopic, json);
        }

        public async void PublishGiveMeAnOrder(int giveMeAnOrder)
        {
            await PublishAsync(_giveMeAnOrderTopic, giveMeAnOrder.ToString());
        }

        public async void PublishDeliveryId(Guid deliveryId)
        {
            await PublishAsync(_deliveryIdTopic, deliveryId.ToString());
        }

        public async void PublishDeliveryDone(int deliveryDone)
        {
            await PublishAsync(_deliveryDoneTopic, deliveryDone.ToString());
        }

        public async void PublishErrorMessage(ErrorMessageDto errorMessage)
        {
            await PublishAsync(_errorMessageTopic, JsonConvert.SerializeObject(errorMessage));
        }

        public async void PublishCurrentPosition(int x1, int y1)
        {
            var message = new
            {
                x = x1,
                y = y1
            };

            var json = JsonConvert.SerializeObject(message);
            await PublishAsync(_currentPositionTopic, json);
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
            else if (x.ApplicationMessage.Topic == _deliveryOrderTopic)
            {
                return _deliveryOrderReceivedHandler.Invoke(x);
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
