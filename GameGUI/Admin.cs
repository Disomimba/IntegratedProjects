using ShuffledWordGameBL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGUI
{
    public partial class frm_admin : Form
    {
        string pass;
        ShuffledWordGameBL.GameBL BusinessLogic = new ShuffledWordGameBL.GameBL();
        public frm_admin(string pin)
        {
            InitializeComponent();
            pass = pin;
            pnl_changePass.Hide();
        }

        private void btn_words_Click(object sender, EventArgs e)
        {
            frm_words words = new frm_words(pass);
            words.Show();
            this.Hide();
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            frm_welcome welcome = new frm_welcome();
            welcome.Show();
            this.Hide();
        }

        private void btn_leaderboards_Click(object sender, EventArgs e)
        {
            BusinessLogic.ClearLeaderboard();
        }

        private void btn_changePass_Click(object sender, EventArgs e)
        {
            pnl_changePass.Show();

        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            string currentPass = txt_current.Text.Trim();
            string newPass = txt_new.Text.Trim();
            if(newPass.Length > 7)
            {
                if (BusinessLogic.ChangeAdminPassword(currentPass, newPass))
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

        private void btn_cancel_CLick(object sender, EventArgs e)
        {
            pnl_changePass.Hide();
            txt_current.Text = "";
            txt_new.Text = "";
        }
    }
}
