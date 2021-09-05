using BenNHControl;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class MainForm : FormEX
    {

        System.Diagnostics.Process W = new System.Diagnostics.Process();
        System.Diagnostics.Process T = new System.Diagnostics.Process();
        private static MainForm formInstance;
        public static MainForm GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new MainForm();
                    return formInstance;
                }
            }
        }


        public object lockObj = new object();
        public bool formSwitchFlag = false;

        /// <summary>
        /// 子窗体界面单例元素
        /// </summary>
        public static 开始体检 form1 = null;
        public static 木马查杀 form2 = null;
        public static 检查更新 form3 = null;
        public static 垃圾清理 form4 = null;
        public static 优化加速 form5 = null;
        public static 工具箱 form6 = null;
        public static 软件管家 form7 = null;



        /// <summary>
        /// 当前显示窗体
        /// </summary>
        private System.Windows.Forms.Form currentForm;


        /// <summary>
        /// 构造方法
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            //主窗体容器打开
            this.IsMdiContainer = true;
            //读写配置文件
            WRini();
            //实例化子窗体界面
            form1 = 开始体检.GetIntance;
            form2 = 木马查杀.GetIntance;
            form3 = 检查更新.GetIntance;
            form4 = 垃圾清理.GetIntance;
            form5 = 优化加速.GetIntance;
            form6 = 工具箱.GetIntance;
            form7 = 软件管家.GetIntance;
            //初始化按钮
            this.initButton();

        }

        #region 读取配置文件

        private void WRini()
        {
            StringBuilder TState = new StringBuilder();
            StringBuilder WState = new StringBuilder();
            StringBuilder State = new StringBuilder().Append("o").Append("n");
  
            //读取
            GetPrivateProfileString("TState", "State", "999", TState, 244, @"config.ini");
            //读取
            GetPrivateProfileString("WState", "State", "999", WState, 244, @"config.ini");

            if (TState.Equals(State)==true)
            {
                try
                {
                    T.StartInfo.FileName = @"TrafficMonitor.exe";
                    T.Start();
                }catch(Exception ex) { }

            }
            if (WState.Equals(State) == true)
            {
                try
                {
                    W.StartInfo.FileName = @"Wise System Monitor\WiseSystemMonitor.exe";
                    W.Start();
                }catch(Exception ex) { }

            }

        }


        /// <summary>
        /// 修改INI配置文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">关键字</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件完整路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        /// <summary>
        /// 读INI配置文件
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="def">缺省值</param>
        /// <param name="retval"></param>
        /// <param name="size">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);


        #endregion


        /// <summary>
        /// 解决闪烁问题
        /// </summary>
        protected override CreateParams CreateParams//双字节解决图片闪烁
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private bool initButton()
        {
            try
            {
                this.button1.BackColor = Color.FromArgb(53, 66, 83);
                this.button2.BackColor = Color.FromArgb(53, 66, 83);
                this.button3.BackColor = Color.FromArgb(53, 66, 83);
                this.button4.BackColor = Color.FromArgb(53, 66, 83);
                this.button5.BackColor = Color.FromArgb(53, 66, 83);
                this.button6.BackColor = Color.FromArgb(53, 66, 83);
                this.button7.BackColor = Color.FromArgb(53, 66, 83);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="frm"></param>
        public void ShowForm(System.Windows.Forms.Control panel, System.Windows.Forms.Form frm)
        {
            lock (this)
            {
                try
                {
                    if (this.currentForm != null && this.currentForm == frm)
                    {
                        return;
                    }
                    else if (this.currentForm != null)
                    {
                        if (this.ActiveMdiChild != null)
                        {
                            this.ActiveMdiChild.Hide();
                        }
                    }
                    this.currentForm = frm;
                    frm.TopLevel = false;
                    frm.MdiParent = this;
                    panel.Controls.Clear();
                    panel.Controls.Add(frm);
                    frm.Show();
                    frm.Dock = System.Windows.Forms.DockStyle.Fill;
                    this.Refresh();
                    foreach (Control item in frm.Controls)
                    {
                        item.Focus();
                        break;
                    }
                }
                catch (System.Exception ex)
                {
                    //
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button1.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form1);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button2.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form2);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button3.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form3);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button4.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form4);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button5.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form5);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button6.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form6);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.initButton();
                this.button7.BackColor = Color.FromArgb(95, 129, 174);
                Monitor.Enter(this.lockObj);
                if (!formSwitchFlag)
                {
                    formSwitchFlag = true;
                    this.ShowForm(pnlCenter, form7);
                    formSwitchFlag = false;
                }
                else
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
                //
            }
            finally
            {
                Monitor.Exit(this.lockObj);
            }
        }



        private void pnlCenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)//退出界面
        {
            this.notifyIcon1.Visible = false;
            try
            {
                T.Kill();
            }catch(Exception ex1) { }
            try
            {
                W.Kill();
            }
            catch (Exception ex1) { }
            this.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();//此方法完全奏效，绝对是完全退出。
            Environment.Exit(0);
        }

        private void 打开性能监控ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 打开主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.ShowInTaskbar = true;
            
            WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)//双击图标打开界面
        {
            if (this.ShowInTaskbar == false)
            {
                this.ShowInTaskbar = true ;
                TopMost = true;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                this.ShowInTaskbar = false;
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }
            
        }
        public void SetBackgroudImage(string imageFileName)
        {
            this.pnlCenter.BackgroundImage = System.Drawing.Image.FromFile(imageFileName);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        #region 打开官网
        private void button8_Click(object sender, EventArgs e)
        {
            // 使用本机默认浏览器打开网址
            System.Diagnostics.Process.Start("https://wsecurity.cloud/");
        }
        #endregion

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 在桌面显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 在任务栏显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 访问官网ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 使用本机默认浏览器打开网址
            System.Diagnostics.Process.Start("https://wsecurity.cloud/");
        }


        private void 随程序启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            W.StartInfo.FileName = @"Wise System Monitor\WiseSystemMonitor.exe";
            W.Start();
            //修改
            WritePrivateProfileString("WState", "State", "on", @"config.ini");
        }

        private void 不随程序启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("WState", "State", "off", @"config.ini");
        }

        private void 都不随程序运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("WState", "State", "off", @"config.ini");
            WritePrivateProfileString("TState", "State", "off", @"config.ini");
        }

        private void 全部随程序运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("WState", "State", "on", @"config.ini");
            WritePrivateProfileString("TState", "State", "on", @"config.ini");
        }

        private void 随程序启动ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            T.StartInfo.FileName = @"TrafficMonitor.exe";
            T.Start();
            WritePrivateProfileString("TState", "State", "on", @"config.ini");
        }

        private void 不随程序运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WritePrivateProfileString("TState", "State", "off", @"config.ini");
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                W.Kill();
            }catch(Exception ex) { }
        }

        private void 退出监视器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                T.Kill();
            }
            catch (Exception ex) { }
        }

        private void 退出所有监视器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                W.Kill();
                T.Kill();
            }
            catch (Exception ex) { }
        }

    }
}
