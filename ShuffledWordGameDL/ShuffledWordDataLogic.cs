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

            public List<GameAccounts> GetAccounts()
            {
                return interfaceDataLogic.Accounts();

            }
            public bool ChangePassword(string username, string old_password, string new_password)
            {
              return  interfaceDataLogic.ChangePassword(username, old_password, new_password); 
            }
            public void CreateAccount(string name, string username, string password)
            {
                interfaceDataLogic.CreateAccount(name, username, password);
            }
            public void AddScoreList(string username, int score, int error)
            {
                interfaceDataLogic.AddScoreList(username, score, error);
            }
            public string DisplayLeaderboard()
            {
                return interfaceDataLogic.DisplayLeaderboard();
            }
            public string DisplayPlayerHistory(string username)
            {
                return interfaceDataLogic.DisplayPlayerHistory(username);
            }
            public string GetPlayerName(string username)
            {
                return interfaceDataLogic.GetPlayerName(username);
            }
            public string GetPlayerUsername(string name)
            {
                return interfaceDataLogic.GetPlayerUsername(name);
            }
            public void ClearLeaderboard()
            {
                interfaceDataLogic.ClearLeaderboard();
            }
        }
    }
