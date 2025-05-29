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
using System.Xml.Linq;

namespace GameGUI
{

    public partial class frm_game : Form
    {
        static ShuffledWordGameBL.GameBL BusinessLogic = new ShuffledWordGameBL.GameBL();
        private string pangalan;

        public frm_game(string name)
        {

            InitializeComponent();
            pangalan = name;
            GameBL.Reset();
            GameBL.RandomizerQuestion();
            lbl_shuffledWord.Text = GameBL.QuestionsList();
            txt_answer.Text = "";
            txt_answer.Clear();

        }

        int currentQuestionIndex = 0;
        private async void btn_submit_Click(object sender, EventArgs e)
        {
            if (currentQuestionIndex < GameBL.TotalWords() && GameBL.Lives() > 0)
            {
                string answer = txt_answer.Text.Trim().ToUpper();

                if (answer == GameBL.AnswersList())
                {   
                    txt_answer.Text = "Correct!";
                    txt_answer.ForeColor = Color.Green;
                    await Task.Delay(3000);
                    txt_answer.ForeColor = Color.Black;
                    txt_answer.Text = "";
                    txt_answer.Clear();
                    GameBL.Correct();
                }
                else
                {
                    txt_answer.Text = "Incorect!";
                    txt_answer.ForeColor = Color.Red;
                    await Task.Delay(3000);
                    txt_answer.ForeColor = Color.Black;
                    txt_answer.Text = "";
                    GameBL.Incorrect();
                    UpdateLivesDisplay();
                }
                
                currentQuestionIndex++;
                if (currentQuestionIndex < GameBL.TotalWords() && GameBL.Lives() > 0)
                {
                    GameBL.RandomizerQuestion();
                    lbl_shuffledWord.Text = GameBL.QuestionsList();
                    txt_answer.Clear();
                }
                else
                {
                    lbl_lives.Text = "💔 💔 💔";
                    txt_answer.Text = "Game Over!";
                    txt_answer.Clear();
                    DisplayFinalScore(pangalan);
                    frm_player player = new frm_player(pangalan);
                    player.Show();
                    this.Close();
                }
                
                
                
            }
        }

        private void UpdateLivesDisplay()
        {
            if (GameBL.Lives() == 2)
            {
                lbl_lives.Text = "❤ ❤ 💔";
            }
            else if (GameBL.Lives() == 1)
            {
                lbl_lives.Text = "❤ 💔 💔";
            }
            
        }
        static void DisplayFinalScore(string name)
        {
            MessageBox.Show($"Your Score is: {GameBL.ShowScore()} out of {GameBL.TotalWords()}");
            BusinessLogic.UpdatePlayerHistory(name);
            
        }
    }
}
