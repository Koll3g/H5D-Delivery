using H5D_Delivery.Mgmt.Backend.Robot.Domain;
using MQTTnet;
using MQTTnet.Client;
using System.ComponentModel;
using Newtonsoft.Json;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public class RobotComm : MqttComm, IRobotComm
    {
        private readonly Guid _robotId;

        public event EventHandler<BatteryCharge>? BatteryChargePctReceivedEvent;
        public event EventHandler<int>? GiveMeAnOrderReceivedEvent;
        public event EventHandler<Guid>? CurrentDeliveryIdReceivedEvent;
        public event EventHandler<int>? CurrentDeliveryStepReceivedEvent;
        public event EventHandler<int>? DeliveryDoneReceivedEvent;
        public event EventHandler<ErrorMessage>? ErrorMessageReceivedEvent;

        //From:
        private readonly string _batteryChargePctTopic;
        private readonly string _giveMeAnOrderTopic;
        private readonly string _currentDeliveryIdTopic;
        private readonly string _currentDeliveryStepTopic;
        private readonly string _deliveryDoneTopic;
        private readonly string _errorMessageTopic;


        //To:
        private readonly string _returnToBaseRequestTopic;
        private readonly string _statusUpdateRequestTopic;


        public RobotComm(Guid robotId, string clientId) : base(clientId) 
        { 
            
            _robotId = robotId;

            //DEFINE ALL TOPICS:

            //From:
            _batteryChargePctTopic = $"Robots/{_robotId}/From/Status/BatteryChargePct";
            _giveMeAnOrderTopic = $"Robots/{_robotId}/From/Requests/GiveMeAnOrder";
            _currentDeliveryIdTopic = $"Robots/{_robotId}/From/Status/CurrentDeliveryId";
            _currentDeliveryStepTopic = $"Robots/{_robotId}/From/Status/CurrentDeliveryStep";
            _deliveryDoneTopic = $"Robots/{_robotId}/From/Status/DeliveryDone";
            _errorMessageTopic = $"Robots/{_robotId}/From/ErrorMessage";

            SubscriptionTopics.Add(_batteryChargePctTopic);
            SubscriptionTopics.Add(_giveMeAnOrderTopic);
            SubscriptionTopics.Add(_currentDeliveryIdTopic);
            SubscriptionTopics.Add(_currentDeliveryStepTopic);
            SubscriptionTopics.Add(_deliveryDoneTopic);
            SubscriptionTopics.Add(_errorMessageTopic);

            //To:
            _statusUpdateRequestTopic = $"Robots/{_robotId}/To/Requests/StatusUpdate";
            _returnToBaseRequestTopic = $"Robots/{_robotId}/To/Requests/ReturnToBase";

            ConnectAndSubscribe();
        }

        public async void RequestStatusUpdate()
        {
            await PublishAsync(_statusUpdateRequestTopic, "1");
        }

        public async void RequestReturnToBase()
        {
            await PublishAsync(_returnToBaseRequestTopic, "1");
        }

        protected override Task MqttMessageHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            var topic = x.ApplicationMessage.Topic;

            if(topic == _batteryChargePctTopic)
            {
                return BatteryChargePctReceivedHandler(x);
            }
            else if (topic == _giveMeAnOrderTopic)
            {
                return GiveMeAnOrderReceivedHandler(x);
            }
            else if (topic == _currentDeliveryIdTopic)
            {
                return CurrentDeliveryIdReceivedHandler(x);
            }
            else if (topic == _currentDeliveryStepTopic)
            {
                return CurrentDeliveryStepReceivedHandler(x);
            }
            else if (topic == _deliveryDoneTopic)
            {
                return DeliveryDoneReceivedHandler(x);
            }
            else if (topic == _errorMessageTopic)
            {
                return ErrorMessageReceivedHandler(x);
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

        private Task GiveMeAnOrderReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                var payload = x.ApplicationMessage.ConvertPayloadToString();
                var value = Convert.ToInt32(payload);
                GiveMeAnOrderReceivedEvent?.Invoke(this, value);
            });
        }

        private Task CurrentDeliveryIdReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                var payload = x.ApplicationMessage.ConvertPayloadToString();
                var value = new Guid(payload);
                CurrentDeliveryIdReceivedEvent?.Invoke(this, value);
            });
        }

        private Task CurrentDeliveryStepReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                var payload = x.ApplicationMessage.ConvertPayloadToString();
                var value = Convert.ToInt32(payload);
                CurrentDeliveryStepReceivedEvent?.Invoke(this, value);
            });
        }

        private Task DeliveryDoneReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                var payload = x.ApplicationMessage.ConvertPayloadToString();
                var value = Convert.ToInt32(payload);
                DeliveryDoneReceivedEvent?.Invoke(this, value);
            });
        }

        private Task ErrorMessageReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                var payload = x.ApplicationMessage.ConvertPayloadToString();
                var value = JsonConvert.DeserializeObject<ErrorMessage>(payload);
                if (value != null)
                {
                    ErrorMessageReceivedEvent?.Invoke(this, value);
                }
            });
        }
    }
}
