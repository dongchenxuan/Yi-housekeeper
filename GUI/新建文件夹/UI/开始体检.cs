using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class 开始体检 : Form
    {
        private static 开始体检 formInstance;
        public static 开始体检 GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new 开始体检();
                    return formInstance;
                }
            }
        }
        public 开始体检()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 解决闪烁问题
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//开始体检显示的页面
        {
            this.button1.Visible = false;
            this.panel1.Visible = true;
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)//点击暂停的事件
        {
            if (timer1.Enabled == true)
            {
                button2.Text = "继续";
                timer1.Enabled = false;
            }
            else
            {
                button2.Text = "暂停";
                timer1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)//点击取消的事件
        {
            timer1.Enabled = false;
            progressBar1.Value = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value++;
            else
                timer1.Enabled = false;
        }
        public void SetBackgroudImage(string imageFileName)
        {
            this.BackgroundImage = System.Drawing.Image.FromFile(imageFileName);
        }
    }
}
