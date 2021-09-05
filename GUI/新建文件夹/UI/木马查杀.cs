using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WsecurityVirus;

namespace GUI.UI
{


    public partial class 木马查杀 : Form
    {
        Virus CompareMD5 = new Virus();

        //定义全局整形变量，为线程结束提供信息
        public static int Scan_option;
        //定义全局变量，给自定义扫描提供目录
        public static string Self_Scan_path;
        //定义全局变量，统计文件总数
        public static int file_num;
        //设置处理方式
        public static string Handing_method;

        //保存遍历所得的文件名称及目录
        List<string> nameList = new List<string>();
        //保存扫描到的危险项
        List<string> Dangerous_items = new List<string>();
        //保存扫描到的威胁项
        List<string> Threat_items = new List<string>();
        
        //计时器  
        private System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
        //自动重置事件类    
        //主要用到其两个方法 WaitOne() 和 Set() , 前者阻塞当前线程，后者通知阻塞线程继续往下执行  
        AutoResetEvent autoEvent = new AutoResetEvent(false);
        long TimeCount;
        //定义委托
        public delegate void SetControlValue(long value);

        private static 木马查杀 formInstance;

        private List<string> files = new List<string>();

        // 代理定义，可以在Invoke时传入相应的参数, 更新进度列表
        private delegate void funHandle(int nValue);

        Thread threadProgress;
        Thread threadFast_scan;
        Thread threadFull_scan;
        Thread threadSelf_scan;
        Thread threadtime_clock;

