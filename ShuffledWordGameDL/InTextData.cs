using ShuffledWordGameCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
using static System.Formats.Asn1.AsnWriter;

namespace ShuffledWordGameDL
{
    public class InTextData : IDataLogic
    {
        public List<GameAccounts> account = new List<GameAccounts>();
        public List<Leaderboards> leaderboards = new List<Leaderboards>();
        public List<AdminData> admin = new List<AdminData>();
        string filePath = "account.txt";
        string adminFilePath = "admin.txt";
        string leaderboardsFilePath = "leaderboards.txt";
        public InTextData()
        {

            GetAdminFromFile();
            GetDataFromFile();
        }
        private void GetDataFromFile()
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                var accountFromFile = new GameAccounts
                {
                    Name = parts[0],
                    Username = parts[1],
                    Password = parts[2],
                };

                if (parts.Length > 3)
                {
                    for (int j = 3; j < parts.Length; j += 2)
                    {
                        if (j + 1 < parts.Length)
                        {
                            accountFromFile.Score.Add(int.Parse(parts[j]));
                            accountFromFile.History.Add($"Score : {parts[j]} | Error : {parts[j + 1]}\n");

                        }
                    }
                }
                account.Add(accountFromFile);
            }
        }
        public void GetAdminFromFile()
        {
            var lines = File.ReadAllLines(adminFilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                var adminData = new AdminData
                {
                    Username = parts[0],
                    Password = parts[1],
                };
                for (int i = 2; i < parts.Length; i++)
                {
                    if (i + 1 < parts.Length)
                    {
                        adminData.ArrangedWord.Add(parts[i + 1]);
                    }
                }
                admin.Add(adminData);

            }
        }
        public void SaveLeaderboardToFile()
        {
            File.WriteAllText(leaderboardsFilePath, string.Empty);
            foreach (var leaderboard in leaderboards)
            {
                var newLeaderboard = $"{leaderboard.Username}|{leaderboard.Score}\n";
                File.AppendAllText(leaderboardsFilePath, newLeaderboard);
            }
        }
        public List<GameAccounts> GetPlayerAccounts()
        {
            return account;
        }
        public void AddScoreList(string username, int score, int error)
        {
            int index = FindAccountIndex(username);
            var lines = File.ReadAllLines(filePath);
            lines[index] = lines[index] + $"|{score}|{error}";
            File.WriteAllLines(filePath, lines);
            AddNewScores(index);

        }
        public void AddNewScores(int index)
        {
            var lines = File.ReadAllLines(filePath);
            var parts = lines[index].Split('|');
            int existingScoreCount = account[index].Score.Count;
            for (int i = 3 + existingScoreCount * 2; i < parts.Length; i += 2)
            {
                int score = int.Parse(parts[i]);
                int error = int.Parse(parts[i + 1]);
                account[index].Score.Add(score);
                account[index].History.Add($"Score : {score} | Error : {error}\n");
            }
        }
        public bool ChangePassword(string username, string old_password, string new_password)
        {
            int index = FindAccountIndex(username);
            var lines = File.ReadAllLines(filePath);
            var parts = lines[index].Split('|');
            for (int i = 0; i <= account.Count - 1; i++)
            {
                bool accInMemory = account[index].Username == username;
                bool accInFile = parts[1] == username;
                if (accInMemory && accInFile)
                {
                    if (parts[2] == old_password)
                    {
                        parts[2] = new_password;
                        lines[index] = string.Join("|", parts);
                        File.WriteAllLines(filePath, lines);
                        account[index].Password = new_password;
                        return true;
                    }
                }
            }


            return false;

        }
        public void ClearLeaderboard()
        {
            leaderboards.Clear();
            foreach (var accounts in account)
            {
                accounts.Score.Clear();
                accounts.History.Clear();
            }
            SaveLeaderboardToFile();
            UpdateAccountsInFile();
        }
        private void UpdateAccountsInFile()
        {
            File.WriteAllText(filePath, string.Empty);
            foreach (var account in this.account)
            {
                var newFile = $"{account.Name}|{account.Username}|{account.Password}\n";
                File.AppendAllText(filePath, newFile);
            }
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
            var newAccount = $"{name}|{username}|{password}\n";
            File.AppendAllText(filePath, newAccount);

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
        public List<AdminData> GetAdminAccounts()
        {
            return admin;
        }
        public List<string> DisplayWord()
        {
            return admin[0].ArrangedWord;
        }
        public int TotalWords()
        {
            return admin[0].ArrangedWord.Count();
        }
        public bool InsertNewWords(string arrangedWord)
        {
            if (!admin[0].ArrangedWord.Contains(arrangedWord))
            {
                admin[0].ArrangedWord.Add(arrangedWord);
                var adminData = new AdminData
                {
                    Username = admin[0].Username,
                    Password = admin[0].Password
                };
                var newWord = $"|{arrangedWord}";
                File.AppendAllText(adminFilePath, newWord);
                return true;
            }
            else
            {
                return false;
            }
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
        public bool ChangeAdminPassword(string old_password, string new_password)
        {
            var lines = File.ReadAllLines(adminFilePath);

            var parts = lines[0].Split('|');
            if (parts[1] == old_password)
            {
                parts[1] = new_password;
                lines[0] = string.Join("|", parts);
                admin[0].Password = new_password;
                File.WriteAllLines(adminFilePath, lines);
                return true;
            }

            return false;
        }
        public bool InsertShuffledWord(string shuffledWord)
        {
            if (!admin[0].ShuffledWord.Contains(shuffledWord))
            {
                admin[0].ShuffledWord.Add(shuffledWord);
                var adminData = new AdminData
                {
                    Username = admin[0].Username,
                    Password = admin[0].Password
                };
                var newWord = $"|{shuffledWord}";
                File.AppendAllText(adminFilePath, newWord);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddToLeaderboard(Leaderboards accountData)
        {
            leaderboards.Add(accountData);
            SaveLeaderboardToFile();
        }
    }
}
