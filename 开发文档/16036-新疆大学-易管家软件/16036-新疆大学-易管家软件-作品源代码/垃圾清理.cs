using Shell32;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class 垃圾清理 : Form
    {
        private static 垃圾清理 formInstance;

        const int SHERB_NOCONFIRMATION = 0x000001;   //不显示确认删除的对话框
        const int SHERB_NOPROGRESSUI = 0x000002;     //不显示删除过程的进度条
        const int SHERB_NOSOUND = 0x000004;          //当删除完成时,不播放声音

        public static 垃圾清理 GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new 垃圾清理();
                    return formInstance;
                }
            }
        }
        public 垃圾清理()
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

        private void 垃圾清理_Load(object sender, EventArgs e)
        {

        }

        public void SetBackgroudImage(string imageFileName)
        {

        }

        private void GetRecycleBin()
        {
            Shell shell = new Shell();
            Folder recycleBin = shell.NameSpace(10);
            foreach (FolderItem2 recfile in recycleBin.Items())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems.Add(recfile.Name);//文件名
                lvi.SubItems.Add(recfile.Path);//目录

                this.listView1.Items.Add(lvi);
                Thread.Sleep(5);
                Application.DoEvents();
            }
        }

        #region 扫描注册表
        private void ScanRegistry()
        {
            // 清理旧的注册表
            //this.treeModel.Nodes.Clear();


        }
        #endregion


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Scan_bt_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel2.Visible = true;
            GetRecycleBin();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            this.panel1.Visible = true;
            this.panel2.Visible = false;
        }



        [DllImportAttribute("shell32.dll")]          //声明API函数
        private static extern int SHEmptyRecycleBin(IntPtr handle, string root, int falgs);

        private void button1_Click(object sender, EventArgs e)
        {

            SHEmptyRecycleBin(this.Handle, "", SHERB_NOCONFIRMATION + SHERB_NOPROGRESSUI + SHERB_NOSOUND);
            Thread.Sleep(5);
            Application.DoEvents();
            listView1.Items.Clear();
            this.panel1.Visible = true;
            this.panel2.Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 垃圾清理_Paint(object sender, PaintEventArgs e)
        {

            Application.DoEvents();
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(Skin_paper.ColorID);
        }
    }
}


