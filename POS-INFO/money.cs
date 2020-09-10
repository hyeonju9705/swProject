using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_INFO
{
    public partial class money : Form
    {
        Bitmap memoryImage;

        public money()
        {
            InitializeComponent();
            listView1.View = View.Details;

            listView1.BeginUpdate();

            listView1.Columns.Add("메뉴", Width = 160);
            listView1.Columns.Add("수량", Width = 40);
            listView1.Columns.Add("가격");
            listView1.Columns.Add("기타", Width = 150);
            listView1.Columns.Add("합계");

            listView1.BeginUpdate();

            Main fa = (Main)this.Owner;


            ListViewItem lv1 = new ListViewItem();

            lv1.Text = "";
            lv1.SubItems.Add("");
            lv1.SubItems.Add("");
            lv1.SubItems.Add("");
            lv1.SubItems.Add("");

            listView1.Items.Add(lv1);

            ListViewItem lv2 = new ListViewItem();

            lv2.Text = "";
            lv2.SubItems.Add("");
            lv2.SubItems.Add("");
            lv2.SubItems.Add("");
            lv2.SubItems.Add("");

            listView1.Items.Add(lv2);

            ListViewItem lv3 = new ListViewItem();

            lv3.Text = "";
            lv3.SubItems.Add("");
            lv3.SubItems.Add("");
            lv3.SubItems.Add("");
            lv3.SubItems.Add("");

            listView1.Items.Add(lv3);

            ListViewItem lv4 = new ListViewItem();

            lv4.Text = "";
            lv4.SubItems.Add("");
            lv4.SubItems.Add("");
            lv4.SubItems.Add("");
            lv4.SubItems.Add("");

            listView1.Items.Add(lv4);

            ListViewItem lv5 = new ListViewItem();

            lv5.Text = "";
            lv5.SubItems.Add("");
            lv5.SubItems.Add("");
            lv5.SubItems.Add("");
            lv5.SubItems.Add("");

            listView1.Items.Add(lv5);

            ListViewItem lv6 = new ListViewItem();

            lv6.Text = "";
            lv6.SubItems.Add("");
            lv6.SubItems.Add("");
            lv6.SubItems.Add("");
            lv6.SubItems.Add("");

            listView1.Items.Add(lv6);

            ListViewItem lv7 = new ListViewItem();

            lv7.Text = "";
            lv7.SubItems.Add("");
            lv7.SubItems.Add("");
            lv7.SubItems.Add("");
            lv7.SubItems.Add("");

            listView1.Items.Add(lv7);

            ListViewItem lv8 = new ListViewItem();

            lv8.Text = "";
            lv8.SubItems.Add("");
            lv8.SubItems.Add("");
            lv8.SubItems.Add("");
            lv8.SubItems.Add("");

            listView1.Items.Add(lv8);

            ListViewItem lv9 = new ListViewItem();

            lv9.Text = "";
            lv9.SubItems.Add("");
            lv9.SubItems.Add("");
            lv9.SubItems.Add("");
            lv9.SubItems.Add("");

            listView1.Items.Add(lv9);

            ListViewItem lv10 = new ListViewItem();

            lv10.Text = "";
            lv10.SubItems.Add("");
            lv10.SubItems.Add("");
            lv10.SubItems.Add("");
            lv10.SubItems.Add("");

            listView1.Items.Add(lv10);


            listView1.EndUpdate();
        }
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);

            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();

            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CaptureScreen();

           
        }
    }


    
    
}

