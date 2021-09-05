using System;
using System.Windows.Forms;

namespace BenNHControl
{
    partial class Skin
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
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnEXClose = new BenNHControl.ButtonEX();
            this.title = new System.Windows.Forms.Label();
            this.btnEXLogo = new BenNHControl.ButtonEX();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(116)))), ((int)(((byte)(151)))));
            this.titleBar.Controls.Add(this.btnEXClose);
            this.titleBar.Controls.Add(this.title);
            this.titleBar.Controls.Add(this.btnEXLogo);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(550, 30);
            this.titleBar.TabIndex = 0;
            this.titleBar.DoubleClick += new System.EventHandler(this.titleBar_DoubleClick);
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);
            // 
            // btnEXClose
            // 
            this.btnEXClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEXClose.AutoSize = true;
            this.btnEXClose.BackColorEX = System.Drawing.Color.Transparent;
            this.btnEXClose.BackColorLeave = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(116)))), ((int)(((byte)(151)))));
            this.btnEXClose.BackColorMove = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEXClose.BackgroundImage = global::BenNHControl.Properties.Resources.Close;
            this.btnEXClose.FontM = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEXClose.ImageDefault = null;
            this.btnEXClose.ImageLeave = null;
            this.btnEXClose.ImageMove = null;
            this.btnEXClose.Location = new System.Drawing.Point(524, 8);
            this.btnEXClose.Name = "btnEXClose";
            this.btnEXClose.Size = new System.Drawing.Size(20, 20);
            this.btnEXClose.TabIndex = 4;
            this.btnEXClose.TextColor = System.Drawing.Color.Black;
            this.btnEXClose.TextEX = "";
            this.btnEXClose.ButtonClick += new System.EventHandler(this.btnEXClose_ButtonClick);
            this.btnEXClose.Load += new System.EventHandler(this.btnEXClose_Load);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(29, 7);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(149, 19);
            this.title.TabIndex = 1;
            this.title.Text = "选择一个你喜欢的主题";
            // 
            // btnEXLogo
            // 
            this.btnEXLogo.BackColorEX = System.Drawing.Color.Transparent;
            this.btnEXLogo.BackColorLeave = System.Drawing.Color.Transparent;
            this.btnEXLogo.BackColorMove = System.Drawing.Color.Transparent;
            this.btnEXLogo.FontM = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEXLogo.ImageDefault = global::BenNHControl.Properties.Resources.ico;
            this.btnEXLogo.ImageLeave = null;
            this.btnEXLogo.ImageMove = null;
            this.btnEXLogo.Location = new System.Drawing.Point(3, 5);
            this.btnEXLogo.Name = "btnEXLogo";
            this.btnEXLogo.Size = new System.Drawing.Size(20, 20);
            this.btnEXLogo.TabIndex = 0;
            this.btnEXLogo.TextColor = System.Drawing.Color.Black;
            this.btnEXLogo.TextEX = "";
            this.btnEXLogo.Load += new System.EventHandler(this.btnEXLogo_Load);
            // 
            // Skin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(550, 300);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Skin";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BenNHForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormEX_Load_1);
            this.Resize += new System.EventHandler(this.FormEX_Resize);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Panel titleBar;
        private ButtonEX btnEXLogo;
        private System.Windows.Forms.Label title;
        private ButtonEX btnEXClose;
    }
}