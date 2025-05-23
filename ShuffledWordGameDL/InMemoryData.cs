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
        public List<GameAccounts> Accounts()
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
                int existingScore = 0;

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
        public string DisplayLeaderboard()
        {
            string username_scores = string.Empty;

            foreach (var displayLeaderboards in leaderboards)
            {
                username_scores += $"{displayLeaderboards.Username}\t{displayLeaderboards.Score}\n";
            }

            return username_scores;
        }
        public string DisplayPlayerHistory(string username)
        {
            foreach (var accounts in account)
            {
                if (accounts.Username == username)
                {
                    string playerHistory = "";
                    for (int i = 0; i <= accounts.History.Count - 1; i++)
                    {
                        playerHistory += accounts.History[i];
                    }
                    return playerHistory;

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
            account.Clear();
        }
    }
}
