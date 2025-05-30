namespace GameGUI
{
    partial class frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            txt_username = new TextBox();
            txt_password = new TextBox();
            btn_login = new Button();
            btn_home = new Button();
            lbl_message = new Label();
            lbl_signin = new Label();
            lbl_name = new Label();
            lbl_password = new Label();
            SuspendLayout();
            // 
            // txt_username
            // 
            txt_username.BackColor = Color.FromArgb(196, 254, 255);
            txt_username.BorderStyle = BorderStyle.FixedSingle;
            txt_username.Location = new Point(82, 195);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(215, 23);
            txt_username.TabIndex = 1;
            txt_username.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_password
            // 
            txt_password.BackColor = Color.FromArgb(196, 254, 255);
            txt_password.BorderStyle = BorderStyle.FixedSingle;
            txt_password.Font = new Font("Segoe UI", 10F);
            txt_password.ForeColor = Color.Black;
            txt_password.Location = new Point(82, 249);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(215, 25);
            txt_password.TabIndex = 2;
            txt_password.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_login.FlatStyle = FlatStyle.Flat;
            btn_login.Font = new Font("Imprint MT Shadow", 12F);
            btn_login.Location = new Point(124, 303);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(130, 28);
            btn_login.TabIndex = 3;
            btn_login.Text = "LOGIN";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // btn_home
            // 
            btn_home.BackColor = Color.Transparent;
            btn_home.BackgroundImage = Properties.Resources.btn_home_normal;
            btn_home.FlatAppearance.BorderSize = 0;
            btn_home.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_home.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_home.FlatStyle = FlatStyle.Flat;
            btn_home.Location = new Point(12, 12);
            btn_home.Name = "btn_home";
            btn_home.Size = new Size(50, 50);
            btn_home.TabIndex = 6;
            btn_home.UseVisualStyleBackColor = false;
            btn_home.Click += btn_back_Click;
            btn_home.MouseLeave += btn_back_MouseLeave;
            btn_home.MouseHover += btn_back_MouseHover;
            // 
            // lbl_message
            // 
            lbl_message.BackColor = Color.Transparent;
            lbl_message.FlatStyle = FlatStyle.Popup;
            lbl_message.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_message.ForeColor = Color.Red;
            lbl_message.Location = new Point(83, 275);
            lbl_message.Name = "lbl_message";
            lbl_message.Size = new Size(214, 25);
            lbl_message.TabIndex = 9;
            lbl_message.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_signin
            // 
            lbl_signin.BackColor = Color.Transparent;
            lbl_signin.Font = new Font("Rockwell", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_signin.ForeColor = Color.White;
            lbl_signin.Location = new Point(150, 46);
            lbl_signin.Name = "lbl_signin";
            lbl_signin.Size = new Size(100, 25);
            lbl_signin.TabIndex = 10;
            lbl_signin.Text = "SIGN-IN";
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.BackColor = Color.FromArgb(140, 84, 22, 117);
            lbl_name.Font = new Font("Microsoft YaHei", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_name.ForeColor = Color.White;
            lbl_name.Location = new Point(83, 173);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(76, 19);
            lbl_name.TabIndex = 11;
            lbl_name.Text = "Username";
            lbl_name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.BackColor = Color.FromArgb(140, 84, 22, 117);
            lbl_password.Font = new Font("Microsoft YaHei", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_password.ForeColor = Color.White;
            lbl_password.Location = new Point(84, 227);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(73, 19);
            lbl_password.TabIndex = 12;
            lbl_password.Text = "Password";
            lbl_password.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frm_login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(384, 401);
            Controls.Add(lbl_password);
            Controls.Add(lbl_name);
            Controls.Add(lbl_signin);
            Controls.Add(lbl_message);
            Controls.Add(btn_home);
            Controls.Add(btn_login);
            Controls.Add(txt_password);
            Controls.Add(txt_username);
            Name = "frm_login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_username;
        private TextBox txt_password;
        private Button btn_login;
        private Button btn_home;
        private Label lbl_message;
        private Label lbl_signin;
        private Label lbl_name;
        private Label lbl_password;
    }
}