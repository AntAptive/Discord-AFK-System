using System.Diagnostics;

namespace Discord_AFK_System
{
    public partial class audiodgElevation : Form
    {
        public audiodgElevation()
        {
            InitializeComponent();
            cpuUpDown.Maximum = Environment.ProcessorCount - 1;
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
