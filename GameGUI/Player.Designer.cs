namespace GameGUI
{
    partial class frm_player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_player));
            btn_play = new Button();
            btn_history = new Button();
            btn_mechanics = new Button();
            btn_settings = new Button();
            btn_exit = new Button();
            lbl_name = new Label();
            lbl_Welcome = new Label();
            pnl_changePass = new Panel();
            btn_cancel = new Label();
            btn_change = new Button();
            lbl_new = new Label();
            lbl_current = new Label();
            txt_new = new TextBox();
            txt_current = new TextBox();
            lbl_changePassword = new Label();
            pnl_mechanics = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btn_back = new Button();
            pnl_history = new Panel();
            pnl_history_small = new Panel();
            label7 = new Label();
            btn_history_back = new Button();
            lb_score_error = new ListBox();
            pnl_changePass.SuspendLayout();
            pnl_mechanics.SuspendLayout();
            pnl_history.SuspendLayout();
            pnl_history_small.SuspendLayout();
            SuspendLayout();
            // 
            // btn_play
            // 
            btn_play.BackColor = Color.Transparent;
            btn_play.BackgroundImage = Properties.Resources.btn_play_normal;
            btn_play.BackgroundImageLayout = ImageLayout.Stretch;
            btn_play.CausesValidation = false;
            btn_play.FlatAppearance.BorderSize = 0;
            btn_play.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_play.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_play.FlatStyle = FlatStyle.Flat;
            btn_play.Location = new Point(125, 130);
            btn_play.Name = "btn_play";
            btn_play.Size = new Size(150, 150);
            btn_play.TabIndex = 0;
            btn_play.UseVisualStyleBackColor = false;
            btn_play.Click += btn_play_Click;
            btn_play.MouseLeave += btn_play_MouseLeave;
            btn_play.MouseHover += btn_play_MouseHover;
            // 
            // btn_history
            // 
            btn_history.BackColor = Color.Transparent;
            btn_history.BackgroundImage = Properties.Resources.btn_history_normal;
            btn_history.BackgroundImageLayout = ImageLayout.Stretch;
            btn_history.FlatAppearance.BorderSize = 0;
            btn_history.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_history.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_history.FlatStyle = FlatStyle.Flat;
            btn_history.Location = new Point(137, 322);
            btn_history.Name = "btn_history";
            btn_history.Size = new Size(50, 50);
            btn_history.TabIndex = 1;
            btn_history.UseVisualStyleBackColor = false;
            btn_history.Click += btn_history_Click;
            btn_history.MouseLeave += btn_history_MouseLeave;
            btn_history.MouseHover += btn_history_MouseHover;
            // 
            // btn_mechanics
            // 
            btn_mechanics.BackColor = Color.Transparent;
            btn_mechanics.BackgroundImage = Properties.Resources.btn_home_normal;
            btn_mechanics.BackgroundImageLayout = ImageLayout.Stretch;
            btn_mechanics.FlatAppearance.BorderSize = 0;
            btn_mechanics.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_mechanics.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_mechanics.FlatStyle = FlatStyle.Flat;
            btn_mechanics.Location = new Point(62, 322);
            btn_mechanics.Name = "btn_mechanics";
            btn_mechanics.Size = new Size(50, 50);
            btn_mechanics.TabIndex = 2;
            btn_mechanics.UseVisualStyleBackColor = false;
            btn_mechanics.Click += btn_mechanics_Click;
            btn_mechanics.MouseLeave += btn_mechanics_MouseLeave;
            btn_mechanics.MouseHover += btn_mechanics_MouseHover;
            // 
            // btn_settings
            // 
            btn_settings.BackColor = Color.Transparent;
            btn_settings.BackgroundImage = Properties.Resources.btn_settings_normal;
            btn_settings.BackgroundImageLayout = ImageLayout.Stretch;
            btn_settings.FlatAppearance.BorderSize = 0;
            btn_settings.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_settings.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_settings.FlatStyle = FlatStyle.Flat;
            btn_settings.Location = new Point(212, 322);
            btn_settings.Name = "btn_settings";
            btn_settings.Size = new Size(50, 50);
            btn_settings.TabIndex = 3;
            btn_settings.UseVisualStyleBackColor = false;
            btn_settings.Click += btn_settings_Click;
            btn_settings.MouseLeave += btn_settings_MouseLeave;
            btn_settings.MouseHover += btn_settings_MouseHover;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.Transparent;
            btn_exit.BackgroundImage = Properties.Resources.btn_home_normal;
            btn_exit.FlatAppearance.BorderSize = 0;
            btn_exit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_exit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_exit.FlatStyle = FlatStyle.Flat;
            btn_exit.Font = new Font("Showcard Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_exit.Location = new Point(287, 322);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(50, 50);
            btn_exit.TabIndex = 4;
            btn_exit.UseVisualStyleBackColor = false;
            btn_exit.Click += lbl_exit_Click;
            btn_exit.MouseLeave += lbl_exit_MouseLeave;
            btn_exit.MouseHover += lbl_exit_MouseHover;
            // 
            // lbl_name
            // 
            lbl_name.BackColor = Color.Transparent;
            lbl_name.FlatStyle = FlatStyle.Flat;
            lbl_name.Font = new Font("Impact", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_name.ForeColor = Color.White;
            lbl_name.Location = new Point(0, 50);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new Size(400, 37);
            lbl_name.TabIndex = 5;
            lbl_name.Text = "SAMPLE NAME";
            lbl_name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Welcome
            // 
            lbl_Welcome.BackColor = Color.Transparent;
            lbl_Welcome.FlatStyle = FlatStyle.Flat;
            lbl_Welcome.Font = new Font("Impact", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_Welcome.ForeColor = Color.White;
            lbl_Welcome.Location = new Point(0, 20);
            lbl_Welcome.Name = "lbl_Welcome";
            lbl_Welcome.Size = new Size(400, 37);
            lbl_Welcome.TabIndex = 6;
            lbl_Welcome.Text = "HELLO!";
            lbl_Welcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnl_changePass
            // 
            pnl_changePass.BackColor = Color.FromArgb(144, 0, 0, 0);
            pnl_changePass.Controls.Add(btn_cancel);
            pnl_changePass.Controls.Add(btn_change);
            pnl_changePass.Controls.Add(lbl_new);
            pnl_changePass.Controls.Add(lbl_current);
            pnl_changePass.Controls.Add(txt_new);
            pnl_changePass.Controls.Add(txt_current);
            pnl_changePass.Controls.Add(lbl_changePassword);
            pnl_changePass.Location = new Point(62, 130);
            pnl_changePass.Name = "pnl_changePass";
            pnl_changePass.Size = new Size(280, 245);
            pnl_changePass.TabIndex = 16;
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = Color.Transparent;
            btn_cancel.Cursor = Cursors.Hand;
            btn_cancel.Font = new Font("Rockwell", 8.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            btn_cancel.ForeColor = Color.White;
            btn_cancel.Location = new Point(113, 208);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(56, 23);
            btn_cancel.TabIndex = 6;
            btn_cancel.Text = "Cancel";
            btn_cancel.TextAlign = ContentAlignment.MiddleCenter;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_change
            // 
            btn_change.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_change.FlatStyle = FlatStyle.Flat;
            btn_change.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_change.ForeColor = Color.White;
            btn_change.Location = new Point(40, 175);
            btn_change.Name = "btn_change";
            btn_change.Size = new Size(200, 26);
            btn_change.TabIndex = 5;
            btn_change.Text = "Change";
            btn_change.UseVisualStyleBackColor = false;
            btn_change.Click += btn_change_Click;
            // 
            // lbl_new
            // 
            lbl_new.BackColor = Color.Transparent;
            lbl_new.Font = new Font("Rockwell", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_new.ForeColor = Color.White;
            lbl_new.Location = new Point(40, 122);
            lbl_new.Name = "lbl_new";
            lbl_new.Size = new Size(200, 23);
            lbl_new.TabIndex = 4;
            lbl_new.Text = "Enter your New Password";
            lbl_new.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_current
            // 
            lbl_current.BackColor = Color.Transparent;
            lbl_current.Font = new Font("Rockwell", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_current.ForeColor = Color.White;
            lbl_current.Location = new Point(40, 67);
            lbl_current.Name = "lbl_current";
            lbl_current.Size = new Size(200, 23);
            lbl_current.TabIndex = 3;
            lbl_current.Text = "Enter your Current Password";
            lbl_current.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_new
            // 
            txt_new.Location = new Point(40, 146);
            txt_new.Name = "txt_new";
            txt_new.Size = new Size(200, 23);
            txt_new.TabIndex = 2;
            // 
            // txt_current
            // 
            txt_current.Location = new Point(40, 90);
            txt_current.Name = "txt_current";
            txt_current.Size = new Size(200, 23);
            txt_current.TabIndex = 1;
            // 
            // lbl_changePassword
            // 
            lbl_changePassword.BackColor = Color.Transparent;
            lbl_changePassword.Font = new Font("Rockwell", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_changePassword.ForeColor = Color.White;
            lbl_changePassword.Location = new Point(20, 34);
            lbl_changePassword.Name = "lbl_changePassword";
            lbl_changePassword.Size = new Size(244, 23);
            lbl_changePassword.TabIndex = 0;
            lbl_changePassword.Text = "CHANGE PASSWORD";
            lbl_changePassword.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnl_mechanics
            // 
            pnl_mechanics.BackColor = Color.FromArgb(144, 0, 0, 0);
            pnl_mechanics.Controls.Add(label4);
            pnl_mechanics.Controls.Add(label3);
            pnl_mechanics.Controls.Add(label2);
            pnl_mechanics.Controls.Add(label1);
            pnl_mechanics.Controls.Add(btn_back);
            pnl_mechanics.Location = new Point(62, 127);
            pnl_mechanics.Name = "pnl_mechanics";
            pnl_mechanics.Size = new Size(280, 245);
            pnl_mechanics.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 0, 0, 0);
            label4.Font = new Font("Rockwell", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(10, 133);
            label4.Name = "label4";
            label4.Size = new Size(177, 17);
            label4.TabIndex = 9;
            label4.Text = "3. You only have 3 tries.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(0, 0, 0, 0);
            label3.Font = new Font("Rockwell", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(10, 99);
            label3.Name = "label3";
            label3.Size = new Size(142, 17);
            label3.TabIndex = 8;
            label3.Text = "2. You'll arrange it.";
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Rockwell", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(10, 17);
            label2.Name = "label2";
            label2.Size = new Size(244, 23);
            label2.TabIndex = 7;
            label2.Text = "MECHANICS";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(0, 0, 0, 0);
            label1.Font = new Font("Rockwell", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(10, 66);
            label1.Name = "label1";
            label1.Size = new Size(247, 17);
            label1.TabIndex = 1;
            label1.Text = "1.  You'll be given shuffled words.\r\n";
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(40, 210);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(200, 23);
            btn_back.TabIndex = 0;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // pnl_history
            // 
            pnl_history.BackColor = Color.FromArgb(144, 0, 0, 0);
            pnl_history.Controls.Add(pnl_history_small);
            pnl_history.Controls.Add(label7);
            pnl_history.Controls.Add(btn_history_back);
            pnl_history.Location = new Point(62, 124);
            pnl_history.Name = "pnl_history";
            pnl_history.Size = new Size(280, 245);
            pnl_history.TabIndex = 18;
            // 
            // pnl_history_small
            // 
            pnl_history_small.Controls.Add(lb_score_error);
            pnl_history_small.Location = new Point(20, 59);
            pnl_history_small.Name = "pnl_history_small";
            pnl_history_small.Size = new Size(244, 136);
            pnl_history_small.TabIndex = 9;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Rockwell", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(20, 16);
            label7.Name = "label7";
            label7.Size = new Size(244, 23);
            label7.TabIndex = 7;
            label7.Text = "HISTORY";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_history_back
            // 
            btn_history_back.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_history_back.FlatStyle = FlatStyle.Flat;
            btn_history_back.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_history_back.ForeColor = Color.White;
            btn_history_back.Location = new Point(40, 210);
            btn_history_back.Name = "btn_history_back";
            btn_history_back.Size = new Size(200, 23);
            btn_history_back.TabIndex = 0;
            btn_history_back.Text = "Back";
            btn_history_back.UseVisualStyleBackColor = false;
            btn_history_back.Click += btn_history_back_Click;
            // 
            // lb_score_error
            // 
            lb_score_error.FormattingEnabled = true;
            lb_score_error.ItemHeight = 15;
            lb_score_error.Location = new Point(0, 0);
            lb_score_error.Name = "lb_score_error";
            lb_score_error.Size = new Size(244, 139);
            lb_score_error.TabIndex = 10;
            // 
            // frm_player
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(384, 582);
            Controls.Add(pnl_history);
            Controls.Add(pnl_mechanics);
            Controls.Add(pnl_changePass);
            Controls.Add(lbl_Welcome);
            Controls.Add(lbl_name);
            Controls.Add(btn_exit);
            Controls.Add(btn_settings);
            Controls.Add(btn_mechanics);
            Controls.Add(btn_history);
            Controls.Add(btn_play);
            Name = "frm_player";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Player";
            pnl_changePass.ResumeLayout(false);
            pnl_changePass.PerformLayout();
            pnl_mechanics.ResumeLayout(false);
            pnl_mechanics.PerformLayout();
            pnl_history.ResumeLayout(false);
            pnl_history_small.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btn_play;
        private Button btn_history;
        private Button btn_mechanics;
        private Button btn_settings;
        private Button btn_exit;
        private Label lbl_name;
        private Label lbl_Welcome;
        private Panel pnl_changePass;
        private Label btn_cancel;
        private Button btn_change;
        private Label lbl_new;
        private Label lbl_current;
        private TextBox txt_new;
        private TextBox txt_current;
        private Label lbl_changePassword;
        private Panel pnl_mechanics;
        private Button btn_back;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Panel pnl_history;
        private Label label7;
        private Button btn_history_back;
        private Panel pnl_history_small;
        private ListBox lb_score_error;
    }
}