using Discord_AFK_System.Threads;
using System.Diagnostics;

namespace Discord_AFK_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string filePath;

        private Thread audioThread;
        CancellationTokenSource cts;

        AFKThreads afkThreads = new AFKThreads();

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Audio file (*.mp3, *.wav)|*.mp3;*.wav";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                audioFileLabel.Text = "" + ofd.SafeFileName;
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (filePath == null)
            {
                MessageBox.Show("Please pick an audio file.", "Cannot play", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Reinstantaite cancellation token for thread
            cts = new CancellationTokenSource();

            // Disable buttons
            playBtn.Enabled = false;
            browseBtn.Enabled = false;
            FiveMinsPresetBtn.Enabled = false;
            TenMinsPresetBtn.Enabled = false;
            TwentyMinsPresetBtn.Enabled = false;

            // Swap UI
            timeNumUpDown.Visible = false;
            secondsLabel.Visible = false;
            timeUntilNextTxt.Visible = true;

            // Start the thread
            audioThread = new Thread(() => afkThreads.StartAudioThread(filePath, (float)timeNumUpDown.Value, cts, this));
            audioThread.Start();

            this.Text = "Discord AFK System - ACTIVE";
            playBtn.Text = "Playing...";
            stopBtn.Enabled = true;
        }

        public int TotalTimeRemaining
        {
            set
            {
                if (timeUntilNextTxt.InvokeRequired)
                {
                    timeUntilNextTxt.Invoke(new Action(() =>
                    {
                        int minutes = value / 60;
                        int seconds = value % 60;
                        string result = $"{minutes} minute{(minutes == 1 ? "" : "s")} {seconds} second{(seconds == 1 ? "" : "s")}";
                        timeUntilNextTxt.Text = $"Time until next sound: {result}";
                    }

                    ));
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cts != null)
                cts.Cancel();

            Environment.Exit(0);
        }

        private void FiveMinsPresetBtn_Click(object sender, EventArgs e)
        {
            timeNumUpDown.Value = 300;
        }

        private void TenMinsPresetBtn_Click(object sender, EventArgs e)
        {
            timeNumUpDown.Value = 600;
        }

        private void TwentyMinsPresetBtn_Click(object sender, EventArgs e)
        {
            timeNumUpDown.Value = 1200;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            stopBtn.Text = "Stopping...";
            stopBtn.Enabled = false;

            cts.Cancel();

            playBtn.Enabled = true;
            browseBtn.Enabled = true;
            this.Text = "Discord AFK System - Inactive";
            playBtn.Text = "Play";
            stopBtn.Text = "Stop";
            FiveMinsPresetBtn.Enabled = true;
            TenMinsPresetBtn.Enabled = true;
            TwentyMinsPresetBtn.Enabled = true;

            // Swap UI
            timeNumUpDown.Visible = true;
            secondsLabel.Visible = true;
            timeUntilNextTxt.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AFKThreads.GetVirtualCableDeviceNumber();
            }
            catch
            {
                DialogResult result = MessageBox.Show("VB-Audio Virtual Cable or VB-Audio Hi-Fi Cable is required to run Discord AFK System.\n\nWould you like to visit the VB-Audio download page?", "Cannot start Discord AFK System", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);

                if (result == DialogResult.Yes)
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://vb-audio.com/Cable/",
                        UseShellExecute = true
                    });

                Environment.Exit(1);
            }

        }

        private void audiodgElevationBtn_Click(object sender, EventArgs e)
        {
            audiodgElevation audiodg = new audiodgElevation();
            audiodg.ShowDialog();
        }
    }
}
