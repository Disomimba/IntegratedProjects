using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShuffledWordGameBL;
using ShuffledWordGameCommon;

namespace ShuffleWordGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderboardController : ControllerBase
    {
        static GameBL BusinessProcess = new GameBL();

        [HttpGet("Get Leaderboards")]
        public List<Leaderboards> GetLeaderboards()
        {
            return BusinessProcess.GetLeaderboardAccounts();
        }
        [HttpDelete("Clear Leaderboard")]
        public void RemoveLeaderboardEntry()
        {
             BusinessProcess.ClearLeaderboard();
        }
    }
}
