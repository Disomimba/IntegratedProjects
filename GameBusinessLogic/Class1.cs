using System;
namespace GameBusinessLogic;

public class GameBL
{
    static int score = 0;
    static int lives = 3;
    static int adminPin = 0000;

    static string[] questions = { "YEES", "NSPI", "SACH", "CEHSS",  "HALKC" };
    static string[] answers = { "EYES", "SPIN", "CASH", "CHESS",  "CHALK" };
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
    public static void Reset()
    {
        lives = 3;
        score = 0;
    }
    public static void Leaderboards(string playerUsername, int playerScore)
    {
        scoreList.Add(playerUsername + "\t" + playerScore);
        
    }
    public static string QuestionsList(int i)
    {
        return questionsList[i];
    }
    public static string AnswersList(int i)
    {
        return answersList[i];
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
            return i + 1 + ". " +questionsList[i] + "\t" + answersList[i];
    }

}
