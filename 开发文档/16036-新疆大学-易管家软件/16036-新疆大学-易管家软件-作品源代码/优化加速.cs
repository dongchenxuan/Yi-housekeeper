using IWshRuntimeLibrary;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;


namespace GUI.UI
{

    public partial class 优化加速 : Form
    {
        //注册表启动项
        List<string> Registrystartupkey = new List<string>();
        //扫描保存的进程
        List<string> ProcessName = new List<string>();
        //保存注册表的键类型
        List<string> RegistryKeys = new List<string>();
        //保存注册表的键值
        List<string> RegistryValues = new List<string>();

        #region 相关线程定义
        Thread threadUpadatereSourceOccupation;
        #endregion



        private static 优化加速 formInstance;
        public static 优化加速 GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new 优化加速();
                    return formInstance;
                }
            }
        }
        public 优化加速()
        {
            InitializeComponent();
            threadUpadatereSourceOccupation = new Thread(new ThreadStart(UpdateResourceLabel));
            threadUpadatereSourceOccupation.Start();

            progressBar1.Value = 0;
            progressBar1.Maximum = 100;

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

        private void 优化加速_Load(object sender, EventArgs e)
        {

        }
        public void SetBackgroudImage(string imageFileName)
        {
            this.BackgroundImage = System.Drawing.Image.FromFile(imageFileName);
        }

        #region 更新计算机资源占用量标签
        private void UpdateResourceLabel()
        {
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
                System.Threading.Thread.Sleep(1000 * 60);
            }
            Decimal a, b, c;

            b = Convert.ToDecimal(FormatSize(GetUsedPhys()));//得到内存总大小

            while (true)
            {
                a = Convert.ToDecimal(FormatSize(GetTotalPhys()));//得到内存已用大小
                c = (int)cpuCounter.NextValue();//得到CPU已用大小

                this.label2.Text = @"内存占用量" + Convert.ToInt32(b / a * 100) + @"%";
                label2.Refresh();
                progressBar1.Value = Convert.ToInt32(Convert.ToInt32(b / a * 100));

                this.label3.Text = @"CPU占用量" + (c) + @"%";
                label3.Refresh();
                progressBar2.Value = Convert.ToInt32(c);
                /*
                this.label3.Text = @"CPU使用量" + GetCPU();
                label3.Refresh();
                */
                Application.DoEvents();

                //progressBar1.Value = Convert.ToInt32(GetRAM());


                Thread.Sleep(1000);
            }

        }

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


        private string GetRAM()
        {
            //需要添加 System.Management 的引用
            //获取总物理内存大小
            ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            double available = 0, capacity = 0;
            foreach (ManagementObject mo1 in moc1)
            {
                capacity += ((Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1)));
            }
            moc1.Dispose();
            cimobject1.Dispose();


            //获取内存可用大小
            ManagementClass cimobject2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            ManagementObjectCollection moc2 = cimobject2.GetInstances();
            foreach (ManagementObject mo2 in moc2)
            {
                available += ((Math.Round(Int64.Parse(mo2.Properties["AvailableMBytes"].Value.ToString()) / 1024.0, 1)));

            }
            moc2.Dispose();
            cimobject2.Dispose();
            /*
            Console.WriteLine("总内存=" + capacity.ToString() + "G");
            Console.WriteLine("可使用=" + available.ToString() + "G");
            Console.WriteLine("已使用=" + ((capacity - available)).ToString() + "G," + (Math.Round((capacity - available) / capacity * 100, 0)).ToString() + "%");
            Console.ReadKey();
            */
            return Math.Round((capacity - available) / capacity * 100, 0).ToString();
        }

        private string GetCPU()
        {
            /*
            float cpuUsage = this.theCPUCounter.NextValue();

            cpuUsage = this.theCPUCounter.NextValue();
            return cpuUsage.ToString() + "%";
            */
            /*
            PerformanceCounter cpuCounter;

            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            return cpuCounter.NextValue() + "%";
            */
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
            var cpuTimes = searcher.Get()
                .Cast<ManagementObject>()
                .Select(mo => new
                {
                    Name = mo["Name"],
                    Usage = mo["PercentProcessorTime"]
                }
                )
                .ToList();

            var query = cpuTimes.Where(x => x.Name.ToString() == "_Total").Select(x => x.Usage);
            var cpuUsage = query.SingleOrDefault();
            return cpuUsage.ToString() + "%";
        }

        private void Create()
        {


        }
        #endregion

        #region 开始扫描
        private void Scan_bt_Click(object sender, EventArgs e)
        {
            this.Scan_loading.Visible = true;
            this.top_panel.Visible = false;
            this.Scan_panel.Visible = true;
            Startupacceleration();

        }
        #endregion

        #region 扫描开机加速项
        private void Startupacceleration()
        {
            //创建父节点
            TreeNode TreeNode1 = treeView1.Nodes.Add("开机启动项加速");
            TreeNode TreeNode2 = treeView1.Nodes.Add("关闭高占用软件");
            TreeNode treeNode3 = treeView1.Nodes.Add("测试");

            treeView1.ImageList = imageList1;
            imageList1.ImageSize = new Size(48, 48);

            try
            {
                RegistryKey localMachine = Registry.LocalMachine;
                RegistryKey localMachineruns = localMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                RegistryKey localCurrentUser = Registry.CurrentUser;
                RegistryKey localCurrentUserruns = localCurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

                foreach (string strName in localMachineruns.GetValueNames())
                {
                    RegistryKeys.Add("localMachine");
                    RegistryValues.Add(localMachineruns.GetValue(strName).ToString());
                    Registrystartupkey.Add(strName);
                    Application.DoEvents();
                }

                foreach (string strName in localCurrentUserruns.GetValueNames())
                {
                    RegistryKeys.Add("localCurrentUser");
                    RegistryValues.Add(localCurrentUserruns.GetValue(strName).ToString());
                    Registrystartupkey.Add(strName);
                    Application.DoEvents();
                }


                string path = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                string[] links = Directory.GetFiles(path + "\\", "*.lnk");
                foreach (string file in links)
                {
                    string lnkPath = null;
                    if (System.IO.File.Exists(file))
                    {
                        WshShell shell = new WshShell();
                        IWshShortcut IWshShortcut = (IWshShortcut)shell.CreateShortcut(file);
                        lnkPath = IWshShortcut.TargetPath;
                        Registrystartupkey.Add(Path.GetFileNameWithoutExtension(file));
                    }
                    Application.DoEvents();
                }
            }
            catch (Exception)
            {
                return;
            }

            //枚举开机启动项的子节点
            for (int i = 0; i < Registrystartupkey.Count; i++)
            {
                TreeNode1.Nodes.Add(Registrystartupkey[i]);//文件名称
                Application.DoEvents();
                Thread.Sleep(5);
            }



            ComputerInfo ci = new ComputerInfo();
            double totalMb = ci.TotalPhysicalMemory / 1024 / 1024;
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                double ProcessMemery = process.WorkingSet64 / 1024.0 / 1024.0;
                //TreeNode Program = new TreeNode(process.ProcessName + "   " + ProcessMemery.ToString("f2") + "MB");

                string Processpath = GetProcesspath(process);
                if (Processpath.Equals("error") != true)
                {
                    if (ProcessMemery > totalMb * 0.00625)
                    {
                        var key = process.ProcessName.ToString();
                        ProcessName.Add(key + " (" + ProcessMemery.ToString("f2") + "MB)");
                    }
                }
                Application.DoEvents();
                Thread.Sleep(0);

            }

            //添加进程子节点(进程名称 + 图标)
            for (int i = 0; i < ProcessName.Count; i++)
            {
                string IcoPath = @"bin\ico\" + ProcessName[i] + @".ico";
                if (Directory.Exists(IcoPath) == false)
                    IcoPath = @"bin\ico\default.ico";
                imageList1.Images.Add(ProcessName[i], Image.FromFile(IcoPath));
                TreeNode2.Nodes.Add(ProcessName[i]);
                Thread.Sleep(5);
                Application.DoEvents();
            }


            this.label1.Text = "选择优化项";
            this.Scan_loading.Visible = false;
        }
        #endregion

        #region 提取并保存进程图标
        private void SaveProgressIco()
        {
            using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select ProcessId, Name, ExecutablePath from Win32_Process"))
            {
                using (var results = managementObjectSearcher.Get())
                {
                    var processes = results.Cast<ManagementObject>().Select(p => new
                    {
                        ProcessId = (UInt32)p["ProcessId"],
                        Name = (string)p["Name"],
                        ExecutablePath = (string)p["ExecutablePath"]
                    });
                    foreach (var pro in processes)
                    {
                        if (System.IO.File.Exists(pro.ExecutablePath))
                        {
                            var icon = Icon.ExtractAssociatedIcon(pro.ExecutablePath);
                            var key = pro.ProcessId.ToString();
                            string[] ProcessName = pro.Name.Split(new char[] { '.' });
                            Icon myIcon = icon;
                            FileStream fileStream = new FileStream(@"bin\ico\" + ProcessName[0] + ".ico", FileMode.Create);
                            myIcon.Save(fileStream);
                            fileStream.Close();
                        }
                    }
                }
            }
        }
        #endregion

        #region 获取应用程序目录
        private string GetProcesspath(Process p)
        {
            try
            {
                return p.MainModule.FileName.ToString();
            }
            catch (Exception) { }
            return "error";
        }
        #endregion

        #region 优化加速
        private void button1_Click(object sender, EventArgs e)
        {

            this.top_panel.Visible = true;
            this.Scan_panel.Visible = false;
            RegistryKeys.Clear();
            RegistryValues.Clear();
            this.treeView1.Nodes.Clear();
        }
        #endregion

        #region 取消优化
        private void button2_Click(object sender, EventArgs e)
        {
            this.top_panel.Visible = true;
            this.Scan_panel.Visible = false;
            RegistryKeys.Clear();
            RegistryValues.Clear();
            this.treeView1.Nodes.Clear();
        }
        #endregion



        private void top_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void TreeView1_(object sender, TreeViewEventArgs e)
        {

        }

        #region 父节点控制子节点CheckBoxe
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {

                if (e.Node.Checked)
                {
                    //取消节点选中状态之后，取消所有父节点的选中状态
                    setChildNodeCheckedState(e.Node, true);
                }
                else
                {
                    //取消节点选中状态之后，取消所有父节点的选中状态
                    setChildNodeCheckedState(e.Node, false);
                    //如果节点存在父节点，取消父节点的选中状态
                    if (e.Node.Parent != null)
                    {
                        setParentNodeCheckedState(e.Node, false);
                    }
                }
            }
        }

        //取消节点选中状态之后，取消所有父节点的选中状态
        private void setParentNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNode parentNode = currNode.Parent;
            parentNode.Checked = state;
            if (currNode.Parent.Parent != null)
            {
                setParentNodeCheckedState(currNode.Parent, state);
            }
        }

        //选中节点之后，选中节点的所有子节点
        private void setChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    setChildNodeCheckedState(tn, state);
                }
        }





        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void 优化加速_Paint(object sender, PaintEventArgs e)
        {
            //Application.DoEvents();

            Application.DoEvents();
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(Skin_paper.ColorID);


        }
    }


}
