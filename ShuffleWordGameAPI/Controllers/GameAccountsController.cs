using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShuffledWordGameCommon;
using ShuffledWordGameBL;
namespace ShuffleWordGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameAccountsController : ControllerBase
    {
        static GameBL BusinessProcess = new GameBL();
        [HttpGet()]
        public IEnumerable<GameAccounts> GetGameAccounts()
        {
            return BusinessProcess.GetAccounts();
        }
        [HttpPost("Add Player")]
        public bool AddPlayer(string name, string username, string password)
        {
            return BusinessProcess.CreateAccount(name, username, password);
        }

        [HttpPatch("Change Player Password")]
        public bool ChangePassword(string username, string old_pass, string new_pass)
        {
            return BusinessProcess.ChangePassword(username, old_pass, new_pass);
        }
        [HttpPatch("Update Player History")]
        public void UpdatePlayerHistory(string name)
        {
            BusinessProcess.UpdatePlayerHistory(name);
        }
        [HttpGet("Show Player History")]
        public List<string> ShowPlayerHistory(string user)
        {
            return BusinessProcess.ShowPlayerHistory(user);
        }
    }
}
