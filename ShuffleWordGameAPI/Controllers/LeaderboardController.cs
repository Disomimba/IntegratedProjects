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
        private readonly ShuffledWordGameBL.GameBL _BusinessProcess;

        public LeaderboardController(ShuffledWordGameBL.GameBL gameService)
        {
            _BusinessProcess = gameService;
        }
        [HttpGet("Get Leaderboards")]
        public List<Leaderboards> GetLeaderboards()
        {
            return _BusinessProcess.GetLeaderboardAccounts();
        }
        [HttpDelete("End Season")]
        public void RemoveLeaderboardEntry()
        {
            _BusinessProcess.ClearLeaderboard();
        }
    }
}
