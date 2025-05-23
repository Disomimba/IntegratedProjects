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

    public partial class frm_words : Form
    {
        ShuffledWordGameBL.GameBL BusinessLogic = new ShuffledWordGameBL.GameBL();
        public frm_words()
        {
            InitializeComponent();
            ShowWords();
        }
        public void ShowWords()
        {
            listBox_words.Items.Clear();
            for (int i = 0; i < GameBL.TotalWords(); i++)
            {
                listBox_words.Items.Add(GameBL.ShowWord(i));
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            string word = txt_word.Text.Trim().ToUpper();
            if (word.Length > 0)
            {
                string ShuffledWord = GameBL.Shuffle(word);
                GameBL.AddShuffledWords(word, ShuffledWord);
                listBox_words.Items.Clear();
                ShowWords();
                txt_word.Text = "";
            }

            else
            {
                MessageBox.Show("Please fill the text.");
            }


        }

        private void listBox_words_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox_words.SelectedIndex;
            if (index >= 0 && index < GameBL.TotalWords())
            {
                txt_word.Text = GameBL.ShowWord(index);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (listBox_words.SelectedIndex != -1)
            {
                int index = listBox_words.SelectedIndex;
                BusinessLogic.RemoveWords(index);
                listBox_words.Items.Clear();
                ShowWords();
                txt_word.Text = "";
            }
            else
            {
                MessageBox.Show("Please select a word to remove.");
            }
        }
    }
}
