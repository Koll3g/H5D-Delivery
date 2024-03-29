﻿using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H5D_Delivery.Mgmt.Backend.Shared;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public abstract class MqttComm
    {
        protected readonly IMqttClient MqttClient;

#if DEBUG
        protected const string BrokerHostName = "localhost";
#else
        protected const string BrokerHostName = "10.1.0.1";
#endif
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
            await ConnectAsync(BrokerHostName, BrokerPort, ClientId);

            SubscribeToAllTopics();
        }

        protected async void SubscribeToAllTopics()
        {
            foreach (var topic in SubscriptionTopics)
            {
                await SubscribeAsync(topic);
            }
            MqttClient.ApplicationMessageReceivedAsync += MqttMessageHandler;
        }

        protected abstract Task MqttMessageHandler(MqttApplicationMessageReceivedEventArgs x);

        protected async Task ConnectAsync(string brokerHostName, int brokerPort, string clientId)
        {
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(brokerHostName, brokerPort)
                .WithClientId(clientId)
                .Build();

            await MqttClient.ConnectAsync(options);
            var test = 1;
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
        }
    }
}
