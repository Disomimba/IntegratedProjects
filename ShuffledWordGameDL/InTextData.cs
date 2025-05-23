using ShuffledWordGameCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace ShuffledWordGameDL
{
    public class InTextData : IDataLogic
    {
        public List<GameAccounts> account = new List<GameAccounts>();
        public List<Leaderboards> leaderboards = new List<Leaderboards>();
        string filePath = "account.txt";
        public InTextData()
        {
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
            FindPlayerHighScore();
        }
        public List<GameAccounts> Accounts()
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
            FindPlayerHighScore();
        }
        public bool ChangePassword(string username, string old_password, string new_password)
        {
            throw new NotImplementedException();
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
            var newAccount = $"{name}|{username}|{password}\n";
            File.AppendAllText(filePath, newAccount);
            GetDataFromFile();

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
    }
}
