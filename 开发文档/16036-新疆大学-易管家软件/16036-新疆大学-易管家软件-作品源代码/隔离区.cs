using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class 隔离区 : Form
    {
        List<string> items = new List<string>();

        public 隔离区()
        {
            InitializeComponent();

            Getfilename();
        }

        #region 遍历隔离箱文件名
        private void Getfilename()
        {
            DirectoryInfo Folder = new DirectoryInfo(@".\IsolationBox");
            foreach (FileInfo NextFile in Folder.GetFiles())
            {
                string[] arr = new string[5];
                arr[1] = NextFile.Name.Remove(NextFile.Name.Length - 3);
                string extension = Path.GetExtension(arr[1]);
                arr[2] = extension;
                arr[3] = NextFile.LastAccessTime + "";
                double filesize = NextFile.Length / 1024.0 / 1024.0;
                arr[4] = filesize.ToString("f2") + "MB";
                Application.DoEvents();

                if (arr.Length != 0)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(arr[1]);
                    lvi.SubItems.Add(arr[2]);
                    lvi.SubItems.Add(arr[3]);
                    lvi.SubItems.Add(arr[4]);
                    this.listView1.Items.Add(lvi);
                    items.Add(NextFile.FullName);
                }

            }
        }
        #endregion

        private void 隔离区_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//设置边框为不可调节

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region 退出
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            items = new List<string>();
        }
        #endregion

        #region 恢复隔离文件
        private void button2_Click(object sender, EventArgs e)
        {
            Boolean state = false;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string subpath = path + @"\恢复文件\";
            //指定存储的路径
            string pSaveFilePath;
            if (Directory.Exists(subpath) == false)
            {
                //创建文件夹
                Directory.CreateDirectory(subpath);
            }
            foreach (string pLocalFilePath in items)
            {
                Application.DoEvents();
                string fileName = Path.GetFileName(pLocalFilePath);
                if (File.Exists(pLocalFilePath)) //判断要复制的文件是否存在
                {
                    pSaveFilePath = subpath + fileName.Remove(fileName.Length - 3);
                    File.Copy(pLocalFilePath, pSaveFilePath, true);
                    File.Delete(pLocalFilePath);
                    state = true;
                }
            }
            if (state == true)
                MessageBox.Show(@"隔离文件已还原至目录：桌面\Ws恢复文件", "文件恢复提示");
            else
                MessageBox.Show(@"没有发现隔离文件。你最近可能没有进行安全维护！", "文件恢复提示");

            listView1.Items.Clear();
            listView1.Columns.Clear();
            items = new List<string>();
        }
        #endregion

        #region 清空隔离箱文件
        private void button3_Click(object sender, EventArgs e)
        {
            Boolean state = false;
            if (items.Count != 0)
                foreach (string pLocalFilePath in items)
                {
                    Application.DoEvents();
                    File.Delete(pLocalFilePath);
                    state = true;
                }
            if (state == true)
                MessageBox.Show(@"隔离文件已清理", "文件清理提示");
            else
                MessageBox.Show(@"隔离箱中没有发现文件", "文件恢复提示");

            listView1.Items.Clear();
            listView1.Columns.Clear();
            items = new List<string>();
        }
        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
