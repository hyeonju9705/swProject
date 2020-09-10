namespace POS_INFO
{
    partial class login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwd = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.passLabel = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.exit);
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Controls.Add(this.passwd);
            this.panel1.Controls.Add(this.id);
            this.panel1.Controls.Add(this.passLabel);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1.Location = new System.Drawing.Point(23, 157);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 178);
            this.panel1.TabIndex = 5;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.DarkGray;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit.Location = new System.Drawing.Point(377, 38);
            this.exit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(102, 82);
            this.exit.TabIndex = 6;
            this.exit.Text = "닫기";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.DarkGray;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginButton.Location = new System.Drawing.Point(263, 38);
            this.loginButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(102, 82);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "로그인";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // passwd
            // 
            this.passwd.Location = new System.Drawing.Point(98, 94);
            this.passwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwd.Name = "passwd";
            this.passwd.PasswordChar = '*';
            this.passwd.Size = new System.Drawing.Size(132, 26);
            this.passwd.TabIndex = 3;
            this.passwd.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Passwd_KeyUp);
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(98, 38);
            this.id.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(132, 26);
            this.id.TabIndex = 2;
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(21, 98);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(57, 20);
            this.passLabel.TabIndex = 1;
            this.passLabel.Text = "비밀번호";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(31, 41);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(45, 20);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "아이디";
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.BackColor = System.Drawing.SystemColors.Desktop;
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LoginLabel.ForeColor = System.Drawing.Color.White;
            this.LoginLabel.Location = new System.Drawing.Point(27, 71);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(169, 36);
            this.LoginLabel.TabIndex = 6;
            this.LoginLabel.Text = "POS Login";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 407);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.panel1);
            this.Name = "login";
            this.Text = "login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button loginButton;
        public System.Windows.Forms.TextBox passwd;
        public System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label LoginLabel;
    }
}