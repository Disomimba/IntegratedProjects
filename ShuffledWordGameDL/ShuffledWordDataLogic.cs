using System;
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
        public List<GameAccounts> Accounts = new List<GameAccounts>();
        IDataLogic interfaceDataLogic;
        public ShuffledWordDataLogic()
        {
            //interfaceDataLogic = new InMemoryData();
            //interfaceDataLogic = new InJsonData();
            //interfaceDataLogic = new InTextData();
            interfaceDataLogic = new InDataBase();
        }
        public void AddToLeaderboard(Leaderboards accountData)
        {
            interfaceDataLogic.AddToLeaderboard(accountData);
        }
        public bool InsertNewWord(string arrangedWord)
        {
           return interfaceDataLogic.InsertNewWords(arrangedWord);
        }
        public bool InsertShuffledWord(string shuffledWord)
        {
            return interfaceDataLogic.InsertShuffledWord(shuffledWord);
        }
        public bool RemoveWord(int index)
        {
            return interfaceDataLogic.RemoveWord(index);
        }
        public List<GameAccounts> GetPlayerAccounts()
        {
            return interfaceDataLogic.GetPlayerAccounts();
        }
        public List<AdminData> GetAdminAccounts()
        {
            return interfaceDataLogic.GetAdminAccounts();
        }
        public bool ChangePassword(string username, string old_password, string new_password)
        {
            return interfaceDataLogic.ChangePassword(username, old_password, new_password);
        }
        public bool ChangeAdminPassword(string old_password, string new_password)
        {
            return interfaceDataLogic.ChangeAdminPassword(old_password, new_password);
        }
        public void CreateAccount(string name, string username, string password)
        {
            interfaceDataLogic.CreateAccount(name, username, password);
        }
        public void AddScoreList(string username, int score, int error)
        {
            interfaceDataLogic.AddScoreList(username, score, error);
        }
        public List<Leaderboards> GetLeaderboardAccounts()
        {
            return interfaceDataLogic.GetLeaderboardAccounts();
        }
        public void ClearLeaderboard()
        {
            interfaceDataLogic.ClearLeaderboard();
        }
    }
}
