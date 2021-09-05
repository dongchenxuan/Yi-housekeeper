using System;
using System.Windows.Forms;

namespace BenNHControl
{
    partial class FormEX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEX));
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnEXClose = new BenNHControl.ButtonEX();
            this.btnEXMax = new BenNHControl.ButtonEX();
            this.btnEXMin = new BenNHControl.ButtonEX();
            this.title = new System.Windows.Forms.Label();
            this.btnEXLogo = new BenNHControl.ButtonEX();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(116)))), ((int)(((byte)(151)))));
            this.titleBar.Controls.Add(this.btnEXClose);
            this.titleBar.Controls.Add(this.btnEXMax);
            this.titleBar.Controls.Add(this.btnEXMin);
            this.titleBar.Controls.Add(this.title);
            this.titleBar.Controls.Add(this.btnEXLogo);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Margin = new System.Windows.Forms.Padding(4);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1076, 38);
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
            this.btnEXClose.FontM = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEXClose.ImageDefault = ((System.Drawing.Image)(resources.GetObject("btnEXClose.ImageDefault")));
            this.btnEXClose.ImageLeave = null;
            this.btnEXClose.ImageMove = null;
            this.btnEXClose.Location = new System.Drawing.Point(1041, 10);
            this.btnEXClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnEXClose.Name = "btnEXClose";
            this.btnEXClose.Size = new System.Drawing.Size(27, 25);
            this.btnEXClose.TabIndex = 4;
            this.btnEXClose.TextColor = System.Drawing.Color.Black;
            this.btnEXClose.TextEX = "";
            this.btnEXClose.ButtonClick += new System.EventHandler(this.btnEXClose_ButtonClick);
            this.btnEXClose.Load += new System.EventHandler(this.btnEXClose_Load);
            // 
            // btnEXMax
            // 
            this.btnEXMax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEXMax.AutoSize = true;
            this.btnEXMax.BackColorEX = System.Drawing.Color.Transparent;
            this.btnEXMax.BackColorLeave = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(116)))), ((int)(((byte)(151)))));
            this.btnEXMax.BackColorMove = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEXMax.FontM = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEXMax.ImageDefault = global::BenNHControl.Properties.Resources.Max;
            this.btnEXMax.ImageLeave = null;
            this.btnEXMax.ImageMove = null;
            this.btnEXMax.Location = new System.Drawing.Point(1006, 10);
            this.btnEXMax.Margin = new System.Windows.Forms.Padding(5);
            this.btnEXMax.Name = "btnEXMax";
            this.btnEXMax.Size = new System.Drawing.Size(27, 25);
            this.btnEXMax.TabIndex = 3;
            this.btnEXMax.TextColor = System.Drawing.Color.Black;
            this.btnEXMax.TextEX = "";
            this.btnEXMax.ButtonClick += new System.EventHandler(this.btnEXMax_ButtonClick);
            // 
            // btnEXMin
            // 
            this.btnEXMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEXMin.AutoSize = true;
            this.btnEXMin.BackColorEX = System.Drawing.Color.Transparent;
            this.btnEXMin.BackColorLeave = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(116)))), ((int)(((byte)(151)))));
            this.btnEXMin.BackColorMove = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEXMin.FontM = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEXMin.ImageDefault = global::BenNHControl.Properties.Resources.Min;
            this.btnEXMin.ImageLeave = null;
            this.btnEXMin.ImageMove = null;
            this.btnEXMin.Location = new System.Drawing.Point(972, 6);
            this.btnEXMin.Margin = new System.Windows.Forms.Padding(5);
            this.btnEXMin.Name = "btnEXMin";
            this.btnEXMin.Size = new System.Drawing.Size(27, 25);
            this.btnEXMin.TabIndex = 2;
            this.btnEXMin.TextColor = System.Drawing.Color.Black;
            this.btnEXMin.TextEX = "";
            this.btnEXMin.ButtonClick += new System.EventHandler(this.btnEXMin_ButtonClick);
            this.btnEXMin.Load += new System.EventHandler(this.btnEXMin_Load);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(39, 9);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(66, 25);
            this.title.TabIndex = 1;
            this.title.Text = "易管家";
            // 
            // btnEXLogo
            // 
            this.btnEXLogo.BackColorEX = System.Drawing.Color.Transparent;
            this.btnEXLogo.BackColorLeave = System.Drawing.Color.Transparent;
            this.btnEXLogo.BackColorMove = System.Drawing.Color.Transparent;
            this.btnEXLogo.FontM = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEXLogo.ImageDefault = global::BenNHControl.Properties.Resources.ygj_logo;
            this.btnEXLogo.ImageLeave = null;
            this.btnEXLogo.ImageMove = null;
            this.btnEXLogo.Location = new System.Drawing.Point(4, 6);
            this.btnEXLogo.Margin = new System.Windows.Forms.Padding(5);
            this.btnEXLogo.Name = "btnEXLogo";
            this.btnEXLogo.Size = new System.Drawing.Size(27, 25);
            this.btnEXLogo.TabIndex = 0;
            this.btnEXLogo.TextColor = System.Drawing.Color.Black;
            this.btnEXLogo.TextEX = "";
            this.btnEXLogo.Load += new System.EventHandler(this.btnEXLogo_Load);
            // 
            // FormEX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1076, 738);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEX";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BenNHForm";
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
        private ButtonEX btnEXMax;
        private ButtonEX btnEXMin;
    }
}