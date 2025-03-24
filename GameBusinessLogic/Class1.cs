using System;
namespace GameBusinessLogic;

public class GameBL
{
    static int score = 0;
    static int lives = 3;

    static string[] questions = { "Y E E S", "N S P I", "S A C H", "C E H S S",  "H A L K C" };
    static string[] answers = { "EYES", "SPIN", "CASH", "CHESS",  "CHALK" };
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
    public static string Questions(int i)
    {
        return questions[i];
    }
    public static string Answers(int i)
    {
        return answers[i];
    }
    public static int TotalQuestions()
    {
        return questions.Length;
    }
    
}
