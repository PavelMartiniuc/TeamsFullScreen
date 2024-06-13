using System.Runtime.InteropServices;

namespace MaxHeight
{
    public partial class Form1 : Form
    {
        private static IntPtr originalWndProc = IntPtr.Zero;

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

        public Form1()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = WinApi.FindWindow(null, "Form1");
            if (hWnd == IntPtr.Zero)
            {
                Console.WriteLine("Window not found!");
                return;
            }

            originalWndProc = WinApi.SetWindowLongPtr(hWnd, WinApi.GWL_WNDPROC,
            Marshal.GetFunctionPointerForDelegate((WinApi.WndProcDelegate)WndProc));
        }
    }
}
