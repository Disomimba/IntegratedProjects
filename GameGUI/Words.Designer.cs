namespace GameGUI
{
    partial class frm_words
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
            txt_word = new TextBox();
            btn_add = new Button();
            btn_remove = new Button();
            lbl_welcome = new Label();
            listBox_words = new ListBox();
            btn_home = new Button();
            SuspendLayout();
            // 
            // txt_word
            // 
            txt_word.BackColor = Color.FromArgb(196, 254, 255);
            txt_word.BorderStyle = BorderStyle.FixedSingle;
            txt_word.Location = new Point(12, 372);
            txt_word.Name = "txt_word";
            txt_word.Size = new Size(356, 23);
            txt_word.TabIndex = 1;
            // 
            // btn_add
            // 
            btn_add.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_add.FlatStyle = FlatStyle.Flat;
            btn_add.Font = new Font("Imprint MT Shadow", 12F);
            btn_add.Location = new Point(12, 410);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(163, 30);
            btn_add.TabIndex = 2;
            btn_add.Text = "ADD";
            btn_add.UseVisualStyleBackColor = false;
            btn_add.Click += btn_add_Click;
            // 
            // btn_remove
            // 
            btn_remove.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_remove.FlatStyle = FlatStyle.Flat;
            btn_remove.Font = new Font("Imprint MT Shadow", 12F);
            btn_remove.Location = new Point(205, 411);
            btn_remove.Name = "btn_remove";
            btn_remove.Size = new Size(163, 30);
            btn_remove.TabIndex = 3;
            btn_remove.Text = "REMOVE";
            btn_remove.UseVisualStyleBackColor = false;
            btn_remove.Click += btn_remove_Click;
            // 
            // lbl_welcome
            // 
            lbl_welcome.Anchor = AnchorStyles.None;
            lbl_welcome.BackColor = Color.Transparent;
            lbl_welcome.Font = new Font("Rockwell", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_welcome.ForeColor = SystemColors.ButtonHighlight;
            lbl_welcome.Location = new Point(-9, 36);
            lbl_welcome.Name = "lbl_welcome";
            lbl_welcome.Size = new Size(400, 25);
            lbl_welcome.TabIndex = 6;
            lbl_welcome.Text = "MEKUS MEKUS";
            lbl_welcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // listBox_words
            // 
            listBox_words.BackColor = Color.FromArgb(196, 254, 255);
            listBox_words.Font = new Font("Imprint MT Shadow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listBox_words.FormattingEnabled = true;
            listBox_words.ItemHeight = 23;
            listBox_words.Location = new Point(12, 125);
            listBox_words.Name = "listBox_words";
            listBox_words.Size = new Size(356, 234);
            listBox_words.TabIndex = 7;
            listBox_words.SelectedIndexChanged += listBox_words_SelectedIndexChanged;
            // 
            // btn_home
            // 
            btn_home.BackColor = Color.Transparent;
            btn_home.BackgroundImage = Properties.Resources.btn_home_normal;
            btn_home.BackgroundImageLayout = ImageLayout.Zoom;
            btn_home.FlatAppearance.BorderSize = 0;
            btn_home.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_home.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_home.FlatStyle = FlatStyle.Flat;
            btn_home.Location = new Point(12, 12);
            btn_home.Name = "btn_home";
            btn_home.Size = new Size(50, 50);
            btn_home.TabIndex = 8;
            btn_home.UseVisualStyleBackColor = false;
            btn_home.Click += btn_home_Click;
            btn_home.MouseLeave += btn_home_MouseLeave;
            btn_home.MouseHover += btn_home_MouseHover;
            // 
            // frm_words
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            ClientSize = new Size(384, 461);
            Controls.Add(btn_home);
            Controls.Add(listBox_words);
            Controls.Add(lbl_welcome);
            Controls.Add(btn_remove);
            Controls.Add(btn_add);
            Controls.Add(txt_word);
            Name = "frm_words";
            Text = "Words";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_word;
        private Button btn_add;
        private Button btn_remove;
        private Label lbl_welcome;
        private ListBox listBox_words;
        private Button btn_home;
    }
}