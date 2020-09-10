using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_INFO
{
    public partial class Form1 : Form
    {
        private bool buttonMoveFlag;
        private List<Control> controlItems;
        private int selectButtonIndex;
        private int gapX, gapY;
        private int numButton;
        private int initLocation = 50;

        
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            makeButton("test", string.Format("좌석{0}", numButton), initLocation, initLocation); // x좌표, y좌표
            numButton++; // 버튼초기 이름
            initLocation += 10; // 겹치지 않게 좌표 변경
           // ScreenCapture(new Point(groupBox1.Left, groupBox1.Top), groupBox1.Size);
        }
        
        private void makeButton(string name, string text, int x, int y)
        {
            Button newButton = new Button(); // button 생성
            groupBox1.Controls.Add(newButton); // gropuBox1
            newButton.Size = new Size(60,60);
            newButton.Name = name;
            newButton.Text = text;
            newButton.Location = new Point(x, y);
            newButton.MouseDown += new MouseEventHandler(this.testButtonDown);
            newButton.MouseMove += new MouseEventHandler(this.testButtonMove);
            newButton.MouseUp += new MouseEventHandler(this.testButtonUp);
        }
        

      

        private void testButtonDown(object sender, MouseEventArgs e) // 마우스 누를때
        {

         
            if (!buttonMoveFlag)
            {
                buttonMoveFlag = true;
                string buttonText = ((Button)sender).Text;
                Control[] test = groupBox1.Controls.Find("test", true);
                controlItems = test.ToList();

                foreach (Control tempTest in controlItems)
                {
                    if (tempTest.Text.Equals(buttonText))
                    {
                        selectButtonIndex = controlItems.IndexOf(tempTest);
                        gapX = e.Location.X;
                        gapY = e.Location.Y;
                    }
                }
            }

         
        }

        private void testButtonMove(object sender, MouseEventArgs e) //클릭중 마우스 이동시
        {
            if (buttonMoveFlag)
            {
                controlItems[selectButtonIndex].Location = new Point(
                    (controlItems[selectButtonIndex].Location.X + e.X) - gapX,
                    (controlItems[selectButtonIndex].Location.Y + e.Y) - gapY);
                groupBox1.Update();
            }
        }
        
        private void testButtonUp(object sender, MouseEventArgs e) // 마우스 올릴때
        {
           
            if (buttonMoveFlag)
            {
                buttonMoveFlag = false;
                controlItems[selectButtonIndex].Location = new Point(
                    (controlItems[selectButtonIndex].Location.X + e.X) - gapX,
                    (controlItems[selectButtonIndex].Location.Y + e.Y) - gapY);
                if (e.Button == System.Windows.Forms.MouseButtons.Right) // 우클릭시
                {
                    Form2 form = new Form2();
                    form.ShowDialog();
                }
            }
        }

    

       public void ScreenCapture(Point _point, Size _size)
        {
            Rectangle rectangle = new Rectangle(_point, _size);
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(rectangle.Left, rectangle.Top, 0, 0, rectangle.Size);
            bitmap.Save(@"C:\test.png", ImageFormat.Png);
        }
    }
}
