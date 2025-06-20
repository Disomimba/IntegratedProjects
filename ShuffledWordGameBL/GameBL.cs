using ShuffledWordGameCommon;
using ShuffledWordGameDL;
using System.Security.Principal;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ShuffledWordGameBL
{
    public class GameBL
    {
        static int score = 0;
        static int lives = 3;
        static int questionShuffler;
        static ShuffledWordDataLogic DataLogic = new ShuffledWordDataLogic();


        static List<int> givenIndex = new List<int>();
        
        public bool RemoveWords(int index)
        {
            return DataLogic.RemoveWord(index);
        }
        public static int Correct()
        {
            score++;
            return score;
        }
        public static int ShowScore()
        {
            return score;
        }
        public static void Incorrect()
        {
            lives--;
        }
        public static int Lives()
        {
            return lives;
        }
        public static int TotalWords()
        {
            return DataLogic.TotalWords();
        }
        public static void Reset()
        {
            givenIndex.Clear();
            lives = 3;
            score = 0;
        }
        public static void RandomizerQuestion()
        {
            Random questionRandom = new Random();

            questionShuffler = questionRandom.Next(TotalWords());

            if (givenIndex.Contains(questionShuffler))
            {
                do
                {
                    questionShuffler = questionRandom.Next(TotalWords());
                }
                while (givenIndex.Contains(questionShuffler));
            }
            givenIndex.Add(questionShuffler);
        }
        public static string QuestionsList()
        {
            return DataLogic.ShuffledWord(questionShuffler);
        }
        public static string AnswersList()
        {
            return DataLogic.ArrangedWord(questionShuffler);
        }
        public static bool AddShuffledWords(string newAnswer)
        {
            return DataLogic.InsertNewWord(newAnswer);
        }
        public static List<string> ShowWord()
        {
            return DataLogic.DisplayWord();
        }
        public static bool MenuValidator(Actions userAction, int number)
        {
            bool result = false;
            if (userAction == Actions.Welcome && number >= 1 && number <= 5)
            {
                result = true;
            }
            if (userAction == Actions.Admin && number >= 1 && number <= 6)
            {
                result = true;
            }
            if (userAction == Actions.Player && number >= 1 && number <= 5)
            {
                result = true;
            }
            return result;
        }
        public static bool WelcomeMenuValidator(int userActions)
        {
            if (userActions >= 1 && userActions <= 4)
            {
                return true;
            }
            return false;
        }
        public string AccountVerifier(string Username, string Pass)
        {
            string Account = "Invalid";
            if (VerifyAdminAccount(Username, Pass))
            {
                return Account = "Admin";
            }
            else if (VerifyPlayerAccount(Username, Pass))
            {
                return Account = "Player";
            }

            return Account;
        }
        public bool VerifyPlayerAccount(string username, string password)
        {
            List<ShuffledWordGameCommon.GameAccounts> accounts = GetAccounts();
            bool result = false;
            foreach (var users in accounts)
            {
                if (users.Username == username && users.Password == password)
                {
                    result = true;
                }
            }
            return result;
        }
        public bool VerifyAdminAccount(string username, string password)
        {
            List<ShuffledWordGameCommon.AdminData> admin = GetAdminAccounts();
            bool result = false;
            foreach (var users in admin)
            {
                if (users.Username == username && users.Password == password)
                {
                    result = true;
                }
            }
            return result;
        }
        public string PlayerName(string Username)
        {
            return DataLogic.GetPlayerName(Username);
        }
        public List<string> ShowPlayerHistory(string user)
        {
            return DataLogic.DisplayPlayerHistory(user);
        }
        public List<Leaderboards> GetLeaderboardAccounts()
        {
            return DataLogic.GetLeaderboardAccounts();
        }
        public void ClearLeaderboard()
        {
            DataLogic.ClearLeaderboard();
        }
        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            return DataLogic.ChangePassword(username, oldPassword, newPassword);
        }
        public List<ShuffledWordGameCommon.GameAccounts> GetAccounts()
        {
            return DataLogic.GetPlayerAccounts();
        }
        public List<ShuffledWordGameCommon.AdminData> GetAdminAccounts()
        {
            return DataLogic.GetAdminAccounts();
        }

        public bool VerifyAccountExisting(string username)
        {
            
            List<ShuffledWordGameCommon.GameAccounts> accounts = GetAccounts();
            if (!username.Contains("ADMIN"))
            {

                foreach (var users in accounts)
                {
                    if (users.Username == username)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CreateAccount(string name, string username, string password)
        {
            if (!username.Contains("ADMIN"))
            {

                if (username.Length > 3 && password.Length > 7)
                {
                    if (!VerifyAccountExisting(username))
                    {
                        DataLogic.CreateAccount(name, username, password);
                        return true;
                    }
                }
            }
            return false;
        }
        public string GetAdminPassword()
        {
            foreach (var admin in DataLogic.GetAdminAccounts())
            {
                if (admin.Username == "ADMIN")
                {
                    return admin.Password;
                }
            }
            return null;
        }
        public bool ChangeAdminPassword(string oldPassword, string newPassword)
        {
            if (newPassword.Length > 7 && oldPassword == GetAdminPassword())
            {
                return DataLogic.ChangeAdminPassword(oldPassword, newPassword);
            }
            return false;
        }
        public string GetPlayerUsername(string name)
        {
            return DataLogic.GetPlayerUsername(name);
        }
        public void UpdatePlayerHistory(string name)
        {
            int error = 3 - Lives();
            int score = ShowScore();
            string scores = score.ToString();
            
            string user = GetPlayerUsername(name);
            DataLogic.AddScoreList(user, score, error);
        }
    }

}
