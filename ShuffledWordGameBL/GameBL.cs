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
        int otp;
        static ShuffledWordDataLogic DataLogic = new ShuffledWordDataLogic();
        static List<int> givenIndex = new List<int>();

        private readonly EmailService _emailService;
        public GameBL(EmailService emailService)
        {
            Shuffle();
            _emailService = emailService;
        }
        public bool OTPSender(string email)
        {
            Random OTPGenerator = new Random();
            otp = OTPGenerator.Next(100000, 1000000);
            string username = VerifyAccountExistingEmail(email);
            if (username != null)
            {
                _emailService.SendEmail(username,otp, email);
                return true;
            }
            return false;
        }
        public bool OTPVerifier(int OTP)
        {
            if (OTP == otp)
            {
                return true;
            }
            return false;
        }
        public void Shuffle()
        {
            int i = 0;
            foreach (var word in GetAdminAccounts()[0].ArrangedWord)
            {
                char[] wordToChar = word.ToString().ToCharArray(); 
                List<char> lettersChar = new List<char>(wordToChar);
                Random numberRandom = new Random();
                string wordShuffled = "";

                while (0 < lettersChar.Count)
                {
                    int randomIndex = numberRandom.Next(lettersChar.Count);
                    wordShuffled += lettersChar[randomIndex];
                    lettersChar.RemoveAt(randomIndex);
                }

                DataLogic.InsertShuffledWord(wordShuffled);
                i++;
            }
        }
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
        public int TotalWords()
        {
            return GetAdminAccounts()[0].ArrangedWord.Count;
        }
        public static void Reset()
        {
            givenIndex.Clear();
            lives = 3;
            score = 0;
        }
        public void FindPlayerHighScore(string username)
        {
            int playerHighScore = 0;
            foreach (var accounts in GetAccounts())
            {
                if (accounts.Username == username)
                {
                    playerHighScore = accounts.Score.Max();
                    TopPlayers(username, playerHighScore);
                }
            }
        }
        public void TopPlayers(string username, int score)
        {
            if (score > 0)
            {
                bool playerExists = false;

                foreach (var leaderboard in GetLeaderboardAccounts())
                {
                    if (leaderboard.Username == username)
                    {
                        playerExists = true;
                        if (score > leaderboard.Score)
                        {
                            leaderboard.Score = score;
                            DataLogic.AddToLeaderboard(leaderboard);
                        }
                        break;
                    }
                }

                if (!playerExists)
                {
                    var accountData = new Leaderboards
                    {
                        Username = username,
                        Score = score
                    };
                    DataLogic.AddToLeaderboard(accountData);
                }
                BubbleSort(GetLeaderboardAccounts().Count());
            }

        }
        public void BubbleSort(int size)
        {
            var leaderboards = GetLeaderboardAccounts();
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1 - i; j++)
                {
                    if (leaderboards[j].Score < leaderboards[j + 1].Score)
                    {
                        var temp = leaderboards[j];
                        leaderboards[j] = leaderboards[j + 1];
                        leaderboards[j + 1] = temp;
                    }
                }
            }
        }
        public  void RandomizerQuestion()
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
        public static bool AddShuffledWords(string newAnswer)
        {
            return DataLogic.InsertNewWord(newAnswer);
        }
        public List<string> ShowWord()
        {
            return GetAdminAccounts()[0].ArrangedWord;
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
        public string GetPlayerName(string Username)
        {
            foreach (var accounts in GetAccounts())
            {
                if (accounts.Username == Username)
                {
                    return accounts.Name;
                }
            }
            return null;
        }
        public List<string> ShowPlayerHistory(string user)
        {
            foreach(var accounts in GetAccounts())
            {
                if (accounts.Username == user)
                {
                    return accounts.History;
                }
            }
            return null;
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
        public bool ForgotPassword(string newPassword, string email)
        {
            
            return DataLogic.ForgotPassword(newPassword, email);
        }
        public List<GameAccounts> GetAccounts()
        {
            return DataLogic.GetPlayerAccounts();
        }
        public List<AdminData> GetAdminAccounts()
        {
            return DataLogic.GetAdminAccounts();
        }
        public string DisplayQuestion()
        {
            return GetAdminAccounts()[0].ShuffledWord[questionShuffler];
        }
        public string AnswerList()
        {
            return GetAdminAccounts()[0].ArrangedWord[questionShuffler];
        }
        public bool VerifyAccountExisting(string username)
        {
            
            List<GameAccounts> accounts = GetAccounts();
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
        public string VerifyAccountExistingEmail(string email)
        {
            foreach (var users in GetAccounts()) {
                if (users.Email == email) {
                    string username = users.Username;
                    return username;
                }
            }
            return null;
        }
        public bool CreateAccount(string name, string userEmail, string username, string password)
        {
            if (!username.Contains("ADMIN"))
            {

                if (username.Length > 3 && password.Length > 7)
                {
                    if (!VerifyAccountExisting(username))
                    {
                        DataLogic.CreateAccount(name, userEmail, username, password);
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
            foreach (var accounts in GetAccounts())
            {
                if (accounts.Name == name)
                {
                    return accounts.Username;
                }
            }
            return null;    
        }
        public void UpdatePlayerHistory(string name)
        {
            int error = 3 - Lives();
            int score = ShowScore();
            string scores = score.ToString();
            
            string user = GetPlayerUsername(name);
            DataLogic.AddScoreList(user, score, error);
            FindPlayerHighScore(user);
        }
    }

}
