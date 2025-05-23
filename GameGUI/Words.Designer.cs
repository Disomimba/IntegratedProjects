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
            SuspendLayout();
            // 
            // txt_word
            // 
            txt_word.Location = new Point(12, 390);
            txt_word.Name = "txt_word";
            txt_word.Size = new Size(356, 23);
            txt_word.TabIndex = 1;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(12, 419);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(163, 30);
            btn_add.TabIndex = 2;
            btn_add.Text = "ADD";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // btn_remove
            // 
            btn_remove.Location = new Point(205, 419);
            btn_remove.Name = "btn_remove";
            btn_remove.Size = new Size(163, 30);
            btn_remove.TabIndex = 3;
            btn_remove.Text = "REMOVE";
            btn_remove.UseVisualStyleBackColor = true;
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
            listBox_words.Location = new Point(12, 148);
            listBox_words.Name = "listBox_words";
            listBox_words.Size = new Size(356, 211);
            listBox_words.TabIndex = 7;
            listBox_words.SelectedIndexChanged += listBox_words_SelectedIndexChanged;
            // 
            // frm_words
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            ClientSize = new Size(384, 461);
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
    }
}