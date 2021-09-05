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
            //初始化实时性能监控器
            //InitializeTasker();
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

        #region 声明变量
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">节点名称[如[TypeName]]</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">值</param>
        /// <param name="retval">stringbulider对象</param>
        /// <param name="size">字节大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        private string strFilePath = Application.StartupPath + "\\MonitorConfig.ini";//获取INI文件路径
        private string strSec = ""; //INI文件名

        #endregion

        #region 读取配置文件

        private void InitializeTasker()
        {
            string DConfig = ContentValue("DesktopConfig", "FollowMain ");
            if (DConfig.Equals("True") == true)
            {
                FormState.Desktop = true;
                FormState.DesktopForm = new 桌面监视器();
                FormState.DesktopForm.Show();
            }
            else
            {
                FormState.Desktop = false;
            }
        }


        private string ContentValue(string Section, string key)
        {

            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, key, "", temp, 1024, strFilePath);
            return temp.ToString();
        }

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
                this.button1.BackColor = ColorTranslator.FromHtml(Skin_paper.ColorID);
                this.button2.BackColor = ColorTranslator.FromHtml(Skin_paper.ColorID);
                this.button3.BackColor = ColorTranslator.FromHtml(Skin_paper.ColorID);
                this.button4.BackColor = ColorTranslator.FromHtml(Skin_paper.ColorID);
                this.button5.BackColor = ColorTranslator.FromHtml(Skin_paper.ColorID);
                this.button6.BackColor = ColorTranslator.FromHtml(Skin_paper.ColorID);
                this.button7.BackColor = ColorTranslator.FromHtml(Skin_paper.ColorID);
                this.button8.BackColor = ColorTranslator.FromHtml(Skin_paper.ColorID);
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

        private void button8_Click(object sender, EventArgs e)
        {
            切换皮肤 formskin = new 切换皮肤();
            formskin.Show();
            // 使用本机默认浏览器打开网址
            //System.Diagnostics.Process.Start("https://wsecurity.cloud/");
        }

        private void pnlCenter_Paint(object sender, PaintEventArgs e)
        {
            this.pnlCenter.BackColor = System.Drawing.ColorTranslator.FromHtml(Skin_paper.ColorID);
            Application.DoEvents();

        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {
            Application.DoEvents();
            this.pnlTop.BackColor = System.Drawing.ColorTranslator.FromHtml(Skin_paper.ColorID);
        }



        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)//双击图标事件
        {

            if (this.ShowInTaskbar == false)
            {
                this.ShowInTaskbar = true;
                TopMost = true;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                this.ShowInTaskbar = false;
                this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }


        }


        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)//单机图标事件
        {

            int x = Control.MousePosition.X;
            int y = Control.MousePosition.Y;

            if (e.Button == MouseButtons.Right)
            {

                托盘菜单 f2 = new 托盘菜单();
                f2.Location = new Point(x - 180, y - 255);
                f2.StartPosition = FormStartPosition.Manual;
                f2.Show();
                if (FormState.MainForm == false)
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();//此方法完全奏效，绝对是完全退出。
                    Environment.Exit(0);
                }
            }

        }

        #region 获取任务栏右下角的位置

        // get current right bottom corner position(X, Y), support four mode: taskbar bottom/right/up/left
        public Point getCornerLocation()
        {
            int xPos = 0, yPos = 0;

            if ((Screen.PrimaryScreen.Bounds.Width == Screen.PrimaryScreen.WorkingArea.Width) &&
                (Screen.PrimaryScreen.WorkingArea.Y == 0))
            {
                //taskbar bottom
                xPos = Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width;
                yPos = Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height;
            }
            else if ((Screen.PrimaryScreen.Bounds.Height == Screen.PrimaryScreen.WorkingArea.Height) &&
                    (Screen.PrimaryScreen.WorkingArea.X == 0))
            {
                //taskbar right
                xPos = Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width;
                yPos = Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height;
            }
            else if ((Screen.PrimaryScreen.Bounds.Width == Screen.PrimaryScreen.WorkingArea.Width) &&
                    (Screen.PrimaryScreen.WorkingArea.Y > 0))
            {
                //taskbar up
                xPos = Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width;
                yPos = Screen.PrimaryScreen.WorkingArea.Y;
            }
            else if ((Screen.PrimaryScreen.Bounds.Height == Screen.PrimaryScreen.WorkingArea.Height) &&
                    (Screen.PrimaryScreen.WorkingArea.X > 0))
            {
                //taskbar left
                xPos = Screen.PrimaryScreen.WorkingArea.X;
                yPos = Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height;
            }

            return new Point(xPos, yPos);
        }

        #endregion
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Application.DoEvents();
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(Skin_paper.ColorID);

        }


    }
}
