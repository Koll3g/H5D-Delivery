using MQTTnet;
using MQTTnet.Client;

namespace H5D_Delivery.RoboSim
{
    public partial class Form1 : Form
    {
        private RobotComm _robotComm;

        private static Guid _idRobot1 = new Guid("6ee9c6c6-09f0-4c06-a17c-e0ecbcbeb09f");

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Connect_Click(object sender, EventArgs e)
        {
            //ToDo: Select Guid based on dropdown

            _robotComm = new RobotComm(_idRobot1, HandleStatusUpdateRequest);
        }

        private void Btn_BatteryPct_Click(object sender, EventArgs e)
        {
            PublishBatteryPct();
        }

        private void PublishBatteryPct()
        {
            var batteryPctValue = (int)Num_BatteryPct.Value;
            _robotComm.PublishBatteryChargePct(batteryPctValue);
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

            }

            return Task.CompletedTask;
        }
    }
}