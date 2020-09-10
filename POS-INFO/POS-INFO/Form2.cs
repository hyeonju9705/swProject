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
    public partial class Form2 : Form
    {
        //main

        //mainClass cs = new mainClass();//class 상속
        public String menu_name; // 
        public int price;
        public String new_menu_name;
        public int new_menu_price;
        public int arr_length;

        //엑셀 내보내는 변수, 리스트
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
        
        public Form2()
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
            
        }

        private void mayo5_Click(object sender, EventArgs e)
        {
            
        }

        private void mayo6_Click(object sender, EventArgs e)
        {
            
        }

        private void mayo7_Click(object sender, EventArgs e)
        {
           
        }

        private void mayo8_Click(object sender, EventArgs e)
        {
           
        }

        private void mayo9_Click(object sender, EventArgs e)
        {
            
        }

        private void mayo10_Click(object sender, EventArgs e)
        {
           
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
    }
}
