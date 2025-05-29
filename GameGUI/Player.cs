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

namespace GameGUI
{
    public partial class frm_player : Form
    {
        ShuffledWordGameBL.GameBL BusinessLogic = new ShuffledWordGameBL.GameBL();
        private string pangalan = "";
        public frm_player(string name)
        {
            InitializeComponent();
            pangalan = name;
            lbl_name.Text = name;
            HideAllPanels();
        }
        void HideAllPanels()
        {
            pnl_changePass.Hide();
            pnl_history.Hide();
            pnl_mechanics.Hide();
        }
        private void btn_play_Click(object sender, EventArgs e)
        {
            frm_game game = new frm_game(pangalan);
            game.Show();
            this.Hide();
        }

        private void btn_history_Click(object sender, EventArgs e)
        {
            string user = BusinessLogic.GetPlayerUsername(pangalan);

            lbl_score_error.Text = BusinessLogic.ShowPlayerHistory(user);
            pnl_history.Show();

        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            frm_welcome welcome = new frm_welcome();
            welcome.Show();
            this.Close();
        }

        private void btn_play_MouseHover(object sender, EventArgs e)
        {
            btn_play.BackgroundImage = Properties.Resources.btn_play_hover;
        }

        private void btn_play_MouseLeave(object sender, EventArgs e)
        {
            btn_play.BackgroundImage = Properties.Resources.btn_play_normal;
        }

        private void lbl_exit_MouseHover(object sender, EventArgs e)
        {
            btn_exit.BackgroundImage = Properties.Resources.btn_home_hover;
        }

        private void lbl_exit_MouseLeave(object sender, EventArgs e)
        {
            btn_exit.BackgroundImage = Properties.Resources.btn_home_normal;
        }

        private void btn_settings_MouseHover(object sender, EventArgs e)
        {
            btn_settings.BackgroundImage = Properties.Resources.btn_settings_hover;
        }

        private void btn_settings_MouseLeave(object sender, EventArgs e)
        {
            btn_settings.BackgroundImage = Properties.Resources.btn_settings_normal;
        }

        private void btn_history_MouseHover(object sender, EventArgs e)
        {
            btn_history.BackgroundImage = Properties.Resources.btn_history_hover;
        }

        private void btn_history_MouseLeave(object sender, EventArgs e)
        {
            btn_history.BackgroundImage = Properties.Resources.btn_history_normal;
        }

        private void btn_mechanics_MouseHover(object sender, EventArgs e)
        {
            btn_mechanics.BackgroundImage = Properties.Resources.btn_mechanics_hover;
        }

        private void btn_mechanics_MouseLeave(object sender, EventArgs e)
        {
            btn_mechanics.BackgroundImage = Properties.Resources.btn_mechanics_normal;
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            pnl_changePass.Show();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            pnl_mechanics.Hide();
        }

        private void btn_mechanics_Click(object sender, EventArgs e)
        {
            pnl_mechanics.Show();
        }

        private void btn_history_back_Click(object sender, EventArgs e)
        {
            pnl_history.Hide();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            pnl_changePass.Hide();
        }
        private void btn_change_Click(object sender, EventArgs e)
        {
            string currentPass = txt_current.Text.Trim();
            string newPass = txt_new.Text.Trim();
            if (newPass.Length > 7)
            {
                string user = BusinessLogic.GetPlayerUsername(pangalan);
                if (BusinessLogic.ChangePassword(user, currentPass, newPass))
                {
                    MessageBox.Show("Password Changed Successfully");
                    pnl_changePass.Hide();
                    txt_current.Text = "";
                    txt_new.Text = "";
                }
                else
                {
                    MessageBox.Show("Current Password is Incorrect");
                }
            }
            else
            {
                MessageBox.Show("Password must be at least 8 characters long.");
            }
        }
    }
}
