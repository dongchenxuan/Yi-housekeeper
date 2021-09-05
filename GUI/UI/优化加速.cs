using IWshRuntimeLibrary;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
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
                string[] links = Directory.GetFiles(path+"\\", "*.lnk");
                foreach (string file in links)
                {
                    string lnkPath = null;
                    if(System.IO.File.Exists(file))
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

            //罗列开机启动项的子节点
            for (int i = 0; i < Registrystartupkey.Count; i++)
            {
                TreeNode1.Nodes.Add(Registrystartupkey[i]);//文件名称
                Application.DoEvents();
                Thread.Sleep(5);
            }



            ComputerInfo ci = new ComputerInfo();
            double totalMb = ci.TotalPhysicalMemory / 1024 / 1024;
            Process[] processes = Process.GetProcesses();
            foreach(Process process in processes)
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
            for(int i=0;i< ProcessName.Count; i++)
            {
                string IcoPath = @"bin\ico\" + ProcessName[i] + @".ico";
                if (Directory.Exists(IcoPath) == false)
                    IcoPath = @"bin\ico\default.ico";
                imageList1.Images.Add(ProcessName[i],Image.FromFile(IcoPath));
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
            }catch (Exception) { }
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




    }


}
