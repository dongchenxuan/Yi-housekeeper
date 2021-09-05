using System;
using System.Threading;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class 开始体检 : Form
    {
        private static 开始体检 formInstance;


        //委托
        private delegate bool IncreaseHandle(int nValue);

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
            ScanRegistry();
        }
        #region 扫描注册表
        private void ScanRegistry()
        {
            // 清理旧的注册表
            //this.treeModel.Nodes.Clear();


        }
        #endregion

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

        private void UpdateWram_title()
        {
            string Now_hour = DateTime.Now.Hour.ToString(); //获取小时  
            if (Now_hour.CompareTo(11) < 0)
            {
                switch (DateTime.Now.DayOfWeek.ToString())
                {
                    case "Moaday":; break;
                }
            }
            Application.DoEvents();
            Thread.Sleep(1000);
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Wram_title_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void 开始体检_Paint(object sender, PaintEventArgs e)
        {
            Application.DoEvents();
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(Skin_paper.ColorID);

        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
