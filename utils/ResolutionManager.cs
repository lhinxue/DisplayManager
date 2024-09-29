using System.Runtime.InteropServices;
namespace DisplayManager.utils
{
    public class ResolutionManager
    {
        // Import necessary Windows API functions
        [DllImport("user32.dll")]
        private static extern int ChangeDisplaySettings(ref DEVMODE devMode, int flags);

        [DllImport("user32.dll")]
        private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        private const int DM_PELSWIDTH = 0x80000;
        private const int DM_PELSHEIGHT = 0x100000;
        private const int CDS_UPDATEREGISTRY = 0x01;
        private const int DISP_CHANGE_SUCCESSFUL = 0;

        // Define the DEVMODE structure
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        public static void ChangeResolution(int width, int height)
        {
            DEVMODE devMode = new DEVMODE();
            devMode.dmDeviceName = new string(new char[32]);
            devMode.dmFormName = new string(new char[32]);
            devMode.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));

            // Get current display settings
            if (EnumDisplaySettings(null, 0, ref devMode))
            {
                // Modify the width and height
                devMode.dmPelsWidth = width;
                devMode.dmPelsHeight = height;
                devMode.dmFields = DM_PELSWIDTH | DM_PELSHEIGHT;

                // Change the display settings
                int result = ChangeDisplaySettings(ref devMode, CDS_UPDATEREGISTRY);

                // Check for success
                if (result == DISP_CHANGE_SUCCESSFUL)
                {
                    Console.WriteLine($"Resolution successfully changed to {width}x{height}");
                }
                else
                {
                    Console.WriteLine("Resolution change failed.");
                }
            }
            else
            {
                Console.WriteLine("Unable to retrieve display settings.");
            }
        }
    }
}


