namespace GUI.UI
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开性能监控ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在桌面显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.随程序启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.不随程序启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出监视器ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.在任务栏显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.随程序启动ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.不随程序运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出监视器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部随程序运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.都不随程序运行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出所有监视器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开主界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.访问官网ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlCenter.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(41)))), ((int)(((byte)(52)))));
            this.pnlTop.Controls.Add(this.button8);
            this.pnlTop.Controls.Add(this.pnlCenter);
            this.pnlTop.Controls.Add(this.button1);
            this.pnlTop.Controls.Add(this.button2);
            this.pnlTop.Controls.Add(this.button3);
            this.pnlTop.Controls.Add(this.button4);
            this.pnlTop.Controls.Add(this.button5);
            this.pnlTop.Controls.Add(this.button6);
            this.pnlTop.Controls.Add(this.button7);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 38);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1365, 712);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BackgroundImage = global::GUI.Properties.Resources.pictureBox1_Image;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.Linen;
            this.button8.Location = new System.Drawing.Point(16, 15);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(208, 78);
            this.button8.TabIndex = 1;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.Gray;
            this.pnlCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCenter.Controls.Add(this.label1);
            this.pnlCenter.Location = new System.Drawing.Point(241, 0);
            this.pnlCenter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1123, 712);
            this.pnlCenter.TabIndex = 2;
            this.pnlCenter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCenter_Paint);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(16, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(929, 102);
            this.label1.TabIndex = 0;
            this.label1.Text = "    欢迎使用由WS团队开发的软件";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::GUI.Properties.Resources.toolItem10_Image;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Linen;
            this.button1.Location = new System.Drawing.Point(33, 100);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "电脑体检";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::GUI.Properties.Resources.toolItem11_Image;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(33, 188);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 56);
            this.button2.TabIndex = 0;
            this.button2.Text = "木马查杀";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::GUI.Properties.Resources.toolItem12_Image;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(33, 275);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 56);
            this.button3.TabIndex = 0;
            this.button3.Text = "检查更新";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::GUI.Properties.Resources.toolItem14_Image;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(33, 362);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(147, 56);
            this.button4.TabIndex = 3;
            this.button4.Text = "垃圾清理";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::GUI.Properties.Resources.toolItem15_Image;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(33, 450);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(147, 56);
            this.button5.TabIndex = 4;
            this.button5.Text = "优化加速";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BackgroundImage = global::GUI.Properties.Resources.toolItem18_Image;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(33, 538);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(147, 56);
            this.button6.TabIndex = 5;
            this.button6.Text = "工具箱";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BackgroundImage = global::GUI.Properties.Resources.toolItem17_Image;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(33, 625);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(147, 56);
            this.button7.TabIndex = 7;
            this.button7.Text = "软件管家";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Wsecurity";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开性能监控ToolStripMenuItem,
            this.打开主界面ToolStripMenuItem,
            this.访问官网ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 128);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 打开性能监控ToolStripMenuItem
            // 
            this.打开性能监控ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在桌面显示ToolStripMenuItem,
            this.在任务栏显示ToolStripMenuItem,
            this.全部随程序运行ToolStripMenuItem,
            this.都不随程序运行ToolStripMenuItem,
            this.退出所有监视器ToolStripMenuItem});
            this.打开性能监控ToolStripMenuItem.Name = "打开性能监控ToolStripMenuItem";
            this.打开性能监控ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.打开性能监控ToolStripMenuItem.Text = "打开性能监控";
            this.打开性能监控ToolStripMenuItem.Click += new System.EventHandler(this.打开性能监控ToolStripMenuItem_Click);
            // 
            // 在桌面显示ToolStripMenuItem
            // 
            this.在桌面显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.随程序启动ToolStripMenuItem,
            this.不随程序启动ToolStripMenuItem,
            this.退出监视器ToolStripMenuItem1});
            this.在桌面显示ToolStripMenuItem.Name = "在桌面显示ToolStripMenuItem";
            this.在桌面显示ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.在桌面显示ToolStripMenuItem.Text = "在桌面显示";
            this.在桌面显示ToolStripMenuItem.Click += new System.EventHandler(this.在桌面显示ToolStripMenuItem_Click);
            // 
            // 随程序启动ToolStripMenuItem
            // 
            this.随程序启动ToolStripMenuItem.Name = "随程序启动ToolStripMenuItem";
            this.随程序启动ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.随程序启动ToolStripMenuItem.Text = "随程序运行";
            this.随程序启动ToolStripMenuItem.Click += new System.EventHandler(this.随程序启动ToolStripMenuItem_Click);
            // 
            // 不随程序启动ToolStripMenuItem
            // 
            this.不随程序启动ToolStripMenuItem.Name = "不随程序启动ToolStripMenuItem";
            this.不随程序启动ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.不随程序启动ToolStripMenuItem.Text = "不随程序运行";
            this.不随程序启动ToolStripMenuItem.Click += new System.EventHandler(this.不随程序启动ToolStripMenuItem_Click);
            // 
            // 退出监视器ToolStripMenuItem1
            // 
            this.退出监视器ToolStripMenuItem1.Name = "退出监视器ToolStripMenuItem1";
            this.退出监视器ToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.退出监视器ToolStripMenuItem1.Text = "退出";
            this.退出监视器ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // 在任务栏显示ToolStripMenuItem
            // 
            this.在任务栏显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.随程序启动ToolStripMenuItem1,
            this.不随程序运行ToolStripMenuItem,
            this.退出监视器ToolStripMenuItem});
            this.在任务栏显示ToolStripMenuItem.Name = "在任务栏显示ToolStripMenuItem";
            this.在任务栏显示ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.在任务栏显示ToolStripMenuItem.Text = "在任务栏显示";
            this.在任务栏显示ToolStripMenuItem.Click += new System.EventHandler(this.在任务栏显示ToolStripMenuItem_Click);
            // 
            // 随程序启动ToolStripMenuItem1
            // 
            this.随程序启动ToolStripMenuItem1.Name = "随程序启动ToolStripMenuItem1";
            this.随程序启动ToolStripMenuItem1.Size = new System.Drawing.Size(182, 26);
            this.随程序启动ToolStripMenuItem1.Text = "随程序运行";
            this.随程序启动ToolStripMenuItem1.Click += new System.EventHandler(this.随程序启动ToolStripMenuItem1_Click);
            // 
            // 不随程序运行ToolStripMenuItem
            // 
            this.不随程序运行ToolStripMenuItem.Name = "不随程序运行ToolStripMenuItem";
            this.不随程序运行ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.不随程序运行ToolStripMenuItem.Text = "不随程序运行";
            this.不随程序运行ToolStripMenuItem.Click += new System.EventHandler(this.不随程序运行ToolStripMenuItem_Click);
            // 
            // 退出监视器ToolStripMenuItem
            // 
            this.退出监视器ToolStripMenuItem.Name = "退出监视器ToolStripMenuItem";
            this.退出监视器ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.退出监视器ToolStripMenuItem.Text = "退出";
            this.退出监视器ToolStripMenuItem.Click += new System.EventHandler(this.退出监视器ToolStripMenuItem_Click);
            // 
            // 全部随程序运行ToolStripMenuItem
            // 
            this.全部随程序运行ToolStripMenuItem.Name = "全部随程序运行ToolStripMenuItem";
            this.全部随程序运行ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.全部随程序运行ToolStripMenuItem.Text = "都随程序运行";
            this.全部随程序运行ToolStripMenuItem.Click += new System.EventHandler(this.全部随程序运行ToolStripMenuItem_Click);
            // 
            // 都不随程序运行ToolStripMenuItem
            // 
            this.都不随程序运行ToolStripMenuItem.Name = "都不随程序运行ToolStripMenuItem";
            this.都不随程序运行ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.都不随程序运行ToolStripMenuItem.Text = "都不随程序运行";
            this.都不随程序运行ToolStripMenuItem.Click += new System.EventHandler(this.都不随程序运行ToolStripMenuItem_Click);
            // 
            // 退出所有监视器ToolStripMenuItem
            // 
            this.退出所有监视器ToolStripMenuItem.Name = "退出所有监视器ToolStripMenuItem";
            this.退出所有监视器ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.退出所有监视器ToolStripMenuItem.Text = "退出所有";
            this.退出所有监视器ToolStripMenuItem.Click += new System.EventHandler(this.退出所有监视器ToolStripMenuItem_Click);
            // 
            // 打开主界面ToolStripMenuItem
            // 
            this.打开主界面ToolStripMenuItem.Name = "打开主界面ToolStripMenuItem";
            this.打开主界面ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.打开主界面ToolStripMenuItem.Text = "打开主界面";
            this.打开主界面ToolStripMenuItem.Click += new System.EventHandler(this.打开主界面ToolStripMenuItem_Click);
            // 
            // 访问官网ToolStripMenuItem
            // 
            this.访问官网ToolStripMenuItem.Name = "访问官网ToolStripMenuItem";
            this.访问官网ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.访问官网ToolStripMenuItem.Text = "访问官网";
            this.访问官网ToolStripMenuItem.Click += new System.EventHandler(this.访问官网ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.退出ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.退出ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.退出ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "first.jpg");
            this.imageList1.Images.SetKeyName(1, "second.jpg");
            this.imageList1.Images.SetKeyName(2, "beijing.jpg");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1365, 750);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "智安";
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.pnlTop.ResumeLayout(false);
            this.pnlCenter.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开性能监控ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开主界面ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ToolStripMenuItem 在桌面显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在任务栏显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 访问官网ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 随程序启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 不随程序启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 随程序启动ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 不随程序运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部随程序运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 都不随程序运行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出监视器ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 退出监视器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出所有监视器ToolStripMenuItem;
    }
}

