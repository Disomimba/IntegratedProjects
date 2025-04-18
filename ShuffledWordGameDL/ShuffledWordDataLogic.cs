﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ShuffledWordGameCommon;
using static System.Formats.Asn1.AsnWriter;

namespace ShuffledWordGameDL
{
    public class ShuffledWordDataLogic
    {
        static List<Leaderboards> playerLeaderboards= new List<Leaderboards>();
        static List<GameAccounts> Accounts = new List<GameAccounts>();
        static ShuffledWordDataLogic()
        {
            Accounts.Add(new GameAccounts
            {
                Name = "Abdul Malik",
                Username = "SHORK",
                Password = "shork123"
            });
        }
        bool VerifyAccountExist(string username)
        {
            foreach (var account in Accounts)
            {
                if (account.Username.Contains(username))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CreateAccount(string name, string username, string password)
        {
            if (!VerifyAccountExist(username) && username.Length >= 4 && password.Length >= 8)
            {
                Accounts.Add(new GameAccounts
                {
                    Name = name,
                    Username = username,
                    Password = password
                });
                return true;
            }
            return false;
        }
        public bool VerifyAccount(string user, string pass)
        {
            foreach (var account in Accounts)
            {
                if (account.Username == user && account.Password == pass)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            foreach (var account in Accounts)
            {
                if (account.Username == username)
                {
                    if (account.Password == oldPassword)
                    {
                        account.Password = newPassword;
                        return true;
                    }
                }
            }

            return false;
        }
        public bool VerifyAdminAccount(string user, string pass)
        {
            if (user == "ADMIN" && pass == "admin123")
            {
                return true;
            }
            return false;
        }
        public string GetPlayerName(string user)
        {
            foreach (var account in Accounts)
            {
                if (account.Username == user)
                {
                    return account.Name;
                }
            }
            return null;
        }
        public string GetUsername(string name)
        {
            foreach (var account in Accounts)
            {
                if (account.Name == name)
                {
                    return account.Username;
                }
               
            }
            return null;
        }
        public  void GameHistoryAdd(string username, string score, int lives)
        {
            foreach (var account in Accounts)
            {
                if (account.Username == username)
                {
                    account.History.Add($"Score : {score} | Error : {lives}\n");
                    FindPlayerHighScore(username);
                }
            }
        }
        public  int FindPlayerHighScore(string username)
        {
            int playerHighScore = 0;
            foreach (var account in Accounts)
            {
                if (account.Username == username)
                {

                    playerHighScore = account.Score.Max();
                    HighScores(username, playerHighScore); 
                    return playerHighScore;
                }
            }
            return playerHighScore;
        }
        public void HighScores(string username, int score)
        {
            if (score > 0)
            {
                bool playerExists = false;
                int existingScore = 0;

                foreach (var leaderboard in playerLeaderboards)
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
                    playerLeaderboards.Add(new Leaderboards
                    {
                        Score = score,
                        Username = username
                    });
                }
                BubbleSort(playerLeaderboards.Count());
                

            }
        }
        static void BubbleSort(int size)
        {
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (playerLeaderboards[j].Score < playerLeaderboards[j + 1].Score)
                    {
                        var temp = playerLeaderboards[j];
                        playerLeaderboards[j] = playerLeaderboards[j + 1];
                        playerLeaderboards[j + 1] = temp;
                    }
                }
            }
        }
        public string DisplayLeaderboard()
        {
            string username_scores = string.Empty;

            foreach (var displayLeaderboards in playerLeaderboards)
            {
                username_scores += $"{displayLeaderboards.Username}\t{displayLeaderboards.Score}\n";
            }

            return username_scores;
        }
        public string PlayerHistory(string username)
        {
            foreach (var account in Accounts)
            {
                if (account.Username == username)
                {
                    string playerHistory = "";
                    for (int i = 0; i <= account.History.Count - 1; i++)
                    {
                        playerHistory += account.History[i];
                    }
                    return playerHistory;

                }
            }
            return "NOTHING";
        }
        public void Score(string username, int score)
        {
            foreach (var account in Accounts)
            {
                if (account.Username == username)
                {
                    account.Score.Add(score);
                    account.Score.Sort();
                    account.Score.Reverse();
                }
            }
        }
        public void ClearLeaderboards()
        {
            playerLeaderboards.Clear();
        }
    }
}