        public static 木马查杀 GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new 木马查杀();
                    return formInstance;
                }
            }
        }
        public 木马查杀()
        {
            InitializeComponent();
            ProgressBar.CheckForIllegalCrossThreadCalls = false;
            tm.Interval = 1;
            tm.Tick += new EventHandler(tm_Tick);
        }

        #region 解决闪烁问题
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        #region 计时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value++;
            else
                timer1.Enabled = false;
        }

        #region 计时器 事件  
        void tm_Tick(object sender, EventArgs e)
        {
            autoEvent.Set(); //通知阻塞的线程继续执行  
        }
        #endregion

        #endregion

        #region 控制扫描线程
        private void button4_Click(object sender, EventArgs e)
        {
            if (tm.Enabled)
            {
                button4.Text = "继续";
                tm.Stop();
                switch (Scan_option)
                {
                    case 1: threadFast_scan.Suspend(); break;
                    case 2: threadFull_scan.Suspend(); break;
                    case 3: threadSelf_scan.Suspend(); break;
                }
            }
            else
            {
                button4.Text = "暂停";
                tm.Start();
                switch (Scan_option)
                {
                    case 1: threadFast_scan.Resume(); break;
                    case 2: threadFull_scan.Resume(); break;
                    case 3: threadSelf_scan.Resume(); break;
                }

            }
        }
        #endregion

        #region 取消扫描
        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要停止扫描吗？", "",
                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK
                  )
            {
                switch (Scan_option)
                {
                    case 1:
                        if (threadFast_scan.ThreadState.ToString() == "Running")
                            threadFast_scan.Abort();
                        else {
                            threadFast_scan.Resume();
                            threadFast_scan.Abort();
                        } break;
                    case 2:
                        if (threadFull_scan.ThreadState.ToString() == "Running")
                            threadFull_scan.Abort();
                        else {
                            threadFull_scan.Resume();
                            threadFull_scan.Abort();
                        } break;
                    case 3:
                        if (threadSelf_scan.ThreadState.ToString() == "Running")
                            threadSelf_scan.Abort();
                        else
                        {
                            threadSelf_scan.Resume();
                            threadSelf_scan.Abort();
                        }
                        break;
                }
                threadProgress.Abort();
                tm.Stop();
                tm.Dispose();
                if (Dangerous_items.Count != 0 || Threat_items.Count != 0)
                {
                    this.button4.Visible = false;
                    this.button5.Visible = false;
                    this.button7.Visible = true;
                    this.button8.Visible = true;
                }
                else
                {
                    this.panel4.Visible = false;
                    this.panel3.Visible = false;
                    this.panel1.Visible = true;
                }
            }
        }
        #endregion

        #region 显示扫描的计时器
        private void Delegate_time()
        {
            this.Invoke(new SetControlValue(ShowTime), TimeCount);
            TimeCount++;
        }
        private void ShowTime(long t)
        {

            TimeSpan temp = new TimeSpan(0, 0, (int)t);
            time_label.Text = string.Format("{0:00}:{1:00}:{2:00}", temp.Hours, temp.Minutes, temp.Seconds);
            time_label.Refresh();
        }
        #endregion

        private void UpdateLabel(string str)
        {
            this.label1.Text = str;
            label1.Refresh();
        }


        #region 进度条相关

        #region 更新进度条线程
        private void ProgressBar_add()
        {

            for (int i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(10);//没什么意思，单纯的执行延时
                SetTextMessage(100 * i / 500);
                autoEvent.WaitOne();    //阻塞当前线程，等待通知以继续执行  
            }
        }
        #endregion

        #region 进度条值更新函数（参数必须跟声明的代理参数一样）
        private void SetTextMessage(int ipos)
        {
            if (this.InvokeRequired)
            {
                funHandle setpos = new funHandle(SetTextMessage);
                this.Invoke(setpos, new object[] { ipos });
            }
            else
            {
                //this.label1.Text = ipos.ToString() + "/100";
                this.progressBar1.Value = Convert.ToInt32(ipos);
            }
        }
        #endregion

        #endregion

        #region 获取文件MD5值
        protected string GetMD5HashFromFile(string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Open);
            try
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return "" + -1;
            }
        }
        #endregion

        #region 反馈扫描结果
        //显示扫描到的威胁文件并进行保存
        private void Show_ScanResult_List(string path, string md5)
        {
            string[] arr = new string[3];
            arr[0] = path; arr[1] = md5; arr[2] = Handing_method;
            ListViewItem lvi = new ListViewItem();
            lvi.SubItems.Add(arr[0]);
            lvi.SubItems.Add(arr[1]);
            lvi.SubItems.Add(arr[2]);
            this.listView1.Items.Add(lvi);
            if (string.Compare(Handing_method, "删除") == 0)
                Dangerous_items.Add(path);
            else if (string.Compare(Handing_method, "隔离") == 0)
                Threat_items.Add(path);
        }
        //罗列标题
        private void Show_Title()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("", 0, HorizontalAlignment.Center);
            listView1.Columns.Add("扫描项", 350, HorizontalAlignment.Left);
            listView1.Columns.Add("特征码", 215, HorizontalAlignment.Center);
            listView1.Columns.Add("处理方式", 70, HorizontalAlignment.Center);
        }
        //清除列表
        private void Remove_items()
        {
            listView1.Items.Clear();
        }
        #endregion

        #region 处理扫描结果
        //获取文件名
        private string Getfilename(string path)
        {
            string filename= Path.GetFileName(path);
            return filename;
        }
        //删除危险文件
        private void DeleteFile()
        {
            foreach (string filename in Dangerous_items)
            {
                File.Delete(filename);
            }
        }
        //隔离威胁文件 
        private void QuaranrineFile()
        {
            string fullName = Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\"));
            fullName = fullName.Substring(0, fullName.LastIndexOf("\\")) + "\\" + "IsolationBox\\" ;
            string Isolation_file = null;
            foreach (string filename in Threat_items) 
            {
                Isolation_file = fullName + Getfilename(filename );
                FileInfo file = new FileInfo(filename);
                file.CopyTo(Isolation_file);
                File.Delete(filename);
            }
        }
        //写入当天扫描结果
        private void Write_Resultlog(string Processing_status,int Dangerous_itemsNum,int Threat_itemsNum)
        {
            string Dangerous_items =Processing_status + "危险项：" + Dangerous_itemsNum;
            string Threat_items = Processing_status + "可疑项：" + Threat_itemsNum;
            string Handle_ting = DateTime.Now.ToString("yyyy,MM,dd,HH,mm,ss");
            //为文件打开一个二进制写入器
            FileStream fs = new FileStream( @".\\bin\\Result.dat", FileMode.Append);
            StreamWriter wr = new StreamWriter(fs);

            wr.WriteLine (Dangerous_items);
            wr.WriteLine(Threat_items);
            wr.WriteLine(Handle_ting);
            wr.Close();
            fs.Close();
            
        }
        //读取上一次保存的日志信息
        private int Read_Resultlog()
        {
            int[] time = new int[6];
            int[] Ctime = new int[6];
            string[] condition = { "," };

            FileStream fs = new FileStream(@".\\bin\\Result.dat", FileMode.Open);//打开txt文件
            StreamReader sr = new StreamReader(fs);
            fs.Seek(0, SeekOrigin.End);//文件定位在末尾
            string last_Resulttime = sr.ReadToEnd();
            
            sr.Close();
            fs.Close();

            string Current_time = DateTime.Now.ToString("yyyy,MM,dd,HH,mm,ss");

            return string.Compare(Current_time,last_Resulttime);
        }
        //相关提示信息
        /*
        private void Show_Tips()
        {
            TimeSpan Time = Read_Resultlog();
            string Ctime = Time.ToString();
            //long Ctime = Time;
            this.label2.Text = "距离上次扫描已有" + Ctime ;
        }
        */
        #endregion

        #region 三个扫描：快速、全盘、自定义

        #region 快速查杀
        private void button1_Click(object sender, EventArgs e)
        {
            Show_Title();

            Scan_option = 1;
            this.panel1.Visible = false;
            this.panel3.Visible = true;
            this.panel4.Visible = true;
            tm.Start();
            threadProgress = new Thread(new ThreadStart(ProgressBar_add));
            threadProgress.Start();
            threadFast_scan = new Thread(new ThreadStart(Fast_scan));
            threadFast_scan.Start();
            threadtime_clock = new Thread(new ThreadStart(Delegate_time));
            threadtime_clock.Start();
        }
        private void Fast_scan()
        {
            string[] path = new string[6];
            /*获取用户逻辑桌面*/
            path[0] = @Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            /*包含“启动”程序组的目录*/
            path[1] = @Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            /*包含用户最近使用的文档的目录*/
            path[2] = @Environment.GetFolderPath(Environment.SpecialFolder.Recent);
            /*包含“开始”菜单项的目录*/
            path[3] = @Environment.GetFolderPath(Environment.SpecialFolder.StartMenu); 
            /*获取我的文档目录*/
            path[4] = @Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            /*获取所有用户使用的应用程序特定数据的公共储存库*/
            path[5] = @Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            
            foreach (string i in path)
            {
                getAll(i);
            }   
        }
       
        #endregion

        #region 全盘查杀
        private void button2_Click(object sender, EventArgs e)
        {
            Show_Title();

            Scan_option = 2;
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.button6.Image = global::GUI.Properties.Resources.b1;
            this.panel3.Visible = true;
            this.panel4.Visible = true;
            this.button4.Visible = true;
            this.button4.Text = "暂停";
            this.button5.Visible = true;
            tm.Start();
            threadProgress = new Thread(new ThreadStart(ProgressBar_add));
            threadFull_scan = new Thread(new ThreadStart(Full_scan));
            threadProgress.Start();
            threadFull_scan.Start();
        }
        private void Full_scan()
        {
            string[] drives = Directory.GetLogicalDrives();
            foreach (string drive in drives)
            {
                getAll(drive);
            }
        }

        #endregion

        #region 文件数取得
        public static int GetFilesCount(DirectoryInfo dirInfo)
        {
            int totalFile = 0;
            totalFile += dirInfo.GetFiles().Length;
            foreach (System.IO.DirectoryInfo subdir in dirInfo.GetDirectories())
            {
                totalFile += GetFilesCount(subdir);
            }
            return totalFile;
        }
        #endregion

        #region 遍历文件夹
        private void getAll(string path)
        {
            
            DirectoryInfo sDir = new DirectoryInfo(path);
            try
            {
                FileInfo[] fileArray = sDir.GetFiles();
                foreach (FileInfo file in fileArray)
                {
                    string str = file.FullName;
                    int index = str.LastIndexOf('.');
                    string result =  string.Empty;
                    string getAll_md5=null;
                    //如果是文件
                    if (File.Exists(file.FullName))
                    {
                        result = str.Substring(index + 1);
                        if (
                            string.Compare(result, "exe") == 0||
                            string.Compare(result, "dll") == 0||
                            string.Compare(result, "bat") == 0||
                            string.Compare(result, "reg") == 0||
                            string.Compare(result, "vbs") == 0||
                            string.Compare(result, "cmd") == 0
                            )
                        {
                            Handing_method = "删除";
                            nameList.Add(file.FullName);
                            UpdateLabel(file.FullName);
                            getAll_md5 = GetMD5HashFromFile(file.FullName);
                            if (CompareMD5.Virusmd5_API(getAll_md5) == 0)
                                Show_ScanResult_List(file.FullName, getAll_md5);
                        }
                        else if (
                            string.Compare(result, "zip") == 0 ||
                            string.Compare(result, "zip") == 0
                            )
                        {
                            Handing_method = "隔离";
                            nameList.Add(file.FullName);
                            UpdateLabel(file.FullName);
                            getAll_md5 = GetMD5HashFromFile(file.FullName);
                            if (CompareMD5.Virusmd5_API(getAll_md5) == 0)
                                Show_ScanResult_List(file.FullName, getAll_md5);
                        }

                    }
                    //如果是文件夹
                    /*else if (Directory.Exists(file.FullName))
                    {
                        System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(file.FullName);
                        file_num = GetFilesCount(dirInfo);
                    }
                    else
                        break;*/
                }
            }
            catch (Exception)
            {
            }

            try
            {
                DirectoryInfo[] subDirArray = sDir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirArray)
                {
                    getAll(subDir.FullName);
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region 自定义查杀
        private void button3_Click(object sender, EventArgs e)
        {
            Show_Title();

            Scan_option = 3;

            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
          

            if (path.ShowDialog() == DialogResult.OK)
            {
                listView1.View = View.Details;
                listView1.Columns.Add("", 0, HorizontalAlignment.Center);
                listView1.Columns.Add("扫描项", 350, HorizontalAlignment.Left);
                listView1.Columns.Add("特征码", 215, HorizontalAlignment.Center);
                listView1.Columns.Add("处理方式", 70, HorizontalAlignment.Center);

                Self_Scan_path = path.SelectedPath;

                this.panel1.Visible = false;
                this.panel2.Visible = false;
                this.button6.Image = global::GUI.Properties.Resources.b1;
                this.panel3.Visible = true;
                this.panel4.Visible = true;

                tm.Start();
                threadProgress = new Thread(new ThreadStart(ProgressBar_add));
                threadSelf_scan = new Thread(new ThreadStart( Self_scan));
                threadProgress.Start();
                threadSelf_scan.Start();
            }
        }
        private void Self_scan()
        {
            getAll(Self_Scan_path);
        }
        #endregion

        #endregion

        #region 扫描选择下拉按钮
        private void button6_Click(object sender, EventArgs e)
        {
            if (this.panel2.Visible)
            {
                this.panel2.Visible = false;
                this.button6.Image = global::GUI.Properties.Resources.b1;
            }      
            else
            {
                this.panel2.Visible = true;
                this.button6.Image = global::GUI.Properties.Resources.b6;
            }
        }
        #endregion

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void 木马查杀_Load(object sender, EventArgs e)
        {

        }

        public void SetBackgroudImage(string imageFileName)
        {
            this.BackgroundImage = System.Drawing.Image.FromFile(imageFileName);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Time_label(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        #region 处理扫描文件
        //立即处理
        private void button7_Click(object sender, EventArgs e)
        {
            Write_Resultlog("已处理", Dangerous_items.Count, Threat_items.Count);
            DeleteFile();
            QuaranrineFile();
            this.panel4.Visible = false;
            this.panel3.Visible = false;
            this.panel1.Visible = true;
            this.button7.Visible = false;
            this.button8.Visible = false;
            Dangerous_items =null;
            Threat_items=null;
        }
        //暂不处理
        private void button8_Click(object sender, EventArgs e)
        {
            Write_Resultlog("未处理", Dangerous_items.Count, Threat_items.Count);
            this.panel4.Visible = false;
            this.panel3.Visible = false;
            this.panel1.Visible = true;
            this.button7.Visible = false;
            this.button8.Visible = false;
            Dangerous_items = null;
            Threat_items = null;
        }

        #endregion

        private void label2_Click(object sender, EventArgs e)
        {
            
            //long Ctime = Time;
            //this.label2.Text = "距离上次扫描已有" + Ctime;
        }
    }
}
