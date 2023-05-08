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
            ((System.ComponentModel.ISupportInitialize)Num_BatteryPct).BeginInit();
            SuspendLayout();
            // 
            // Connect
            // 
            Connect.Location = new Point(248, 84);
            Connect.Name = "Connect";
            Connect.Size = new Size(75, 23);
            Connect.TabIndex = 0;
            Connect.Text = "Connect";
            Connect.UseVisualStyleBackColor = true;
            Connect.Click += Connect_Click;
            // 
            // Btn_BatteryPct
            // 
            Btn_BatteryPct.Location = new Point(458, 201);
            Btn_BatteryPct.Name = "Btn_BatteryPct";
            Btn_BatteryPct.Size = new Size(75, 23);
            Btn_BatteryPct.TabIndex = 1;
            Btn_BatteryPct.Text = "Update";
            Btn_BatteryPct.UseVisualStyleBackColor = true;
            Btn_BatteryPct.Click += Btn_BatteryPct_Click;
            // 
            // Num_BatteryPct
            // 
            Num_BatteryPct.Location = new Point(369, 201);
            Num_BatteryPct.Name = "Num_BatteryPct";
            Num_BatteryPct.Size = new Size(83, 23);
            Num_BatteryPct.TabIndex = 2;
            // 
            // Lbl_StatusUpdate
            // 
            Lbl_StatusUpdate.AutoSize = true;
            Lbl_StatusUpdate.Location = new Point(587, 331);
            Lbl_StatusUpdate.Name = "Lbl_StatusUpdate";
            Lbl_StatusUpdate.Size = new Size(16, 15);
            Lbl_StatusUpdate.TabIndex = 3;
            Lbl_StatusUpdate.Text = "...";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Lbl_StatusUpdate);
            Controls.Add(Num_BatteryPct);
            Controls.Add(Btn_BatteryPct);
            Controls.Add(Connect);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Num_BatteryPct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Connect;
        private Button Btn_BatteryPct;
        private NumericUpDown Num_BatteryPct;
        private Label Lbl_StatusUpdate;
    }
}