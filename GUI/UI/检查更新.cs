using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using version;

namespace GUI.UI
{

    public partial class 检查更新 : Form
    {
        static version.Version GetAllVersion = new version.Version();
        System.Diagnostics.Process U = new System.Diagnostics.Process();

        #region 公有变量
        private static byte[] result = new Byte[1024];
        private static int one_socker_send = 0;
        private static string Message = null;
        #endregion
        private static 检查更新 formInstance;
        public static 检查更新 GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new 检查更新();
                    return formInstance;
                }
            }
        }
        public 检查更新()
        {
            if (one_socker_send == 0)
                Version();
            InitializeComponent();
            this.label2.Text = GetAllVersion.Getversion(0);
            this.label4.Text = GetAllVersion.Getversion(1);
            this.label5.Text = Message;
            if (DateTime.Now.DayOfWeek.Equals("星期一") == true)
            {
                System.Diagnostics.Process.Start(@".\Update\AutoUpdater.exe");
            }

        }

        #region 网络交互：向服务器发送信息
        public static string GetMacByNetworkInterface()
        {
            try
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface ni in interfaces)
                {
                    return BitConverter.ToString(ni.GetPhysicalAddress().GetAddressBytes());
                }
            }
            catch (Exception)
            {
            }
            return "00-00-00-00-00-00";
        }
        public static string GetIpAddRess()
        {
            WebRequest request = WebRequest.Create("http://ip.ws.126.net/ipquery?ip");
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("gb2312"));
            string read = reader.ReadToEnd();
            Regex regex = new Regex("\"[^\"]*\"");
            if (regex.IsMatch(read))
            {
                read = regex.Match(read).Value.Replace("\"", "");
            }
            return read;
        }
        private static void Version()
        {
            //服务器IP地址
            IPAddress ip = IPAddress.Parse("39.97.108.27");
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, 666));
                Message = "云服务器连接正常";
            }
            catch
            {
                Message = "云服务器连接异常";
                return;
            }
            //通过clientSocket接收数据
            int receiveLength = clientSocket.Receive(result);
            // 通过clientSocket发送数据

            try
            {
                // Thread.Sleep(1000);
                string sendMessage = " " + GetMacByNetworkInterface() + /*MAC作为计算机ID*/
                                     " " + GetIpAddRess() + /*IP归属地*/
                                     " " + DateTime.Now +   /*连接时间*/
                                     " " + GetAllVersion.Getversion(0) + /*软件版本*/
                                     " " + GetAllVersion.Getversion(1); /*+病毒库版本*/
                clientSocket.Send(Encoding.Unicode.GetBytes(sendMessage));
                one_socker_send = 1;
            }
            catch
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void 检查更新_Button_Click(object sender, EventArgs e)
        {
            U.StartInfo.FileName = @".\Update\AutoUpdater.exe";
            U.Start();

        }

        public void SetBackgroudImage(string imageFileName)
        {
            this.BackgroundImage = System.Drawing.Image.FromFile(imageFileName);
        }
        /// <summary>
        /// 解决闪烁问题
        /// </summary>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x02000000;
        //        return cp;
        //    }
        //}
    }
}
