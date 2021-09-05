using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BenNHControl
{
    public partial class ButtonEX : UserControl
    {


        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        public event EventHandler ButtonClick;

        /// <summary>
        /// 控件的默认图片
        /// </summary>
        private Image _imageDefault = null;

        [Description("控件的默认图片")]
        public Image ImageDefault
        {
            get { return _imageDefault; }
            set
            {
                _imageDefault = value;
                label.Image = _imageDefault;
            }
        }
        /// <summary>
        /// 光标移动到控件上方显示的图片
        /// </summary>
        private Image _imageMove = null;
        [Description("光标移动到控件上方显示的图片")]
        public Image ImageMove
        {
            get { return _imageMove; }
            set { _imageMove = value; }
        }
        /// <summary>
        /// 光标离开控件显示的图片
        /// </summary>
        private Image _imageLeave = null;
        [Description("光标离开控件显示的图片")]
        public Image ImageLeave
        {
            get { return _imageLeave; }
            set { _imageLeave = value; }
        }
        /// <summary>
        /// 控件的背景色
        /// </summary>
        private Color _backColorEX = Color.Transparent;

        [Description("控件的背景色")]
        public Color BackColorEX
        {
            get { return _backColorEX; }
            set
            {
                _backColorEX = value;
                label.BackColor = _backColorEX;
            }
        }

        /// <summary>
        /// 鼠标移动到控件上方显示的颜色
        /// </summary>
        private Color backColorMove = Color.Transparent;
        [Description("鼠标移动到控件上方显示的颜色")]
        public Color BackColorMove
        {
            get { return backColorMove; }
            set { backColorMove = value; }
        }
        /// <summary>
        /// 鼠标离开控件显示的背景色
        /// </summary>
        private Color backColorLeave = Color.Transparent;
        [Description("鼠标离开控件显示的背景色")]
        public Color BackColorLeave
        {
            get { return backColorLeave; }
            set { backColorLeave = value; }
        }
        /// <summary>
        /// 控件的文字显示
        /// </summary>
        private string textEX = "";
        [Description("显示的文字")]
        public string TextEX
        {
            get { return textEX; }
            set
            {
                textEX = value;
                label.Text = textEX;
            }
        }
        /// <summary>
        /// 文字的颜色
        /// </summary>
        private Color textColor = Color.Black;
        [Description("文字的颜色")]
        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value;
                label.ForeColor = textColor;
            }
        }
        /// <summary>
        /// 用于显示文本的字体
        /// </summary>
        private Font fontM = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        [Description("用于显示文本的字体")]
        public Font FontM
        {
            get { return fontM; }
            set
            {
                fontM = value;
                label.Font = fontM;
            }
        }


        public ButtonEX()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 鼠标单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Click(object sender, EventArgs e)
        {
            if (ButtonClick != null)
            {
                ButtonClick(sender, e);
            }
        }

        /// <summary>
        /// 鼠标移动到控件上显示的背景色和背景图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (backColorMove != Color.Transparent)
            {
                BackColorEX = backColorMove;
            }
            if (_imageMove != null)
            {
                _imageDefault = _imageMove;
            }
            this.Invalidate();
        }

        /// <summary>
        /// 鼠标离开控件后显示的背景色和背景图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_MouseLeave(object sender, EventArgs e)
        {
            if (backColorLeave != Color.Transparent)
            {
                BackColorEX = backColorLeave;
            }
            if (_imageLeave != null)
            {
                _imageDefault = _imageLeave;
            }
            this.Invalidate();
        }


    }
}
