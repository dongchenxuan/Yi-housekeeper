using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace GUI.UI
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //获得当前登录的Windows用户标示
            WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            //判断当前登录用户是否为管理员
            if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //如果是管理员，则直接运行
                Application.Run(new MainForm());
            }
            else
            {
                //创建启动对象
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行
                startInfo.Verb = "runas";
                try
                {
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch
                {
                    return;
                }

            }


        }
    }
    public static class Skin_paper//包含所有的全局变量
    {
        public static string ColorID = "Gray";
        public static string Full = "false";
    }

    public static class FormState
    {
        public static Boolean MainForm = true;
        public static Boolean Desktop = false;
        public static Form DesktopForm;
        public static Boolean Taskbar = false;
        public static Process Tmonitor;

    }
}
