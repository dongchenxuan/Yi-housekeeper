using GUI.UI;
using Microsoft.VisualBasic.Devices;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WinRing0_Test;
using Computer = OpenHardwareMonitor.Hardware.Computer;

namespace GUI
{


    public partial class 桌面监视器 : Form
    {
        #region 声明变量
        Point mouseOff;
        bool leftFlag = false;

        private TestByWinRing0 testByWinRing = null;

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

        private string strFilePath = Application.StartupPath + "\\MonitorConfig.ini";//获取INI文件路径
        private string strSec = ""; //INI文件名
        #endregion

        #region 相关线程定义
        Thread threadUsage;
        Thread threadTCPU;


        #endregion

        private Queue<double> dataQueue = new Queue<double>(25);

        private int curValue = 0;

        private int num = 1;//每次删除增加几个点

        public 桌面监视器()
        {
            InitializeComponent();
            StartThread();

        }



        private void 桌面监视器_Load(object sender, EventArgs e)
        {

        }

        private void StartThread()
        {
            threadUsage = new Thread(new ThreadStart(GetRAMCPUUsage));
            threadUsage.IsBackground = true;
            threadUsage.Start();
           

            threadTCPU = new Thread(new ThreadStart(GetCPUTemperature));
            threadTCPU.IsBackground = true;
            threadTCPU.Start();


        }

        #region 获取RAM和CPU占用量
        private void GetRAMCPUUsage()
        {
            /*
            for (int i = 0; i < num; i++)
            {
                dataQueue.Enqueue(0);
            }
            */

            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            if ((int)cpuCounter.NextValue() > 80)
            {
                Thread.Sleep(1000 * 60);
            }
            Decimal a, b,c;

            b = Convert.ToDecimal(FormatSize(GetUsedPhys()));//得到内存总大小

            while (true)
            {
                a = Convert.ToDecimal(FormatSize(GetTotalPhys()));//得到内存已用大小
                this.RAMProgramBar.Progress = Convert.ToInt32(b / a * 100);
                //this.chart1.Series[2].Points.AddY(Convert.ToInt32(b / a * 100));

                c = (int)cpuCounter.NextValue();//得到CPU已用大小
                this.CPUProgramBar.Progress = Convert.ToInt32(c);
                //this.chart1.Series[1].Points.AddY(Convert.ToInt32(c));

                /*
                if (dataQueue.Count > 25)
                {
                    //先出列
                    for (int i = 0; i < num; i++)
                    {
                        dataQueue.Dequeue();
                    }
                }
                
                dataQueue.Enqueue(Convert.ToInt32(c));
                */

                Application.DoEvents();
                Thread.Sleep(1000);
            }

        }
        #endregion

        #region 获取CPU温度
        private void GetCPUTemperature()
        {
            testByWinRing = new TestByWinRing0();
            bool initResult = testByWinRing.Initialize();
            while (true)
            {
                if (initResult)
                {
                    testByWinRing.InitEc();
                    int temp = this.testByWinRing.CpuTemp();
                    CPUTemlabel.Text = "CPU:" + temp + "℃";
                    //this.chart1.Series[0].Points.AddY(temp);
                    Thread.Sleep(1000);
                    CPUTemlabel.Refresh();
                }
                else
                {
                    CPUTemlabel.Text = "False";
                }
            }   
        }
        #endregion



        private void 桌面监视器_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);
                leftFlag = true;
            }
        }

        private void 桌面监视器_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);
                this.Location = mouseSet;
            }
        }


        private void 桌面监视器_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        #region 获取计算机实时性能
        #region 获得内存信息API
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GlobalMemoryStatusEx(ref MEMORY_INFO mi);

        //定义内存的信息结构
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_INFO
        {
            public uint dwLength; //当前结构体大小
            public uint dwMemoryLoad; //当前内存使用率
            public ulong ullTotalPhys; //总计物理内存大小
            public ulong ullAvailPhys; //可用物理内存大小
            public ulong ullTotalPageFile; //总计交换文件大小
            public ulong ullAvailPageFile; //总计交换文件大小
            public ulong ullTotalVirtual; //总计虚拟内存大小
            public ulong ullAvailVirtual; //可用虚拟内存大小
            public ulong ullAvailExtendedVirtual; //保留 这个值始终为0
        }
        #endregion

        #region 格式化容量大小
        /// <summary>
        /// 格式化容量大小
        /// </summary>
        /// <param name="size">容量（B）</param>
        /// <returns>已格式化的容量</returns>
        private static string FormatSize(double size)
        {
            double d = (double)size;
            int i = 0;
            while ((d > 1024) && (i < 5))
            {
                d /= 1024;
                i++;
            }
            string[] unit = { "", "", "", "", "" };
            return (string.Format("{0} {1}", Math.Round(d, 2), unit[i]));
        }
        #endregion


        #region 获得当前内存使用情况
        /// <summary>
        /// 获得当前内存使用情况
        /// </summary>
        /// <returns></returns>
        public static MEMORY_INFO GetMemoryStatus()
        {
            MEMORY_INFO mi = new MEMORY_INFO();
            mi.dwLength = (uint)System.Runtime.InteropServices.Marshal.SizeOf(mi);
            GlobalMemoryStatusEx(ref mi);
            return mi;
        }
        #endregion

        #region 获得当前可用物理内存大小
        /// <summary>
        /// 获得当前可用物理内存大小
        /// </summary>
        /// <returns>当前可用物理内存（B）</returns>
        public static ulong GetAvailPhys()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return mi.ullAvailPhys;
        }
        #endregion

        #region 获得当前已使用的内存大小
        /// <summary>
        /// 获得当前已使用的内存大小
        /// </summary>
        /// <returns>已使用的内存大小（B）</returns>
        public static ulong GetUsedPhys()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return (mi.ullTotalPhys - mi.ullAvailPhys);
        }
        #endregion

        #region 获得当前总计物理内存大小
        /// <summary>
        /// 获得当前总计物理内存大小
        /// </summary>
        /// <returns&amp;gt;总计物理内存大小（B）&amp;lt;/returns&amp;gt;
        public static ulong GetTotalPhys()
        {
            MEMORY_INFO mi = GetMemoryStatus();
            return mi.ullTotalPhys;
        }
        #endregion

        #endregion

        private void RAM_Paint(object sender, PaintEventArgs e)
        {

        }


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

        private void btn_close_Click(object sender, EventArgs e)
        {
            IniReadValue("DesktopConfig", "FollowMain", false.ToString());

            threadUsage.Abort();
            threadTCPU.Abort();

            FormState.DesktopForm.Close();
            FormState.Desktop = false;
            //System.Diagnostics.Process.GetCurrentProcess().Kill();//此方法完全奏效，绝对是完全退出。
            //Environment.Exit(0);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void GPUTemlabel_Click(object sender, EventArgs e)
        {

        }
    }

    public class UpdateVisitor : IVisitor
    {
        public void VisitComputer(IComputer computer)
        {
            computer.Traverse(this);
        }

        public void VisitHardware(IHardware hardware)
        {
            hardware.Update();
            foreach (IHardware subHardware in hardware.SubHardware)
            {
                subHardware.Accept(this);
            }
        }

        public void VisitParameter(IParameter parameter)
        {
            throw new NotImplementedException();
        }

        public void VisitSensor(ISensor sensor)
        {
        }

    }

}
