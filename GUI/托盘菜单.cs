using GUI.UI;
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class 托盘菜单 : Form
    {
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

        #region 写入INI文件
        /// <summary>
        /// 自定义写入INI文件中的内容方法
        /// </summary>
        /// <param name="Section">结节点</param>
        /// <param name="key">键名</param>
        /// <param name="key">键值</param>
        private void IniReadValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, strFilePath);
        }
        #endregion

        #region 读取INI文件
        /// <summary>
        /// 自定义读取INI文件中的内容方法
        /// </summary>
        /// <param name="Section">键</param>
        /// <param name="key">值</param>
        /// <returns></returns>
        private string ContentValue(string Section, string key)
        {

            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, key, "", temp, 1024, strFilePath);
            return temp.ToString();
        }
        #endregion

        public 托盘菜单()
        {
            InitializeComponent();
            InitializeBtn();
            Timer T = new Timer();
            T.Interval = 100;
            T.Tick += new EventHandler(T_Tick);
            T.Enabled = true;
        }

        #region 初始化按钮状态
        private void InitializeBtn()
        {

            //获取桌面的任务
            string DConfig = ContentValue("DesktopConfig", "FollowMain ");
            if (DConfig.Equals("True") == true)
            {
                FormState.Desktop = true;
                this.btn_desktop.BackgroundImage = Properties.Resources.open;
                btn_desktop.BackgroundImage = Properties.Resources.open;
                FormState.DesktopForm = new 桌面监视器();
                FormState.DesktopForm.Show();
            }

            else
            {
                this.btn_desktop.BackgroundImage = Properties.Resources.close1;
            }

            //获取任务栏的任务
            string TConfig = ContentValue("TaskbarConfig", "FollowMain ");
            if (TConfig.Equals("True") == true)
            {
                this.btn_taskbar.BackgroundImage = Properties.Resources.open;
                try
                {
                    Process[] pro = Process.GetProcesses();//获取已开启的所有进程
                                                           //遍历所有查找到的进程
                    for (int i = 0; i < pro.Length; i++)
                    {
                        //判断此进程是否是要查找的进程
                        if (pro[i].ProcessName.ToString().ToLower() == "TrafficMonitor.exe")
                        {
                            FormState.Taskbar = true;
                            break;
                        }
                    }
                    if (FormState.Taskbar == false)
                    {
                        FormState.Tmonitor.StartInfo.FileName = @"TrafficMonitor.exe";
                        FormState.Tmonitor.Start();
                        FormState.Taskbar = true;
                    }
                }
                catch (Exception)
                {

                }
            }
            else
            {
                this.btn_taskbar.BackgroundImage = Properties.Resources.close1;
            }
            if (FormState.Desktop == true || FormState.Taskbar == true)
            {
                btn_all.BackgroundImage = Properties.Resources.close1;
            }
            else
            {
                btn_all.BackgroundImage = Properties.Resources.open;
            }
        }
        #endregion

        void T_Tick(object sender, EventArgs e)
        {
            //label1.Text = this.Location.ToString();

            if (!this.Bounds.Contains(Control.MousePosition)
                && Control.MouseButtons == MouseButtons.Left)
                Close();
        }


        private void 托盘菜单_Load(object sender, EventArgs e)
        {

        }



        private void btn_desktop_Click(object sender, EventArgs e)
        {
            if (FormState.Desktop == false)
            {
                btn_desktop.BackgroundImage = Properties.Resources.open;
                FormState.DesktopForm = new 桌面监视器();
                FormState.DesktopForm.Show();
                FormState.Desktop = true;
                this.btn_all.BackgroundImage = Properties.Resources.close1;
                IniReadValue("DesktopConfig", "FollowMain", FormState.Desktop.ToString());
            }
            else
            {
                btn_desktop.BackgroundImage = Properties.Resources.close1;
                if (FormState.Taskbar == false)
                {
                    this.btn_all.BackgroundImage = Properties.Resources.open;
                }
                FormState.DesktopForm.Close();
                FormState.DesktopForm.Dispose();
                FormState.Desktop = false;
                IniReadValue("DesktopConfig", "FollowMain", FormState.Desktop.ToString());
            }

        }

        private void btn_taskbar_Click(object sender, EventArgs e)
        {
            if (FormState.Taskbar == false)
            {
                btn_taskbar.BackgroundImage = Properties.Resources.open;
                FormState.Taskbar = true;
                IniReadValue("TaskbarConfig", "FollowMain", FormState.Taskbar.ToString());
                this.btn_all.BackgroundImage = Properties.Resources.close1;
                try
                {

                    FormState.Tmonitor.StartInfo.FileName = @"TrafficMonitor.exe";
                    FormState.Tmonitor.Start();

                }
                catch (Exception)
                {

                }
            }
            else
            {
                btn_taskbar.BackgroundImage = Properties.Resources.close1;
                FormState.Taskbar = false;
                if (FormState.Desktop == false)
                {
                    this.btn_all.BackgroundImage = Properties.Resources.close1;
                }
                IniReadValue("TaskbarConfig", "FollowMain", FormState.Taskbar.ToString());
                try
                {
                    FormState.Tmonitor.Kill();
                    FormState.Tmonitor.Dispose();
                }
                catch (Exception)
                {

                }
            }

        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            if (FormState.Desktop == false || FormState.Taskbar == false)
            {
                btn_all.BackgroundImage = Properties.Resources.close1;

                FormState.Desktop = false;
                FormState.Taskbar = false;
                IniReadValue("DesktopConfig", "FollowMain", FormState.Desktop.ToString());
                IniReadValue("TaskbarConfig", "FollowMain", FormState.Taskbar.ToString());
                if (FormState.Desktop == false)
                {
                    FormState.DesktopForm.Close();
                    FormState.DesktopForm.Dispose();
                }

                if (FormState.Taskbar == false)
                    try
                    {
                        FormState.Tmonitor.Kill();
                        FormState.Tmonitor.Dispose();
                    }
                    catch (Exception)
                    {

                    }
            }
            else
            {
                btn_all.BackgroundImage = Properties.Resources.open;
            }
        }

        private void 反馈_Click(object sender, EventArgs e)
        {

        }
        private void 反馈_MouseEnter(object sender, EventArgs e)
        {
            this.反馈.Image = Properties.Resources.fk_on;
        }
        private void 反馈_MouseLeave(object sender, EventArgs e)
        {
            this.反馈.Image = Properties.Resources.fk_off;
        }

        private void 举报_Click(object sender, EventArgs e)
        {

        }
        private void 举报_MouseEnter(object sender, EventArgs e)
        {
            this.举报.Image = Properties.Resources.jb_on;
        }
        private void 举报_MouseLeave(object sender, EventArgs e)
        {
            this.举报.Image = Properties.Resources.jb_off;
        }


        private void 退出_Click(object sender, EventArgs e)
        {

            {
                this.Close();
                FormState.MainForm = false;
                System.Diagnostics.Process.GetCurrentProcess().Kill();//此方法完全奏效，绝对是完全退出。
                Environment.Exit(0);
                
            }
        }

        private void 退出_MouseEnter(object sender, EventArgs e)
        {
            this.退出.Image = Properties.Resources.tc_on;
        }

        private void 退出_MouseLeave(object sender, EventArgs e)
        {
            this.退出.Image = Properties.Resources.tc_off;
        }


    }
}
