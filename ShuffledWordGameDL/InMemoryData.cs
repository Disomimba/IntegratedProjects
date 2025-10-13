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
                Password = "admin123",
                Email = "admin123@admin.com"
            });
            account.Add(new GameAccounts
            {
                Name = "Abdul Malik",
                Username = "ABDUL",
                Email = "abdul@gmail.com",
                Password = "abdul123"
            });
            account.Add(new GameAccounts
            {
                Name = "Shork",
                Username = "SHORK",
                Email = "shork@gmail.com",
                Password = "shork123"
            });
            string[] defaultWords = { "CASH", "EAGLE", "BRIGHT", "BOUGHT", "SARCASM" };
            foreach (var word in defaultWords)
            {
                admin[0].ArrangedWord.Add(word);            }
        }
        public List<GameAccounts> GetPlayerAccounts()
        {
            return account;
        }
        public void CreateAccount(string name, string email, string username, string password)
        {
            account.Add(new GameAccounts
            {
                Name = name,
                Username = username,
                Password = password,
                Email = email
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
                    
                }
            }
        }
        public void AddToLeaderboard(Leaderboards accountData)
        {
            leaderboards.Add(accountData);
        }
        public List<Leaderboards> GetLeaderboardAccounts()
        {
            return leaderboards;
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
                return true;
            }
            return false;
        }
        public bool InsertShuffledWord(string shuffledWord)
        {
            if (!admin[0].ShuffledWord.Contains(shuffledWord))
            {
                admin[0].ShuffledWord.Add(shuffledWord);
                return true;
            }
            return false;
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

        public bool ForgotPassword(string newPassword, string email)
        {
            foreach(var accounts in account)
            {
                if(accounts.Email == email)
                {
                    accounts.Password = newPassword;
                    return true;
                }
            }
            return false;
        }
    }
}
