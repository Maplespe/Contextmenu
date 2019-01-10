using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class BlackAero
    {   //读配置
        public static string Content = IniFile.ReadIniData("Text", "value", null, System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
        public static string Times = IniFile.ReadIniData("Refresh", "value", null, System.IO.Directory.GetCurrentDirectory() + "\\config.ini");


        static bool[] State = new bool[2] { false, true };

        public void StartBlackAero()
        {
            if (IniFile.ReadIniData("win10", "value", null, System.IO.Directory.GetCurrentDirectory() + "\\config.ini") == "true")
            {
                State[0] = true;
            }

            if ((int.Parse(Times) / 100) < 15 && (int.Parse(Times) / 100) > 1)
            {
                Times = "1000";
            }

            if (Content == string.Empty)
            {   //默认进程
                Content = "explorer.exe\r\n任务管理器\r\ncmd.exe";
            }
            Thread BlackAeroThread = new Thread(new ThreadStart(AeroBlackCycle));
            BlackAeroThread.Start();

        }
        //刷新配置
        Aero aero = new Aero();
        static string name = string.Empty; 

        private void AeroBlackCycle()
        {
            while (State[1])
            {
                Thread.Sleep(int.Parse(Times));
                Content = Content.Replace("&n", "\r\n");
                string[] text = Content.Split(new char[] { '\n' });
                for (int i = 0; i < text.Length; i++)
                {
                    //取得每行内容
                    text[i] = text[i].Replace("\r", string.Empty);
                    if (text[i].IndexOf(".exe") != -1)
                    {
                        AeroProcess process = new AeroProcess();
                        process.ProcessAeros(text[i].Replace(".exe", string.Empty));
                        process = null;
                        GC.Collect();
                    } else
                    {
                        IntPtr IntPtrs = Win32Api.FindWindow(null, text[i]);
                        if (State[0])
                        {
                            aero.LoadAero2(IntPtrs);
                        }
                        else { aero.LoadAero1(IntPtrs); }
                    }
                }
            }
        }
        //枚举窗口句柄
        public  void GetMainWindowHandle(int processId)
        {
            Aero aero = new Aero();
            Win32Api.EnumWindows(new Win32Api.EnumWindowsProc((hWnd, lParam) =>
            {
                IntPtr PID;
                Win32Api.GetWindowThreadProcessId(hWnd, out PID);

                if (PID == lParam &&
                    Win32Api.IsWindowVisible(hWnd) &&
                    Win32Api.GetWindow(hWnd, Win32Api.GW_OWNER) == IntPtr.Zero)
                {
                    StringBuilder name = new StringBuilder(256);
                    StringBuilder ClassName = new StringBuilder(256);
                    Win32Api.GetWindowText(hWnd, name, 256);
                    Win32Api.GetClassName(hWnd, ClassName, 256);
                    if (ClassName.ToString() != "WorkerW")//防止Aero桌面
                    {
                    //所有窗口附加Aero
                        if (State[0])
                        {
                            aero.LoadAero2(hWnd);
                        }
                        else { aero.LoadAero1(hWnd); }
                    }
                }
                return true;
            }), new IntPtr(processId));
        }
    }
}
