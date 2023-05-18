using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public abstract class MqttComm
    {
        protected readonly IMqttClient MqttClient;

        protected const string BrokerHostName = "localhost";
        protected const int BrokerPort = 1883;
        protected readonly string ClientId;

        protected List<string> SubscriptionTopics = new List<string>();

        protected MqttComm(string clientId)
        {
            ClientId = clientId;
            var factory = new MqttFactory();
            MqttClient = factory.CreateMqttClient();
        }

        protected async void ConnectAndSubscribe()
        {
            await ConnectAsync("localhost", 1883, ClientId);

            SubscribeToAllTopics();
        }

        protected async void SubscribeToAllTopics()
        {
            foreach (var topic in SubscriptionTopics)
            {
                await SubscribeAsync(topic);
            }
            
        }

        protected abstract Task MqttMessageHandler(MqttApplicationMessageReceivedEventArgs x);

        protected async Task ConnectAsync(string brokerHostName, int brokerPort, string clientId)
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(brokerHostName, brokerPort)
                .WithClientId(clientId)
                .Build();

            await MqttClient.ConnectAsync(options);
        }

        protected async Task PublishAsync(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
            .Build();

            await MqttClient.PublishAsync(message);
        }

        protected async Task SubscribeAsync(string topic)
        {
            await MqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
            MqttClient.ApplicationMessageReceivedAsync += MqttMessageHandler;
        }
    }
}
