using System.Diagnostics;

namespace Discord_AFK_System
{
    public partial class audiodgElevation : Form
    {
        public static string GetAudiodgCores()
        {
            var audiodg = Process.GetProcessesByName("audiodg");
            if (audiodg.Length == 0) return string.Empty;

            var affinity = audiodg[0].ProcessorAffinity.ToInt64();
            var activeCores = new List<int>();

            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                if ((affinity & (1L << i)) != 0)
                {
                    activeCores.Add(i);
                }
            }

            return string.Join(", ", activeCores);
        }

        public static string GetAudiodgPriority()
        {
            var audiodg = Process.GetProcessesByName("audiodg");
            if (audiodg.Length == 0) return string.Empty;

            return audiodg[0].PriorityClass.ToString();
        }

        public audiodgElevation()
        {
            InitializeComponent();
            cpuUpDown.Maximum = Environment.ProcessorCount - 1;
            affinityLabel.Text = "Current Affinity: " + GetAudiodgCores();
            priorityLabel.Text = "Current Priority: " + GetAudiodgPriority();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void elevateBtn_Click(object sender, EventArgs e)
        {
            string elevatedTaskPath = Path.Combine(
                Path.GetDirectoryName(Application.ExecutablePath) ?? string.Empty,
                "AudiodgElevator.exe"
            );

            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = elevatedTaskPath,
                UseShellExecute = true,
                Verb = "runas", // Request administrator privileges
                Arguments = $"-cpu {cpuUpDown.Value + 1}"
            };

            try
            {
                Process.Start(psi);
                Console.WriteLine($"Task requested with administrator privileges for CPU{cpuUpDown.Value + 1}.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to execute elevate audiodg.exe task.\nMake sure AudiodgElevator.exe is in the same location as Discord AFK System.exe.\n\nTechy mumbo jumbo:\n" + ex.Message, "Failed to elevate audiodg.exe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
