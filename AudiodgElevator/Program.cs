using System.Diagnostics;

namespace AudiodgElevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get the number of logical processors on the system
            int logicalProcessorCount = Environment.ProcessorCount;

            // Default CPU core is CPU2 (3 because it starts at 0)
            int cpuNumber = 3;

            // Command-line argument for custom CPU core
            if (args.Length >= 2 && args[0] == "-cpu" && int.TryParse(args[1], out int customCpu))
            {
                if (customCpu < 1 || customCpu > logicalProcessorCount)
                {
                    Console.WriteLine($"Invalid CPU number. Please specify a value between 1 and {logicalProcessorCount}. Note: 1 = CPU0");
                    Thread.Sleep(2000);
                    Environment.Exit(1);
                    return;
                }
                cpuNumber = customCpu;
            }

            // Calculate the CPU affinity bitmask for the specified CPU
            IntPtr cpuAffinity = (1 << (cpuNumber - 1));

            // Find the audiodg.exe process
            Process[] processes = Process.GetProcessesByName("audiodg");
            if (processes.Length == 0)
            {
                Console.WriteLine("audiodg.exe is not running, what? how?");
                Thread.Sleep(2000);
                Environment.Exit(1);
                return;
            }

            foreach (Process process in processes)
            {
                // Set process priority to High
                process.PriorityClass = ProcessPriorityClass.High; 

                // Set CPU affinity
                process.ProcessorAffinity = cpuAffinity;

                Console.WriteLine($"audiodg.exe priority set to High and affinity set to CPU{cpuNumber-1}.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
    }
}
