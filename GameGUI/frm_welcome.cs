using ShuffledWordGameBL;

namespace GameGUI
{

    public partial class frm_welcome : Form
    {
        ShuffledWordGameBL.GameBL BusinessLogic = new ShuffledWordGameBL.GameBL();
        public frm_welcome()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.Show();
            this.Hide();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            frm_registration register = new frm_registration();
            register.Show();
            this.Hide();
        }

        private void btn_leaderboards_Click(object sender, EventArgs e)
        {
            string leaderboardText = "LEADERBOARDS:\n\n";
            foreach (var leaderboards in BusinessLogic.GetLeaderboardAccounts())
            {
                 leaderboardText += $"{leaderboards.Username} | {leaderboards.Score}\n";
            }
            MessageBox.Show(leaderboardText, "Leaderboard", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
