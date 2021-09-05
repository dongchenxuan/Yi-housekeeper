using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class 隔离区 : Form
    {
        List<string> items = new List<string>();

        public 隔离区()
        {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("", 0, HorizontalAlignment.Center);
            listView1.Columns.Add("文件名称", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("文件类型", 70, HorizontalAlignment.Center);
            listView1.Columns.Add("处理时间", 150, HorizontalAlignment.Center);
            Getfilename();
        }

        #region 遍历隔离箱文件名
        private void Getfilename()
        {
            DirectoryInfo Folder = new DirectoryInfo(@".\IsolationBox");
            foreach(FileInfo NextFile in Folder.GetFiles())
            {
                string[] arr = new string[4];
                arr[1] = NextFile.Name.Remove(NextFile.Name.Length-3);
                string extension = Path.GetExtension(arr[1]);
                arr[2] = extension;
                arr[3] = NextFile.LastAccessTime + "";

                Application.DoEvents();

                if (arr.Length != 0)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(arr[1]);
                    lvi.SubItems.Add(arr[2]);
                    lvi.SubItems.Add(arr[3]);
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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string subpath = path + @"\Ws恢复文件\";
            //指定存储的路径
            string pSaveFilePath;
            if (Directory.Exists(subpath) == false)
            {
                //创建文件夹
                Directory.CreateDirectory(subpath);
            }
            foreach (string pLocalFilePath in items)
            {
                string fileName = Path.GetFileName(pLocalFilePath);
                if (File.Exists(pLocalFilePath)) //判断要复制的文件是否存在
                {
                    pSaveFilePath = subpath + fileName.Remove(fileName.Length-3) ;
                    File.Copy(pLocalFilePath, pSaveFilePath, true);
                    File.Delete(pLocalFilePath);
                }
            }
            items = new List<string>();
        }
        #endregion

        #region 清空隔离箱文件
        private void button3_Click(object sender, EventArgs e)
        {
            if(items.Count!=0)
                foreach (string pLocalFilePath in items)
                {
                    File.Delete(pLocalFilePath);
                }
            items = new List<string>();
        }
        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
