namespace H5D_Delivery.RoboSim
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Connect = new Button();
            Btn_BatteryPct = new Button();
            Num_BatteryPct = new NumericUpDown();
            Lbl_StatusUpdate = new Label();
            btn_CurrentDeliveryStep = new Button();
            Num_UpdateCurrentDeliveryStep = new NumericUpDown();
            Lbl_Connect = new Label();
            label1 = new Label();
            label2 = new Label();
            Lbl_ReturnToBaseRequest = new Label();
            Combo_robos = new ComboBox();
            btn_GiveMeAnOrder = new Button();
            btn_deliveryDone = new Button();
            combo_Errors = new ComboBox();
            btn_sendError = new Button();
            ((System.ComponentModel.ISupportInitialize)Num_BatteryPct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Num_UpdateCurrentDeliveryStep).BeginInit();
            SuspendLayout();
            // 
            // Connect
            // 
            Connect.Location = new Point(27, 83);
            Connect.Name = "Connect";
            Connect.Size = new Size(75, 23);
            Connect.TabIndex = 0;
            Connect.Text = "Connect";
            Connect.UseVisualStyleBackColor = true;
            Connect.Click += Connect_Click;
            // 
            // Btn_BatteryPct
            // 
            Btn_BatteryPct.Location = new Point(116, 192);
            Btn_BatteryPct.Name = "Btn_BatteryPct";
            Btn_BatteryPct.Size = new Size(180, 23);
            Btn_BatteryPct.TabIndex = 1;
            Btn_BatteryPct.Text = "UpdateBatteryCharge";
            Btn_BatteryPct.UseVisualStyleBackColor = true;
            Btn_BatteryPct.Click += Btn_BatteryPct_Click;
            // 
            // Num_BatteryPct
            // 
            Num_BatteryPct.Location = new Point(27, 192);
            Num_BatteryPct.Name = "Num_BatteryPct";
            Num_BatteryPct.Size = new Size(83, 23);
            Num_BatteryPct.TabIndex = 2;
            // 
            // Lbl_StatusUpdate
            // 
            Lbl_StatusUpdate.AutoSize = true;
            Lbl_StatusUpdate.Location = new Point(162, 324);
            Lbl_StatusUpdate.Name = "Lbl_StatusUpdate";
            Lbl_StatusUpdate.Size = new Size(16, 15);
            Lbl_StatusUpdate.TabIndex = 3;
            Lbl_StatusUpdate.Text = "...";
            // 
            // btn_CurrentDeliveryStep
            // 
            btn_CurrentDeliveryStep.Location = new Point(116, 141);
            btn_CurrentDeliveryStep.Name = "btn_CurrentDeliveryStep";
            btn_CurrentDeliveryStep.Size = new Size(180, 23);
            btn_CurrentDeliveryStep.TabIndex = 4;
            btn_CurrentDeliveryStep.Text = "UpdateDeliveryStep";
            btn_CurrentDeliveryStep.UseVisualStyleBackColor = true;
            btn_CurrentDeliveryStep.Click += btn_CurrentDeliveryStep_Click;
            // 
            // Num_UpdateCurrentDeliveryStep
            // 
            Num_UpdateCurrentDeliveryStep.Location = new Point(27, 141);
            Num_UpdateCurrentDeliveryStep.Name = "Num_UpdateCurrentDeliveryStep";
            Num_UpdateCurrentDeliveryStep.Size = new Size(83, 23);
            Num_UpdateCurrentDeliveryStep.TabIndex = 6;
            // 
            // Lbl_Connect
            // 
            Lbl_Connect.AutoSize = true;
            Lbl_Connect.Location = new Point(108, 87);
            Lbl_Connect.Name = "Lbl_Connect";
            Lbl_Connect.Size = new Size(16, 15);
            Lbl_Connect.TabIndex = 7;
            Lbl_Connect.Text = "...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 324);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 8;
            label1.Text = "Status Update";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 350);
            label2.Name = "label2";
            label2.Size = new Size(129, 15);
            label2.TabIndex = 9;
            label2.Text = "Return To Base Request";
            // 
            // Lbl_ReturnToBaseRequest
            // 
            Lbl_ReturnToBaseRequest.AutoSize = true;
            Lbl_ReturnToBaseRequest.Location = new Point(162, 350);
            Lbl_ReturnToBaseRequest.Name = "Lbl_ReturnToBaseRequest";
            Lbl_ReturnToBaseRequest.Size = new Size(16, 15);
            Lbl_ReturnToBaseRequest.TabIndex = 10;
            Lbl_ReturnToBaseRequest.Text = "...";
            // 
            // Combo_robos
            // 
            Combo_robos.FormattingEnabled = true;
            Combo_robos.Items.AddRange(new object[] { "Roboter 1", "Roboter 2", "Roboter 3" });
            Combo_robos.Location = new Point(12, 35);
            Combo_robos.Name = "Combo_robos";
            Combo_robos.Size = new Size(121, 23);
            Combo_robos.TabIndex = 11;
            Combo_robos.SelectedIndexChanged += Combo_robos_SelectedIndexChanged;
            // 
            // btn_GiveMeAnOrder
            // 
            btn_GiveMeAnOrder.Location = new Point(27, 240);
            btn_GiveMeAnOrder.Name = "btn_GiveMeAnOrder";
            btn_GiveMeAnOrder.Size = new Size(164, 23);
            btn_GiveMeAnOrder.TabIndex = 12;
            btn_GiveMeAnOrder.Text = "GiveMeAnOrder";
            btn_GiveMeAnOrder.UseVisualStyleBackColor = true;
            btn_GiveMeAnOrder.Click += btn_GiveMeAnOrder_Click;
            // 
            // btn_deliveryDone
            // 
            btn_deliveryDone.Location = new Point(27, 282);
            btn_deliveryDone.Name = "btn_deliveryDone";
            btn_deliveryDone.Size = new Size(164, 23);
            btn_deliveryDone.TabIndex = 13;
            btn_deliveryDone.Text = "DeliveryDone";
            btn_deliveryDone.UseVisualStyleBackColor = true;
            btn_deliveryDone.Click += btn_deliveryDone_Click;
            // 
            // combo_Errors
            // 
            combo_Errors.FormattingEnabled = true;
            combo_Errors.Items.AddRange(new object[] { "personNotAtHome", "personNotAuthorized", "cannotDeposit", "blockedEntrance", "cannotMove", "navigationError", "outOfBattery", "pickMeUpImScared", "noError" });
            combo_Errors.Location = new Point(496, 350);
            combo_Errors.Name = "combo_Errors";
            combo_Errors.Size = new Size(121, 23);
            combo_Errors.TabIndex = 14;
            combo_Errors.SelectedIndexChanged += combo_Errors_SelectedIndexChanged;
            // 
            // btn_sendError
            // 
            btn_sendError.Location = new Point(633, 350);
            btn_sendError.Name = "btn_sendError";
            btn_sendError.Size = new Size(75, 23);
            btn_sendError.TabIndex = 15;
            btn_sendError.Text = "Send";
            btn_sendError.UseVisualStyleBackColor = true;
            btn_sendError.Click += btn_sendError_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_sendError);
            Controls.Add(combo_Errors);
            Controls.Add(btn_deliveryDone);
            Controls.Add(btn_GiveMeAnOrder);
            Controls.Add(Combo_robos);
            Controls.Add(Lbl_ReturnToBaseRequest);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Lbl_Connect);
            Controls.Add(Num_UpdateCurrentDeliveryStep);
            Controls.Add(btn_CurrentDeliveryStep);
            Controls.Add(Lbl_StatusUpdate);
            Controls.Add(Num_BatteryPct);
            Controls.Add(Btn_BatteryPct);
            Controls.Add(Connect);
            Name = "Form1";
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)Num_BatteryPct).EndInit();
            ((System.ComponentModel.ISupportInitialize)Num_UpdateCurrentDeliveryStep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Connect;
        private Button Btn_BatteryPct;
        private NumericUpDown Num_BatteryPct;
        private Label Lbl_StatusUpdate;
        private Button btn_CurrentDeliveryStep;
        private NumericUpDown Num_UpdateCurrentDeliveryStep;
        private Label Lbl_Connect;
        private Label label1;
        private Label label2;
        private Label Lbl_ReturnToBaseRequest;
        private ComboBox Combo_robos;
        private Button btn_GiveMeAnOrder;
        private Button btn_deliveryDone;
        private ComboBox combo_Errors;
        private Button btn_sendError;
    }
}