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
            this.Connect = new System.Windows.Forms.Button();
            this.Btn_BatteryPct = new System.Windows.Forms.Button();
            this.Num_BatteryPct = new System.Windows.Forms.NumericUpDown();
            this.Lbl_StatusUpdate = new System.Windows.Forms.Label();
            this.btn_CurrentDeliveryStep = new System.Windows.Forms.Button();
            this.Num_UpdateCurrentDeliveryStep = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Connect = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Lbl_ReturnToBaseRequest = new System.Windows.Forms.Label();
            this.Combo_robos = new System.Windows.Forms.ComboBox();
            this.btn_GiveMeAnOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Num_BatteryPct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_UpdateCurrentDeliveryStep)).BeginInit();
            this.SuspendLayout();
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(27, 83);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 0;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // Btn_BatteryPct
            // 
            this.Btn_BatteryPct.Location = new System.Drawing.Point(116, 192);
            this.Btn_BatteryPct.Name = "Btn_BatteryPct";
            this.Btn_BatteryPct.Size = new System.Drawing.Size(180, 23);
            this.Btn_BatteryPct.TabIndex = 1;
            this.Btn_BatteryPct.Text = "Update";
            this.Btn_BatteryPct.UseVisualStyleBackColor = true;
            this.Btn_BatteryPct.Click += new System.EventHandler(this.Btn_BatteryPct_Click);
            // 
            // Num_BatteryPct
            // 
            this.Num_BatteryPct.Location = new System.Drawing.Point(27, 192);
            this.Num_BatteryPct.Name = "Num_BatteryPct";
            this.Num_BatteryPct.Size = new System.Drawing.Size(83, 23);
            this.Num_BatteryPct.TabIndex = 2;
            // 
            // Lbl_StatusUpdate
            // 
            this.Lbl_StatusUpdate.AutoSize = true;
            this.Lbl_StatusUpdate.Location = new System.Drawing.Point(162, 279);
            this.Lbl_StatusUpdate.Name = "Lbl_StatusUpdate";
            this.Lbl_StatusUpdate.Size = new System.Drawing.Size(16, 15);
            this.Lbl_StatusUpdate.TabIndex = 3;
            this.Lbl_StatusUpdate.Text = "...";
            // 
            // btn_CurrentDeliveryStep
            // 
            this.btn_CurrentDeliveryStep.Location = new System.Drawing.Point(116, 141);
            this.btn_CurrentDeliveryStep.Name = "btn_CurrentDeliveryStep";
            this.btn_CurrentDeliveryStep.Size = new System.Drawing.Size(180, 23);
            this.btn_CurrentDeliveryStep.TabIndex = 4;
            this.btn_CurrentDeliveryStep.Text = "UpdateDeliveryStep";
            this.btn_CurrentDeliveryStep.UseVisualStyleBackColor = true;
            this.btn_CurrentDeliveryStep.Click += new System.EventHandler(this.btn_CurrentDeliveryStep_Click);
            // 
            // Num_UpdateCurrentDeliveryStep
            // 
            this.Num_UpdateCurrentDeliveryStep.Location = new System.Drawing.Point(27, 141);
            this.Num_UpdateCurrentDeliveryStep.Name = "Num_UpdateCurrentDeliveryStep";
            this.Num_UpdateCurrentDeliveryStep.Size = new System.Drawing.Size(83, 23);
            this.Num_UpdateCurrentDeliveryStep.TabIndex = 6;
            // 
            // Lbl_Connect
            // 
            this.Lbl_Connect.AutoSize = true;
            this.Lbl_Connect.Location = new System.Drawing.Point(108, 87);
            this.Lbl_Connect.Name = "Lbl_Connect";
            this.Lbl_Connect.Size = new System.Drawing.Size(16, 15);
            this.Lbl_Connect.TabIndex = 7;
            this.Lbl_Connect.Text = "...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Status Update";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Return To Base Request";
            // 
            // Lbl_ReturnToBaseRequest
            // 
            this.Lbl_ReturnToBaseRequest.AutoSize = true;
            this.Lbl_ReturnToBaseRequest.Location = new System.Drawing.Point(162, 305);
            this.Lbl_ReturnToBaseRequest.Name = "Lbl_ReturnToBaseRequest";
            this.Lbl_ReturnToBaseRequest.Size = new System.Drawing.Size(16, 15);
            this.Lbl_ReturnToBaseRequest.TabIndex = 10;
            this.Lbl_ReturnToBaseRequest.Text = "...";
            // 
            // Combo_robos
            // 
            this.Combo_robos.FormattingEnabled = true;
            this.Combo_robos.Items.AddRange(new object[] {
            "Roboter 1",
            "Roboter 2",
            "Roboter 3"});
            this.Combo_robos.Location = new System.Drawing.Point(32, 25);
            this.Combo_robos.Name = "Combo_robos";
            this.Combo_robos.Size = new System.Drawing.Size(121, 23);
            this.Combo_robos.TabIndex = 11;
            // 
            // btn_GiveMeAnOrder
            // 
            this.btn_GiveMeAnOrder.Location = new System.Drawing.Point(27, 240);
            this.btn_GiveMeAnOrder.Name = "btn_GiveMeAnOrder";
            this.btn_GiveMeAnOrder.Size = new System.Drawing.Size(164, 23);
            this.btn_GiveMeAnOrder.TabIndex = 12;
            this.btn_GiveMeAnOrder.Text = "GiveMeAnOrder";
            this.btn_GiveMeAnOrder.UseVisualStyleBackColor = true;
            this.btn_GiveMeAnOrder.Click += new System.EventHandler(this.btn_GiveMeAnOrder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_GiveMeAnOrder);
            this.Controls.Add(this.Combo_robos);
            this.Controls.Add(this.Lbl_ReturnToBaseRequest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lbl_Connect);
            this.Controls.Add(this.Num_UpdateCurrentDeliveryStep);
            this.Controls.Add(this.btn_CurrentDeliveryStep);
            this.Controls.Add(this.Lbl_StatusUpdate);
            this.Controls.Add(this.Num_BatteryPct);
            this.Controls.Add(this.Btn_BatteryPct);
            this.Controls.Add(this.Connect);
            this.Name = "Form1";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.Num_BatteryPct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Num_UpdateCurrentDeliveryStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}