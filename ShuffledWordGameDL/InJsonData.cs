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
        public List<AdminData> admin = new List<AdminData>();
        string filePath = "account.json";
        string adminFilePath = "admin.json";
        string leaderboardsFilePath = "leaderboards.json";

        public InJsonData()
        {
            GetDataFromFile();

            GetAdminDataFromFile();
        }
        private void GetDataFromFile()
        {
            string jsonText = File.ReadAllText(filePath);
            account = JsonSerializer.Deserialize<List<GameAccounts>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            FindPlayerHighScore();
        }
        private void GetAdminDataFromFile()
        {
            string jsonText = File.ReadAllText(adminFilePath);
            admin = JsonSerializer.Deserialize<List<AdminData>>(jsonText,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
            admin[0].ShuffledWord.Clear();
            for (int i = 0; i < admin[0].ArrangedWord.Count; i++)
            {
                Shuffle(admin[0].ArrangedWord[i]);
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
            SaveDataToFile("ADMIN");
        }
        public List<GameAccounts> GetPlayerAccounts()
        {
            return account;
        }
        public void AddScoreList(string username, int score, int error)
        {
            int index = FindAccountIndex(username);
            account[index].Score.Add(score);
            account[index].History.Add("Score : " + score + " | Error : " + error + "\n");
            SaveDataToFile("PLAYER");
            FindPlayerHighScore();
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
                            SaveDataToFile("LEADERBOARDS");
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
                    SaveDataToFile("LEADERBOARDS");
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
            else if(saveTo == "LEADERBOARDS")
            {
                string json = JsonSerializer.Serialize(leaderboards, new JsonSerializerOptions
                { WriteIndented = true });
                File.WriteAllText(leaderboardsFilePath, json);
            }
        }
        public List<string> DisplayWord()
        {
            return admin[0].ArrangedWord;
        }
        public int TotalWords()
        {
            return admin[0].ArrangedWord.Count;
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
    }
}

