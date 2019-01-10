using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //获取配置
            string Content = IniFile.ReadIniData("Text", "value", null, System.IO.Directory.GetCurrentDirectory() + "\\config.ini");

            if(BlackAero.Times != string.Empty)
            {
                trackBar1.Value = int.Parse(BlackAero.Times) / 100;
                label4.Text = BlackAero.Times + " Ms";
            }
            //替换行
            if (Content != string.Empty)
            {
                textBox1.Text = Content.Replace("&n", "\r\n");
            }
            //Win10API
            if (IniFile.ReadIniData("win10", "value", null, System.IO.Directory.GetCurrentDirectory() + "\\config.ini") == "true")
            {
                checkBox1.Checked = true;
            } else {
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   //保存配置
            string Text = textBox1.Text;
            bool returns = IniFile.WriteIniData("Text", "value", Text.Replace("\r\n", "&n"), System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
            if (checkBox1.Checked)
            {
                Form1 form = new Form1();

                returns = IniFile.WriteIniData("win10", "value", "true", System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
            }
            else { returns = IniFile.WriteIniData("win10", "value", "false", System.IO.Directory.GetCurrentDirectory() + "\\config.ini"); }

            int Ms = trackBar1.Value * 100;
            IniFile.WriteIniData("Refresh", "value", Ms.ToString(), System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
            BlackAero.Times = Ms.ToString();

            if (returns)
            {
                BlackAero.Content = IniFile.ReadIniData("Text", "value", null, System.IO.Directory.GetCurrentDirectory() + "\\config.ini");
                MessageBox.Show("保存配置成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else { MessageBox.Show("保存配置失败..", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label4.Text = (trackBar1.Value * 100).ToString() + " Ms";
        }
    }
}
