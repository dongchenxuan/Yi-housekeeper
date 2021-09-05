using ProgressBarDemo;
using System;

namespace GUI
{
    partial class 桌面监视器
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(桌面监视器));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_close = new System.Windows.Forms.Button();
            this.temperature = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.CPUTemlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CPU = new System.Windows.Forms.Panel();
            this.CPUProgramBar = new ProgressBarDemo.CircleProgramBar();
            this.label1 = new System.Windows.Forms.Label();
            this.RAM = new System.Windows.Forms.Panel();
            this.RAMProgramBar = new ProgressBarDemo.CircleProgramBar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.temperature.SuspendLayout();
            this.CPU.SuspendLayout();
            this.RAM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_close.Location = new System.Drawing.Point(360, 0);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(20, 20);
            this.btn_close.TabIndex = 0;
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // temperature
            // 
            this.temperature.BackColor = System.Drawing.Color.Transparent;
            this.temperature.Controls.Add(this.label3);
            this.temperature.Controls.Add(this.CPUTemlabel);
            this.temperature.Location = new System.Drawing.Point(260, 20);
            this.temperature.Name = "temperature";
            this.temperature.Size = new System.Drawing.Size(120, 100);
            this.temperature.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "量度";
            // 
            // CPUTemlabel
            // 
            this.CPUTemlabel.AutoSize = true;
            this.CPUTemlabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPUTemlabel.Location = new System.Drawing.Point(0, 50);
            this.CPUTemlabel.Name = "CPUTemlabel";
            this.CPUTemlabel.Size = new System.Drawing.Size(98, 15);
            this.CPUTemlabel.TabIndex = 0;
            this.CPUTemlabel.Text = "正在获取...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(31, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "CPU";
            // 
            // CPU
            // 
            this.CPU.BackColor = System.Drawing.Color.Transparent;
            this.CPU.Controls.Add(this.label2);
            this.CPU.Controls.Add(this.CPUProgramBar);
            this.CPU.Location = new System.Drawing.Point(140, 20);
            this.CPU.Name = "CPU";
            this.CPU.Size = new System.Drawing.Size(100, 100);
            this.CPU.TabIndex = 2;
            // 
            // CPUProgramBar
            // 
            this.CPUProgramBar.BackColor = System.Drawing.Color.MediumPurple;
            this.CPUProgramBar.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CPUProgramBar.FinishedColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(179)))), ((int)(((byte)(63)))));
            this.CPUProgramBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CPUProgramBar.Location = new System.Drawing.Point(-28, -28);
            this.CPUProgramBar.MaxValue = 100;
            this.CPUProgramBar.Name = "CPUProgramBar";
            this.CPUProgramBar.Progress = 50;
            this.CPUProgramBar.Size = new System.Drawing.Size(155, 155);
            this.CPUProgramBar.TabIndex = 1;
            this.CPUProgramBar.Text = "circleProgramBar2";
            this.CPUProgramBar.TopColor = System.Drawing.Color.Blue;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(31, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "RAM";
            // 
            // RAM
            // 
            this.RAM.BackColor = System.Drawing.Color.Transparent;
            this.RAM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RAM.Controls.Add(this.label1);
            this.RAM.Controls.Add(this.RAMProgramBar);
            this.RAM.Location = new System.Drawing.Point(20, 20);
            this.RAM.Name = "RAM";
            this.RAM.Size = new System.Drawing.Size(100, 100);
            this.RAM.TabIndex = 1;
            this.RAM.Paint += new System.Windows.Forms.PaintEventHandler(this.RAM_Paint);
            // 
            // RAMProgramBar
            // 
            this.RAMProgramBar.BackColor = System.Drawing.Color.MediumPurple;
            this.RAMProgramBar.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RAMProgramBar.FinishedColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(179)))), ((int)(((byte)(63)))));
            this.RAMProgramBar.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RAMProgramBar.Location = new System.Drawing.Point(-28, -28);
            this.RAMProgramBar.MaxValue = 100;
            this.RAMProgramBar.Name = "RAMProgramBar";
            this.RAMProgramBar.Progress = 50;
            this.RAMProgramBar.Size = new System.Drawing.Size(155, 155);
            this.RAMProgramBar.TabIndex = 0;
            this.RAMProgramBar.TopColor = System.Drawing.Color.Blue;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.MediumPurple;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineWidth = 0;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackImageTransparentColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 95F;
            chartArea1.Position.Width = 75F;
            chartArea1.Position.Y = 5F;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.Title = "量度";
            legend1.TitleAlignment = System.Drawing.StringAlignment.Near;
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 126);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "CPU(℃)";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "CPU(%)";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "RAM(%)";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(380, 175);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // 桌面监视器
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(380, 130);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.temperature);
            this.Controls.Add(this.CPU);
            this.Controls.Add(this.RAM);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "桌面监视器";
            this.Opacity = 0.75D;
            this.ShowInTaskbar = false;
            this.Text = "桌面监视器";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.桌面监视器_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.桌面监视器_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.桌面监视器_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.桌面监视器_MouseUp);
            this.temperature.ResumeLayout(false);
            this.temperature.PerformLayout();
            this.CPU.ResumeLayout(false);
            this.CPU.PerformLayout();
            this.RAM.ResumeLayout(false);
            this.RAM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel temperature;
        private CircleProgramBar CPUProgramBar;
        private System.Windows.Forms.Label CPUTemlabel;
        private System.Windows.Forms.Label label3;
        private CircleProgramBar RAMProgramBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel CPU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel RAM;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}