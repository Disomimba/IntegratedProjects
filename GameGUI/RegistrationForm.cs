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
    public partial class frm_registration : Form
    {
        ShuffledWordGameBL.GameBL BusinessLogic = new ShuffledWordGameBL.GameBL();
        public frm_registration()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text.Trim().ToUpper();
            string username = txt_username.Text.Trim().ToUpper();
            string password = txt_password.Text.Trim();
            string email = txt_email.Text.Trim();

            bool result = BusinessLogic.CreateAccount(name, email, username, password);
            if (result)
            {
                MessageBox.Show("Account created successfully!");
                frm_welcome welcome = new frm_welcome();
                welcome.Show();
                this.Hide();
            }
            
            else if (txt_password.Text == "" || txt_username.Text == "" || txt_name.Text == "")
            {
                MessageBox.Show("Please fill the text.");
            }
            else
            {

                MessageBox.Show("Failed to create account. \nUsername may already exist.\nUsername must greater than 3 Characters\nPassword must greater than 7 characters.");
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
