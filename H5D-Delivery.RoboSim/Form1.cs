using MQTTnet;
using MQTTnet.Client;

namespace H5D_Delivery.RoboSim
{
    public partial class Form1 : Form
    {
        private RobotComm _robotComm;

        private static Guid _idRobot1 = new Guid("6ee9c6c6-09f0-4c06-a17c-e0ecbcbeb09f");
        private static Guid _idRobot2 = new Guid("490fde85-cfc1-47a8-bd6e-0eca6eb81f98");
        private static Guid _idRobot3 = new Guid("ad4b8e7e-e2d9-4547-9b5c-9e827e94961d");

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Guid selectedRobotId;

            // ToDo: Select Guid based on dropdown
            if (Combo_robos.SelectedItem.ToString() == "Roboter 1")
            {
                selectedRobotId = _idRobot1;
            }
            else if (Combo_robos.SelectedItem.ToString() == "Roboter 2")
            {
                selectedRobotId = _idRobot2;
            }
            else if (Combo_robos.SelectedItem.ToString() == "Roboter 3")
            {
                selectedRobotId = _idRobot3;
            }
            else
            {
                // Handle invalid selection or error condition
                return;
            }

            _robotComm = new RobotComm(selectedRobotId, HandleStatusUpdateRequest, ReturnToBaseHandler);
            Lbl_Connect.Text = "connected";
        }

        //private void Connect_Click(object sender, EventArgs e)
        //{

        //    //ToDo: Select Guid based on dropdown

        //    _robotComm = new RobotComm(_idRobot1, HandleStatusUpdateRequest, ReturnToBaseHandler);

        //    Lbl_Connect.Text = "connected";

        //}

        private void Btn_BatteryPct_Click(object sender, EventArgs e)
        {
            PublishBatteryPct();
        }

        private void PublishBatteryPct()
        {
            var batteryPctValue = (int)Num_BatteryPct.Value;
            _robotComm.PublishBatteryChargePct(batteryPctValue);
        }

        private void PublishDeliveryStep()
        {
            var deliverystepValue = (int)Num_UpdateCurrentDeliveryStep.Value;
            _robotComm.PublishCurrentDeliveryStep(deliverystepValue);
        }

        private void PublishGiveMeAnOrder()
        {
            _robotComm.PublishGiveMeAnOrder(1);
        }

        private void PublishDeliveryDone()
        {
            _robotComm.PublishDeliveryDone(1);
        }

        private Task HandleStatusUpdateRequest(MqttApplicationMessageReceivedEventArgs x)
        {
            //Todo: implement functionality

            //Show status on GUI (invoke UI update operation)
            Lbl_StatusUpdate.Invoke(new Action(() =>
            {
                Lbl_StatusUpdate.Text = x.ApplicationMessage.ConvertPayloadToString();
            }));

            var value = x.ApplicationMessage.ConvertPayloadToString();
            if (value != null && value == "1")
            {
                //Send updates for all status fields
                PublishBatteryPct();
                PublishDeliveryStep();
                PublishDeliveryDone();

            }

            return Task.CompletedTask;
        }

        private Task ReturnToBaseHandler(MqttApplicationMessageReceivedEventArgs x)
        {
            //Todo: implement functionality

            //Show status on GUI (invoke UI update operation)
            Lbl_ReturnToBaseRequest.Invoke(new Action(() =>
            {
                Lbl_ReturnToBaseRequest.Text = x.ApplicationMessage.ConvertPayloadToString();
            }));

            return Task.CompletedTask;
        }

        private void btn_CurrentDeliveryStep_Click(object sender, EventArgs e)
        {
            PublishDeliveryStep();
        }



        private void btn_GiveMeAnOrder_Click(object sender, EventArgs e)
        {
            PublishGiveMeAnOrder();
        }

        private void btn_deliveryDone_Click(object sender, EventArgs e)
        {
            PublishDeliveryDone();
        }

        private void btn_sendError_Click(object sender, EventArgs e)
        {
            string selectedError = combo_Errors.SelectedItem.ToString() ?? string.Empty;
            var error = new ErrorMessageDto()
            {
                deliveryId = Guid.NewGuid(),
                step = (int)Num_UpdateCurrentDeliveryStep.Value,
                type = selectedError
            };
            _robotComm.PublishErrorMessage(error);
        }

        private void combo_Errors_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Combo_robos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}