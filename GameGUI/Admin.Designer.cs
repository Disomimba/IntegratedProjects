namespace GameGUI
{
    partial class frm_admin
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
            btn_quit = new Button();
            btn_leaderboards = new Button();
            btn_changePass = new Button();
            btn_words = new Button();
            lbl_welcome = new Label();
            label1 = new Label();
            pnl_changePass = new Panel();
            btn_cancel = new Label();
            btn_change = new Button();
            label3 = new Label();
            label2 = new Label();
            txt_new = new TextBox();
            txt_current = new TextBox();
            lbl_changePassword = new Label();
            pnl_changePass.SuspendLayout();
            SuspendLayout();
            // 
            // btn_quit
            // 
            btn_quit.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_quit.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_quit.FlatStyle = FlatStyle.Flat;
            btn_quit.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_quit.ForeColor = Color.Black;
            btn_quit.Location = new Point(106, 290);
            btn_quit.Name = "btn_quit";
            btn_quit.Size = new Size(200, 30);
            btn_quit.TabIndex = 9;
            btn_quit.Text = "QUIT";
            btn_quit.UseVisualStyleBackColor = false;
            btn_quit.Click += btn_quit_Click;
            // 
            // btn_leaderboards
            // 
            btn_leaderboards.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_leaderboards.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_leaderboards.FlatStyle = FlatStyle.Flat;
            btn_leaderboards.Font = new Font("Imprint MT Shadow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_leaderboards.ForeColor = Color.Black;
            btn_leaderboards.Location = new Point(106, 250);
            btn_leaderboards.Name = "btn_leaderboards";
            btn_leaderboards.Size = new Size(200, 30);
            btn_leaderboards.TabIndex = 8;
            btn_leaderboards.Text = "CLEAR LEADERBOARDS";
            btn_leaderboards.UseVisualStyleBackColor = false;
            btn_leaderboards.Click += btn_leaderboards_Click;
            // 
            // btn_changePass
            // 
            btn_changePass.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_changePass.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_changePass.FlatStyle = FlatStyle.Flat;
            btn_changePass.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_changePass.ForeColor = Color.Black;
            btn_changePass.Location = new Point(106, 205);
            btn_changePass.Name = "btn_changePass";
            btn_changePass.Size = new Size(200, 30);
            btn_changePass.TabIndex = 7;
            btn_changePass.Text = "CHANGE PASSWORD";
            btn_changePass.UseVisualStyleBackColor = false;
            btn_changePass.Click += btn_changePass_Click;
            // 
            // btn_words
            // 
            btn_words.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_words.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_words.FlatStyle = FlatStyle.Flat;
            btn_words.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_words.ForeColor = Color.Black;
            btn_words.Location = new Point(106, 160);
            btn_words.Name = "btn_words";
            btn_words.Size = new Size(200, 30);
            btn_words.TabIndex = 6;
            btn_words.Text = "WORDS";
            btn_words.UseVisualStyleBackColor = false;
            btn_words.Click += btn_words_Click;
            // 
            // lbl_welcome
            // 
            lbl_welcome.Anchor = AnchorStyles.None;
            lbl_welcome.BackColor = Color.Transparent;
            lbl_welcome.Font = new Font("Rockwell", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_welcome.ForeColor = SystemColors.ButtonHighlight;
            lbl_welcome.Location = new Point(6, 37);
            lbl_welcome.Name = "lbl_welcome";
            lbl_welcome.Size = new Size(400, 25);
            lbl_welcome.TabIndex = 5;
            lbl_welcome.Text = "MEKUS MEKUS";
            lbl_welcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Rockwell", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(6, 61);
            label1.Name = "label1";
            label1.Size = new Size(400, 25);
            label1.TabIndex = 10;
            label1.Text = "ADMIN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnl_changePass
            // 
            pnl_changePass.BackColor = Color.FromArgb(144, 0, 0, 0);
            pnl_changePass.Controls.Add(btn_cancel);
            pnl_changePass.Controls.Add(btn_change);
            pnl_changePass.Controls.Add(label3);
            pnl_changePass.Controls.Add(label2);
            pnl_changePass.Controls.Add(txt_new);
            pnl_changePass.Controls.Add(txt_current);
            pnl_changePass.Controls.Add(lbl_changePassword);
            pnl_changePass.Location = new Point(80, 150);
            pnl_changePass.Name = "pnl_changePass";
            pnl_changePass.Size = new Size(250, 207);
            pnl_changePass.TabIndex = 11;
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.Transparent;
            btn_cancel.Cursor = Cursors.Hand;
            btn_cancel.Font = new Font("Rockwell", 8.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btn_cancel.ForeColor = Color.White;
            btn_cancel.Location = new Point(100, 176);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(56, 23);
            btn_cancel.TabIndex = 6;
            btn_cancel.Text = "Cancel";
            btn_cancel.TextAlign = ContentAlignment.MiddleCenter;
            btn_cancel.Click += btn_cancel_CLick;
            // 
            // btn_change
            // 
            btn_change.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_change.FlatStyle = FlatStyle.Flat;
            btn_change.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_change.ForeColor = Color.White;
            btn_change.Location = new Point(27, 147);
            btn_change.Name = "btn_change";
            btn_change.Size = new Size(200, 26);
            btn_change.TabIndex = 5;
            btn_change.Text = "Change";
            btn_change.UseVisualStyleBackColor = false;
            btn_change.Click += btn_change_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Rockwell", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(27, 94);
            label3.Name = "label3";
            label3.Size = new Size(200, 23);
            label3.TabIndex = 4;
            label3.Text = "Enter your New Password";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Rockwell", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(27, 39);
            label2.Name = "label2";
            label2.Size = new Size(200, 23);
            label2.TabIndex = 3;
            label2.Text = "Enter your Current Password";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_new
            // 
            txt_new.Location = new Point(27, 118);
            txt_new.Name = "txt_new";
            txt_new.Size = new Size(200, 23);
            txt_new.TabIndex = 2;
            // 
            // txt_current
            // 
            txt_current.Location = new Point(27, 62);
            txt_current.Name = "txt_current";
            txt_current.Size = new Size(200, 23);
            txt_current.TabIndex = 1;
            // 
            // lbl_changePassword
            // 
            lbl_changePassword.BackColor = Color.Transparent;
            lbl_changePassword.Font = new Font("Rockwell", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_changePassword.ForeColor = Color.White;
            lbl_changePassword.Location = new Point(3, 7);
            lbl_changePassword.Name = "lbl_changePassword";
            lbl_changePassword.Size = new Size(244, 23);
            lbl_changePassword.TabIndex = 0;
            lbl_changePassword.Text = "CHANGE PASSWORD";
            lbl_changePassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frm_admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            ClientSize = new Size(384, 461);
            Controls.Add(pnl_changePass);
            Controls.Add(label1);
            Controls.Add(btn_quit);
            Controls.Add(btn_leaderboards);
            Controls.Add(btn_changePass);
            Controls.Add(btn_words);
            Controls.Add(lbl_welcome);
            Name = "frm_admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            pnl_changePass.ResumeLayout(false);
            pnl_changePass.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btn_quit;
        private Button btn_leaderboards;
        private Button btn_changePass;
        private Button btn_words;
        private Label lbl_welcome;
        private Label label1;
        private Panel pnl_changePass;
        private TextBox txt_new;
        private TextBox txt_current;
        private Label lbl_changePassword;
        private Button btn_change;
        private Label label3;
        private Label btn_cancel;
        private Label label2;
    }
}