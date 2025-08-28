using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace HmAllKill
{
    /// <summary>
    /// 秀丸プロセスの管理・終了を行うユーティリティクラス
    /// </summary>
    public static class HidemaruProcessManager
    {
        private const string ProcessName = "hidemaru";
        private const uint WM_CLOSE = 0x0010;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        /// <summary>
        /// 秀丸のウィンドウにWM_CLOSEを送信し、自然終了を促す
        /// </summary>
        public static async Task RequestGracefulCloseAsync()
        {
            var handles = GetWindowHandlesByProcessName(ProcessName);
            if (handles.Count == 0)
                return;

            var tasks = new List<Task>();
            foreach (var hWnd in handles)
            {
                tasks.Add(Task.Run(() => SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero)));
            }
            await Task.WhenAll(tasks);
        }

        /// <summary>
        /// 秀丸プロセスを全て強制終了する
        /// </summary>
        public static void KillAll()
        {
            foreach (var p in Process.GetProcessesByName(ProcessName))
            {
                try { p.Kill(); } catch { /* ignore */ }
            }
        }

        /// <summary>
        /// 指定プロセス名のウィンドウハンドルを列挙
        /// </summary>
        private static List<IntPtr> GetWindowHandlesByProcessName(string processName)
        {
            var handles = new List<IntPtr>();
            var processIds = new HashSet<int>();
            foreach (var p in Process.GetProcessesByName(processName))
                processIds.Add(p.Id);

            EnumWindows((hWnd, lParam) =>
            {
                int pid;
                GetWindowThreadProcessId(hWnd, out pid);
                if (processIds.Contains(pid))
                    handles.Add(hWnd);
                return true;
            }, IntPtr.Zero);
            return handles;
        }
    }
}
