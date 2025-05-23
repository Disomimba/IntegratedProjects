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
            btn_mechanics.BackgroundImage = Properties.Resources.btn_mechanics_normal;
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
            btn_mechanics.UseWaitCursor = true;
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
            // frm_player
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(384, 461);
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
    }
}