using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            BlackAero aero = new BlackAero();
            Thread Threads = new Thread(new ThreadStart(Hooks));
            Threads.Start();
            aero.StartBlackAero();

            if(IniFile.ReadIniData("rightwin10", "value", null, System.IO.Directory.GetCurrentDirectory() + "\\config.ini") == "true") { checkBox1.Checked = true; }
            if (IniFile.ReadIniData("output", "value", null, System.IO.Directory.GetCurrentDirectory() + "\\config.ini") == "true") { checkBox2.Checked = true;}
            if (IniFile.ReadIniData("tray", "value", null, System.IO.Directory.GetCurrentDirectory() + "\\config.ini") == "true")
            {
                checkBox3.Checked = true;

                ShowInTaskbar = false;
                WindowState = FormWindowState.Minimized;
                Visible = false;
                notifyIcon1.Visible = true;
                Hide();
            }
        }
        //钩子消息
        public const int WM_LBUTTONDOWN = 0x201; //按下鼠标左键
        public const int WM_LBUTTONUP = 0x202; //释放鼠标左键
        public const int WM_LBUTTONDBLCLK = 0x203;//双击鼠标左键
        public const int WM_RBUTTONDOWN = 0x204;//按下鼠标右键
        public const int WM_RBUTTONUP = 0x205;//释放鼠标右键
        public const int WM_RBUTTONDBLCLK = 0x206; //双击鼠标右键
        public const int WM_MBUTTONDOWN = 0x207; //按下鼠标中键
        public const int WM_MBUTTONUP = 0x208;//释放鼠标中键
        public const int WM_MBUTTONDBLCLK = 0x209;//双击鼠标中键

        public void Hooks()
        {
            Hook hooks = new Hook();
             int HookHandle = hooks.SetHook();
             Addtext("State:" + HookHandle.ToString());
             if (HookHandle > 0)
             {
                 Addtext("Hook explorer.exe");
                 hooks.Msgs += Mh_msg;
             }
             else { Addtext("Error: Hook initialization failed"); }
            Win32Api.tagMSG Msgs;
            while (Win32Api.GetMessage(out Msgs, IntPtr.Zero, 0, 0) > 0)
            {
                Win32Api.TranslateMessage(ref Msgs);
                Win32Api.DispatchMessage(ref Msgs);
            }
        }
        //消息处理
        Thread CycleThread;
        void Mh_msg(object sender, MouseEventArgs Msg)
        {
            if (Msg.Clicks == WM_RBUTTONUP)//松开弹出右键菜单 所以找它
            {
                Addtext("Hook msg id: WM_RBUTTONUP");
                //线程启动
                if (CycleThread !=null)
                {
                   CycleThread.Abort();
                }
                Thread AeroThread = new Thread(new ThreadStart(addAero));
                AeroThread.Start();
            }
            if (Msg.Clicks == WM_LBUTTONDOWN)//菜单被点击就会关闭 所以找它
            {
                if (CycleThread != null)
                {
                    CycleThread.Abort();
                }
                //线程启动
                Thread AeroThread = new Thread(new ThreadStart(judge));
                AeroThread.Start();
                Thread LeftThread = new Thread(new ThreadStart(judge2));
                LeftThread.Start();
            }
        }
        //第一次右键出现菜单的主菜单句柄
        IntPtr FirstHandle = IntPtr.Zero;
        Aero aero = new Aero();
        private void addAero()
        {   //右键菜单弹出有延迟 200毫秒就差不多正好
            Thread.Sleep(200);
            //右键菜单只有一个默认类名 没有标题
            IntPtr MenuHandle = Win32Api.FindWindowExA(IntPtr.Zero, IntPtr.Zero, "#32768", string.Empty);
            if (FirstHandle == IntPtr.Zero) { FirstHandle = MenuHandle; }//初始化
            Addtext("ClassNmae: #32768 Handle: " + MenuHandle.ToString());
            //菜单的宽高
            Win32Api.RECT rect = new Win32Api.RECT();
            Win32Api.GetClientRect(MenuHandle, ref rect);
            Addtext("Window Wide: " + rect.right.ToString() + " High: " + rect.bottom.ToString());
            //再小应该就不是菜单了
            if (rect.right > 100 && rect.bottom > 20)
            {
                Addtext("Contextmenu");
                if (checkBox1.Checked)
                {
                    aero.LoadAero2(MenuHandle);
                }
                else { aero.LoadAero1(MenuHandle); }
                Addtext("StartAero");
            }
            //子菜单循环进程
            CycleThread = new Thread(new ThreadStart(Cycle));
            CycleThread.Start();
            
        }
        //刷新菜单
        //存放上一个句柄
        IntPtr Previous = IntPtr.Zero;
        private void RefreshAero()
        {   //子菜单很快10毫秒就够
            Thread.Sleep(10);
            //子菜单也只有一个默认类名 没有标题
            IntPtr MenuHandle = Win32Api.FindWindowExA(IntPtr.Zero, IntPtr.Zero, "#32768", string.Empty);
            if (FirstHandle == IntPtr.Zero) { FirstHandle = MenuHandle; }//初始化
            //菜单的宽高
            Win32Api.RECT rect = new Win32Api.RECT();
            Win32Api.GetClientRect(MenuHandle, ref rect);
            //再小应该就不是菜单了
            if (Previous != MenuHandle && rect.right > 100 && rect.bottom > 20)
            {
                Addtext("New Submenu");
                if (checkBox1.Checked)
                {
                    aero.LoadAero2(MenuHandle);
                }
                else { aero.LoadAero1(MenuHandle); }
                Addtext("StartAero");
            }
            Previous = MenuHandle;
        }
        private void judge()
        {   //关闭也很快10毫秒足够
            Thread.Sleep(10);
            Win32Api.RECT rect = new Win32Api.RECT();
            Win32Api.GetClientRect(FirstHandle, ref rect);
            //那就不存在的 都是0
            if (rect.left == 0 && rect.top == 0 && rect.right == 0 && rect.bottom == 0)
            {   //清空，初始化
                FirstHandle = IntPtr.Zero;
            }
        }
        private void judge2()
        {
            Thread.Sleep(100);
            IntPtr MenuHandle = Win32Api.FindWindowExA(IntPtr.Zero, IntPtr.Zero, "#32768", string.Empty);
            if (MenuHandle != IntPtr.Zero)
            {   //左键点击弹出的菜单
                Addtext("DiscoveryMenu");
                Thread AeroThread = new Thread(new ThreadStart(addAero));
                AeroThread.Start();
            }
        }
        //循环查找子窗口
        public void Cycle()
        {
            while (true)
            {   //200毫秒一次 和弹出菜单速度一样
                Thread.Sleep(200);
                judge();
                if (FirstHandle != IntPtr.Zero)
                {   //启动检测子菜单线程
                    RefreshAero();
                }
            }
        }
        //添加输出文本
        private void Addtext(string text)
        {
            if (checkBox2.Checked)
            {
                Invoke((EventHandler)(delegate
                {
                    textBox1.Text = textBox1.Text + "[" + DateTime.Now.ToLongTimeString().ToString() + "]> " + text + "\r\n";
                }));
            }
        }

        //以下是窗口事件
        private void textBox1_TextChanged(object sender, EventArgs e)
        {   //自动清理和滚动
            if (textBox1.Text.Split("\r\n".ToCharArray()).Length > 200)
            {
                textBox1.Text = string.Empty;
            }
            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {   //最小化托盘窗口
            WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
            Hide();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {   //显示窗口
            ShowInTaskbar = true;
            Visible = true;
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Hook hook = new Hook();
            hook.UnHook();
            Environment.Exit(System.Environment.ExitCode);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            win10APIToolStripMenuItem1.Checked = checkBox1.Checked;
            if (checkBox1.Checked) {
                IniFile.WriteIniData("rightwin10", "value", "true", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
            } else { IniFile.WriteIniData("rightwin10", "value", "false", System.IO.Directory.GetCurrentDirectory() + "\\config.ini"); }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            OutputToolStripMenuItem.Checked = checkBox2.Checked;
            if (checkBox2.Checked){
                IniFile.WriteIniData("output", "value", "true", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
            } else { IniFile.WriteIniData("output", "value", "false", System.IO.Directory.GetCurrentDirectory() + "\\config.ini"); }
        }

        private void win10APIToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (win10APIToolStripMenuItem1.Checked)
            {
                IniFile.WriteIniData("rightwin10", "value", "false", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
                win10APIToolStripMenuItem1.Checked = false;
                checkBox1.Checked = false;
            }
            else
            {
                IniFile.WriteIniData("rightwin10", "value", "true", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
                win10APIToolStripMenuItem1.Checked = true;
                checkBox1.Checked = true;
            }
        }
        private void OutputToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (OutputToolStripMenuItem.Checked)
            {
                IniFile.WriteIniData("output", "value", "false", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
                OutputToolStripMenuItem.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                IniFile.WriteIniData("output", "value", "false", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
                OutputToolStripMenuItem.Checked = true;
                checkBox2.Checked = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                notifyIcon1.Visible = true;
                Hide();
                return;
            }
        }

        private void aeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            Tray.Checked = checkBox3.Checked;
            if (checkBox3.Checked)
            {
                IniFile.WriteIniData("tray", "value", "true", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
            }
            else { IniFile.WriteIniData("tray", "value", "false", System.IO.Directory.GetCurrentDirectory() + "\\config.ini"); }
        }

        private void Tray_Click(object sender, EventArgs e)
        {
            if (Tray.Checked)
            {
                IniFile.WriteIniData("tray", "value", "false", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
                win10APIToolStripMenuItem1.Checked = false;
                checkBox1.Checked = false;
            }
            else
            {
                IniFile.WriteIniData("tray", "value", "true", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
                win10APIToolStripMenuItem1.Checked = true;
                checkBox1.Checked = true;
            }
        }
    }
}
