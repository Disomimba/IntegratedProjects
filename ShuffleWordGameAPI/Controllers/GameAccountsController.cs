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
        public bool AddPlayer(string name, string email, string username, string password)
        {
            return BusinessProcess.CreateAccount(name, email, username, password);
        }
        [HttpPost("Forgot Password")] 
        public bool OTPSender(string userEmail)
        {
            if (BusinessProcess.OTPSender(userEmail)) 
            {
                return true; 
            }
            return false; 
        }
        [HttpPatch("Verify OTP")] 
        public bool VerifyOTP(string email, int otp, string newPassword)
        {
            if (BusinessProcess.OTPVerifier(otp)) 
            {
                BusinessProcess.ForgotPassword(newPassword, email);
                return true; 
            }
            return false; 
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
