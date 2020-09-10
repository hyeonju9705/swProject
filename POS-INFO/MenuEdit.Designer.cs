namespace POS_INFO
{
    partial class MenuEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancel = new System.Windows.Forms.Button();
            this.menu_make = new System.Windows.Forms.Button();
            this.new_price = new System.Windows.Forms.TextBox();
            this.new_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.select_menu = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(229, 326);
            this.cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(106, 44);
            this.cancel.TabIndex = 30;
            this.cancel.Text = "취소";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // menu_make
            // 
            this.menu_make.Location = new System.Drawing.Point(78, 326);
            this.menu_make.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.menu_make.Name = "menu_make";
            this.menu_make.Size = new System.Drawing.Size(106, 44);
            this.menu_make.TabIndex = 29;
            this.menu_make.Text = "만들기";
            this.menu_make.UseVisualStyleBackColor = true;
            this.menu_make.Click += new System.EventHandler(this.menu_make_Click);
            // 
            // new_price
            // 
            this.new_price.Location = new System.Drawing.Point(78, 254);
            this.new_price.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.new_price.Name = "new_price";
            this.new_price.Size = new System.Drawing.Size(257, 25);
            this.new_price.TabIndex = 28;
            // 
            // new_name
            // 
            this.new_name.Location = new System.Drawing.Point(80, 161);
            this.new_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.new_name.Name = "new_name";
            this.new_name.Size = new System.Drawing.Size(255, 25);
            this.new_name.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "새로운 메뉴 가격을 입력하세요.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "새로운 메뉴의 이름을 입력하세요.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "추가하시려는 상위 메뉴를 선택하세요.";
            // 
            // select_menu
            // 
            this.select_menu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.select_menu.FormattingEnabled = true;
            this.select_menu.Items.AddRange(new object[] {
            "마요",
            "직화",
            "사이드 MENU"});
            this.select_menu.Location = new System.Drawing.Point(80, 69);
            this.select_menu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_menu.Name = "select_menu";
            this.select_menu.Size = new System.Drawing.Size(254, 23);
            this.select_menu.TabIndex = 23;
            // 
            // MenuEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 420);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.menu_make);
            this.Controls.Add(this.new_price);
            this.Controls.Add(this.new_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.select_menu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MenuEdit";
            this.Text = "MenuEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button menu_make;
        private System.Windows.Forms.TextBox new_price;
        private System.Windows.Forms.TextBox new_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox select_menu;
    }
}