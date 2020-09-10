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
    public partial class MenuEdit : Form
    {
        public MenuEdit()
        {
            InitializeComponent();
        }

        private void menu_make_Click(object sender, EventArgs e)
        {
            Main fm1 = new Main();
            fm1.new_menu_name = new_name.Text;
            fm1.new_menu_price = int.Parse(new_price.Text);
            switch (select_menu.SelectedIndex)
            {
                case 0:
                    fm1.add_mayo();
                    fm1.Show();
                    break;
                case 1:
                    fm1.add_fire();
                    fm1.Show();
                    break;
                case 2:
                    fm1.add_side();
                    fm1.Show();
                    break;
            }

            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }
    }
}
