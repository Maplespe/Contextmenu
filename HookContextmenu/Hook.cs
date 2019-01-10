using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Hook
    {
        //全局
        public const int WH_MOUSE_LL = 14;
        private int msg;

        private int Msg
        {
            get { return msg; }
            set {if (msg != value){msg = value;if (Msgs!= null){var e = new MouseEventArgs(MouseButtons.None, msg ,0 , 0, 0);Msgs(this, e);}} }}

        //委托
        public delegate void MouseMsg(object sender, MouseEventArgs e);
        public event MouseMsg Msgs;

        private int hHook;
        public Win32Api.HookProc hProc;
        public void MouseHook() { Msg = 0; }
        //安装钩子
        public int SetHook()
        {
            hProc = new Win32Api.HookProc(MouseHookProc);
            hHook = Win32Api.SetWindowsHookEx(WH_MOUSE_LL, hProc, IntPtr.Zero, 0);
            return hHook;
        }
        //卸载钩子
        public void UnHook()
        {
            Win32Api.UnhookWindowsHookEx(hHook);
        }
        //消息回调
        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            Debug.WriteLine(wParam.ToString());
            Win32Api.MouseHookStruct MyMouseHookStruct = (Win32Api.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32Api.MouseHookStruct));
            if (nCode < 0)
            {
                return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
            } else
            {
                Msg = wParam.ToInt32();
                return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
            }
        }
    }
}
