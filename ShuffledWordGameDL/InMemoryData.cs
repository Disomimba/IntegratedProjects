using Microsoft.Data.SqlClient;
using ShuffledWordGameCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffledWordGameDL
{
    public class InMemoryData : IDataLogic
    {
        public List<GameAccounts> account = new List<GameAccounts>();
        public List<Leaderboards> leaderboards = new List<Leaderboards>();
        public List<AdminData> admin = new List<AdminData>();
        public InMemoryData()
        {
            admin.Add(new AdminData
            {
                Username = "ADMIN",
                Password = "admin123"
            });
            string[] defaultWords = { "CASH", "EAGLE", "BRIGHT", "BOUGHT", "SARCASM" };
            foreach (var word in defaultWords)
            {
                admin[0].ArrangedWord.Add(word);
                Shuffle(word);
            }
        }
        public void Shuffle(string word)
        {
            char[] wordToChar = word.ToCharArray();
            List<char> lettersChar = new List<char>(wordToChar);
            Random numberRandom = new Random();
            string wordShuffled = "";

            while (0 < lettersChar.Count)
            {
                int randomIndex = numberRandom.Next(lettersChar.Count);
                wordShuffled += lettersChar[randomIndex];
                lettersChar.RemoveAt(randomIndex);
            }

            admin[0].ShuffledWord.Add(wordShuffled);

        }
        public List<GameAccounts> GetPlayerAccounts()
        {
            return account;
        }
        public void CreateAccount(string name, string username, string password)
        {
            account.Add(new GameAccounts
            {
                Name = name,
                Username = username,
                Password = password
            });
        }
        public bool ChangePassword(string username, string old_password, string new_password)
        {
            foreach (var accounts in account)
            {
                if (accounts.Username == username)
                {
                    if (accounts.Password == old_password)
                    {
                        accounts.Password = new_password;
                        return true;

                    }
                }
            }

            return false;
        }
        public void AddScoreList(string username, int score, int error)
        {
            foreach (var accounts in account)
            {
                if (accounts.Username == username)
                {
                    accounts.Score.Add(score);
                    accounts.Score.Sort();
                    accounts.Score.Reverse();
                    accounts.History.Add($"Score : {score} | Error : {error}\n");
                    FindPlayerHighScore(username);
                }
            }
        }
        public void FindPlayerHighScore(string username)
        {
            int playerHighScore = 0;
            foreach (var accounts in account)
            {
                if (accounts.Username == username)
                {

                    playerHighScore = accounts.Score.Max();
                    TopPlayers(username, playerHighScore);
                }
            }
        }
        public void TopPlayers(string username, int score)
        {
            if (score > 0)
            {
                bool playerExists = false;

                foreach (var leaderboard in leaderboards)
                {
                    if (leaderboard.Username == username)
                    {
                        playerExists = true;
                        if (score > leaderboard.Score)
                        {
                            leaderboard.Score = score;
                        }
                        break;
                    }
                }

                if (!playerExists)
                {
                    leaderboards.Add(new Leaderboards
                    {
                        Score = score,
                        Username = username
                    });
                }
                BubbleSort(leaderboards.Count());
            }

        }
        public void BubbleSort(int size)
        {
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (leaderboards[j].Score < leaderboards[j + 1].Score)
                    {
                        var temp = leaderboards[j];
                        leaderboards[j] = leaderboards[j + 1];
                        leaderboards[j + 1] = temp;
                    }
                }
            }
        }
        public List<Leaderboards> GetLeaderboardAccounts()
        {
            return leaderboards;
        }
        public List<string> DisplayPlayerHistory(string username)
        {
            foreach (var accounts in account)
            {
                if (accounts.Username == username)
                {
                    return accounts.History;
                }
            }
            return null;
        }
        public string GetPlayerName(string username)
        {

            foreach (var accounts in account)
            {
                if (accounts.Username == username)
                {
                    return accounts.Name;
                }
            }
            return null;

        }
        public string GetPlayerUsername(string name)
        {

            foreach (var accounts in account)
            {
                if (accounts.Name == name)
                {
                    return accounts.Username;
                }
            }
            return null;

        }
        public void ClearLeaderboard()
        {
            leaderboards.Clear();
            foreach (var accounts in account)
            {
                accounts.Score.Clear();
                accounts.History.Clear();
            }
        }
        public bool InsertNewWords(string arrangedWord)
        {
            if (!admin[0].ArrangedWord.Contains(arrangedWord))
            {
                admin[0].ArrangedWord.Add(arrangedWord);
                Shuffle(arrangedWord);
                return true;
            }
            return false;
        }
        public List<string> DisplayWord()
        {
            return admin[0].ArrangedWord;
        }

        public int TotalWords()
        {
            return admin[0].ArrangedWord.Count();
        }

        public bool RemoveWord(int index)
        {
            string word = admin[0].ArrangedWord[index];

            if (admin[0].ArrangedWord.Contains(word))
            {
                admin[0].ArrangedWord.RemoveAt(index);
                admin[0].ShuffledWord.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ShuffledWord(int index)
        {
            return admin[0].ShuffledWord[index];
        }

        public string ArrangedWord(int index)
        {
            return admin[0].ArrangedWord[index];
        }
        public List<AdminData> GetAdminAccounts()
        {
            return admin;
        }
        public bool ChangeAdminPassword(string old_password, string new_password)
        {
            if (admin[0].Password == old_password)
            {
                admin[0].Password = new_password;
                return true;
            }

            return false;
        }
    }
}
