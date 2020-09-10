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
{//date 어떻게 해보기
    
    public partial class login : Form
    {
        begin date = new begin();
        public login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (id.Text.Equals("admin") & passwd.Text.Equals("123"))
            {
                id.Text = "";
                passwd.Text = "";
                date.AddOwnedForm(this); //date를 begin으로 바꿔보았다 이 밑에 줄ㄹ도
                date.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 맞지 않습니다.", "에러",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Error);
                id.Text = "";
                passwd.Text = "";
                id.Focus();
                return;
            }
        }

        private void Passwd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (id.Text.Equals("admin") & passwd.Text.Equals("123"))
                {
                    id.Text = "";
                    passwd.Text = "";
                    date.AddOwnedForm(this);
                    date.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("아이디 또는 비밀번호가 맞지 않습니다.", "에러",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Error);
                    id.Text = "";
                    passwd.Text = "";
                    id.Focus();
                    return;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
