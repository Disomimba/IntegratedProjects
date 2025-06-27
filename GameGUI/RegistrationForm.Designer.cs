namespace GameGUI
{
    partial class frm_registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_registration));
            lbl_SignUp = new Label();
            txt_name = new TextBox();
            txt_username = new TextBox();
            txt_password = new TextBox();
            btn_register = new Button();
            btn_home = new Button();
            lbl_name = new Label();
            lbl_username = new Label();
            lbl_password = new Label();
            SuspendLayout();
            // 
            // lbl_SignUp
            // 
            lbl_SignUp.AutoSize = true;
            lbl_SignUp.BackColor = Color.Transparent;
            lbl_SignUp.Font = new Font("Rockwell", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_SignUp.ForeColor = Color.White;
            lbl_SignUp.Location = new Point(150, 46);
            lbl_SignUp.Name = "lbl_SignUp";
            lbl_SignUp.Size = new Size(94, 25);
            lbl_SignUp.TabIndex = 0;
            lbl_SignUp.Text = "SIGNUP";
            // 
            // txt_name
            // 
            txt_name.BackColor = Color.FromArgb(196, 254, 255);
            txt_name.BorderStyle = BorderStyle.FixedSingle;
            txt_name.CausesValidation = false;
            txt_name.Font = new Font("Segoe UI", 10F);
            txt_name.Location = new Point(82, 183);
            txt_name.Name = "txt_name";
            txt_name.Size = new Size(215, 25);
            txt_name.TabIndex = 1;
            // 
            // txt_username
            // 
            txt_username.BackColor = Color.FromArgb(196, 254, 255);
            txt_username.BorderStyle = BorderStyle.FixedSingle;
            txt_username.Location = new Point(82, 234);
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(215, 23);
            txt_username.TabIndex = 2;
            // 
            // txt_password
            // 
            txt_password.BackColor = Color.FromArgb(196, 254, 255);
            txt_password.BorderStyle = BorderStyle.FixedSingle;
            txt_password.Location = new Point(82, 286);
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(215, 23);
            txt_password.TabIndex = 3;
            // 
            // btn_register
            // 
            btn_register.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_register.FlatStyle = FlatStyle.Flat;
            btn_register.Font = new Font("Imprint MT Shadow", 12F);
            btn_register.Location = new Point(122, 335);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(130, 28);
            btn_register.TabIndex = 4;
            btn_register.Text = "Submit";
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += btn_register_Click;
            // 
            // btn_home
            // 
            btn_home.BackColor = Color.Transparent;
            btn_home.BackgroundImage = Properties.Resources.btn_home_normal;
            btn_home.FlatAppearance.BorderSize = 0;
            btn_home.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_home.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_home.FlatStyle = FlatStyle.Flat;
            btn_home.Location = new Point(20, 20);
            btn_home.Name = "btn_home";
            btn_home.Size = new Size(50, 50);
            btn_home.TabIndex = 5;
            btn_home.UseVisualStyleBackColor = false;
            btn_home.Click += btn_back_Click;
            btn_home.MouseLeave += btn_back_MouseLeave;
            btn_home.MouseHover += btn_back_MouseHover;
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.BackColor = Color.FromArgb(140, 84, 22, 117);
            lbl_name.Font = new Font("Microsoft YaHei", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_name.ForeColor = Color.White;
            lbl_name.Location = new Point(84, 162);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(49, 19);
            lbl_name.TabIndex = 6;
            lbl_name.Text = "Name";
            lbl_name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_username
            // 
            lbl_username.AutoSize = true;
            lbl_username.BackColor = Color.FromArgb(140, 84, 22, 117);
            lbl_username.Font = new Font("Microsoft YaHei", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_username.ForeColor = Color.White;
            lbl_username.Location = new Point(83, 213);
            lbl_username.Name = "lbl_username";
            lbl_username.Size = new Size(76, 19);
            lbl_username.TabIndex = 7;
            lbl_username.Text = "Username";
            lbl_username.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.BackColor = Color.FromArgb(140, 84, 22, 117);
            lbl_password.Font = new Font("Microsoft YaHei", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_password.ForeColor = Color.White;
            lbl_password.Location = new Point(83, 266);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(73, 19);
            lbl_password.TabIndex = 8;
            lbl_password.Text = "Password";
            lbl_password.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frm_registration
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(384, 461);
            Controls.Add(lbl_password);
            Controls.Add(lbl_username);
            Controls.Add(lbl_name);
            Controls.Add(btn_home);
            Controls.Add(btn_register);
            Controls.Add(txt_password);
            Controls.Add(txt_username);
            Controls.Add(txt_name);
            Controls.Add(lbl_SignUp);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frm_registration";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_SignUp;
        private TextBox txt_name;
        private TextBox txt_username;
        private TextBox txt_password;
        private Button btn_register;
        private Button btn_home;
        private Label lbl_name;
        private Label lbl_username;
        private Label lbl_password;
    }
}