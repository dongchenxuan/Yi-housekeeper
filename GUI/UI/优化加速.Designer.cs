namespace GUI.UI
{
    partial class 优化加速
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button Scan_bt;
            System.Windows.Forms.Button button1;
            System.Windows.Forms.Button button2;
            this.top = new System.Windows.Forms.Label();
            this.top_panel = new System.Windows.Forms.Panel();
            this.Scan_panel = new System.Windows.Forms.Panel();
            this.Scan_loading = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            Scan_bt = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            this.top_panel.SuspendLayout();
            this.Scan_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scan_loading)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scan_bt
            // 
            Scan_bt.BackColor = System.Drawing.Color.LimeGreen;
            Scan_bt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            Scan_bt.FlatAppearance.BorderSize = 0;
            Scan_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Scan_bt.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            Scan_bt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            Scan_bt.Location = new System.Drawing.Point(113, 152);
            Scan_bt.Name = "Scan_bt";
            Scan_bt.Size = new System.Drawing.Size(219, 78);
            Scan_bt.TabIndex = 2;
            Scan_bt.Text = "一键扫描";
            Scan_bt.UseVisualStyleBackColor = false;
            Scan_bt.Click += new System.EventHandler(this.Scan_bt_Click);
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.LimeGreen;
            button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            button1.Location = new System.Drawing.Point(217, 28);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(147, 54);
            button1.TabIndex = 3;
            button1.Text = "一键加速";
            button1.UseVisualStyleBackColor = false;
            button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.Gainsboro;
            button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            button2.Location = new System.Drawing.Point(26, 40);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(68, 33);
            button2.TabIndex = 4;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // top
            // 
            this.top.AutoSize = true;
            this.top.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.top.Location = new System.Drawing.Point(4, 10);
            this.top.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(660, 70);
            this.top.TabIndex = 1;
            this.top.Text = "常加速，电脑更给力";
            // 
            // top_panel
            // 
            this.top_panel.Controls.Add(Scan_bt);
            this.top_panel.Controls.Add(this.top);
            this.top_panel.Location = new System.Drawing.Point(164, 173);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(751, 311);
            this.top_panel.TabIndex = 2;
            this.top_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.top_panel_Paint);
            // 
            // Scan_panel
            // 
            this.Scan_panel.BackColor = System.Drawing.Color.White;
            this.Scan_panel.Controls.Add(this.Scan_loading);
            this.Scan_panel.Controls.Add(this.label1);
            this.Scan_panel.Controls.Add(this.panel1);
            this.Scan_panel.Controls.Add(this.treeView1);
            this.Scan_panel.Location = new System.Drawing.Point(74, 67);
            this.Scan_panel.Name = "Scan_panel";
            this.Scan_panel.Size = new System.Drawing.Size(980, 570);
            this.Scan_panel.TabIndex = 3;
            this.Scan_panel.Visible = false;
            // 
            // Scan_loading
            // 
            this.Scan_loading.Image = global::GUI.Properties.Resources.indicator_mozilla_yellow1;
            this.Scan_loading.Location = new System.Drawing.Point(47, 48);
            this.Scan_loading.Name = "Scan_loading";
            this.Scan_loading.Size = new System.Drawing.Size(37, 33);
            this.Scan_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Scan_loading.TabIndex = 6;
            this.Scan_loading.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(90, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 43);
            this.label1.TabIndex = 4;
            this.label1.Text = "正在扫描加速项...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(button2);
            this.panel1.Controls.Add(button1);
            this.panel1.Location = new System.Drawing.Point(539, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 100);
            this.panel1.TabIndex = 7;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Indent = 19;
            this.treeView1.ItemHeight = 40;
            this.treeView1.Location = new System.Drawing.Point(47, 147);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(882, 378);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // 优化加速
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1101, 672);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.Scan_panel);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "优化加速";
            this.Text = "优化加速";
            this.Load += new System.EventHandler(this.优化加速_Load);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            this.Scan_panel.ResumeLayout(false);
            this.Scan_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scan_loading)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label top;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel Scan_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox Scan_loading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imageList1;
    }
}