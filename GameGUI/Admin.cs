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
        public frm_admin(string pin)
        {
            InitializeComponent();
            pass = pin;
        }

        private void btn_words_Click(object sender, EventArgs e)
        {
            frm_words words = new frm_words();
            words.Show();
            this.Hide();
        }
    }
}
