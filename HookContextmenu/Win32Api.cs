using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsFormsApp1
{
    public class Win32Api
    {
        //坐标
        [StructLayout(LayoutKind.Sequential)]
        public class POINT

        {
            public int x;
            public int y;

        }
        //钩子结构
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }
        //矩形结构
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        public struct tagMSG
        {
            public int hwnd;
            public uint message;
            public int wParam;
            public long lParam;
            public uint time;
            public int pt;
        }
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        //安装钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        //卸载钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        //调用下一个钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
        //查找窗口句柄
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowExA(IntPtr hwndParent, IntPtr hwndChildAfter,string lpszClass,string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //取窗口矩形
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hwnd,ref RECT rect);

        internal const uint GW_OWNER = 4;
        //枚举进程窗口句柄
        internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern int GetWindowThreadProcessId(IntPtr hWnd, out IntPtr lpdwProcessId);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32", EntryPoint = "GetMessage")]
        public static extern int GetMessage(out tagMSG lpMsg,IntPtr hwnd,int wMsgFilterMin,int wMsgFilterMax);

        [DllImport("user32", EntryPoint = "DispatchMessage")]
        public static extern int DispatchMessage(ref tagMSG lpMsg);

        [DllImport("user32", EntryPoint = "TranslateMessage")]
        public static extern int TranslateMessage(ref tagMSG lpMsg);

        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(IntPtr hWnd,StringBuilder lpString,int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "GetClassName")]
        public static extern int GetClassName(IntPtr hWnd,StringBuilder lpString,int nMaxCont);
    }
}
