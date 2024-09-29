using System.Diagnostics;

namespace DisplayManager.utils
{
    public class ScreenManager
    {
        // Extend the display across all monitors
        public static void ExtendScreen()
        {
            RunDisplaySwitch("/extend");
        }

        // Clone the display to all monitors
        public static void InternalScreenOnly()
        {
            RunDisplaySwitch("/internal");
        }

        // Helper function to run DisplaySwitch.exe with the given argument
        private static void RunDisplaySwitch(string argument)
        {
            Process process = new Process();
            process.StartInfo.FileName = "DisplaySwitch.exe";
            process.StartInfo.Arguments = argument;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
        }

    }
}
