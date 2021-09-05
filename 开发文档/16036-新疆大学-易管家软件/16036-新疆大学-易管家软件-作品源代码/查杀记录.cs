using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class 查杀记录 : Form
    {
        public 查杀记录()
        {
            InitializeComponent();

            listView1.View = View.Details;
            /*
            listView1.Columns.Add("", 0, HorizontalAlignment.Center);
            listView1.Columns.Add("查杀方式", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("任务状态", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("查杀时间", 170, HorizontalAlignment.Center);
            */
            Raaddaylog();
        }

        private void Raaddaylog()
        {

            string filepath = @".\\bin\\history.dat";
            string[] data = File.ReadAllLines(filepath, Encoding.GetEncoding("utf-8"));
            string[] condition = { "," };

            //string[] sArray=s.Split('c'); 

            foreach (string line in data)
            {
                string[] result = line.Split(',');
                ListViewItem lvi = new ListViewItem();

                lvi.SubItems.Add(result[0]);

                lvi.SubItems.Add(result[1]);
                lvi.SubItems.Add(result[2]);

                this.listView1.Items.Add(lvi);
            }
        }

        private void 查杀记录_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
