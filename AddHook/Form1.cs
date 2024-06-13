using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AddHook
{
    public class WinApi
    {

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public const int GWL_WNDPROC = -4;
        public const int WM_GETMINMAXINFO = 0x0024;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        // RECT structure for GetWindowRect function
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
    }


    public partial class Form1 : Form
    {
        private static IntPtr originalWndProc = IntPtr.Zero;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Hello";

            this.Load += Form1_Load;

            //_hookID = SetHook(_proc);
           
        }

        private void Form1_Load(object? sender, EventArgs e)
        {

            IntPtr hWnd = WinApi.FindWindow(null, "Form1");
            if (hWnd == IntPtr.Zero)
            {
                Console.WriteLine("Window not found!");
                return;
            }

            var proc = System.Diagnostics.Process.GetProcessesByName("MaxHeight");

            originalWndProc = WinApi.SetWindowLongPtr(proc[0].Handle, WinApi.GWL_WNDPROC,
            Marshal.GetFunctionPointerForDelegate((WinApi.WndProcDelegate)WndProc));

            // Set desired height and width
            int desiredWidth = 800;  // Example width
            int desiredHeight = 1200; // Example height

            if (WinApi.GetWindowRect(proc[0].MainWindowHandle, out WinApi.RECT rect))
            {
                int currentWidth = rect.Right - rect.Left;
                int currentHeight = rect.Bottom - rect.Top;

                // Center the window and resize it
                int newX = rect.Left + (currentWidth - desiredWidth) / 2;
                int newY = rect.Top + (currentHeight - desiredHeight) / 2;

                // Move and resize the window
                bool result = WinApi.MoveWindow(hWnd, 0, 0, desiredWidth, desiredHeight, true);

                if (result)
                {
                    Console.WriteLine("Window resized successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to resize window.");
                }
            }
                Console.WriteLine("Window subclassed successfully!");
        }

        private static IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (msg == WinApi.WM_GETMINMAXINFO)
            {
                WinApi.MINMAXINFO mmi = Marshal.PtrToStructure<WinApi.MINMAXINFO>(lParam);
                mmi.ptMaxTrackSize.y = 2000; // Set the maximum height here
                Marshal.StructureToPtr(mmi, lParam, true);
            }
            return WinApi.CallWindowProc(originalWndProc, hWnd, msg, wParam, lParam);
        }

        private enum HookType
        {
            WH_MSGFILTER = -1,
            WH_JOURNALRECORD = 0,
            WH_JOURNALPLAYBACK = 1,
            WH_KEYBOARD = 2,
            WH_GETMESSAGE = 3,
            WH_CALLWNDPROC = 4,
            WH_CBT = 5,
            WH_SYSMSGFILTER = 6,
            WH_MOUSE = 7,
            WH_HARDWARE = 8,
            WH_DEBUG = 9,
            WH_SHELL = 10,
            WH_FOREGROUNDIDLE = 11,
            WH_CALLWNDPROCRET = 12,
            WH_KEYBOARD_LL = 13,
            WH_MOUSE_LL = 14
        }
    }
}

