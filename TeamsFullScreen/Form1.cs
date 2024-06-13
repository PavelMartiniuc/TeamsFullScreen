using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace TeamsFullScreen
{


    public partial class frmMain : Form
    {
        public class MyMessageFilter : IMessageFilter
        {
            //private const int WM_xxx = 0x0;

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_GETMINMAXINFO)
                {
                    //code to handle the message
                }

                return false;
            }
        }



        private System.Diagnostics.Process[]? processs;
        private uint action = 4;
        private int x;
        private int y;
        private int width;
        private int height;
        private const short SWP_NOMOVE = 2;
        private const short SWP_NOSIZE = 1;
        private const short SWP_NOZORDER = 4;
        private const int SWP_SHOWWINDOW = 64;
        private const int SWP_NOSENDCHANGING = 1024;
        private const int SWP_HIDEWINDOW = 128;
        private const int SWP_DEFERERASE = 8192;
        private const int SW_NORMAL = 1;


        private const int WM_GETMINMAXINFO = 0x0024;
        private const int WM_CLOSE = 0x0010;
        private const int GWL_WNDPROC = -4;

        #region Controls
        private Button btSetShow;
        private Button btSetHide;
        private Button btMoveLeft;
        private Button btMoveRight;
        private Button btMoveTop;
        private Button btMoveButtom;
        private Label label1;
        private Button btWidthUp;
        private Button btWidthDown;
        private Label label2;
        private Button btHeightDown;
        private Button btHeightUp;
        private Label label3;
        private Label lbX;
        private Label lbY;
        private Label lbWidth;
        private Label lbHeight;
        private Button btTeamsFullscreen;
        private GroupBox groupBox1;
        private RadioButton fsZoomed;
        private RadioButton fsNormal;
        #endregion
        
        private static WinProc newWndProc = null;
        private static IntPtr oldWndProc = IntPtr.Zero;

        private delegate IntPtr WinProc(IntPtr hWnd, WindowMessage Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        private static IntPtr WndProc(IntPtr hWnd, WindowMessage Msg, IntPtr wParam, IntPtr lParam)
        {
            switch (Msg)
            {
                case WindowMessage.WM_GETMINMAXINFO:
                    var dpi = GetDpiForWindow(hWnd);
                    var scalingFactor = (float)dpi / 96;

                    var minMaxInfo = Marshal.PtrToStructure<MINMAXINFO>(lParam);
                    minMaxInfo.ptMinTrackSize.x = (int)(MinWindowWidth * scalingFactor);
                    minMaxInfo.ptMaxTrackSize.x = (int)(MaxWindowWidth * scalingFactor);
                    minMaxInfo.ptMinTrackSize.y = (int)(MinWindowHeight * scalingFactor);
                    minMaxInfo.ptMaxTrackSize.y = (int)(MaxWindowHeight * scalingFactor);

                    Marshal.StructureToPtr(minMaxInfo, lParam, true);
                    break;

            }
            return CallWindowProc(oldWndProc, hWnd, Msg, wParam, lParam);
        }

        //private static IntPtr SetWindowLongPtr(IntPtr hWnd, WindowLongIndexFlags nIndex, WinProc newProc)
        //{
        //    if (IntPtr.Size == 8)
        //        return SetWindowLongPtr64(hWnd, nIndex, newProc);
        //    else
        //        return new IntPtr(SetWindowLong32(hWnd, nIndex, newProc));
        //}

        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        [Flags]
        private enum WindowLongIndexFlags : int
        {
            GWL_WNDPROC = -4,
        }

        private enum WindowMessage : int
        {
            WM_GETMINMAXINFO = 0x0024,
        }
       


        [DllImport("User32.dll")]
        internal static extern int GetDpiForWindow(IntPtr hwnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong32(IntPtr hWnd, WindowLongIndexFlags nIndex, WinProc newProc);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, WindowLongIndexFlags nIndex, WinProc newProc);

        [DllImport("user32.dll")]
        private static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, WindowMessage Msg, IntPtr wParam, IntPtr lParam);

        public static int MinWindowWidth { get; set; } = 900;
        public static int MaxWindowWidth { get; set; } = 1800;
        public static int MinWindowHeight { get; set; } = 600;
        public static int MaxWindowHeight { get; set; } = 1600;


        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(
      IntPtr hWnd,
      int X,
      int Y,
      int nWidth,
      int nHeight,
      bool bRepaint);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowPos(
          IntPtr hWnd,
          int hWndInsertAfter,
          int x,
          int Y,
          int cx,
          int cy,
          int wFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(
#nullable enable
        string lp1, string lp2);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindWindowEx(
          IntPtr hwndParent,
          IntPtr hwndChildAfter,
          string lpszClass,
          string lpszWindow);

        private IntPtr SelectedHandle
        {
            get => this.gvProcesses.SelectedRows.Count > 0 ? (IntPtr)this.gvProcesses.SelectedRows[0].Cells["Handle"].Value : 0;
        }

        private List<IntPtr> GetAllChildrenWindowHandles(IntPtr hParent, int maxCount)
        {
            List<IntPtr> childrenWindowHandles = new List<IntPtr>();
            int num = 0;
            IntPtr hwndChildAfter = IntPtr.Zero;
            IntPtr zero = IntPtr.Zero;
            for (; num < maxCount; ++num)
            {
                IntPtr windowEx = frmMain.FindWindowEx(hParent, hwndChildAfter, (string)null, (string)null);
                if (windowEx != IntPtr.Zero)
                {
                    childrenWindowHandles.Add(windowEx);
                    hwndChildAfter = windowEx;
                }
                else
                    break;
            }
            return childrenWindowHandles;
        }

        private IntPtr GetFirstButton(IntPtr mainWindowHandle)
        {
            foreach (IntPtr childrenWindowHandle in this.GetAllChildrenWindowHandles(mainWindowHandle, 200))
            {
                IntPtr windowEx = frmMain.FindWindowEx(childrenWindowHandle, IntPtr.Zero, "Button", (string)null);
                if (windowEx != IntPtr.Zero)
                    return windowEx;
            }
            return IntPtr.Zero;
        }


        public frmMain()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gvProcesses.AutoGenerateColumns = false;
            RefreshProcesses();
        }

        private void RefreshProcesses()
        {
            //this.processs = System.Diagnostics.Process.GetProcessesByName("ms-teams");
            this.processs = System.Diagnostics.Process.GetProcessesByName("firefox");

            //  HwndSource.FromHwnd(_windowHandle).AddHook(HwndSourceHookHandler)

            
            this.gvProcesses.DataSource = (object)this.processs;
            return;

            IntPtr hWnd = this.SelectedHandle;
            //Application.AddMessageFilter(new MyMessageFilter());


            var dpi = GetDpiForWindow(hWnd);
            var scalingFactor = (float)dpi / 96;

            var lParam = IntPtr.Zero;

            //var minMaxInfo = Marshal.PtrToStructure<MINMAXINFO>(0);
            //minMaxInfo.ptMinTrackSize.x = (int)(MinWindowWidth * scalingFactor);
            //minMaxInfo.ptMaxTrackSize.x = (int)(MaxWindowWidth * scalingFactor);
            //minMaxInfo.ptMinTrackSize.y = (int)(MinWindowHeight * scalingFactor);
            //minMaxInfo.ptMaxTrackSize.y = (int)(MaxWindowHeight * scalingFactor);

            //Marshal.StructureToPtr(minMaxInfo, lParam, true);

            //PostMessage(hWnd, WM_GETMINMAXINFO, IntPtr.Zero, IntPtr.Zero);


            newWndProc = new WinProc(WndProc);
            oldWndProc = SetWindowLongPtr64(SelectedHandle, WindowLongIndexFlags.GWL_WNDPROC, newWndProc);

        }

        private void btnRefreshProcesses_Click(object sender, EventArgs e)
        {
            RefreshProcesses();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            IntPtr selectedHandle = this.SelectedHandle;
            frmMain.ShowWindow(selectedHandle, 1U);
            frmMain.SetForegroundWindow(selectedHandle);
            this.width = Screen.PrimaryScreen.Bounds.Width;
            this.height = Screen.PrimaryScreen.Bounds.Height;
            this.x = 0;
            this.y = 0;
            this.MoveWindow();
        }
        private void MoveWindow()
        {
            frmMain.MoveWindow(this.SelectedHandle, this.y, this.x, this.width, this.height, true);
            //SetWindowPos(this.SelectedHandle, 0, this.y, this.x, y + 100, x + 100, 0);
            Label lbX = this.lbX;
            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
            interpolatedStringHandler.AppendLiteral("X: ");
            interpolatedStringHandler.AppendFormatted<int>(this.x);
            string stringAndClear1 = interpolatedStringHandler.ToStringAndClear();
            lbX.Text = stringAndClear1;
            Label lbY = this.lbY;
            interpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
            interpolatedStringHandler.AppendLiteral("Y: ");
            interpolatedStringHandler.AppendFormatted<int>(this.y);
            string stringAndClear2 = interpolatedStringHandler.ToStringAndClear();
            lbY.Text = stringAndClear2;
            Label lbWidth = this.lbWidth;
            interpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
            interpolatedStringHandler.AppendLiteral("Width: ");
            interpolatedStringHandler.AppendFormatted<int>(this.width);
            string stringAndClear3 = interpolatedStringHandler.ToStringAndClear();
            lbWidth.Text = stringAndClear3;
            Label lbHeight = this.lbHeight;
            interpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
            interpolatedStringHandler.AppendLiteral("Height: ");
            interpolatedStringHandler.AppendFormatted<int>(this.height);
            string stringAndClear4 = interpolatedStringHandler.ToStringAndClear();
            lbHeight.Text = stringAndClear4;
        }

        private void ShowHideContent()
        {
            foreach (IntPtr childrenWindowHandle in this.GetAllChildrenWindowHandles((IntPtr)this.gvProcesses.SelectedRows[0].Cells["Handle"].Value, 200))
            {
                frmMain.FindWindowEx(childrenWindowHandle, IntPtr.Zero, "Panel", (string)null);
                frmMain.ShowWindow(childrenWindowHandle, this.action);
            }
        }

        private void button1_Click_1(object sender, EventArgs e) => this.action = 0U;

        private void btSetShow_Click(object sender, EventArgs e) => this.action = 4U;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btMoveTop_Click(object sender, EventArgs e)
        {
            this.x -= 10;
            this.MoveWindow();
        }

        private void btMoveButtom_Click(object sender, EventArgs e)
        {
            this.x += 10;
            this.MoveWindow();
        }

        private void btMoveLeft_Click(object sender, EventArgs e)
        {
            this.y -= 10;
            this.MoveWindow();
        }

        private void btMoveRight_Click(object sender, EventArgs e)
        {
            this.y += 10;
            this.MoveWindow();
        }

        private void btWidthUp_Click(object sender, EventArgs e)
        {
            this.width += 10;
            this.MoveWindow();
        }

        private void btWidthDown_Click(object sender, EventArgs e)
        {
            this.width -= 10;
            this.MoveWindow();
        }

        private void btHeightDown_Click(object sender, EventArgs e)
        {
            this.height -= 10;
            this.MoveWindow();
        }

        private void btHeightUp_Click(object sender, EventArgs e)
        {
            this.height += 10;
            this.MoveWindow();
        }

        private void btTeamsFullscreen_Click(object sender, EventArgs e)
        {
            /*
            if (this.fsNormal.Checked)
            {
                this.y = 0;
                this.x = -120;
                this.width = 1920;
                this.height = 1210;
            }
            if (this.fsZoomed.Checked)
            {
                this.y = -10;
                this.x = -160;
                this.width = 2000;
                this.height = 1240;
            }
            */
            this.y = -90;
            this.x = -230;
            this.width = 2020;
            this.height = 1320;
            

            this.MoveWindow();
        }
    }
}
