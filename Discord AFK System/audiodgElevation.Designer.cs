namespace Discord_AFK_System
{
    partial class audiodgElevation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            closeBtn = new Button();
            elevateBtn = new Button();
            cpuUpDown = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)cpuUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(318, 45);
            label1.TabIndex = 0;
            label1.Text = "This tool will elevate audiodg.exe to a High priority on your\r\nmachine and isolate it to only one CPU core to mitigate\r\nstuttering.";
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(12, 144);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(327, 23);
            closeBtn.TabIndex = 1;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // elevateBtn
            // 
            elevateBtn.BackColor = Color.LightGreen;
            elevateBtn.Location = new Point(12, 95);
            elevateBtn.Name = "elevateBtn";
            elevateBtn.Size = new Size(327, 43);
            elevateBtn.TabIndex = 2;
            elevateBtn.Text = "Elevate";
            elevateBtn.UseVisualStyleBackColor = false;
            elevateBtn.Click += elevateBtn_Click;
            // 
            // cpuUpDown
            // 
            cpuUpDown.Location = new Point(51, 66);
            cpuUpDown.Name = "cpuUpDown";
            cpuUpDown.Size = new Size(288, 23);
            cpuUpDown.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 68);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 4;
            label2.Text = "CPU:";
            // 
            // audiodgElevation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 178);
            Controls.Add(label2);
            Controls.Add(cpuUpDown);
            Controls.Add(elevateBtn);
            Controls.Add(closeBtn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "audiodgElevation";
            ShowIcon = false;
            Text = "Elevator. What floor, ma'am?";
            ((System.ComponentModel.ISupportInitialize)cpuUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button closeBtn;
        private Button elevateBtn;
        private NumericUpDown cpuUpDown;
        private Label label2;
    }
}