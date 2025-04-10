using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffledWordGameCommon
{
    public class GameAccounts
    {
        public string Password { get; set; }
        public string Username { get; set; }
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
