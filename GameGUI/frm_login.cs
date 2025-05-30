using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShuffledWordGameBL;
using ShuffledWordGameDL;
using ShuffledWordGameCommon;
namespace GameGUI
{
    public partial class frm_login : Form
    {
        ShuffledWordGameBL.GameBL BusinessLogic = new ShuffledWordGameBL.GameBL();
        public frm_login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text.Trim().ToUpper();
            string password = txt_password.Text.Trim();
            var resultPlayer = BusinessLogic.VerifyPlayerAccount(username, password);
            var resultAdmin = BusinessLogic.VerifyAdminAccount(username, password);
            if (resultPlayer)
            {
                string playerName = BusinessLogic.PlayerName(username);
                frm_player player = new frm_player(playerName);
                player.Show();
                this.Close();
            }
            if (resultAdmin)
            {
                string pin = txt_password.Text.Trim();
                frm_admin admin = new frm_admin(pin);
                admin.Show();
                this.Close();
            }
            else if (txt_password.Text == "" || txt_username.Text == "")
            {
                lbl_message.ForeColor = Color.Red;
                lbl_message.BackColor = Color.FromArgb(75, 255, 255, 255);
                lbl_message.Text = "Please fill the text.";

            }
            else
            {
                lbl_message.BackColor = Color.FromArgb(75, 255, 255, 255);
                lbl_message.ForeColor = Color.Red;
                lbl_message.Text = "Invalid Account.";
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            frm_welcome welcome = new frm_welcome();
            welcome.Show();
            this.Hide();
        }

        private void btn_back_MouseHover(object sender, EventArgs e)
        {
            btn_home.BackgroundImage = Properties.Resources.btn_home_hover;
        }

        private void btn_back_MouseLeave(object sender, EventArgs e)
        {
            btn_home.BackgroundImage = Properties.Resources.btn_home_normal;
        }
    }
}
