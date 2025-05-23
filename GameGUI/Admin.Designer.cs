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
            btn_accounts = new Button();
            btn_words = new Button();
            lbl_welcome = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_quit
            // 
            btn_quit.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_quit.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_quit.FlatStyle = FlatStyle.Flat;
            btn_quit.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_quit.ForeColor = Color.Black;
            btn_quit.Location = new Point(92, 298);
            btn_quit.Name = "btn_quit";
            btn_quit.Size = new Size(200, 30);
            btn_quit.TabIndex = 9;
            btn_quit.Text = "QUIT";
            btn_quit.UseVisualStyleBackColor = false;
            // 
            // btn_leaderboards
            // 
            btn_leaderboards.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_leaderboards.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_leaderboards.FlatStyle = FlatStyle.Flat;
            btn_leaderboards.Font = new Font("Imprint MT Shadow", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_leaderboards.ForeColor = Color.Black;
            btn_leaderboards.Location = new Point(92, 258);
            btn_leaderboards.Name = "btn_leaderboards";
            btn_leaderboards.Size = new Size(200, 30);
            btn_leaderboards.TabIndex = 8;
            btn_leaderboards.Text = "CLEAR LEADERBOARDS";
            btn_leaderboards.UseVisualStyleBackColor = false;
            // 
            // btn_accounts
            // 
            btn_accounts.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_accounts.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_accounts.FlatStyle = FlatStyle.Flat;
            btn_accounts.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_accounts.ForeColor = Color.Black;
            btn_accounts.Location = new Point(92, 213);
            btn_accounts.Name = "btn_accounts";
            btn_accounts.Size = new Size(200, 30);
            btn_accounts.TabIndex = 7;
            btn_accounts.Text = "PLAYERS";
            btn_accounts.UseVisualStyleBackColor = false;
            // 
            // btn_words
            // 
            btn_words.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_words.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_words.FlatStyle = FlatStyle.Flat;
            btn_words.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_words.ForeColor = Color.Black;
            btn_words.Location = new Point(92, 168);
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
            lbl_welcome.Location = new Point(-8, 37);
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
            label1.Location = new Point(-8, 61);
            label1.Name = "label1";
            label1.Size = new Size(400, 25);
            label1.TabIndex = 10;
            label1.Text = "ADMIN";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frm_admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            ClientSize = new Size(384, 461);
            Controls.Add(label1);
            Controls.Add(btn_quit);
            Controls.Add(btn_leaderboards);
            Controls.Add(btn_accounts);
            Controls.Add(btn_words);
            Controls.Add(lbl_welcome);
            Name = "frm_admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_quit;
        private Button btn_leaderboards;
        private Button btn_accounts;
        private Button btn_words;
        private Label lbl_welcome;
        private Label label1;
    }
}