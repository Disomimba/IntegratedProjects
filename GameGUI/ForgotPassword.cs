using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameGUI
{
    public partial class ForgotPassword : Form
    {

        ShuffledWordGameBL.GameBL BusinessLogic = new ShuffledWordGameBL.GameBL();
        string userEmail;
        public ForgotPassword()
        {
            InitializeComponent();
            pnl_changePass.Hide();
        }


        private void btn_send_otp_Click(object sender, EventArgs e)
        {
            userEmail = txt_email.Text;
            string username = BusinessLogic.VerifyAccountExistingEmail(userEmail);
            if (BusinessLogic.VerifyAccountExisting(username))
            {
                if (BusinessLogic.OTPSender(userEmail))
                {
                    lbl_message_email.Text = "OTP Has been sent to your email.";
                }
                else
                {
                    lbl_message_email.Text = "Email doesn't exist.";
                }

            }
        }
        private void btn_changePassword_Click(object sender, EventArgs e)
        {
            string newPassword = txt_newPassword.Text;
            string confPassword = txt_confirmPassword.Text;
            if (newPassword.IsNullOrEmpty() || confPassword.IsNullOrEmpty())
            {
                lbl_confPass.Text = "Please fill all the fields.";
            }
            else if (newPassword.Length < 8)
            {
                lbl_confPass.Text = "Password must be 8 characters.";
            }
            else if (newPassword != confPassword)
            {
                lbl_confPass.Text = "Please fill all the fields.";
            }
            else if (BusinessLogic.ForgotPassword(newPassword, userEmail))
            {
                MessageBox.Show("Password Changed!.");
                frm_welcome welcome = new frm_welcome();
                welcome.Show();
                this.Hide();
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            int otp = Convert.ToInt32(txt_otp.Text);
            if (txt_otp.Text.IsNullOrEmpty() && txt_email.Text.IsNullOrEmpty())
            {
                lbl_otp_message.Text = "OTP and Email must not empty.";
            }
            else if (txt_email.Text.IsNullOrEmpty())
            {
                lbl_otp_message.Text = "Email must not empty.";
            }
            else if (txt_otp.Text.IsNullOrEmpty())
            {
                lbl_otp_message.Text = "OTP must not empty.";
            }
            else if (BusinessLogic.OTPVerifier(otp))
            {
                pnl_otp.Hide();
                pnl_changePass.Show();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            frm_welcome welcome = new frm_welcome();
            welcome.Show();
            this.Close();
        }
    }
}
