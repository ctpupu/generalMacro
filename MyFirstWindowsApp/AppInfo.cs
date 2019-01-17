using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppInfo
{
    class AppInfo
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        public static string GetForegroundAppName()
        {
            IntPtr hWnd = GetForegroundWindow();
            uint processId;
            GetWindowThreadProcessId(hWnd, out processId);
            Process p = Process.GetProcessById((int)processId);
            return p.ProcessName;
        }
    }
}
