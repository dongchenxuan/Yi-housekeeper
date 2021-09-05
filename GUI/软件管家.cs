using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class 软件管家 : Form
    {
        private static 软件管家 formInstance;

        private Button Uninstall = new Button();

        private Boolean repeat = false;

        public static 软件管家 GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new 软件管家();
                    return formInstance;
                }
            }
        }
        public 软件管家()
        {
            InitializeComponent();

            this.toolTip1.IsBalloon = true;
            this.toolTip1.SetToolTip(this.button6, "查看已成功安装的软件");

            //GetSoftware();
            // listView1.Click += new EventHandler(listView1_Click);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Success!");
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

        private void 软件管家_Load(object sender, EventArgs e)
        {

        }
        public void SetBackgroudImage(string imageFileName)
        {
            this.BackgroundImage = System.Drawing.Image.FromFile(imageFileName);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("你确定要卸载改应用吗？");
        }


        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.View = View.Tile;
            listView1.LargeImageList = imageList1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
            listView1.LargeImageList = imageList1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
            listView1.LargeImageList = imageList1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.LargeImageList = imageList1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetSoftware();
        }

        #region 添加卸载按钮
        private void AddUninstallBut()
        {

            Uninstall.Text = "卸载";
            Uninstall.Location = new Point(0, 20);
            Uninstall.Height = 20;
            Uninstall.Width = 40;
            this.listView1.Controls.Add(Uninstall);
        }
        #endregion

        #region 获取软件
        private void GetSoftware()
        {
            using (RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false))
            {

                if (key != null)
                {

                    foreach (string keyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey key2 = key.OpenSubKey(keyName, false))
                        {
                            if (key2 != null)
                            {
                                string softwareName = key2.GetValue("DisplayName", "").ToString();
                                string installLocation = key2.GetValue("InstallLocation", "").ToString();
                                Regex regSymbol = new Regex("\"");
                                if (regSymbol.IsMatch(installLocation))
                                {
                                    string words = installLocation;
                                    Regex regex = new Regex("\"[^\"]*\"");
                                    installLocation = regex.Match(words).Value.Replace("\"", "");
                                }
                                double softwareFootprint = GetDirectorySize(installLocation) / 1048576;
                                if (!string.IsNullOrEmpty(installLocation))
                                {

                                    //this.textBox1.AppendText(string.Format("软件名：{0} -- 安装路径：{1}\r\n", softwareName, installLocation));
                                    ListViewItem lvi = new ListViewItem();
                                    lvi.SubItems.Add(softwareName);
                                    lvi.SubItems.Add(softwareFootprint.ToString("f2") + "MB");
                                    lvi.SubItems.Add(installLocation);
                                    this.listView1.Items.Add(lvi);
                                    Thread.Sleep(5);
                                    Application.DoEvents();


                                    //this.listView1.Items.Add(string.Format("软件名：{0} -- 安装路径：{1}\r\n", softwareName, installLocation));
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 获取软件占用空间
        /// 获取文件夹大小
        /// </summary>
        /// <param name="dirPath"></param>
        /// <returns></returns> 
        private static long GetDirectorySize(string dirPath)
        {
            if (!System.IO.Directory.Exists(dirPath))
                return 0;
            long len = 0;
            DirectoryInfo di = new DirectoryInfo(dirPath);
            //获取di目录中所有文件的大小
            foreach (FileInfo item in di.GetFiles())
            {
                len += item.Length;
                Application.DoEvents();
            }

            //获取di目录中所有的文件夹,并保存到一个数组中,以进行递归
            DirectoryInfo[] dis = di.GetDirectories();
            if (dis.Length > 0)
            {
                for (int i = 0; i < dis.Length; i++)
                {
                    //递归dis.Length个文件夹,得到每隔dis[i]
                    len += GetDirectorySize(dis[i].FullName);
                    Application.DoEvents();
                }
            }
            return len;
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static long GetFileSize(string filePath)
        {
            long temp = 0;
            //判断当前路径是否指向某个文件
            if (!File.Exists(filePath))
            {
                string[] strs = Directory.GetFileSystemEntries(filePath);
                foreach (string item in strs)
                {
                    temp += GetFileSize(item);
                    Application.DoEvents();
                }
            }
            else
            {
                FileInfo fileInfo = new FileInfo(filePath);
                return fileInfo.Length;
            }
            return temp;
        }


        #endregion

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void 软件管家_Paint(object sender, PaintEventArgs e)
        {
            Application.DoEvents();
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(Skin_paper.ColorID);
        }
    }
}
