namespace GUI
{
    partial class 托盘菜单
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
            this.label_taskbar = new System.Windows.Forms.Label();
            this.label_desktop = new System.Windows.Forms.Label();
            this.label_all = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_desktop = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.btn_taskbar = new System.Windows.Forms.Button();
            this.举报 = new System.Windows.Forms.Button();
            this.反馈 = new System.Windows.Forms.Button();
            this.退出 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_taskbar
            // 
            this.label_taskbar.AutoSize = true;
            this.label_taskbar.Location = new System.Drawing.Point(20, 141);
            this.label_taskbar.Name = "label_taskbar";
            this.label_taskbar.Size = new System.Drawing.Size(82, 15);
            this.label_taskbar.TabIndex = 2;
            this.label_taskbar.Text = "任务栏显示";
            // 
            // label_desktop
            // 
            this.label_desktop.AutoSize = true;
            this.label_desktop.Location = new System.Drawing.Point(20, 96);
            this.label_desktop.Name = "label_desktop";
            this.label_desktop.Size = new System.Drawing.Size(67, 15);
            this.label_desktop.TabIndex = 2;
            this.label_desktop.Text = "桌面显示";
            // 
            // label_all
            // 
            this.label_all.AutoSize = true;
            this.label_all.Location = new System.Drawing.Point(20, 186);
            this.label_all.Name = "label_all";
            this.label_all.Size = new System.Drawing.Size(67, 15);
            this.label_all.TabIndex = 2;
            this.label_all.Text = "退出所有";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GUI.Properties.Resources.notifytitleBackgroundImage;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 69);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btn_desktop
            // 
            this.btn_desktop.BackgroundImage = global::GUI.Properties.Resources.close1;
            this.btn_desktop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_desktop.FlatAppearance.BorderSize = 0;
            this.btn_desktop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_desktop.Location = new System.Drawing.Point(130, 86);
            this.btn_desktop.Name = "btn_desktop";
            this.btn_desktop.Size = new System.Drawing.Size(80, 32);
            this.btn_desktop.TabIndex = 1;
            this.btn_desktop.UseVisualStyleBackColor = true;
            this.btn_desktop.Click += new System.EventHandler(this.btn_desktop_Click);
            // 
            // btn_all
            // 
            this.btn_all.BackgroundImage = global::GUI.Properties.Resources.close1;
            this.btn_all.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_all.FlatAppearance.BorderSize = 0;
            this.btn_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_all.Location = new System.Drawing.Point(130, 176);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(80, 32);
            this.btn_all.TabIndex = 1;
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // btn_taskbar
            // 
            this.btn_taskbar.BackgroundImage = global::GUI.Properties.Resources.close1;
            this.btn_taskbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_taskbar.FlatAppearance.BorderSize = 0;
            this.btn_taskbar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_taskbar.Location = new System.Drawing.Point(130, 131);
            this.btn_taskbar.Name = "btn_taskbar";
            this.btn_taskbar.Size = new System.Drawing.Size(80, 32);
            this.btn_taskbar.TabIndex = 1;
            this.btn_taskbar.UseVisualStyleBackColor = true;
            this.btn_taskbar.Click += new System.EventHandler(this.btn_taskbar_Click);
            // 
            // 举报
            // 
            this.举报.BackColor = System.Drawing.Color.White;
            this.举报.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.举报.FlatAppearance.BorderSize = 0;
            this.举报.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.举报.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.举报.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.举报.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.举报.Image = global::GUI.Properties.Resources.jb_off;
            this.举报.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.举报.Location = new System.Drawing.Point(88, 221);
            this.举报.Name = "举报";
            this.举报.Size = new System.Drawing.Size(85, 25);
            this.举报.TabIndex = 0;
            this.举报.Text = "举报";
            this.举报.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.举报.UseVisualStyleBackColor = false;
            this.举报.Click += new System.EventHandler(this.举报_Click);
            this.举报.MouseEnter += new System.EventHandler(this.举报_MouseEnter);
            this.举报.MouseLeave += new System.EventHandler(this.举报_MouseLeave);
            // 
            // 反馈
            // 
            this.反馈.BackColor = System.Drawing.Color.White;
            this.反馈.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.反馈.FlatAppearance.BorderSize = 0;
            this.反馈.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.反馈.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.反馈.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.反馈.Font = new System.Drawing.Font("宋体", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.反馈.Image = global::GUI.Properties.Resources.fk_off;
            this.反馈.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.反馈.Location = new System.Drawing.Point(0, 221);
            this.反馈.Name = "反馈";
            this.反馈.Size = new System.Drawing.Size(85, 25);
            this.反馈.TabIndex = 0;
            this.反馈.Text = "反馈";
            this.反馈.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.反馈.UseVisualStyleBackColor = false;
            this.反馈.Click += new System.EventHandler(this.反馈_Click);
            this.反馈.MouseEnter += new System.EventHandler(this.反馈_MouseEnter);
            this.反馈.MouseLeave += new System.EventHandler(this.反馈_MouseLeave);
            // 
            // 退出
            // 
            this.退出.BackColor = System.Drawing.Color.White;
            this.退出.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.退出.FlatAppearance.BorderSize = 0;
            this.退出.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.退出.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.退出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.退出.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.退出.Image = global::GUI.Properties.Resources.tc_off;
            this.退出.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.退出.Location = new System.Drawing.Point(179, 221);
            this.退出.Name = "退出";
            this.退出.Size = new System.Drawing.Size(85, 25);
            this.退出.TabIndex = 0;
            this.退出.Text = "退出";
            this.退出.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.退出.UseVisualStyleBackColor = false;
            this.退出.Click += new System.EventHandler(this.退出_Click);
            this.退出.MouseEnter += new System.EventHandler(this.退出_MouseEnter);
            this.退出.MouseLeave += new System.EventHandler(this.退出_MouseLeave);
            // 
            // 托盘菜单
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(260, 250);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_desktop);
            this.Controls.Add(this.label_all);
            this.Controls.Add(this.label_taskbar);
            this.Controls.Add(this.btn_desktop);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_taskbar);
            this.Controls.Add(this.举报);
            this.Controls.Add(this.反馈);
            this.Controls.Add(this.退出);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "托盘菜单";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "托盘菜单";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.托盘菜单_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button 退出;
        private System.Windows.Forms.Button 反馈;
        private System.Windows.Forms.Button btn_taskbar;
        private System.Windows.Forms.Button btn_desktop;
        private System.Windows.Forms.Label label_taskbar;
        private System.Windows.Forms.Label label_desktop;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Label label_all;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button 举报;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}