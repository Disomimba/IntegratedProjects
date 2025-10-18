namespace GameGUI
{
    partial class ForgotPassword
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
            pnl_otp = new Panel();
            btn_send_otp = new Button();
            lbl_otp_message = new Label();
            label1 = new Label();
            label3 = new Label();
            txt_otp = new TextBox();
            btn_submit = new Button();
            lbl_message_email = new Label();
            txt_email = new TextBox();
            label7 = new Label();
            btn_back = new Button();
            pnl_changePass = new Panel();
            lbl_confPass = new Label();
            lbl_newPassword = new Label();
            label5 = new Label();
            txt_confirmPassword = new TextBox();
            btn_changePassword = new Button();
            label6 = new Label();
            txt_newPassword = new TextBox();
            pnl_otp.SuspendLayout();
            pnl_changePass.SuspendLayout();
            SuspendLayout();
            // 
            // pnl_otp
            // 
            pnl_otp.BackColor = Color.FromArgb(144, 0, 0, 0);
            pnl_otp.Controls.Add(btn_send_otp);
            pnl_otp.Controls.Add(lbl_otp_message);
            pnl_otp.Controls.Add(label1);
            pnl_otp.Controls.Add(label3);
            pnl_otp.Controls.Add(txt_otp);
            pnl_otp.Controls.Add(btn_submit);
            pnl_otp.Controls.Add(lbl_message_email);
            pnl_otp.Controls.Add(txt_email);
            pnl_otp.Location = new Point(52, 108);
            pnl_otp.Name = "pnl_otp";
            pnl_otp.Size = new Size(280, 245);
            pnl_otp.TabIndex = 19;
            // 
            // btn_send_otp
            // 
            btn_send_otp.Font = new Font("Segoe UI", 4F);
            btn_send_otp.Location = new Point(215, 75);
            btn_send_otp.Name = "btn_send_otp";
            btn_send_otp.Size = new Size(25, 17);
            btn_send_otp.TabIndex = 26;
            btn_send_otp.Text = ">";
            btn_send_otp.TextImageRelation = TextImageRelation.TextBeforeImage;
            btn_send_otp.UseVisualStyleBackColor = true;
            btn_send_otp.Click += btn_send_otp_Click;
            // 
            // lbl_otp_message
            // 
            lbl_otp_message.BackColor = Color.Transparent;
            lbl_otp_message.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_otp_message.ForeColor = Color.White;
            lbl_otp_message.Location = new Point(40, 174);
            lbl_otp_message.Name = "lbl_otp_message";
            lbl_otp_message.Size = new Size(195, 16);
            lbl_otp_message.TabIndex = 25;
            lbl_otp_message.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(40, 57);
            label1.Name = "label1";
            label1.Size = new Size(195, 16);
            label1.TabIndex = 24;
            label1.Text = "Enter your email:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(40, 136);
            label3.Name = "label3";
            label3.Size = new Size(195, 16);
            label3.TabIndex = 23;
            label3.Text = "Enter the OTP:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_otp
            // 
            txt_otp.BorderStyle = BorderStyle.None;
            txt_otp.Location = new Point(40, 155);
            txt_otp.Name = "txt_otp";
            txt_otp.Size = new Size(200, 16);
            txt_otp.TabIndex = 22;
            // 
            // btn_submit
            // 
            btn_submit.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_submit.FlatStyle = FlatStyle.Flat;
            btn_submit.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_submit.ForeColor = Color.White;
            btn_submit.Location = new Point(40, 210);
            btn_submit.Name = "btn_submit";
            btn_submit.Size = new Size(200, 23);
            btn_submit.TabIndex = 0;
            btn_submit.Text = "Submit";
            btn_submit.UseVisualStyleBackColor = false;
            btn_submit.Click += btn_submit_Click;
            // 
            // lbl_message_email
            // 
            lbl_message_email.BackColor = Color.Transparent;
            lbl_message_email.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_message_email.ForeColor = Color.White;
            lbl_message_email.Location = new Point(40, 95);
            lbl_message_email.Name = "lbl_message_email";
            lbl_message_email.Size = new Size(195, 16);
            lbl_message_email.TabIndex = 21;
            lbl_message_email.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_email
            // 
            txt_email.BorderStyle = BorderStyle.None;
            txt_email.Location = new Point(40, 76);
            txt_email.Margin = new Padding(3, 3, 25, 3);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(174, 16);
            txt_email.TabIndex = 0;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Rockwell", 16F, FontStyle.Bold);
            label7.ForeColor = Color.White;
            label7.Location = new Point(52, 9);
            label7.Name = "label7";
            label7.Size = new Size(284, 70);
            label7.TabIndex = 7;
            label7.Text = "FORGOT PASSWORD";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(12, 24);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(48, 23);
            btn_back.TabIndex = 27;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // pnl_changePass
            // 
            pnl_changePass.BackColor = Color.FromArgb(144, 0, 0, 0);
            pnl_changePass.Controls.Add(lbl_confPass);
            pnl_changePass.Controls.Add(lbl_newPassword);
            pnl_changePass.Controls.Add(label5);
            pnl_changePass.Controls.Add(txt_confirmPassword);
            pnl_changePass.Controls.Add(btn_changePassword);
            pnl_changePass.Controls.Add(label6);
            pnl_changePass.Controls.Add(txt_newPassword);
            pnl_changePass.Location = new Point(52, 108);
            pnl_changePass.Name = "pnl_changePass";
            pnl_changePass.Size = new Size(280, 245);
            pnl_changePass.TabIndex = 27;
            // 
            // lbl_confPass
            // 
            lbl_confPass.BackColor = Color.Transparent;
            lbl_confPass.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_confPass.ForeColor = Color.White;
            lbl_confPass.Location = new Point(40, 174);
            lbl_confPass.Name = "lbl_confPass";
            lbl_confPass.Size = new Size(195, 16);
            lbl_confPass.TabIndex = 25;
            lbl_confPass.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_newPassword
            // 
            lbl_newPassword.BackColor = Color.Transparent;
            lbl_newPassword.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_newPassword.ForeColor = Color.White;
            lbl_newPassword.Location = new Point(40, 57);
            lbl_newPassword.Name = "lbl_newPassword";
            lbl_newPassword.Size = new Size(195, 16);
            lbl_newPassword.TabIndex = 24;
            lbl_newPassword.Text = "Enter your new password.";
            lbl_newPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(40, 136);
            label5.Name = "label5";
            label5.Size = new Size(195, 16);
            label5.TabIndex = 23;
            label5.Text = "Confirm password.";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txt_confirmPassword
            // 
            txt_confirmPassword.BorderStyle = BorderStyle.None;
            txt_confirmPassword.Location = new Point(40, 155);
            txt_confirmPassword.Name = "txt_confirmPassword";
            txt_confirmPassword.Size = new Size(200, 16);
            txt_confirmPassword.TabIndex = 22;
            // 
            // btn_changePassword
            // 
            btn_changePassword.BackColor = Color.FromArgb(150, 196, 254, 255);
            btn_changePassword.FlatStyle = FlatStyle.Flat;
            btn_changePassword.Font = new Font("Rockwell", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_changePassword.ForeColor = Color.White;
            btn_changePassword.Location = new Point(40, 210);
            btn_changePassword.Name = "btn_changePassword";
            btn_changePassword.Size = new Size(200, 23);
            btn_changePassword.TabIndex = 0;
            btn_changePassword.Text = "Submit";
            btn_changePassword.UseVisualStyleBackColor = false;
            btn_changePassword.Click += btn_changePassword_Click;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(40, 95);
            label6.Name = "label6";
            label6.Size = new Size(195, 16);
            label6.TabIndex = 21;
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_newPassword
            // 
            txt_newPassword.BorderStyle = BorderStyle.None;
            txt_newPassword.Location = new Point(40, 76);
            txt_newPassword.Margin = new Padding(3, 3, 25, 3);
            txt_newPassword.Name = "txt_newPassword";
            txt_newPassword.Size = new Size(200, 16);
            txt_newPassword.TabIndex = 0;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            ClientSize = new Size(384, 461);
            Controls.Add(pnl_changePass);
            Controls.Add(btn_back);
            Controls.Add(pnl_otp);
            Controls.Add(label7);
            Name = "ForgotPassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ForgotPassword";
            pnl_otp.ResumeLayout(false);
            pnl_otp.PerformLayout();
            pnl_changePass.ResumeLayout(false);
            pnl_changePass.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_otp;
        private Button btn_submit;
        private Label label7;
        private Label label3;
        private TextBox txt_otp;
        private Label lbl_message_email;
        private TextBox txt_email;
        private Label label1;
        private Button btn_send_otp;
        private Label lbl_otp_message;
        private Button btn_back;
        private Panel pnl_changePass;
        private Label lbl_confPass;
        private Label lbl_newPassword;
        private Label label5;
        private TextBox txt_confirmPassword;
        private Button btn_changePassword;
        private Label label6;
        private TextBox txt_newPassword;
    }
}