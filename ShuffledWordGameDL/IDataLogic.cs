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
        public List<GameAccounts> Accounts();
        public void CreateAccount(string name, string username, string password); 
        public void AddScoreList(string username, int score, int error);
        public bool ChangePassword(string username, string old_password, string new_password);
        public string DisplayLeaderboard();
        public string DisplayPlayerHistory(string username);
        public string GetPlayerName(string username);
        public string GetPlayerUsername(string name);
        public void ClearLeaderboard();
    }
}
