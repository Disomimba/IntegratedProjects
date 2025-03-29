using System;
namespace GameBusinessLogic;

public class GameBL
{
    static int score = 0;
    static int lives = 3;
    static int adminPin = 0000;
    static int questionShuffler;
    public static string username = "";
    static string[] questions = { "YEES", "NSPI", "SACH", "CEHSS", "HALKC" };
    static string[] answers = { "EYES", "SPIN", "CASH", "CHESS", "CHALK" };
    public static List<int> givenIndex = new List<int>();
    public static List<string> questionsList = new List<string>(questions);
    public static List<string> answersList = new List<string>(answers);
    public static List<string> scoreList = new List<string>();
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
        givenIndex.RemoveRange(0, TotalWords());
        lives = 3;
        score = 0;
    }
    public static void Leaderboards(string playerUsername, int playerScore)
    {
        scoreList.Add(playerUsername + "\t" + playerScore);
    }
    public static void RandomizerQuestion()
    {
        Random questionRandom = new Random();

        questionShuffler = questionRandom.Next(TotalWords() );

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
    public static void LeaderboardClear()
    {
        scoreList.Clear();
    }
    public static void AddShuffledWords(string newAnswer, string newShuffled)
    {
        answersList.Add(newAnswer);
        questionsList.Add(newShuffled);
    }
    public static bool PinValidator(int inputtedPin)
    {
        return adminPin == inputtedPin;
    }
    public static void ChangePIN(int inputtedPin)
    {
        adminPin = inputtedPin;
    }
    
    public static string ShowQuestionAndAnwers(int i)
    {
        return i + 1 + ". " + questionsList[i] + "\t" + answersList[i];
    }
    public static bool WelcomeMenuValidator(int userActions)
    {
        if(userActions >= 1 && userActions <= 4 )
        {
            return true;
        }
        return false;
    }
    
    public static bool AdminMenuValidator(int adminActions)
    {
        if (adminActions >= 1 && adminActions <= 5)
        {
            return true;
        }
        return false;
    }
    public static string PlayerUsername()
    {
        return username;
    }
    public static void ChangeUsername(string newUsername)
    {
        username = newUsername;
    }
    
}
