using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShuffledWordGameBL;
using ShuffledWordGameCommon;

namespace ShuffleWordGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        static GameBL BusinessProcess = new GameBL();
        [HttpGet("Get Words")]
        public IEnumerable<string> GetWords()
        {
            return BusinessProcess.ShowWord();
        }
        [HttpPost("Add Word")]
        public bool AddWord(string newWord)
        {
            return GameBL.AddShuffledWords(newWord);
        }
        [HttpDelete("Remove Word")]
        public bool RemoveWord(int index)
        {
            return BusinessProcess.RemoveWords(index);
        }
        [HttpGet("Get Admin Data")]
        public IEnumerable<AdminData> GetAdminData()
        {
            return BusinessProcess.GetAdminAccounts();
        }
        [HttpGet("Change Password")]
        public bool AdminChangePass(string old_pass, string new_pass)
        {
            return BusinessProcess.ChangeAdminPassword(old_pass, new_pass);
        }
    }
}
