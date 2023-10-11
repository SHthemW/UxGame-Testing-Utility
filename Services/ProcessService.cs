using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UxGame_Testing_Utility.Services
{
    internal sealed class ProcessService
    {
        public static void KillWindow(string title)
        {
            //按照MessageBox的标题，找到MessageBox的窗口
            IntPtr ptr = FindWindow(null!, title);
            if (ptr != IntPtr.Zero)
                _ = PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero); //找到则关闭MessageBox窗口
        }
        public static void Startup(string exe, string filePath)
        {
            Process process = new()
            {
                StartInfo = new ProcessStartInfo(exe, filePath)
            };
            process.Start();
        }

        private const int WM_CLOSE = 0x10;

        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Unicode)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    }
}
