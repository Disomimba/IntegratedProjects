using ShuffledWordGameCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShuffledWordGameDL
{
    public class InJsonData : IDataLogic
    {
        public List<GameAccounts> account = new List<GameAccounts>();
        public List<Leaderboards> leaderboards = new List<Leaderboards>();
        string filePath = "account.json";

        public InJsonData()
        {
            
            GetDataFromFile();
        }

        private void GetDataFromFile()
        {
            string jsonText = File.ReadAllText(filePath);

            account = JsonSerializer.Deserialize<List<GameAccounts>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            FindPlayerHighScore();
        }

        public List<GameAccounts> Accounts()
        {
            return account;
        }

        public void AddScoreList(string username, int score, int error)
        {
            int index = FindAccountIndex(username);
                account[index].Score.Add(score);
                account[index].History.Add("Score : " + score + " | Error : " + error + "\n");
                SaveDataToFile();
                FindPlayerHighScore();
            
        }

        public bool ChangePassword(string username, string old_password, string new_password)
        {
            int index = FindAccountIndex(username);
            if(index != -1)
            {
                if (account[index].Password == old_password)
                {
                    account[index].Password = new_password;
                    SaveDataToFile();
                    return true;
                }
            }
           return false;
        }

        public void ClearLeaderboard()
        {
            leaderboards.Clear();
        }

        public int FindAccountIndex(string username)
        {
            for (int i = 0; i < account.Count; i++)
            {
                if (account[i].Username == username)
                {
                    return i;
                }
            }
            return -1;
        }

        public void CreateAccount(string name, string username, string password)
        {
            account.Add(new GameAccounts
            {
                Name = name,
                Username = username,
                Password = password
            });
            SaveDataToFile();
            
        }

        public void FindPlayerHighScore()
        {
            foreach (var accounts in account)
            {
                string username = accounts.Username;
                if (accounts.Score.Any())
                {
                    int playerHighScore = accounts.Score.Max();
                    TopPlayers(username, playerHighScore);
                }


            }
        }

        public void TopPlayers(string username, int score)
        {
            if (score > 0)
            {
                bool playerExists = false;
                for (int i = 0; i < leaderboards.Count; i++)
                {
                    if (leaderboards[i].Username == username)
                    {
                        playerExists = true;
                        if (score > leaderboards[i].Score)
                        {
                            leaderboards[i].Score = score;
                        }
                        break;
                    }
                }

                if (!playerExists)
                {
                    Leaderboards newEntry = new Leaderboards();
                    newEntry.Username = username;
                    newEntry.Score = score;
                    leaderboards.Add(newEntry);
                }
                BubbleSort(leaderboards.Count);
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
        private void SaveDataToFile()
        {
            string json = JsonSerializer.Serialize(account, new JsonSerializerOptions
            { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}

