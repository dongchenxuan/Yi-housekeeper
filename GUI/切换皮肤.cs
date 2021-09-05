using GUI.UI;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class 切换皮肤 : Form
    {
        #region 声明变量

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
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="def">值</param>
        /// <param name="retval">stringbulider对象</param>
        /// <param name="size">字节大小</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);

        private string strFilePath = Application.StartupPath + "\\SkinConfig.ini";//获取INI文件路径
        private string strSec = ""; //INI文件名

        #endregion

        public 切换皮肤()
        {
            InitializeComponent();
            Readini();
        }

        #region 读取配置文件
        private void Readini()
        {
            if (File.Exists(strFilePath))//读取时先要判读INI文件是否存在
            {
                strSec = Path.GetFileNameWithoutExtension(strFilePath);

                Skin_paper.ColorID = ContentValue(strSec, "ColorID ");

            }
            else
            {
                MessageBox.Show("配置文件不存在！功能暂不可用！");
            }
        }

        /// <summary>
        /// 自定义读取INI文件中的内容方法
        /// </summary>
        /// <param name="Section">键</param>
        /// <param name="key">值</param>
        /// <returns></returns>
        private string ContentValue(string Section, string key)
        {

            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, key, "", temp, 1024, strFilePath);
            return temp.ToString();
        }
        #endregion
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

        private void 切换皮肤_Load(object sender, EventArgs e)
        {

        }


        private void img1_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "Beige";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img2_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "Control";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img3_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "IndianRed";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img4_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "Window";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img5_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "MenuHighlight";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img6_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "InactiveCaption";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img7_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "DarkSeaGreen";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img8_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "PaleTurquoise";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img9_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "Thistle";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img10_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "LavenderBlush";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img11_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "LightPink";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }

        private void img12_Click(object sender, EventArgs e)
        {
            Skin_paper.ColorID = "Lavender";
            WritePrivateProfileString(strSec, "ColorID", Skin_paper.ColorID, strFilePath);
        }


    }
}
