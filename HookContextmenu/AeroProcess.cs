using System.Diagnostics;

namespace WindowsFormsApp1
{
    internal class AeroProcess
    {
        public void ProcessAeros(string name)
        {
            try
            {   //同进程名的所有窗口
                Process[] localByName = Process.GetProcessesByName(name);
                for (int i = 0; i < localByName.Length; i++)
                {
                    BlackAero aero = new BlackAero();
                    aero.GetMainWindowHandle(localByName[i].Id);
                }

            }
            catch { /*进程不存在*/}
        }
    }
}