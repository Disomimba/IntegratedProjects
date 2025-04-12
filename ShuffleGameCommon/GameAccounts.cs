using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffledWordGameCommon
{
    public class GameAccounts
    {
        private string username;
        private string password;
        public string Username
        {
            get { return username; }
            set
            {
                if (value.Length >= 4)
                {
                    username = value;
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length >= 8 )
                {
                    password = value;
                }
            }
        }
        public string Name { get; set; }
        public List<int> Score { get; set; }
        public List<string> History { get; set; }
        public GameAccounts()
        {
            History = new List<string>();
            Score = new List<int>();
        }
    }
}
