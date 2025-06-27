using ShuffledWordGameCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShuffledWordGameDL
{
    public class InJsonData :  IDataLogic
    {
        public List<GameAccounts> account = new List<GameAccounts>();
        public List<Leaderboards> leaderboards = new List<Leaderboards>();
        public List<AdminData> admin = new List<AdminData>();
        string filePath = "account.json";
        string adminFilePath = "admin.json";
        string leaderboardsFilePath = "leaderboards.json";
        public InJsonData()
        {
            GetDataFromFile();
            GetLeaderboardsFromFile();
            GetAdminDataFromFile();
        }
        public List<Leaderboards> GetLeaderboardAccounts()
        {
            return leaderboards;
        }
        public List<GameAccounts> GetPlayerAccounts()
        {
            return account;
        }
        public List<AdminData> GetAdminAccounts()
        {
            return admin;
        }
        private void SaveDataToFile(string saveTo)
        {
            if (saveTo == "ADMIN")
            {
                string json = JsonSerializer.Serialize(admin, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(adminFilePath, json);
            }
            else if (saveTo == "PLAYER")
            {
                string json = JsonSerializer.Serialize(account, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            else if (saveTo == "LEADERBOARDS")
            {
                string json = JsonSerializer.Serialize(leaderboards, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(leaderboardsFilePath, json);
            }
        }
        private void GetDataFromFile()
        {
            string jsonText = File.ReadAllText(filePath);
            account = JsonSerializer.Deserialize<List<GameAccounts>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }
        private void GetAdminDataFromFile()
        {
            string jsonText = File.ReadAllText(adminFilePath);
            admin = JsonSerializer.Deserialize<List<AdminData>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            admin[0].ShuffledWord.Clear();
        }
        private void GetLeaderboardsFromFile()
        {
            string jsonText = File.ReadAllText(leaderboardsFilePath);
            leaderboards = JsonSerializer.Deserialize<List<Leaderboards>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }
        public void AddScoreList(string username, int score, int error)
        {
            int index = FindAccountIndex(username);
            account[index].Score.Add(score);
            account[index].History.Add("Score : " + score + " | Error : " + error + "\n");
            SaveDataToFile("PLAYER");
        }
        public bool ChangePassword(string username, string old_password, string new_password)
        {
            int index = FindAccountIndex(username);
            if (index != -1)
            {
                if (account[index].Password == old_password)
                {
                    account[index].Password = new_password;
                    SaveDataToFile("PLAYER");
                    return true;
                }
            }
            return false;
        }
        public void ClearLeaderboard()
        {
            leaderboards.Clear();
            foreach(var accounts in account)
            {
                accounts.Score.Clear();
                accounts.History.Clear();
            }
            SaveDataToFile("LEADERBOARDS");
            SaveDataToFile("PLAYER");
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
            SaveDataToFile("PLAYER");
        }
        public bool RemoveWord(int index)
        {
            string word = admin[0].ArrangedWord[index];
            if (admin[0].ArrangedWord.Contains(word))
            {
                admin[0].ArrangedWord.RemoveAt(index);
                admin[0].ShuffledWord.RemoveAt(index);
                SaveDataToFile("ADMIN");
                return true;
            }
            return false;
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
        public bool ChangeAdminPassword(string old_password, string new_password)
        {
            if (admin[0].Password == old_password)
            {
                admin[0].Password = new_password;
                SaveDataToFile("ADMIN");
                return true;
            }
            return false;
        }
        public bool InsertShuffledWord(string shuffledWord)
        {
            if (!admin[0].ShuffledWord.Contains(shuffledWord))
            {

                admin[0].ShuffledWord.Add(shuffledWord);
                SaveDataToFile("ADMIN");
                return true;
            }
            return false;
        }
        public void AddToLeaderboard(Leaderboards accountData)
        {
            bool playerExists = false;

            foreach (var leaderboard in leaderboards)
            {
                if (leaderboard.Username == accountData.Username)
                {
                    leaderboard.Score = accountData.Score; 
                    playerExists = true; 
                    break; 
                }
            }
            if (!playerExists)
            {
                leaderboards.Add(accountData);
            }

            SaveDataToFile("LEADERBOARDS");
        }
    }
}

