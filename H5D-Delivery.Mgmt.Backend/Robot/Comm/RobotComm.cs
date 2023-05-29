using H5D_Delivery.Mgmt.Backend.Robot.Domain;
using MQTTnet;
using MQTTnet.Client;
using System.ComponentModel;
using Autofac;
using H5D_Delivery.Mgmt.Backend.Delivery.Comm;
using H5D_Delivery.Mgmt.Backend.Delivery.Domain;
using Newtonsoft.Json;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Battery;
using H5D_Delivery.Mgmt.Backend.Robot.Domain.Error;
using H5D_Delivery.Mgmt.Backend.Shared.IoC;
using H5D_Delivery.RoboSim;

namespace H5D_Delivery.Mgmt.Backend.Robot.Comm
{
    public class RobotComm : MqttComm, IRobotComm
    {
        private readonly Guid _robotId;

        public event EventHandler<BatteryCharge>? BatteryChargePctReceivedEvent;
        public event EventHandler<int>? GiveMeAnOrderReceivedEvent;
        public event EventHandler<Guid>? CurrentDeliveryIdReceivedEvent;
        public event EventHandler<CurrentDeliveryStep>? CurrentDeliveryStepReceivedEvent;
        public event EventHandler<int>? DeliveryDoneReceivedEvent;
        public event EventHandler<ErrorMessage>? ErrorMessageReceivedEvent;
        public event EventHandler<Coordinates>? CurrentPositionReceivedEvent;

        //From:
        private readonly string _batteryChargePctTopic;
        private readonly string _giveMeAnOrderTopic;
        private readonly string _currentDeliveryIdTopic;
        private readonly string _currentDeliveryStepTopic;
        private readonly string _deliveryDoneTopic;
        private readonly string _errorMessageTopic;
        private readonly string _currentPositionTopic;

        //To:
        private readonly string _returnToBaseRequestTopic;
        private readonly string _statusUpdateRequestTopic;
        private readonly string _deliveryOrderTopic;


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
            _currentPositionTopic = $"Robots/{_robotId}/From/Status/CurrentPosition";

            SubscriptionTopics.Add(_batteryChargePctTopic);
            SubscriptionTopics.Add(_giveMeAnOrderTopic);
            SubscriptionTopics.Add(_currentDeliveryIdTopic);
            SubscriptionTopics.Add(_currentDeliveryStepTopic);
            SubscriptionTopics.Add(_deliveryDoneTopic);
            SubscriptionTopics.Add(_errorMessageTopic);
            SubscriptionTopics.Add(_currentPositionTopic);

            //To:
            _statusUpdateRequestTopic = $"Robots/{_robotId}/To/Requests/StatusUpdate";
            _returnToBaseRequestTopic = $"Robots/{_robotId}/To/Requests/ReturnToBase";
            _deliveryOrderTopic = $"Robots/{_robotId}/To/DeliveryOrder";

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

        public async void GiveDeliveryOrder(DeliveryOrderDto deliveryOrder)
        {
            var deliveryOrderAsJson = JsonConvert.SerializeObject(deliveryOrder);
            await PublishAsync(_deliveryOrderTopic, deliveryOrderAsJson);
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
            else if (topic == _currentPositionTopic)
            {
                return CurrentPositionReceivedHandler(x);
            }

            return Task.CompletedTask;
        }

        private Task BatteryChargePctReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                try
                {
                    var payload = x.ApplicationMessage.ConvertPayloadToString();
                    var value = Convert.ToInt32(payload);
                    var batteryCharge = new BatteryCharge(Guid.NewGuid(), _robotId, value, DateTime.Now);
                    BatteryChargePctReceivedEvent?.Invoke(this, batteryCharge);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        private Task GiveMeAnOrderReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                try
                {
                    var payload = x.ApplicationMessage.ConvertPayloadToString();
                    var value = Convert.ToInt32(payload);
                    GiveMeAnOrderReceivedEvent?.Invoke(this, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        private Task CurrentDeliveryIdReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                try
                {
                    var payload = x.ApplicationMessage.ConvertPayloadToString();
                    var value = new Guid(payload);
                    CurrentDeliveryIdReceivedEvent?.Invoke(this, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        private Task CurrentDeliveryStepReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                try
                {
                    var payload = x.ApplicationMessage.ConvertPayloadToString();
                    var dto = JsonConvert.DeserializeObject<CurrentDeliveryStepDto>(payload);
                    var step = dto?.ConvertToCurrentDeliveryStep();
                    if (step != null)
                    {
                        CurrentDeliveryStepReceivedEvent?.Invoke(this, step);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        private Task DeliveryDoneReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                try
                {
                    var payload = x.ApplicationMessage.ConvertPayloadToString();
                    var value = Convert.ToInt32(payload);
                    DeliveryDoneReceivedEvent?.Invoke(this, value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        private Task ErrorMessageReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                try
                {
                    var payload = x.ApplicationMessage.ConvertPayloadToString();
                    var dto = JsonConvert.DeserializeObject<ErrorMessageDto>(payload);
                    var errorMessage = dto?.ConvertToErrorMessage();
                    if (errorMessage != null)
                    {
                        errorMessage.RobotId = _robotId;
                        ErrorMessageReceivedEvent?.Invoke(this, errorMessage);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        private Task CurrentPositionReceivedHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            return Task.Run(() =>
            {
                try
                {
                    var payload = x.ApplicationMessage.ConvertPayloadToString();
                    var dto = JsonConvert.DeserializeObject<CurrentPositionDto>(payload);
                    var coordinates = dto?.ConvertToCoordinates();
                    if (coordinates != null)
                    {
                        CurrentPositionReceivedEvent?.Invoke(this, coordinates);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }
    }
}
