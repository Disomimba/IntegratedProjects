namespace GameGUI
{
    partial class frm_welcome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_welcome));
            lbl_welcome = new Label();
            btn_start = new Button();
            btn_register = new Button();
            btn_leaderboards = new Button();
            btn_quit = new Button();
            SuspendLayout();
            // 
            // lbl_welcome
            // 
            lbl_welcome.Anchor = AnchorStyles.None;
            lbl_welcome.BackColor = Color.Transparent;
            lbl_welcome.Font = new Font("Rockwell", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_welcome.ForeColor = SystemColors.ButtonHighlight;
            lbl_welcome.Location = new Point(0, 44);
            lbl_welcome.Name = "lbl_welcome";
            lbl_welcome.Size = new Size(400, 25);
            lbl_welcome.TabIndex = 0;
            lbl_welcome.Text = "MEKUS MEKUS";
            lbl_welcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_start
            // 
            btn_start.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_start.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_start.FlatStyle = FlatStyle.Flat;
            btn_start.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_start.ForeColor = Color.Black;
            btn_start.Location = new Point(100, 175);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(200, 30);
            btn_start.TabIndex = 1;
            btn_start.Text = "START";
            btn_start.UseVisualStyleBackColor = false;
            btn_start.Click += btn_start_Click;
            // 
            // btn_register
            // 
            btn_register.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_register.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_register.FlatStyle = FlatStyle.Flat;
            btn_register.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_register.ForeColor = Color.Black;
            btn_register.Location = new Point(100, 220);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(200, 30);
            btn_register.TabIndex = 2;
            btn_register.Text = "REGISTER";
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += btn_register_Click;
            // 
            // btn_leaderboards
            // 
            btn_leaderboards.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_leaderboards.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_leaderboards.FlatStyle = FlatStyle.Flat;
            btn_leaderboards.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_leaderboards.ForeColor = Color.Black;
            btn_leaderboards.Location = new Point(100, 265);
            btn_leaderboards.Name = "btn_leaderboards";
            btn_leaderboards.Size = new Size(200, 30);
            btn_leaderboards.TabIndex = 3;
            btn_leaderboards.Text = "LEADERBOARDS";
            btn_leaderboards.UseVisualStyleBackColor = false;
            btn_leaderboards.Click += btn_leaderboards_Click;
            // 
            // btn_quit
            // 
            btn_quit.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_quit.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 64);
            btn_quit.FlatStyle = FlatStyle.Flat;
            btn_quit.Font = new Font("Imprint MT Shadow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_quit.ForeColor = Color.Black;
            btn_quit.Location = new Point(100, 305);
            btn_quit.Name = "btn_quit";
            btn_quit.Size = new Size(200, 30);
            btn_quit.TabIndex = 4;
            btn_quit.Text = "QUIT";
            btn_quit.UseVisualStyleBackColor = false;
            btn_quit.Click += btn_quit_Click;
            // 
            // frm_welcome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = Properties.Resources.background;
            ClientSize = new Size(384, 461);
            Controls.Add(btn_quit);
            Controls.Add(btn_leaderboards);
            Controls.Add(btn_register);
            Controls.Add(btn_start);
            Controls.Add(lbl_welcome);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frm_welcome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mekus-Mekus";
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_welcome;
        private Button btn_start;
        private Button btn_register;
        private Button btn_leaderboards;
        private Button btn_quit;
    }
}
