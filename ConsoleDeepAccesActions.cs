using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace KTZEngine
{
    ////─────────────────────────────────────────────────────────────────class ConsoleResizableDisable─────────────────────────────────────────────────────────────────|
    public static class ConsoleBasicSettings
    {
        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public static void ConsoleResizableDisable_()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                // DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);
                // DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                // DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
        }

        const uint ENABLE_QUICK_EDIT = 0x0040;

        // STD_INPUT_HANDLE (DWORD): -10 is the standard input device.
        const int STD_INPUT_HANDLE = -10;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        internal static bool StopConsoleExecuting()
        {

            IntPtr consoleHandle = GetStdHandle(STD_INPUT_HANDLE);

            // get current console mode
            uint consoleMode;
            if (!GetConsoleMode(consoleHandle, out consoleMode))
            {
                // ERROR: Unable to get console mode.
                return false;
            }

            // Clear the quick edit bit in the mode flags
            consoleMode &= ~ENABLE_QUICK_EDIT;

            // set the new mode
            if (!SetConsoleMode(consoleHandle, consoleMode))
            {
                // ERROR: Unable to set console mode
                return false;
            }

            return true;
        }


    }


    ////─────────────────────────────────────────────────────────────────class ConsoleFullScreen─────────────────────────────────────────────────────────────────|
    public class ConsoleFullScreen
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        private static Array modes = new[] { HIDE, MAXIMIZE, MINIMIZE, RESTORE };
        //────────────────────────────────────────────Include────────────────────────────────────────────|
        /// <summary>
        /// Set Console Window mode
        /// </summary>
        /// <param name="modeIndex"></param>
        public static void SetMode(int modeIndex)
        {
            //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);  
            ShowWindow(ThisConsole, modeIndex);
        }
    }


}