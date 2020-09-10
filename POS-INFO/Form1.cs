using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_INFO
{
    public partial class Form1 : Form
    {
        public bool buttonMoveFlag;
        public List<Control> controlItems;
        public int selectButtonIndex;
        public int gapX, gapY;
        public int numButton;
        public int initLocation = 50;
        int i;
        int j;
        Button[] btn = new Button[100];


        public Form1()
        {
            InitializeComponent();
            inniteButton();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

       
        public void inniteButton()
        {
            
            string filePath = ConfigurationManager.AppSettings["filepath"].ToString();

            FileInfo fileInfo = new FileInfo(filePath);

            
            if (!fileInfo.Exists)
            {
              
                System.IO.File.WriteAllText(filePath, string.Empty, Encoding.Default);
            }
            else
            {
                string fileValue = System.IO.File.ReadAllText(filePath, Encoding.Default);

                

                string[] tableList = fileValue.Split('*');
                List<int> tableNumberList = new List<int>();

                for (int cnt = 1; cnt < tableList.Count(); cnt++)
                {
                    string table = tableList[cnt];
                    string tablenumber = table.Split(']')[0].Replace("[", "");
                    tablenumber = tablenumber.Replace("테이블", "");
                    int tablenum = int.Parse(tablenumber);
                    tableNumberList.Add(tablenum);
                }

                if(tableNumberList != null && tableNumberList.Count > 0)
                {
                    int maxtablenum = tableNumberList.Max();

                   
                    for (int cnt = 0; cnt <= maxtablenum; cnt++)
                    {
                        if (fileValue.Contains(string.Format("[테이블{0}]", cnt)))
                        {
                            string[] stringarry = fileValue.Split(new[] { string.Format("[테이블{0}]", cnt) }, StringSplitOptions.None);
                            string selectmenu = string.Format("[{0}]", string.Format("테이블{0}", cnt)) + stringarry[1].Split('*')[0];

                            makeButton("test", selectmenu, initLocation, initLocation, j); // x좌표, y좌표
                            numButton++; // 버튼초기 이름
                            initLocation += 50; // 겹치지 않게 좌표 변경
                            if (initLocation > 550) initLocation = 50;
                            i++;
                            j++;
                        }
                        else
                        {
                            makeButton("test", string.Format("테이블{0}", cnt), initLocation, initLocation, j); // x좌표, y좌표
                            numButton = cnt + 1; // 버튼초기 이름
                            initLocation += 50; // 겹치지 않게 좌표 변경
                            if (initLocation > 550) initLocation = 50;
                            i++;
                            j++;
                        }
                    }
                }
               
            }

            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            makeButton("test", string.Format("테이블{0}", numButton), initLocation, initLocation, j); // x좌표, y좌표
            numButton++; // 버튼초기 이름
            initLocation += 50; // 겹치지 않게 좌표 변경
            if (initLocation > 550) initLocation = 50;
            i++;
            j++;
            // ScreenCapture(new Point(groupBox1.Left, groupBox1.Top), groupBox1.Size);
        }

        public void makeButton(string name, string text, int x, int y, int f)
        {
            Button[] newButton = new Button[100]; // button 생성
            newButton[f] = new Button();
            groupBox1.Controls.Add(newButton[f]); // gropuBox1
            newButton[f].Size = new Size(60, 60);
            newButton[f].Name = name;
            newButton[f].Text = text;
            newButton[f].Location = new Point(x, y);
            newButton[f].MouseDown += new MouseEventHandler(this.testButtonDown);
            newButton[f].MouseMove += new MouseEventHandler(this.testButtonMove);
            newButton[f].MouseUp += new MouseEventHandler(this.testButtonUp);
            btn[i] = newButton[f];
        }

        public void testButtonDown(object sender, MouseEventArgs e) // 마우스 누를때
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

        public void testButtonMove(object sender, MouseEventArgs e) //클릭중 마우스 이동시
        {
            if (buttonMoveFlag)
            {
                controlItems[selectButtonIndex].Location = new Point(
                    (controlItems[selectButtonIndex].Location.X + e.X) - gapX,
                    (controlItems[selectButtonIndex].Location.Y + e.Y) - gapY);
                groupBox1.Update();
            }
        }

        public void btn_Click(object sender, EventArgs e)
        {
            controlItems[selectButtonIndex].BackColor = Color.Red;
        }




        public void testButtonUp(object sender, MouseEventArgs e) // 마우스 올릴때
        {

            if (buttonMoveFlag)
            {
                buttonMoveFlag = false;
                controlItems[selectButtonIndex].Location = new Point(
                    (controlItems[selectButtonIndex].Location.X + e.X) - gapX,
                    (controlItems[selectButtonIndex].Location.Y + e.Y) - gapY);

                if (e.Button == System.Windows.Forms.MouseButtons.Right) // 우클릭시
                {
                    btn[selectButtonIndex].BackColor = Color.Red;

                    Main form = new Main(btn[selectButtonIndex]);
                
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;

                    this.StartPosition = FormStartPosition.Manual;

                    Rectangle fullScreen_bounds;

                    fullScreen_bounds = Rectangle.Empty;

                    foreach (var screen in Screen.AllScreens)
                    {
                        fullScreen_bounds = Rectangle.Union(fullScreen_bounds, screen.Bounds);
                    }
                    this.ClientSize = new Size(fullScreen_bounds.Width, fullScreen_bounds.Height);
                    this.Location = new Point(fullScreen_bounds.Left, fullScreen_bounds.Top);
                    

                    
                    form.ShowDialog();
                    form.AddOwnedForm(this);
                    
                    

                }
            }
        }

        public void Form1_Load(object sender, EventArgs e)
        {
           // ScreenCapture(new Point(groupBox1.Left, groupBox1.Top), groupBox1.Size);
        }

        public void ScreenCapture(Point _point, Size _size)
        {
            Rectangle rectangle = new Rectangle(_point, _size);
            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(rectangle.Left, rectangle.Top, 0, 0, rectangle.Size);
            bitmap.Save(@"D:\test.png", ImageFormat.Png);
        }
    }

}