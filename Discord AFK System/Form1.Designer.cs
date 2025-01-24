namespace Discord_AFK_System
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
            browseBtn = new Button();
            playBtn = new Button();
            FiveMinsPresetBtn = new Button();
            TenMinsPresetBtn = new Button();
            TwentyMinsPresetBtn = new Button();
            stopBtn = new Button();
            audioFileLabel = new Label();
            secondsLabel = new Label();
            timeNumUpDown = new NumericUpDown();
            label3 = new Label();
            timeUntilNextTxt = new Label();
            audiodgElevationBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)timeNumUpDown).BeginInit();
            SuspendLayout();
            // 
            // browseBtn
            // 
            browseBtn.Location = new Point(12, 12);
            browseBtn.Name = "browseBtn";
            browseBtn.Size = new Size(75, 23);
            browseBtn.TabIndex = 0;
            browseBtn.Text = "Browse";
            browseBtn.UseVisualStyleBackColor = true;
            browseBtn.Click += browseBtn_Click;
            // 
            // playBtn
            // 
            playBtn.BackColor = Color.LightGreen;
            playBtn.Location = new Point(12, 41);
            playBtn.Name = "playBtn";
            playBtn.Size = new Size(150, 23);
            playBtn.TabIndex = 2;
            playBtn.Text = "Play";
            playBtn.UseVisualStyleBackColor = false;
            playBtn.Click += playBtn_Click;
            // 
            // FiveMinsPresetBtn
            // 
            FiveMinsPresetBtn.Location = new Point(12, 91);
            FiveMinsPresetBtn.Name = "FiveMinsPresetBtn";
            FiveMinsPresetBtn.Size = new Size(98, 23);
            FiveMinsPresetBtn.TabIndex = 3;
            FiveMinsPresetBtn.Text = "5 MInutes";
            FiveMinsPresetBtn.UseVisualStyleBackColor = true;
            FiveMinsPresetBtn.Click += FiveMinsPresetBtn_Click;
            // 
            // TenMinsPresetBtn
            // 
            TenMinsPresetBtn.Location = new Point(116, 91);
            TenMinsPresetBtn.Name = "TenMinsPresetBtn";
            TenMinsPresetBtn.Size = new Size(98, 23);
            TenMinsPresetBtn.TabIndex = 4;
            TenMinsPresetBtn.Text = "10 Minutes";
            TenMinsPresetBtn.UseVisualStyleBackColor = true;
            TenMinsPresetBtn.Click += TenMinsPresetBtn_Click;
            // 
            // TwentyMinsPresetBtn
            // 
            TwentyMinsPresetBtn.Location = new Point(220, 91);
            TwentyMinsPresetBtn.Name = "TwentyMinsPresetBtn";
            TwentyMinsPresetBtn.Size = new Size(98, 23);
            TwentyMinsPresetBtn.TabIndex = 5;
            TwentyMinsPresetBtn.Text = "20 Minutes";
            TwentyMinsPresetBtn.UseVisualStyleBackColor = true;
            TwentyMinsPresetBtn.Click += TwentyMinsPresetBtn_Click;
            // 
            // stopBtn
            // 
            stopBtn.BackColor = Color.LightCoral;
            stopBtn.Enabled = false;
            stopBtn.Location = new Point(168, 41);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(150, 23);
            stopBtn.TabIndex = 6;
            stopBtn.Text = "Stop";
            stopBtn.UseVisualStyleBackColor = false;
            stopBtn.Click += stopBtn_Click;
            // 
            // audioFileLabel
            // 
            audioFileLabel.AutoSize = true;
            audioFileLabel.Location = new Point(93, 16);
            audioFileLabel.Name = "audioFileLabel";
            audioFileLabel.Size = new Size(121, 15);
            audioFileLabel.TabIndex = 7;
            audioFileLabel.Text = "No audio file selected";
            // 
            // secondsLabel
            // 
            secondsLabel.AutoSize = true;
            secondsLabel.Location = new Point(12, 122);
            secondsLabel.Name = "secondsLabel";
            secondsLabel.Size = new Size(54, 15);
            secondsLabel.TabIndex = 8;
            secondsLabel.Text = "Seconds:";
            // 
            // timeNumUpDown
            // 
            timeNumUpDown.Location = new Point(72, 120);
            timeNumUpDown.Maximum = new decimal(new int[] { 3600, 0, 0, 0 });
            timeNumUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            timeNumUpDown.Name = "timeNumUpDown";
            timeNumUpDown.Size = new Size(246, 23);
            timeNumUpDown.TabIndex = 9;
            timeNumUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(128, 70);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 10;
            label3.Text = "Preset Times";
            // 
            // timeUntilNextTxt
            // 
            timeUntilNextTxt.AutoSize = true;
            timeUntilNextTxt.Location = new Point(12, 122);
            timeUntilNextTxt.Name = "timeUntilNextTxt";
            timeUntilNextTxt.Size = new Size(134, 15);
            timeUntilNextTxt.TabIndex = 11;
            timeUntilNextTxt.Text = "Time until next sound: 0";
            timeUntilNextTxt.Visible = false;
            // 
            // audiodgElevationBtn
            // 
            audiodgElevationBtn.Location = new Point(12, 149);
            audiodgElevationBtn.Name = "audiodgElevationBtn";
            audiodgElevationBtn.Size = new Size(306, 23);
            audiodgElevationBtn.TabIndex = 12;
            audiodgElevationBtn.Text = "Audio Crackling Fixer";
            audiodgElevationBtn.UseVisualStyleBackColor = true;
            audiodgElevationBtn.Click += audiodgElevationBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 184);
            Controls.Add(audiodgElevationBtn);
            Controls.Add(timeUntilNextTxt);
            Controls.Add(label3);
            Controls.Add(timeNumUpDown);
            Controls.Add(secondsLabel);
            Controls.Add(audioFileLabel);
            Controls.Add(stopBtn);
            Controls.Add(TwentyMinsPresetBtn);
            Controls.Add(TenMinsPresetBtn);
            Controls.Add(FiveMinsPresetBtn);
            Controls.Add(playBtn);
            Controls.Add(browseBtn);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Discord AFK System - Inactive";
            ((System.ComponentModel.ISupportInitialize)timeNumUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button browseBtn;
        private Button playBtn;
        private Button FiveMinsPresetBtn;
        private Button TenMinsPresetBtn;
        private Button TwentyMinsPresetBtn;
        private Button stopBtn;
        private Label audioFileLabel;
        private Label secondsLabel;
        private NumericUpDown timeNumUpDown;
        private Label label3;
        private Label timeUntilNextTxt;
        private Button audiodgElevationBtn;
    }
}
