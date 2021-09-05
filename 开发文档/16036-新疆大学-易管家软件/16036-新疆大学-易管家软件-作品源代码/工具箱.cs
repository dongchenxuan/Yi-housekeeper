using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GUI.UI
{
    public partial class 工具箱 : Form
    {
        //class里面放入这段代码
        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, StringBuilder lpszOp, StringBuilder lpszFile, StringBuilder lpszParams, StringBuilder lpszDir, int FsShowCmd);

        private static 工具箱 formInstance;
        public static 工具箱 GetIntance
        {
            get
            {
                if (formInstance != null)
                {
                    return formInstance;
                }
                else
                {
                    formInstance = new 工具箱();
                    return formInstance;
                }
            }
        }
        public 工具箱()
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
        public void SetBackgroudImage(string imageFileName)
        {
            this.BackgroundImage = System.Drawing.Image.FromFile(imageFileName);
        }



        private void 工具箱_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //需要打开的地方插入此段代码
            ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("GoogleEarthPortable.exe"), new StringBuilder(""), new StringBuilder(@""), 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //需要打开的地方插入此段代码
            ShellExecute(IntPtr.Zero, new StringBuilder("Open"), new StringBuilder("iFlyVoice.exe"), new StringBuilder(""), new StringBuilder(@""), 1);
        }


        private void 工具箱_Paint(object sender, PaintEventArgs e)
        {

            Application.DoEvents();
            this.BackColor = System.Drawing.ColorTranslator.FromHtml(Skin_paper.ColorID);
        }
    }
}
