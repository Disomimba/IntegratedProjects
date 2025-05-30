namespace GameGUI
{
    partial class frm_game
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
            lbl_shuffledWord = new Label();
            txt_answer = new TextBox();
            lbl_lives = new Label();
            btn_submit = new Button();
            SuspendLayout();
            // 
            // lbl_shuffledWord
            // 
            lbl_shuffledWord.BackColor = Color.Transparent;
            lbl_shuffledWord.Font = new Font("Imprint MT Shadow", 20.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lbl_shuffledWord.ForeColor = Color.White;
            lbl_shuffledWord.Location = new Point(0, 135);
            lbl_shuffledWord.Name = "lbl_shuffledWord";
            lbl_shuffledWord.Size = new Size(400, 50);
            lbl_shuffledWord.TabIndex = 0;
            lbl_shuffledWord.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_answer
            // 
            txt_answer.Location = new Point(100, 229);
            txt_answer.Name = "txt_answer";
            txt_answer.Size = new Size(200, 23);
            txt_answer.TabIndex = 1;
            // 
            // lbl_lives
            // 
            lbl_lives.BackColor = Color.Transparent;
            lbl_lives.Font = new Font("Segoe UI", 20F);
            lbl_lives.ForeColor = Color.White;
            lbl_lives.Location = new Point(100, 25);
            lbl_lives.Name = "lbl_lives";
            lbl_lives.Size = new Size(200, 37);
            lbl_lives.TabIndex = 3;
            lbl_lives.Text = "❤ ❤ ❤";
            lbl_lives.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_submit
            // 
            btn_submit.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_submit.FlatAppearance.BorderSize = 0;
            btn_submit.FlatStyle = FlatStyle.Flat;
            btn_submit.Font = new Font("Imprint MT Shadow", 12F);
            btn_submit.ForeColor = Color.Black;
            btn_submit.Location = new Point(150, 272);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(100, 27);
            btn_submit.TabIndex = 4;
            btn_submit.Text = "SUBMIT";
            btn_submit.UseVisualStyleBackColor = false;
            btn_submit.Click += btn_submit_Click;
            // 
            // frm_game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            ClientSize = new Size(384, 461);
            Controls.Add(btn_submit);
            Controls.Add(lbl_lives);
            Controls.Add(txt_answer);
            Controls.Add(lbl_shuffledWord);
            Name = "frm_game";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_shuffledWord;
        private TextBox txt_answer;
        private Label lbl_lives;
        private Button btn_submit;
    }
}