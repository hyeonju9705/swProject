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
    public partial class begin : Form
    {
        public begin()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Form1 fb = new Form1();
            fb.Show();
            //fb.AddOwnedForm(this); 이게 클릭눌렀을때 실행되는 폼 에 보인다... 그걸 지운것
        }
    }
}
