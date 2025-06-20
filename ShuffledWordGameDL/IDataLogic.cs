using Microsoft.IdentityModel.Logging;
using ShuffledWordGameCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffledWordGameDL
{
    public interface IDataLogic
    {
        public List<GameAccounts> GetPlayerAccounts();
        public List<AdminData> GetAdminAccounts();
        public List<Leaderboards> GetLeaderboardAccounts();
        public bool InsertNewWords(string arrangedWord);
        public List<string> DisplayWord();
        public int TotalWords();
        public bool RemoveWord(int index);
        public string ShuffledWord(int index);
        public string ArrangedWord(int index);
        public void CreateAccount(string name, string username, string password); 
        public void AddScoreList(string username, int score, int error);
        public bool ChangePassword(string username, string old_password, string new_password);
        public bool ChangeAdminPassword(string old_password, string new_password);
        public List<string> DisplayPlayerHistory(string username);
        public string GetPlayerName(string username);
        public string GetPlayerUsername(string name);
        public void ClearLeaderboard();
    }
}
