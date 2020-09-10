using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_INFO
{
    public partial class calculate : Form
    {
        Button selectButton;
        public static Form1 form1 = new Form1();

        public void innit()
        {
            InitializeComponent();
            Timer t = new Timer();
            t.Tick += new EventHandler(t_Tick);
            t.Start();

            menulistView.View = View.Details;

            menulistView.BeginUpdate();

            menulistView.Columns.Add("메뉴", Width = 160);
            menulistView.Columns.Add("수량", Width = 40);
            menulistView.Columns.Add("가격");
            menulistView.Columns.Add("기타", Width = 150);
            menulistView.Columns.Add("합계");
            ListViewItem lv1 = new ListViewItem();

            lv1.Text = "";
            lv1.SubItems.Add("");
            lv1.SubItems.Add("");
            lv1.SubItems.Add("");
            lv1.SubItems.Add("");

            menulistView.Items.Add(lv1);

            ListViewItem lv2 = new ListViewItem();

            lv2.Text = "";
            lv2.SubItems.Add("");
            lv2.SubItems.Add("");
            lv2.SubItems.Add("");
            lv2.SubItems.Add("");

            menulistView.Items.Add(lv2);

            ListViewItem lv3 = new ListViewItem();

            lv3.Text = "";
            lv3.SubItems.Add("");
            lv3.SubItems.Add("");
            lv3.SubItems.Add("");
            lv3.SubItems.Add("");

            menulistView.Items.Add(lv3);

            ListViewItem lv4 = new ListViewItem();

            lv4.Text = "";
            lv4.SubItems.Add("");
            lv4.SubItems.Add("");
            lv4.SubItems.Add("");
            lv4.SubItems.Add("");

            menulistView.Items.Add(lv4);

            ListViewItem lv5 = new ListViewItem();

            lv5.Text = "";
            lv5.SubItems.Add("");
            lv5.SubItems.Add("");
            lv5.SubItems.Add("");
            lv5.SubItems.Add("");

            menulistView.Items.Add(lv5);

            ListViewItem lv6 = new ListViewItem();

            lv6.Text = "";
            lv6.SubItems.Add("");
            lv6.SubItems.Add("");
            lv6.SubItems.Add("");
            lv6.SubItems.Add("");

            menulistView.Items.Add(lv6);

            ListViewItem lv7 = new ListViewItem();

            lv7.Text = "";
            lv7.SubItems.Add("");
            lv7.SubItems.Add("");
            lv7.SubItems.Add("");
            lv7.SubItems.Add("");

            menulistView.Items.Add(lv7);

            ListViewItem lv8 = new ListViewItem();

            lv8.Text = "";
            lv8.SubItems.Add("");
            lv8.SubItems.Add("");
            lv8.SubItems.Add("");
            lv8.SubItems.Add("");

            menulistView.Items.Add(lv8);

            ListViewItem lv9 = new ListViewItem();

            lv9.Text = "";
            lv9.SubItems.Add("");
            lv9.SubItems.Add("");
            lv9.SubItems.Add("");
            lv9.SubItems.Add("");

            menulistView.Items.Add(lv9);

            ListViewItem lv10 = new ListViewItem();

            lv10.Text = "";
            lv10.SubItems.Add("");
            lv10.SubItems.Add("");
            lv10.SubItems.Add("");
            lv10.SubItems.Add("");

            menulistView.Items.Add(lv10);


            menulistView.EndUpdate();
        }

        public calculate()
        {
            innit();
        }
        public calculate(Button selectButton)
        {
            this.selectButton = selectButton;
            innit();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            this.label18.Text = DateTime.Now.ToString();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox6.Text = radioButton1.Text;
            int discount = 15;     // 할인율 15%
            textBox5.Text = discount.ToString();
            int cash = int.Parse(textBox7.Text);
            int result = cash - (cash * discount / 100);
            textBox1.Text = result.ToString();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox6.Text = radioButton2.Text;
            int discount = 10;      // 할인율 10%
            textBox5.Text = discount.ToString();
            int cash = int.Parse(textBox7.Text);
            int result = cash - (cash * discount / 100);
            textBox1.Text = result.ToString();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox6.Text = radioButton3.Text;
            int discount = 15;      // 할인율 15%
            textBox5.Text = discount.ToString();
            int cash = int.Parse(textBox7.Text);
            int result = cash - (cash * discount / 100);
            textBox1.Text = result.ToString();
        }

        private void Money_Click(object sender, EventArgs e)
        {
            if ((radioButton1.Checked) | (radioButton2.Checked) | (radioButton3.Checked))//| (!textBox4.Equals("")
            {
                money fb = new money();
                fb.Owner = this;
                fb.Show();

                for (int i = 1; i <= menulistView.Items.Count; i++)

                    for (int j = 1; j <= menulistView.Items[i - 1].SubItems.Count; j++)
                    {
                        fb.listView1.Items[i - 1].SubItems[j - 1].Text = menulistView.Items[i - 1].SubItems[j - 1].Text;
                    }

                //int prise = int.Parse(textBox7.Text);
                //double principal = prise * 0.9;
                //double tax = prise * 0.1;
                //int rate = int.Parse(textBox5.Text);
                //int discount = (prise * rate) / 100;
                //int getmoney = int.Parse(textBox8.Text);
                //int money = int.Parse(textBox1.Text);
                //int change = getmoney - money;

                //fb.label9.Text = label18.Text; //일자
                //fb.textBox1.Text = principal.ToString() + "원";  // 세금 제외
                //fb.textBox2.Text = tax.ToString() + "원";  // 세금
                //fb.textBox3.Text = discount.ToString() + "원";  // 할인 금액
                //fb.textBox4.Text = money.ToString() + "원";  // 현금
                //fb.textBox5.Text = getmoney.ToString() + "원";  // 받은돈
                //fb.textBox6.Text = change.ToString() + "원";  // 거스름돈


                //int a = int.Parse(fb.textBox2.Text);
                //int b = int.Parse(fb.textBox1.Text);
                //int c = b - a;
                //fb.textBox3.Text = c.ToString();
                // fb.textBox4.Text = textBox2.Text;  

                
                string filePath = ConfigurationManager.AppSettings["filepath"].ToString();

                FileInfo fileInfo = new FileInfo(filePath);

                
                if (!fileInfo.Exists)
                {
                    
                    System.IO.File.WriteAllText(filePath, string.Empty, Encoding.Default);
                }

                
                string fileValue = System.IO.File.ReadAllText(filePath, Encoding.Default);

                string tableName = selectButton.Text;

              
                char ch = '*';

                if (tableName.Contains("/"))
                {
                    tableName = tableName.Split(']')[0] + "]";
                }

                // 있을 때
                if (fileValue.Contains(tableName))
                {
                    string[] stringarray = fileValue.Split(ch);
                    for (int cnt = 0; cnt < stringarray.Count(); cnt++)
                    {
                        if (stringarray[cnt].Contains(tableName))
                        {
                            fileValue = fileValue.Replace("*" + stringarray[cnt], "");
                        }
                    }
                }

                System.IO.File.WriteAllText(filePath, fileValue, Encoding.Default);

                // 버튼 초기화 시키기
                string tbname = selectButton.Text.Split(']')[0] + "]";
                tbname = tbname.Replace("*", "");
                selectButton.Text = tbname;
            }
            else
            {
                MessageBox.Show("할인을 체크해 주세요", "에러",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Error);
                // lable2.Text = "";
                // label3.Text = "";
                return;
            }
            Form1 fr1 = new Form1();
            selectButton.BackColor = Color.LightGray;
        }

        private void Goback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
