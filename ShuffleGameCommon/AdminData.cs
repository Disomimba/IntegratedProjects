using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShuffledWordGameCommon
{
    public class AdminData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> ShuffledWord { get; set; } = new List<string>();
        public List<string> ArrangedWord { get; set; } = new List<string>();

    }
}
