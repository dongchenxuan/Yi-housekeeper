using FastScan_API;
using HingeScan_API;
using SelfScan_API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace GUI.UI
{


    public partial class 木马查杀 : Form
    {

        #region 病毒库的方法引用

        FastScan CompareFastScan = new FastScan();
        HingeScan CompareHingeScan = new HingeScan();
        SelfScan CompareSelfScan = new SelfScan();

        #endregion

        //完成扫描信号
        Boolean Completedsignal = false;

        //定义全局变量，为线程结束提供信息
        public static int Scan_option;
        //定义全局变量，给自定义扫描提供目录
        public static string Self_Scan_path;
        //定义全局变量，统计文件总数
        public static int file_num;
        //设置处理方式
        public static string Handing_method;
        //保存扫描到的危险项
        List<string> Dangerous_items = new List<string>();
        //保存扫描到的威胁项
        List<string> Threat_items = new List<string>();
        //保存自定义的所有文件
        List<string> FileName_item = new List<string>();
        //用于保存文件数
        int allfile_num;

        //计时器  
        private System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();

        //自动重置事件类    
        //主要用到其两个方法 WaitOne() 和 Set() , 前者阻塞当前线程，后者通知阻塞线程继续往下执行  
        AutoResetEvent autoEvent = new AutoResetEvent(false);

        private static 木马查杀 formInstance;

        /// <summary>
        /// 私有：线程同步信号
        /// </summary>
        private ManualResetEvent cmdWaiter;
        // 代理定义，可以在Invoke时传入相应的参数, 更新进度列表
        private delegate void funHandle(float nValue);
        /// <summary>
        /// 结束提示委托
        /// </summary>
        private delegate void showEnd();

        #region 相关线程定义
        Thread threadProgress;
        Thread threadtime_clock;
        Thread threadFast_scan;
        Thread threadHing_scan;
        Thread threadSelf_scan;

        Thread threadReminder;
        Thread threadTimeLabel;
        Thread threadProcessedLabel;
        #endregion

        #region 相关窗口
        public static 隔离区 form = null;
        #endregion

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
            // 阻塞当前线程
            cmdWaiter = new ManualResetEvent(false);

            InitializeComponent();
            ProgressBar.CheckForIllegalCrossThreadCalls = false;
            tm.Interval = 1;
            tm.Tick += new EventHandler(tm_Tick);
            threadtime_clock = new Thread(new ThreadStart(UpdateLacation_time));
            threadReminder = new Thread(new ThreadStart(UpdateReminder));
            threadProcessedLabel = new Thread(new ThreadStart(UpdateProcessedLabel));

            threadtime_clock.Start();
            threadReminder.Start();
            threadProcessedLabel.Start();
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

        #region 计时器相关
        void tm_Tick(object sender, EventArgs e)
        {
            autoEvent.Set(); //通知阻塞的线程继续执行
        }
        #endregion

        #region 控制扫描线程
        private void button4_Click(object sender, EventArgs e)
        {
            if (tm.Enabled)
            {
                button4.Text = "继续";
                tm.Stop();
            }
            else
            {
                button4.Text = "暂停";
                tm.Start();
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
                Write_Cancel();
                switch (Scan_option)
                {
                    case 1: threadFast_scan.Abort(); threadFast_scan.DisableComObjectEagerCleanup(); break;
                    case 2: threadHing_scan.Abort(); threadHing_scan.DisableComObjectEagerCleanup(); break;
                    case 3: threadSelf_scan.Abort(); threadSelf_scan.DisableComObjectEagerCleanup(); threadSelf_scan.Abort(); break;
                }

                threadTimeLabel.Abort(); threadTimeLabel.DisableComObjectEagerCleanup();
                threadProgress.Abort(); threadProgress.DisableComObjectEagerCleanup();
                tm.Dispose(); tm.Stop();
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
                    #region 数据初始化
                    file_num = 0;
                    progressBar1.Value = 0;
                    #endregion
                }
            }
        }
        #endregion

        #region 更新Label标签
        #region 更新扫描时间
        private int second = 1;
        private void Time_add()
        {
            int Timeadd_min = 0, Timeadd_seconds = 0;
            while (true)
            {
                Timeadd_seconds += second;
                if (Timeadd_seconds == 60)
                {
                    Timeadd_min++;
                    Timeadd_seconds = 0;
                }
                this.time_label.Refresh();
                this.time_label.Text = String.Format("{0:00}", Timeadd_min) + ":" + String.Format("{0:00}", Timeadd_seconds); ;//Timeadd_min + ":" + Timeadd_seconds;//String.Format("{0:00}:{0:00}", Timeadd_min, Timeadd_seconds);//Timeadd_min + ":" + Timeadd_seconds;
                Application.DoEvents();
                Thread.Sleep(1000);
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
            }
        }
        #endregion
        private void UpdateLabel(string str)
        {
            this.label1.Text = str;
            Application.DoEvents();
        }
        private void UpdateLacation_time()
        {
            while (true)
            {
                string This_time = DateTime.Now.ToLongTimeString().ToString();
                string This_date = DateTime.Now.ToString("yyyy年MM月dd日");
                this.Lacation_time.Text = This_time + "\n" + This_date;
                Application.DoEvents();
                Thread.Sleep(1000);
                Lacation_time.Refresh();
            }
        }
        private void UpdateReminder()
        {
            while (true)
            {
                string[] TimeArray = Read_Resultlog().Split(',');

                TimeSpan ts1 = new TimeSpan(DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                TimeSpan ts2 = new TimeSpan(int.Parse(TimeArray[2]), int.Parse(TimeArray[3]), int.Parse(TimeArray[4]), int.Parse(TimeArray[5]));

                TimeSpan ts = ts1.Subtract(ts2).Duration();

                if (ts.Hours > 0)
                    this.label2.Text = "距离上次扫描已有" + "\n" + ts.Days.ToString() + "天"
                    + ts.Hours.ToString() + "小时";
                else
                    this.label2.Text = "上次扫描" + "\n" + TimeArray[1] + "月" + TimeArray[2] + "日" + TimeArray[3] + ":" + TimeArray[4];
                Application.DoEvents();
                Thread.Sleep(1000);
                label2.Refresh();
            }
        }

        //更新已处理文件数
        private void UpdateProcessedLabel()
        {
            int Dangerousitemsnum, Suspiciousitemnum;
            //if(Completedsignal == true)
                while (true)
                {
                    /*
                    FileStream fs1 = new FileStream(@".\\bin\\processed.dat", FileMode.Open, FileAccess.Read);
                    BinaryReader r1 = new BinaryReader(fs1);
                    Dangerousitemsnum = r1.ReadInt32();
                    r1.Close();
                    fs1.Close();
                    */
                    Suspiciousitemnum = Getfilenum(@".\IsolationBox");
                    //this.label4.Text = "已处理危险项：" + Dangerousitemsnum;
                    this.label5.Text = "已处理可疑项：" + Suspiciousitemnum;
                    Completedsignal = false;
                    Application.DoEvents();
                    Thread.Sleep(1000);
                }
        }

        //更新扫描文件数
        private void UpdateScannedfilenum()
        {
            label3.Text = "已扫描：" + allfile_num;
            label3.Refresh();
        }
        //更新已发现危险项数
        private void UpdateDangerouslabel()
        {
            Threatlabel.Text = "已发现风险项：" + Threat_items.Count;
            Threatlabel.Refresh();
        }
        //更新已发现风险项数
        private void UpdateThreatlabel()
        {
            Dangerouslabel.Text = "已发现危险项：" + Dangerous_items.Count;
            Dangerouslabel.Refresh();
        }

        #endregion

        #region 进度条相关

        #region 更新进度条线程
        private void ProgressBar_add()
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = file_num;
            progressBar1.Step = 1;
            for (int i = 0; i < file_num; i++)
            {
                progressBar1.PerformStep();
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                //SetTextMessage(100 * i / file_num);
            }
            this.On_EndLog();
            this.cmdWaiter.Reset();

        }
        #endregion

        /*
        #region 进度条值更新函数（参数必须跟声明的代理参数一样）
        private void SetTextMessage(float ipos)
        {
            if (this.InvokeRequired)
            {
                funHandle setpos = new funHandle(SetTextMessage);
                this.Invoke(setpos, new object[] { ipos });
            }
            else
            {
                this.progressBar1.Value = Convert.ToInt32(ipos);
            }
        }
        #endregion
        */

        private void On_EndLog()
        {
            
            showEnd endDeg = new showEnd(DisplaySRI);
            this.Invoke(endDeg);
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
            Application.DoEvents();
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
            listView1.Columns.Clear();
        }
        #endregion

        #region 处理扫描结果

        //获取文件名
        private string Getfilename(string path)
        {
            string filename = Path.GetFileName(path);
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
            //指定存储的路径
            string pSaveFilePath ;

            foreach (string pLocalFilePath in Threat_items)
            {
                string fileName = Path.GetFileName(pLocalFilePath);
                if (File.Exists(pLocalFilePath)) //判断要复制的文件是否存在
                {
                    pSaveFilePath = Directory.GetCurrentDirectory() + @"\IsolationBox\" + fileName + @".ws";
                    File.Copy(pLocalFilePath, pSaveFilePath, true);
                    File.Delete(pLocalFilePath);
                }   
            }
        }

        //写入当天扫描结果
        private void Write_Resultlog(string Processing_status, int Dangerous_itemsNum, int Threat_itemsNum)
        {
            string Dangerous_items = Processing_status + "危险项：" + Dangerous_itemsNum;
            string Threat_items = Processing_status + "可疑项：" + Threat_itemsNum;
            string Handle_ting = DateTime.Now.ToString("yyyy,MM,dd,HH,mm,ss");
            FileInfo finfo = new FileInfo(@".\\bin\\Result.dat");
            if (finfo.Exists==false)//如果文件不存在
            {
                File.Create(@".\\bin\\Result.dat");
            }
            //为文件打开一个二进制写入器
            FileStream fs = new FileStream(@".\\bin\\Result.dat", FileMode.Append);
            StreamWriter wr = new StreamWriter(fs);

            wr.WriteLine(Dangerous_items);
            wr.WriteLine(Threat_items);
            wr.WriteLine(Handle_ting);
            wr.Close();
            fs.Close();
            FileInfo finfo1 = new FileInfo(@".\\bin\\processed.dat");
            if (finfo1.Exists == false)//如果文件不存在
            {
                File.Create(@".\\bin\\processed.dat");
            }
            FileStream fs1 = new FileStream(@".\\bin\\processed.dat", FileMode.Open, FileAccess.Read);
            FileStream fs2 = new FileStream(@".\\bin\\processed.dat", FileMode.Open, FileAccess.Write);
            BinaryReader r1 = new BinaryReader(fs1);
            int items = r1.ReadInt32();
            items += Dangerous_itemsNum;
            r1.Close();
            fs1.Close();
            StreamWriter wr1 = new StreamWriter(fs2);
            wr1.WriteLine(items);
            wr1.Close();
            fs2.Close(); 
        }
        
        //取消处理的处理操作
        private void Write_Cancel()
        {
            string Cancel_Result = "已取消扫描";
            string Handle_ting = DateTime.Now.ToString("yyyy,MM,dd,HH,mm,ss");
            //为文件打开一个二进制写入器
            FileStream fs = new FileStream(@".\\bin\\Result.dat", FileMode.Append);
            StreamWriter wr = new StreamWriter(fs);
            wr.WriteLine(Cancel_Result);
            wr.WriteLine(Handle_ting);
            wr.Close();
            fs.Close();
        }

        //读取上一次保存的日志信息
        private string Read_Resultlog()
        {
            string oldValue = string.Empty, newValue = string.Empty;

            FileStream fs = new FileStream(@".\\bin\\Result.dat", FileMode.Open);//打开txt文件
            StreamReader sr = new StreamReader(fs);
            do
            {
                newValue = sr.ReadLine();
                oldValue = newValue ?? oldValue;
            } while (newValue != null);

            sr.Close();
            fs.Close();

            return oldValue;
        }

        #endregion

        #region 三个扫描：快速、全盘、自定义

        #region 快速查杀
        private void button1_Click(object sender, EventArgs e)
        {
            Show_Title();

            Scan_option = 1;
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.button6.Image = global::GUI.Properties.Resources.b1;
            this.panel3.Visible = true;
            this.panel4.Visible = true;
            this.button4.Visible = true;
            this.button4.Text = "暂停";
            this.button5.Visible = true;
            StartThread();
        }
        //获取扫描路径
        private string GetFastscan_File(int i)
        {
            string[] path = new string[4];

            /*获取用户逻辑桌面*/
            path[0] = @Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            /*包含“启动”程序组的目录*/
            path[1] = @Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            /*包含当前软件的目录*/
            path[2] = Directory.GetCurrentDirectory();
            /*包含用户最近使用的文档的目录*/
            path[3] = @Environment.GetFolderPath(Environment.SpecialFolder.Recent);

            return @path[i];
        }
        //获取快速扫描文件总数
        private int GetFastscan_Filenum()
        {
            int filenum = 0;

            //获取文件总数
            for (int i = 0; i < 4; i++)
            {
                filenum += Getfilenum(GetFastscan_File(i));
            }
            return filenum;
        }
        //快速扫描函数
        private void Fast_Scan()
        {
            for (int i = 0; i < 4; i++)
            {
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                getAll(GetFastscan_File(i));
            }
            this.On_EndLog();
            this.cmdWaiter.Reset();
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
            StartThread();
        }
        //获取全盘扫描的文件数
        private int GetHingescan_Filenum()
        {
            int filenum = 0;
            string[] drives = Directory.GetLogicalDrives();
            foreach (string drive in drives)
            {
                filenum += Getfilenum(drive);
            }
            return filenum;
        }
        //全盘扫描函数
        private void Hinge_Scan()
        {
            string[] drives = Directory.GetLogicalDrives();
            foreach (string drive in drives)
            {
                getAll(drive);
            }
            this.On_EndLog();
            this.cmdWaiter.Reset();
        }
        #endregion
        #region 自定义查杀
        private void button3_Click(object sender, EventArgs e)
        {
            Scan_option = 3;

            FolderBrowserDialog path = new FolderBrowserDialog();
            path.Description = "选择文件目录";
            path.ShowNewFolderButton = false;

            if (path.ShowDialog() == DialogResult.OK)
            {
                Show_Title();
                Self_Scan_path = path.SelectedPath;

                this.panel1.Visible = false;
                this.panel2.Visible = false;
                this.button6.Image = global::GUI.Properties.Resources.b1;
                this.panel3.Visible = true;
                this.panel4.Visible = true;
                this.button4.Visible = true;
                this.button4.Text = "暂停";
                this.button5.Visible = true;
                StartThread();
            }
            else
            {
                this.panel2.Visible = false;
                this.button6.Image = global::GUI.Properties.Resources.b1;
                this.panel4.Visible = false;
                this.panel3.Visible = false;
                this.panel1.Visible = true;
                this.button7.Visible = false;
                this.button8.Visible = false;
            }

        }
        //获取自定义扫描的文件数
        private int GetSelfscan_Filenum()
        {
            int filenum = Getfilenum(Self_Scan_path);
            //GetSelfFile(Self_Scan_path);
            return filenum;
        }
        //自定义扫描函数
        private void Self_Self()
        {
            getAll(Self_Scan_path);
            /*
            autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
            foreach (var filname in FileName_item)
            {
                Document_validation(filname);
                allfile_num++;
                UpdateLabel(filname);//显示文件路径+文件名
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
            }
            */
            this.On_EndLog();
            this.cmdWaiter.Reset();
        }
        private void GetSelfFile(string path)
        {

            DirectoryInfo sDir = new DirectoryInfo(path);
            try
            {
                FileInfo[] fileArray = sDir.GetFiles();
                foreach (FileInfo file in fileArray)
                {
                    FileName_item.Add(file.FullName);
                }
            }
            catch (Exception e)
            {
            }

            try
            {
                DirectoryInfo[] subDirArray = sDir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirArray)
                {
                    GetSelfFile(subDir.FullName);
                }
            }
            catch (Exception e)
            {
            }
        }
        #endregion

        #region 获取文件MD5值
        protected string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
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
        #region 文件验证
        private void Document_validation(string path)
        {
            string Now_time = DateTime.Now.ToString("yyyy-MM-dd");
            //为文件打开一个二进制写入器
            FileStream fs = new FileStream(@"log\" + Now_time + @".log", FileMode.Append);
            StreamWriter wr = new StreamWriter(fs);

            wr.WriteLine(path);

            wr.Close();
            fs.Close();
            string extension = Path.GetExtension(path);
            string file_md5 = GetMD5HashFromFile(path); //获取文件md5
            //快速扫描
            if (Scan_option == 1 && extension.Equals(".ws")==false)
            {
                if (CompareFastScan.GetFastScanmd5(file_md5) == 0)
                {
                     Extension_validation(extension,path);
                     Show_ScanResult_List(path, file_md5);
                 }
            }
            //全盘扫描
            if (Scan_option == 2 && extension.Equals(".ws") == false)
            {
                if (CompareHingeScan.GetHingeScanmd5(file_md5) == 0)
                 {
                     Extension_validation(extension,path);
                     Show_ScanResult_List(path, file_md5);
                 }
            }
            //自定义扫描    
            if (Scan_option == 3 && extension.Equals(".ws") == false)
            {
                if (CompareSelfScan.GetSelfScanmd5(file_md5) == 0)
                {
                    Extension_validation(extension,path);
                    Show_ScanResult_List(path, file_md5);
                }
            }
            UpdateScannedfilenum();
            UpdateDangerouslabel();
            UpdateThreatlabel();
        }
        #region 验证文件后缀名
        private void Extension_validation(string extension,string path)
        {
            string[] Del_extension = new string[6];
            Del_extension[0] = ".exe";
            Del_extension[1] = ".dll";
            Del_extension[2] = ".bat";
            Del_extension[3] = ".reg";
            Del_extension[4] = ".vbs";
            Del_extension[5] = ".cmd";

            for (int i = 0; i < Del_extension.Length; i++)
            {
                if (extension.Equals(Del_extension[i]) == true)
                {
                    Handing_method = "删除";
                    Dangerous_items.Add(path);
                    break;
                }
                else if (i == Del_extension.Length - 1)
                {
                    Threat_items.Add(path);
                    Handing_method = "隔离";
                }   
            }
        }
        #endregion

        #endregion
        #region 遍历文件夹
        private void getAll(string @path)
        {
            DirectoryInfo sDir = new DirectoryInfo(path);
            //try
            {
                FileInfo[] fileArray = sDir.GetFiles();
                foreach (FileInfo file in fileArray)
                {
                    allfile_num++;
                    UpdateLabel(file.FullName);//显示文件路径+文件名
                    Document_validation(file.FullName);
                    autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                }
            }
            //catch (Exception e)
            {
            }

            //try
            {
                DirectoryInfo[] subDirArray = sDir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirArray)
                {
                    getAll(subDir.FullName);
                }
            }
            //catch (Exception e)
            {
            }
            /*
            //遍历文件夹
            DirectoryInfo theFolder = new DirectoryInfo(path);
            FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile in thefileInfo)  //遍历文件
            {
                allfile_num++;
                UpdateLabel(NextFile.FullName);//显示文件路径+文件名
                //验证文件
                Document_validation(NextFile.FullName);
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
            }

            //遍历子文件夹
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            foreach (DirectoryInfo NextFolder in dirInfo)
            {
                FileInfo[] fileInfo = NextFolder.GetFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo NextFile in fileInfo)  //遍历文件
                {
                    allfile_num++;
                    UpdateLabel(NextFile.FullName);//显示文件路径+文件名
                    //验证文件
                    Document_validation(NextFile.FullName);
                    autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行
                }
            }

            */


            /*
            DirectoryInfo sDir = new DirectoryInfo(path);
            try
            {
                FileInfo[] fileArray = sDir.GetFiles();
                
                foreach (FileInfo file in fileArray)
                {
                    //如果是文件
                    if (!Directory.Exists(file.FullName))
                    {
                        allfile_num++;
                        UpdateLabel(file.FullName);//显示文件路径+文件名
                        Document_validation(file.FullName);
                    }
                    autoEvent.WaitOne();  
                }
            }
            catch (Exception){  }

            try
            {
                DirectoryInfo[] subDirArray = sDir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirArray)
                {
                    GetAll(subDir.FullName);
                }
            }
            catch (Exception)
            {
            }

            */

        }
        #endregion
        #region 取得目录下的文件数
        private int Getfilenum(string filepath)
        {
            int filenum = 0;
            try
            {
                filenum += Directory.GetFiles(filepath).Length;
                foreach (var folder in Directory.GetDirectories(filepath))
                    filenum += Getfilenum(folder);
            }
            catch(Exception ex) { }
            /*
            filenum += Directory.GetFiles(filepath).Length;

            foreach (var folder in Directory.GetDirectories(filepath))
                filenum += Getfilenum(folder);
            */
            return filenum;
        }
        #endregion

        #endregion

        #region 启动相关线程

        private void StartThread()
        {
            //如果是快速扫描
            if (Scan_option == 1)
            {
                file_num = GetFastscan_Filenum();
                threadFast_scan = new Thread(new ThreadStart(Fast_Scan));
                threadProgress = new Thread(new ThreadStart(ProgressBar_add));
                threadTimeLabel = new Thread(new ThreadStart(Time_add));
                tm.Start();
                threadFast_scan.Start();
                threadProgress.Start();
                threadTimeLabel.Start();
            }
            //如果是全盘扫描
            else if (Scan_option == 2)
            {
                file_num = GetHingescan_Filenum();
                threadHing_scan = new Thread(new ThreadStart(Hinge_Scan));
                threadProgress = new Thread(new ThreadStart(ProgressBar_add));
                threadTimeLabel = new Thread(new ThreadStart(Time_add));
                tm.Start();
                threadHing_scan.Start();
                threadProgress.Start();
                threadTimeLabel.Start();
            }
            //如果是自定义扫描
            else
            {
                file_num = GetSelfscan_Filenum();
                threadSelf_scan = new Thread(new ThreadStart(Self_Self));
                threadProgress = new Thread(new ThreadStart(ProgressBar_add));
                threadTimeLabel = new Thread(new ThreadStart(Time_add));
                tm.Start();
                threadSelf_scan.Start();
                threadProgress.Start();
                threadTimeLabel.Start();
            }
        }

        #endregion

        #region 显示扫描结果界面
        private void DisplaySRI()
        {
            switch (Scan_option)
            {
                case 1:
                    threadTimeLabel.Abort();
                    threadTimeLabel.DisableComObjectEagerCleanup();
                    threadProgress.Abort();
                    threadProgress.DisableComObjectEagerCleanup();
                    threadFast_scan.Abort();
                    threadFast_scan.DisableComObjectEagerCleanup();
                    tm.Dispose(); tm.Stop();
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
                        #region 数据初始化
                        file_num = 0;
                        progressBar1.Value = 0;
                        FileName_item = new List<string>();
                        Remove_items();
                        allfile_num = 0;
                        #endregion
                    }
                    break;
                case 2:
                    threadTimeLabel.Abort();
                    threadTimeLabel.DisableComObjectEagerCleanup();
                    threadProgress.Abort();
                    threadProgress.DisableComObjectEagerCleanup();
                    threadHing_scan.Abort();
                    threadHing_scan.DisableComObjectEagerCleanup();
                    tm.Dispose(); tm.Stop();
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
                        #region 数据初始化
                        file_num = 0;
                        progressBar1.Value = 0;
                        FileName_item = new List<string>();
                        Remove_items();
                        allfile_num = 0;
                        #endregion
                    }
                    break;
                case 3:
                    threadTimeLabel.Abort();
                    threadTimeLabel.DisableComObjectEagerCleanup();
                    threadProgress.Abort();
                    threadProgress.DisableComObjectEagerCleanup();
                    threadSelf_scan.Abort();
                    threadSelf_scan.DisableComObjectEagerCleanup();
                    tm.Dispose(); tm.Stop();
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
                        #region 数据初始化
                        file_num = 0;
                        progressBar1.Value = 0;
                        FileName_item = new List<string>();
                        Remove_items();
                        allfile_num = 0;
                        #endregion
                    }
                    break;
            }
        }
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
            #region 数据初始化
            file_num = 0;
            progressBar1.Value = 0;
            FileName_item = new List<string>();
            Dangerous_items = new List<string>();
            Threat_items = new List<string>();
            allfile_num = 0;
            #endregion
            Remove_items();
            Completedsignal = true;
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
            #region 数据初始化
            file_num = 0;
            progressBar1.Value = 0;
            FileName_item = new List<string>();
            Dangerous_items = new List<string>();
            Threat_items = new List<string>();
            allfile_num = 0;
            #endregion
            Remove_items();
            Completedsignal = true;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Lacation_time_Click(object sender, EventArgs e)
        {

        }

        private void Wram_title_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Threatlabel_Click(object sender, EventArgs e)
        {

        }

        private void Dangerouslabel_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            隔离区 form = new 隔离区();
            form.Show();
        }
    }
}
