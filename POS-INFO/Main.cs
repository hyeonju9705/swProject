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
    public partial class Main : Form
    {
        
        //main

        //mainClass cs = new mainClass();//class 상속
        public String menu_name; // 
        public int price;
        public String new_menu_name;
        public int new_menu_price;
        public int arr_length;
        public static  Form1 form1 = new Form1();
        
        public String stat_name = "";
        public String stat_count = "";
        public String stat_price = "";
        //마요
        public String[] mayo = new String[21] { "", "스팸마요", "참치마요", "치킨마요", "",
            "", "", "", "", "", "", "", "", "", "", "","","","","",""};
        public int[] mayo_price = new int[21] { 0, 3500, 3500, 4500, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //직화
        public String[] fire = new String[21] { "","직화제육", "돼지숙주", "쭈꾸미숙주", 
            "", "", "", "", "", "", "", "", "", "", "", "","","","","",""};
        public int[] fire_price = new int[21] { 0, 4500, 4500, 5500, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        //사이드MENU
        public String[] side = new String[21] { "사이드MENU", "숙주라면", "오징어링", "치킨까스", "닭껍질교자",
            "탄산음료", "生맥주(200cc) [레드락]", "치즈라면", "", "", "", "", "", "", "", "" ,"","","","",""};
        public int[] side_price = new int[21] { 0, 3500, 2000, 2000, 2500, 1500, 1500, 3500, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        Button selectButton;
        // 테이블 이름
        public string ffname;

       
        public void init()
        {
            InitializeComponent();

            menulistView.View = View.Details;

            menulistView.BeginUpdate();

            menulistView.Columns.Add("메뉴", Width = 160);
            menulistView.Columns.Add("수량", Width = 40);
            menulistView.Columns.Add("가격");
            menulistView.Columns.Add("기타", Width = 150);
            menulistView.Columns.Add("합계");

            menulistView.EndUpdate();
        }

        public Main()
        {
            init();
        }

        
        /// <param name="selectButton"></param>
        public Main(Button selectButton)
        {
            init();
            ffname = selectButton.Text;
            this.selectButton = selectButton;

            
            string filePath = ConfigurationManager.AppSettings["filepath"].ToString();

            FileInfo fileInfo = new FileInfo(filePath);

            
            if (!fileInfo.Exists)
            {
               
                System.IO.File.WriteAllText(filePath, string.Empty, Encoding.Default);
            }

            string fileValue = System.IO.File.ReadAllText(filePath, Encoding.Default);

            string[] tableList = fileValue.Split('*');

            for(int cnt = 0; cnt < tableList.Count(); cnt++)
            {
             
                if (tableList[cnt].Contains(selectButton.Text))
                {
                    string[] menulist = tableList[cnt].Split('&');
                    for(int cc = 0; cc < menulist.Count(); cc++)
                    {
                        string menustring = menulist[cc];

                        menustring = menustring.Replace("\n", "").Trim();
                        if (!string.IsNullOrEmpty(menustring))
                        {
                           
                            menustring = menustring.Replace((selectButton.Text.Split(']')[0] + "]"), "").Replace("[", "");
                            string[] submenulist = menustring.Split('/');
                            string[] sublist = new string[submenulist.Count() - 1];

                            for (int count = 0; count < submenulist.Count() -1; count++)
                            {
                                sublist[count] = submenulist[count];
                            }
                            var listViewItem = new ListViewItem(sublist);
                            menulistView.Items.Add(listViewItem);
                        }
                    }
                }
            }
            price1.Text = "0";
            int a = int.Parse(price1.Text);
            int total = 0;

            for (int i = 1; i <= menulistView.Items.Count; i++)
            {
                a = int.Parse(menulistView.Items[i - 1].SubItems[4].Text);
                total += a;
            }
            price1.Text = total.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        // total
        public void total()
        {
            price1.Text = "0";
            int a = int.Parse(price1.Text);
            int total = 0;

            for (int i = 1; i <= menulistView.Items.Count; i++)
            {
                    a = int.Parse(menulistView.Items[i - 1].SubItems[4].Text);
                    total += a;
            }
            price1.Text = total.ToString();

          
            set_text();
        }

        
        public void set_text()
        {
      
            string filePath = ConfigurationManager.AppSettings["filepath"].ToString();

            FileInfo fileInfo = new FileInfo(filePath);

            
            if (!fileInfo.Exists)
            {
                
                System.IO.File.WriteAllText(filePath, string.Empty, Encoding.Default);
            }

        
            string fileValue = System.IO.File.ReadAllText(filePath,Encoding.Default);

            string tableName = selectButton.Text;

           
            char ch = '*';

            // 주문한 전체 내용
            string menu = string.Empty;

            foreach(ListViewItem item in menulistView.Items)
            {
                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    menu += sub.Text + "/";
                }
                menu += "&\n";
            }

            if (tableName.Contains("/"))
            {
                tableName = tableName.Split(']')[0] + "]";
            }

            // 있을 때
            if (fileValue.Contains(tableName))
            {
                string[] stringarray = fileValue.Split('*');
                for(int cnt = 0; cnt < stringarray.Count(); cnt++)
                {
                    if (stringarray[cnt].Contains(tableName))
                    {
                        fileValue = fileValue.Replace("*"+stringarray[cnt], "");
                    }
                }
                ffname = string.Format("[{0}]{1} ", tableName.Replace("[","").Replace("]",""), menu);
            }
            else
            {
                ffname = tableName.Replace("[", "").Replace("]", "");
            }

            fileValue += ch;
            tableName = tableName.Replace("[", "").Replace("]", "");
            fileValue += string.Format("[{0}]{1} ", tableName, menu);

            System.IO.File.WriteAllText(filePath, fileValue, Encoding.Default);
        }

        //listview update
        //리스트뷰에 메뉴 추가
        public void list_update(String menu_name, int price)
        {
            menulistView.BeginUpdate();

            ListViewItem lv1 = new ListViewItem();

            lv1.Text = menu_name;
            lv1.SubItems.Add("1");
            lv1.SubItems.Add(price.ToString());
            lv1.SubItems.Add("");
            lv1.SubItems.Add("");
            menulistView.Items.Add(lv1);
            lv1.SubItems[4].Text = price.ToString();

            menulistView.EndUpdate();

            int listView_index = menulistView.Items.Count - 1;

            menulistView.Focus();
            for (int i = 0; i <= menulistView.Items.Count - 1; i++)
            {
                menulistView.Items[i].Focused = false;
                menulistView.Items[i].Selected = false;
            }
            menulistView.Items[listView_index].Focused = true;
            menulistView.Items[listView_index].Selected = true;
        }

        //리스트뷰 항목 선택시 한줄 전체 선택되게 하는 이벤트
        private void menulistView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void menulistView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (this.menulistView.SelectedIndices.Contains(e.ItemIndex))
            {
                e.SubItem.BackColor = System.Drawing.SystemColors.MenuHighlight;
            }
            else
            {
                e.SubItem.BackColor = Color.White;
            }
            e.DrawBackground();
            e.DrawText();
        }

        

        private void menulistView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //스팸마요
        private void mayo1_Click(object sender, EventArgs e)
        {
            menu_name = mayo[1];
            price = mayo_price[1];
            list_update(menu_name, price);
            total();
        }
        //참치마요
        private void mayo2_Click(object sender, EventArgs e)
        {
            menu_name = mayo[2];
            price = mayo_price[2];
            list_update(menu_name, price);
            total();
        }
        //치킨마요
        private void mayo3_Click(object sender, EventArgs e)
        {
            menu_name = mayo[3];
            price = mayo_price[3];
            list_update(menu_name, price);
            total();
        }

        private void mayo4_Click(object sender, EventArgs e)
        {
            menu_name = mayo[4];
            price = mayo_price[4];
            list_update(menu_name, price);
            total();
        }

        private void mayo5_Click(object sender, EventArgs e)
        {
            menu_name = mayo[5];
            price = mayo_price[5];
            list_update(menu_name, price);
            total();
        }

        private void mayo6_Click(object sender, EventArgs e)
        {
            menu_name = mayo[6];
            price = mayo_price[6];
            list_update(menu_name, price);
            total();
        }

        private void mayo7_Click(object sender, EventArgs e)
        {
            menu_name = mayo[7];
            price = mayo_price[7];
            list_update(menu_name, price);
            total();
        }

        private void mayo8_Click(object sender, EventArgs e)
        {
            menu_name = mayo[8];
            price = mayo_price[8];
            list_update(menu_name, price);
            total();
        }

        private void mayo9_Click(object sender, EventArgs e)
        {
            menu_name = mayo[9];
            price = mayo_price[9];
            list_update(menu_name, price);
            total();
        }

        private void mayo10_Click(object sender, EventArgs e)
        {
            menu_name = mayo[10];
            price = mayo_price[10];
            list_update(menu_name, price);
            total();
        }

        private void mayo11_Click(object sender, EventArgs e)
        {
          
        }

        private void mayo12_Click(object sender, EventArgs e)
        {
          
        }

        private void mayo13_Click(object sender, EventArgs e)
        {

        }

        private void mayo14_Click(object sender, EventArgs e)
        {

        }

        private void mayo15_Click(object sender, EventArgs e)
        {

        }

        private void mayo16_Click(object sender, EventArgs e)
        {

        }

        private void mayo17_Click(object sender, EventArgs e)
        {

        }

        private void mayo18_Click(object sender, EventArgs e)
        {

        }

        private void mayo19_Click(object sender, EventArgs e)
        {

        }

        private void mayo20_Click(object sender, EventArgs e)
        {

        }

        private void increase_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                menulistView.BeginUpdate();
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;
                int a = int.Parse(subItem[1].Text);
                a += 1;
                subItem[1].Text = a.ToString();

                int d = int.Parse(i.SubItems[2].Text);
                int g = int.Parse(i.SubItems[1].Text);
                int f = d * g;
                i.SubItems[4].Text = f.ToString();


                menulistView.EndUpdate();
                total();
            }
        }

        private void decrease_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                menulistView.BeginUpdate();
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;
                int a = int.Parse(subItem[1].Text);
                a -= 1;
                subItem[1].Text = a.ToString();

                int d = int.Parse(i.SubItems[2].Text);
                int g = int.Parse(i.SubItems[1].Text);
                int f = d * g;
                i.SubItems[4].Text = f.ToString();

                menulistView.EndUpdate();

                if (i.SubItems[1].Text.Equals("0"))
                {
                    menulistView.Items.RemoveAt(menulistView.SelectedIndices[0]);
                }
                total();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (menulistView.SelectedIndices.Count > 0)
            {
                menulistView.Items.RemoveAt(menulistView.SelectedIndices[0]);
            }

            total();
        }

        private void allcancel_Click(object sender, EventArgs e)
        {
            menulistView.Items.Clear();
            price1.Clear();
            total();
        }
        //직화제육
        private void fire1_Click(object sender, EventArgs e)
        {
            menu_name = fire[1];
            price = fire_price[1];
            list_update(menu_name, price);
            total();
        }
        //돼지숙주
        private void fire2_Click(object sender, EventArgs e)
        {
            menu_name = fire[2];
            price = fire_price[2];
            list_update(menu_name, price);
            total();
        }
        //쭈꾸미숙주
        private void fire3_Click(object sender, EventArgs e)
        {
            menu_name = fire[3];
            price = fire_price[3];
            list_update(menu_name, price);
            total();
        }

        // 추가 메뉴
        private void fire4_Click(object sender, EventArgs e)
        {
            menu_name = fire[4];
            price = fire_price[4];
            list_update(menu_name, price);
            total();
        }

        private void fire5_Click(object sender, EventArgs e)
        {
            menu_name = fire[5];
            price = fire_price[5];
            list_update(menu_name, price);
            total();
        }

        private void fire6_Click(object sender, EventArgs e)
        {
            menu_name = fire[6];
            price = fire_price[6];
            list_update(menu_name, price);
            total();
        }

        private void fire7_Click(object sender, EventArgs e)
        {
            menu_name = fire[7];
            price = fire_price[7];
            list_update(menu_name, price);
            total();
        }

        private void fire8_Click(object sender, EventArgs e)
        {
            menu_name = fire[8];
            price = fire_price[8];
            list_update(menu_name, price);
            total();
        }

        private void fire9_Click(object sender, EventArgs e)
        {
            menu_name = fire[9];
            price = fire_price[9];
            list_update(menu_name, price);
            total();
        }

        private void fire10_Click(object sender, EventArgs e)
        {
            menu_name = fire[10];
            price = fire_price[10];
            list_update(menu_name, price);
            total();
        }

        private void fire11_Click(object sender, EventArgs e)
        {
            menu_name = fire[11];
            price = fire_price[11];
            list_update(menu_name, price);
            total();
        }

        private void fire12_Click(object sender, EventArgs e)
        {
            menu_name = fire[12];
            price = fire_price[12];
            list_update(menu_name, price);
            total();
        }

        private void fire13_Click(object sender, EventArgs e)
        {
            menu_name = fire[13];
            price = fire_price[13];
            list_update(menu_name, price);
            total();
        }

        private void fire14_Click(object sender, EventArgs e)
        {
            menu_name = fire[14];
            price = fire_price[14];
            list_update(menu_name, price);
            total();
        }

        private void fire15_Click(object sender, EventArgs e)
        {
            menu_name = fire[15];
            price = fire_price[15];
            list_update(menu_name, price);
            total();
        }

        private void fire16_Click(object sender, EventArgs e)
        {
            menu_name = fire[16];
            price = fire_price[16];
            list_update(menu_name, price);
            total();
        }

        private void fire17_Click(object sender, EventArgs e)
        {
            menu_name = fire[17];
            price = fire_price[17];
            list_update(menu_name, price);
            total();
        }

        private void fire18_Click(object sender, EventArgs e)
        {
            menu_name = fire[18];
            price = fire_price[18];
            list_update(menu_name, price);
            total();
        }

        private void fire19_Click(object sender, EventArgs e)
        {
            menu_name = fire[19];
            price = fire_price[19];
            list_update(menu_name, price);
            total();
        }

        private void fire20_Click(object sender, EventArgs e)
        {
            menu_name = fire[20];
            price = fire_price[20];
            list_update(menu_name, price);
            total();
        }

        //숙주라면
        private void side1_Click(object sender, EventArgs e)
        {
            menu_name = side[1];
            price = side_price[1];
            list_update(menu_name, price);
            total();
        }
        
        //오징어링
        private void side2_Click(object sender, EventArgs e)
        {
            menu_name = side[2];
            price = side_price[2];
            list_update(menu_name, price);
            total();
        }

        private void side3_Click(object sender, EventArgs e)
        {
            menu_name = side[3];
            price = side_price[3];
            list_update(menu_name, price);
            total();
        }

        private void side4_Click(object sender, EventArgs e)
        {
            menu_name = side[4];
            price = side_price[4];
            list_update(menu_name, price);
            total();
        }

        private void side5_Click(object sender, EventArgs e)
        {
            menu_name = side[5];
            price = side_price[5];
            list_update(menu_name, price);
            total();
        }

        private void side6_Click(object sender, EventArgs e)
        {
            menu_name = side[6];
            price = side_price[6];
            list_update(menu_name, price);
            total();
        }

        //치즈라면
        private void side7_Click(object sender, EventArgs e)
        {
            menu_name = side[7];
            price = side_price[7];
            list_update(menu_name, price);
            total();

        }
        // 사이드 추가
        private void side8_Click(object sender, EventArgs e)
        {
            menu_name = side[8];
            price = side_price[8];
            list_update(menu_name, price);
            total();

        }

        private void side9_Click(object sender, EventArgs e)
        {
            menu_name = side[9];
            price = side_price[9];
            list_update(menu_name, price);
            total();

        }

        private void side10_Click(object sender, EventArgs e)
        {
            menu_name = side[10];
            price = side_price[10];
            list_update(menu_name, price);
            total();

        }


        private void 메뉴추가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuEdit Nmenu = new MenuEdit();
            Nmenu.Show();
            Close();
        }

        public void add_mayo()
        {
            if (mayo1.Text.Equals(""))
            {
                mayo1.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo1.Enabled = true;
                mayo[1] = new_menu_name;
                mayo_price[1] = new_menu_price;
            }
            else if (mayo2.Text.Equals(""))
            {
                mayo2.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo2.Enabled = true;
                mayo[2] = new_menu_name;
                mayo_price[2] = new_menu_price;
            }
            else if (mayo3.Text.Equals(""))
            {
                mayo3.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo3.Enabled = true;
                mayo[3] = new_menu_name;
                mayo_price[3] = new_menu_price;
            }
            else if (mayo4.Text.Equals(""))
            {
                mayo4.Text = new_menu_name;
                mayo4.Enabled = true;
                mayo[4] = new_menu_name;
                mayo_price[4] = new_menu_price;
            }
            else if (mayo5.Text.Equals(""))
            {
                mayo5.Text = new_menu_name;
                mayo5.Enabled = true;
                mayo[5] = new_menu_name;
                mayo_price[5] = new_menu_price;
            }
            else if (mayo6.Text.Equals(""))
            {
                mayo6.Text = new_menu_name;
                mayo6.Enabled = true;
                mayo[6] = new_menu_name;
                mayo_price[6] = new_menu_price;
            }
            else if (mayo7.Text.Equals(""))
            {
                mayo7.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo7.Enabled = true;
                mayo[7] = new_menu_name;
                mayo_price[7] = new_menu_price;
            }
            else if (mayo8.Text.Equals(""))
            {
                mayo8.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo8.Enabled = true;
                mayo[8] = new_menu_name;
                mayo_price[8] = new_menu_price;
            }
            else if (mayo9.Text.Equals(""))
            {
                mayo9.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo9.Enabled = true;
                mayo[9] = new_menu_name;
                mayo_price[9] = new_menu_price;
            }
            else if (mayo10.Text.Equals(""))
            {
                mayo10.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo10.Enabled = true;
                mayo[10] = new_menu_name;
                mayo_price[10] = new_menu_price;
            }
            else if (mayo11.Text.Equals(""))
            {
                mayo11.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo11.Enabled = true;
                mayo[11] = new_menu_name;
                mayo_price[11] = new_menu_price;
            }
            else if (mayo12.Text.Equals(""))
            {
                mayo12.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo12.Enabled = true;
                mayo[12] = new_menu_name;
                mayo_price[12] = new_menu_price;
            }
            else if (mayo13.Text.Equals(""))
            {
                mayo13.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo13.Enabled = true;
                mayo[13] = new_menu_name;
                mayo_price[13] = new_menu_price;
            }
            else if (mayo14.Text.Equals(""))
            {
                mayo14.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo14.Enabled = true;
                mayo[14] = new_menu_name;
                mayo_price[14] = new_menu_price;
            }
            else if (mayo15.Text.Equals(""))
            {
                mayo15.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo15.Enabled = true;
                mayo[15] = new_menu_name;
                mayo_price[15] = new_menu_price;
            }
            else if (mayo16.Text.Equals(""))
            {
                mayo16.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo16.Enabled = true;
                mayo[16] = new_menu_name;
                mayo_price[16] = new_menu_price;
            }
            else if (mayo17.Text.Equals(""))
            {
                mayo17.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo17.Enabled = true;
                mayo[17] = new_menu_name;
                mayo_price[17] = new_menu_price;
            }
            else if (mayo18.Text.Equals(""))
            {
                mayo18.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo18.Enabled = true;
                mayo[18] = new_menu_name;
                mayo_price[18] = new_menu_price;
            }
            else if (mayo19.Text.Equals(""))
            {
                mayo19.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo19.Enabled = true;
                mayo[19] = new_menu_name;
                mayo_price[19] = new_menu_price;
            }
            else if (mayo20.Text.Equals(""))
            {
                mayo20.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                mayo20.Enabled = true;
                mayo[20] = new_menu_name;
                mayo_price[20] = new_menu_price;
            }

        }

        public void add_fire()
        {
            if (fire1.Text.Equals(""))
            {
                fire1.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire1.Enabled = true;
                fire[1] = new_menu_name;
                fire_price[1] = new_menu_price;
            }
            else if (fire2.Text.Equals(""))
            {
                fire2.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire2.Enabled = true;
                fire[2] = new_menu_name;
                fire_price[2] = new_menu_price;
            }
            else if (fire3.Text.Equals(""))
            {
                fire3.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire3.Enabled = true;
                fire[3] = new_menu_name;
                fire_price[3] = new_menu_price;
            }
            else if (fire4.Text.Equals(""))
            {
                fire4.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire4.Enabled = true;
                fire[4] = new_menu_name;
                fire_price[4] = new_menu_price;
            }
            else if (fire5.Text.Equals(""))
            {
                fire5.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire5.Enabled = true;
                fire[5] = new_menu_name;
                fire_price[5] = new_menu_price;
            }
            else if (fire6.Text.Equals(""))
            {
                fire6.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire6.Enabled = true;
                fire[6] = new_menu_name;
                fire_price[6] = new_menu_price;
            }
            else if (fire7.Text.Equals(""))
            {
                fire7.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire7.Enabled = true;
                fire[7] = new_menu_name;
                fire_price[7] = new_menu_price;
            }
            else if (fire8.Text.Equals(""))
            {
                fire8.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire8.Enabled = true;
                fire[8] = new_menu_name;
                fire_price[8] = new_menu_price;
            }
            else if (fire9.Text.Equals(""))
            {
                fire9.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire9.Enabled = true;
                fire[9] = new_menu_name;
                fire_price[9] = new_menu_price;
            }
            else if (fire10.Text.Equals(""))
            {
                fire10.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire10.Enabled = true;
                fire[10] = new_menu_name;
                fire_price[10] = new_menu_price;
            }
            else if (fire11.Text.Equals(""))
            {
                fire11.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire11.Enabled = true;
                fire[11] = new_menu_name;
                fire_price[11] = new_menu_price;
            }
            else if (fire12.Text.Equals(""))
            {
                fire12.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire12.Enabled = true;
                fire[12] = new_menu_name;
                fire_price[12] = new_menu_price;
            }
            else if (fire13.Text.Equals(""))
            {
                fire13.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire13.Enabled = true;
                fire[13] = new_menu_name;
                fire_price[13] = new_menu_price;
            }
            else if (fire14.Text.Equals(""))
            {
                fire14.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire14.Enabled = true;
                fire[14] = new_menu_name;
                fire_price[14] = new_menu_price;
            }
            else if (fire15.Text.Equals(""))
            {
                fire15.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire15.Enabled = true;
                fire[15] = new_menu_name;
                fire_price[15] = new_menu_price;
            }
            else if (fire16.Text.Equals(""))
            {
                fire16.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire16.Enabled = true;
                fire[16] = new_menu_name;
                fire_price[16] = new_menu_price;
            }   
            else if (fire17.Text.Equals(""))
            {
                fire17.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire17.Enabled = true;
                fire[17] = new_menu_name;
                fire_price[17] = new_menu_price;
            }
            else if (fire18.Text.Equals(""))
            {
                fire18.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire18.Enabled = true;
                fire[18] = new_menu_name;
                fire_price[18] = new_menu_price;
            }
            else if (fire19.Text.Equals(""))
            {
                fire19.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire19.Enabled = true;
                fire[19] = new_menu_name;
                fire_price[19] = new_menu_price;
            }
            else if (fire20.Text.Equals(""))
            {
                fire20.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                fire20.Enabled = true;
                fire[20] = new_menu_name;
                fire_price[20] = new_menu_price;
            }
        }

        public void add_side()
        {
            if (side1.Text.Equals(""))
            {
                side1.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side1.Enabled = true;
                side[1] = new_menu_name;
                side_price[1] = new_menu_price;
            }
            else if (side2.Text.Equals(""))
            {
                side2.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side2.Enabled = true;
                side[2] = new_menu_name;
                side_price[2] = new_menu_price;
            }
            else if (side3.Text.Equals(""))
            {
                side3.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side3.Enabled = true;
                side[3] = new_menu_name;
                side_price[3] = new_menu_price;
            }
            else if (side4.Text.Equals(""))
            {
                side4.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side4.Enabled = true;
                side[4] = new_menu_name;
                side_price[4] = new_menu_price;
            }
            else if (side5.Text.Equals(""))
            {
                side5.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side5.Enabled = true;
                side[5] = new_menu_name;
                side_price[5] = new_menu_price;
            }
            else if (side6.Text.Equals(""))
            {
                side6.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side6.Enabled = true;
                side[6] = new_menu_name;
                side_price[6] = new_menu_price;
            }
            else if (side7.Text.Equals(""))
            {
                side7.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side7.Enabled = true;
                side[7] = new_menu_name;
                side_price[7] = new_menu_price;
            }
            else if (side8.Text.Equals(""))
            {
                side8.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side8.Enabled = true;
                side[8] = new_menu_name;
                side_price[8] = new_menu_price;
            }
            else if (side9.Text.Equals(""))
            {
                side9.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side9.Enabled = true;
                side[9] = new_menu_name;
                side_price[9] = new_menu_price;
            }
            else if (side10.Text.Equals(""))
            {
                side10.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side10.Enabled = true;
                side[10] = new_menu_name;
                side_price[10] = new_menu_price;
            }
            else if (side11.Text.Equals(""))
            {
                side11.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side11.Enabled = true;
                side[11] = new_menu_name;
                side_price[11] = new_menu_price;
            }
            else if (side12.Text.Equals(""))
            {
                side12.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side12.Enabled = true;
                side[12] = new_menu_name;
                side_price[12] = new_menu_price;
            }
            else if (side13.Text.Equals(""))
            {
                side13.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side13.Enabled = true;
                side[13] = new_menu_name;
                side_price[13] = new_menu_price;
            }
            else if (side14.Text.Equals(""))
            {
                side14.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side14.Enabled = true;
                side[14] = new_menu_name;
                side_price[14] = new_menu_price;
            }
            else if (side15.Text.Equals(""))
            {
                side15.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side15.Enabled = true;
                side[15] = new_menu_name;
                side_price[15] = new_menu_price;
            }
            else if (side16.Text.Equals(""))
            {
                side16.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side16.Enabled = true;
                side[16] = new_menu_name;
                side_price[16] = new_menu_price;
            }
            else if (side17.Text.Equals(""))
            {
                side17.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side17.Enabled = true;
                side[17] = new_menu_name;
                side_price[17] = new_menu_price;
            }
            else if (side18.Text.Equals(""))
            {
                side18.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side18.Enabled = true;
                side[18] = new_menu_name;
                side_price[18] = new_menu_price;
            }
            else if (side19.Text.Equals(""))
            {
                side19.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side19.Enabled = true;
                side[19] = new_menu_name;
                side_price[19] = new_menu_price;
            }
            else if (side20.Text.Equals(""))
            {
                side20.Text = new_menu_name + "\r\n" + new_menu_price + "원";
                side20.Enabled = true;
                side[20] = new_menu_name;
                side_price[20] = new_menu_price;
            }

        }

        public void close_Click(object sender, EventArgs e)
        {
            this.Opacity=0;
            this.Close();
            form1.ScreenCapture(new Point(form1.groupBox1.Left, form1.groupBox1.Top), form1.groupBox1.Size);

            string filePath = ConfigurationManager.AppSettings["filepath"].ToString();

            FileInfo fileInfo = new FileInfo(filePath);

            // 파일 있는지 확인
            if (!fileInfo.Exists)
            {
                // 없으면 생성해준다.
                System.IO.File.WriteAllText(filePath, string.Empty, Encoding.Default);
            }

            // 텍스트파일 내용 읽어오기
            string fileValue = System.IO.File.ReadAllText(filePath, Encoding.Default);

            string tableName = selectButton.Text;

            // 읽어와야 할 내용
            // menulistView.Items의 전부
            //      그리고 각각의 SubItems의 전부
            //          * Text를 읽어와야 한다.

            // 각 테이블의 메뉴 내용 구분자
            char ch = '*';

            // 주문한 전체 내용
            string menu = string.Empty;

            foreach (ListViewItem item in menulistView.Items)
            {
                foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                {
                    menu += sub.Text + "/";
                }
                menu += "&\n";
            }

            if (tableName.Contains("/"))
            {
                tableName = tableName.Split(']')[0] + "]";
            }

            // 있을 때
            if (fileValue.Contains(tableName))
            {
                ffname = string.Format("[{0}]{1} ", tableName.Replace("[", "").Replace("]", ""), menu);
            }
            else
            {
                ffname = tableName.Replace("[", "").Replace("]", "");
            }
            selectButton.Text = ffname;
        }

        private void 메뉴삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete Nmenu = new delete();
            Nmenu.Show();
            Nmenu.AddOwnedForm(this);
            //Close();
        }

        private void Riceadd_Click(object sender, EventArgs e) //밥추가
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;

                if (i.SubItems[3].Text != "")
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(add.Text);
                    int g = int.Parse(subItem[4].Text);
                    int f = g + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = i.SubItems[3].Text + "," + riceadd.Text;
                }
                else
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(add.Text);
                    int g = int.Parse(subItem[2].Text);
                    int f = (a * g) + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = riceadd.Text;
                }
            }
            menulistView.EndUpdate();
            total();
        }

        private void Dasiadd_Click(object sender, EventArgs e) //국추가
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;

                if (i.SubItems[3].Text != "")
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(add2.Text);
                    int g = int.Parse(subItem[4].Text);
                    int f = g + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = i.SubItems[3].Text + "," + dasiadd.Text;
                }
                else
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(add2.Text);
                    int g = int.Parse(subItem[2].Text);
                    int f = (a * g) + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = dasiadd.Text;
                }
            }
            menulistView.EndUpdate();
            total();
        }

        private void Kimchiadd_Click(object sender, EventArgs e)
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;

                if (i.SubItems[3].Text != "")
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(add3.Text);
                    int g = int.Parse(subItem[4].Text);
                    int f = g + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = i.SubItems[3].Text + "," + kimchiadd.Text;
                }
                else
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(add3.Text);
                    int g = int.Parse(subItem[2].Text);
                    int f = (a * g) + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = kimchiadd.Text;
                }
            }
            menulistView.EndUpdate();
            total();
        }

        private void Gimadd_Click(object sender, EventArgs e)
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;

                if (i.SubItems[3].Text != "")
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(add4.Text);
                    int g = int.Parse(subItem[4].Text);
                    int f = g + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = i.SubItems[3].Text + "," + gimadd.Text;
                }
                else
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(add4.Text);
                    int g = int.Parse(subItem[2].Text);
                    int f = (a * g) + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = gimadd.Text;
                }
            }
            menulistView.EndUpdate();
            total();
        }

        private void Packing_Click(object sender, EventArgs e)
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;

                if (i.SubItems[3].Text != "")
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(sub.Text);
                    int g = int.Parse(subItem[4].Text);
                    int f = g + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = i.SubItems[3].Text + "," + packing.Text;
                }
                else
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = int.Parse(sub.Text);
                    int g = int.Parse(subItem[2].Text);
                    int f = (a * g) + (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h + d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = packing.Text; 
                }
            }
            menulistView.EndUpdate();
            total();
        }

        private void Icecup_Click(object sender, EventArgs e)
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;
                if (i.SubItems[3].Text != "")
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = -500;
                    int g = int.Parse(subItem[4].Text);
                    int f = g - (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h - d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = i.SubItems[3].Text + "," + "얼음컵";
                }
                else
                {
                    int a = int.Parse(subItem[1].Text);
                    int d = -500;
                    int g = int.Parse(subItem[2].Text);
                    int f = (a * g) - (d * a);
                    int h = int.Parse(subItem[2].Text);
                    int j = h - d;
                    i.SubItems[2].Text = j.ToString();
                    i.SubItems[4].Text = f.ToString();
                    i.SubItems[3].Text = "얼음컵";
                }
            }
            menulistView.EndUpdate();
            total();
        }

        private void Fork_Click(object sender, EventArgs e)
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;
                i.SubItems[3].Text = i.SubItems[3].Text + "," + fork.Text;
            }
            menulistView.EndUpdate();
        }

        private void Some_Click(object sender, EventArgs e)
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;
                i.SubItems[3].Text = i.SubItems[3].Text + "," + some.Text;
            }
            menulistView.EndUpdate();
        }

        private void More_Click(object sender, EventArgs e)
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;
                i.SubItems[3].Text = i.SubItems[3].Text + "," + more.Text;
            }
            menulistView.EndUpdate();
        }

        private void Straw_Click(object sender, EventArgs e)
        {
            menulistView.BeginUpdate();
            foreach (ListViewItem i in menulistView.SelectedItems)
            {
                ListViewItem.ListViewSubItemCollection subItem = i.SubItems;
                i.SubItems[3].Text = i.SubItems[3].Text + "," + straw.Text;
            }
            menulistView.EndUpdate();
        }

        private void Calculatebutton_Click(object sender, EventArgs e)
        {
            calculate fb = new calculate(selectButton);
            Main main = new Main();
            fb.textBox7.Text = price1.Text;
            fb.Owner = this;
            fb.Show();




            for (int i = 1; i <= menulistView.Items.Count; i++)

                for (int j = 1; j <= menulistView.Items[i - 1].SubItems.Count; j++)
                {
                    fb.menulistView.Items[i - 1].SubItems[j - 1].Text = menulistView.Items[i - 1].SubItems[j - 1].Text;
                }
            
        }
    }
}
