using ShuffledWordGameDL;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace ShuffledWordGameBL
{
    public class GameBL
    {
        static int score = 0;
        static int lives = 3;
        static int questionShuffler;

        static string[] questions = { "YEES", "NSPI", "SACH", "CEHSS", "HALKC" };
        static string[] answers = { "EYES", "SPIN", "CASH", "CHESS", "CHALK" };
        static List<int> givenIndex = new List<int>();
        static List<string> questionsList = new List<string>(questions);
        static List<string> answersList = new List<string>(answers);
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
            return questionsList.Count();
        }
        public static void Reset()
        {
            givenIndex.Clear();
            lives = 3;
            score = 0;
        }
        public static string Shuffle(string word)
        {
            char[] wordToChar = word.ToCharArray();
            List<char> lettersChar = new List<char>(wordToChar);
            Random numberRandom = new Random();
            string wordShuffled = "";

            while (0 < lettersChar.Count)
            {
                int randomIndex = numberRandom.Next(lettersChar.Count);
                wordShuffled += lettersChar[randomIndex];
                lettersChar.RemoveAt(randomIndex);
            }

            return wordShuffled;

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
            return questionsList[questionShuffler];
        }
        public static string AnswersList()
        {
            return answersList[questionShuffler];
        }
        public static void AddShuffledWords(string newAnswer, string newShuffled)
        {
            answersList.Add(newAnswer);
            questionsList.Add(newShuffled);
        }
        public static string ShowWord(int i)
        {
            return i + 1 + ". " + answersList[i];
        }
        public static bool MenuValidator(Actions userAction, int number)
        {
            bool result = false;
            if (userAction == Actions.Welcome && number >= 1 && number <= 5)
            {
                result = true;
            }
            if (userAction == Actions.Admin && number >= 1 && number <= 5)
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
        public static string AccountVerifier(string Username, string Pass)
        {
            string Account = "Invalid";
            if (ShuffledWordDataLogic.VerifyAdminAccount(Username, Pass))
            {
                return Account = "Admin";
            }
            else if (ShuffledWordDataLogic.VerifyAccount(Username, Pass))
            {
                return Account = "Player";
            }

            return Account;
        }
        public static string PlayerName(string Username)
        {
            return ShuffledWordDataLogic.GetPlayerName(Username);
        }
        public static string GetUsername(string name)
        {
            return ShuffledWordDataLogic.GetUsername(name);
        }
        public static void UpdatePlayerHistory(string name, int score)
        {
            int error = 3 - Lives();
            string scores = score.ToString();
            string user = ShuffledWordDataLogic.GetUsername(name);
            ShuffledWordDataLogic.Score(user, score);
            ShuffledWordDataLogic.GameHistoryAdd(user, scores, error);
        }
        public static string ShowPlayerHistory(string user)
        {
            return ShuffledWordDataLogic.PlayerHistory(user);
        }
        public static bool CreateAccount(string name, string username, string password)
        {
            return ShuffledWordDataLogic.CreateAccount(name, username, password);
        }
        public static string DisplayLeaderboard()
        {
            return ShuffledWordDataLogic.DisplayLeaderboard();
        }
        public static void ClearLeaderboard()
        {
            ShuffledWordDataLogic.ClearLeaderboards();
        }
    }

}
