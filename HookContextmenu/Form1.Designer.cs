namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.右键菜单透明设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.win10APIToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Tray = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(425, 248);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "输出：";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(0, 247);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "最小化为托盘";
            this.toolTip1.SetToolTip(this.button1, "将程序最小化为托盘");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "黑色透明测试";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1,
            this.aeroToolStripMenuItem,
            this.右键菜单透明设置ToolStripMenuItem,
            this.ToolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 92);
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem1.Image")));
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem1.Text = "测试主窗口";
            this.ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // aeroToolStripMenuItem
            // 
            this.aeroToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aeroToolStripMenuItem.Image")));
            this.aeroToolStripMenuItem.Name = "aeroToolStripMenuItem";
            this.aeroToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.aeroToolStripMenuItem.Text = "BlackAero设置窗口";
            this.aeroToolStripMenuItem.Click += new System.EventHandler(this.aeroToolStripMenuItem_Click);
            // 
            // 右键菜单透明设置ToolStripMenuItem
            // 
            this.右键菜单透明设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.win10APIToolStripMenuItem1,
            this.OutputToolStripMenuItem,
            this.Tray});
            this.右键菜单透明设置ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("右键菜单透明设置ToolStripMenuItem.Image")));
            this.右键菜单透明设置ToolStripMenuItem.Name = "右键菜单透明设置ToolStripMenuItem";
            this.右键菜单透明设置ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.右键菜单透明设置ToolStripMenuItem.Text = "右键菜单透明选项";
            // 
            // win10APIToolStripMenuItem1
            // 
            this.win10APIToolStripMenuItem1.Name = "win10APIToolStripMenuItem1";
            this.win10APIToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.win10APIToolStripMenuItem1.Text = "Win10API";
            this.win10APIToolStripMenuItem1.Click += new System.EventHandler(this.win10APIToolStripMenuItem1_Click);
            // 
            // OutputToolStripMenuItem
            // 
            this.OutputToolStripMenuItem.Name = "OutputToolStripMenuItem";
            this.OutputToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.OutputToolStripMenuItem.Text = "显示输出";
            this.OutputToolStripMenuItem.Click += new System.EventHandler(this.OutputToolStripMenuItem_Click_1);
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem2.Image")));
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(183, 22);
            this.ToolStripMenuItem2.Text = "退出程序";
            this.ToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(331, 254);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 21);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Win10API";
            this.toolTip1.SetToolTip(this.checkBox1, "默认使用win7Aero (win8及以上系统需要安装AeroGlass,会使用AeroGlass配置)\r\nWin10API(除模糊度外其他与AeroGlass不" +
        "关联 可独立运行)");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox2.Location = new System.Drawing.Point(250, 254);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(75, 21);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "显示输出";
            this.toolTip1.SetToolTip(this.checkBox2, "显示Aero右键菜单进程的状态与输出\r\n操作过于频繁可能会导致卡顿\r\n输出到达200行会自动清理");
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(155, 254);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(87, 21);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "启动为托盘";
            this.toolTip1.SetToolTip(this.checkBox3, "启动程序时为直接托盘而不显示此窗口");
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // Tray
            // 
            this.Tray.Name = "Tray";
            this.Tray.Size = new System.Drawing.Size(180, 22);
            this.Tray.Text = "启动为托盘";
            this.Tray.Click += new System.EventHandler(this.Tray_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 281);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "右键菜单透明测试(输出)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ToolStripMenuItem 右键菜单透明设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem win10APIToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OutputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aeroToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem Tray;
    }
}

