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
        private readonly ShuffledWordGameBL.GameBL _BusinessProcess;

        public GameAccountsController(ShuffledWordGameBL.GameBL gameService)
        {
            _BusinessProcess = gameService;
        }
        [HttpGet()]
        public IEnumerable<GameAccounts> GetGameAccounts()
        {
            return _BusinessProcess.GetAccounts();
        }
        [HttpPost("Add Player")]
        public bool AddPlayer(string name, string email, string username, string password)
        {
            return _BusinessProcess.CreateAccount(name, email, username, password);
        }
        [HttpPost("Forgot Password")] 
        public bool OTPSender(string userEmail)
        {
            if (_BusinessProcess.OTPSender(userEmail)) 
            {
                return true; 
            }
            return false; 
        }
        [HttpPatch("Verify OTP")] 
        public bool VerifyOTP(string email, int otp, string newPassword)
        {
            if (_BusinessProcess.OTPVerifier(otp)) 
            {
                _BusinessProcess.ForgotPassword(newPassword, email);
                return true; 
            }
            return false; 
        }

        [HttpPatch("Change Player Password")]
        public bool ChangePassword(string username, string old_pass, string new_pass)
        {
            return _BusinessProcess.ChangePassword(username, old_pass, new_pass);
        }
        [HttpPatch("Update Player History")]
        public void UpdatePlayerHistory(string name)
        {
            _BusinessProcess.UpdatePlayerHistory(name);
        }
        [HttpGet("Show Player History")]
        public List<string> ShowPlayerHistory(string user)
        {
            return _BusinessProcess.ShowPlayerHistory(user);
        }
    }
}
