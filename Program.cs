using GameBusinessLogic;
using System.Net.NetworkInformation;
namespace Project_1
{
    internal class Program
    {
        static string ign = "";
        static string playersScore = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mekus Mekus Game");
            WelcomePage();
        }
        static void WelcomePage()
        {
            Console.WriteLine("---------------------");
            string[] listAction = { "[1] Admin", "[2] Player", "[3] Leaderboards", "[4] Exit" };
            foreach (string list in listAction)
            {
                Console.WriteLine(list);
            }
            Console.Write("Enter Action : ");
            int action = Convert.ToInt16(Console.ReadLine());
            switch (action)
            {
                case 1:
                    AdminLogin();
                    break;
                case 2:
                    Username(ign);
                    break;
                case 3:
                    Leaderboards(playersScore);
                    break;
                case 4:
                    Console.WriteLine("Until next time, word wizard!");
                    break;
                default:
                    Console.WriteLine("Please select 1 - 4 only.");
                    WelcomePage();
                    break;
            }
        }
        static void AdminLogin()
        {
            Console.WriteLine("---------------------");
            Console.Write("Enter Pin : ");
            int pin = Convert.ToInt16(Console.ReadLine());
            if (GameBL.PinValidator(pin))
            {
                AdminMenu(pin);
            }
            else
            {
                Console.WriteLine("Incorrect Pin!");
                Console.ReadKey();
                AdminLogin();
            }
        }
        static void AdminMenu(int pin)
        {
            Console.WriteLine("---------------------");
            Console.Write("Correct Pin!\n[1] Clear Leaderboards\n[2] Change Pin\n[3] Add Word\n[4] Show Arranged and Shuffled Words\n[4] Exit\nEnter Action : ");
            int adminAction = Convert.ToInt16(Console.ReadLine());
            if (adminAction == 1)
            {
                GameBL.LeaderboardClear();
                Console.WriteLine("---------------------");
                Console.WriteLine("Leaderboards Cleared!");
                Console.ReadKey();
                AdminMenu(pin);
            }
            else if (adminAction == 2)
            {
                AdminChangePin();

            }
            else if (adminAction == 3)
            {
                AddWord(pin);

            }
            else if (adminAction == 4)
            {
                ShowWords(pin);
            }
            else if (adminAction == 5)
            {
                WelcomePage();
                
            }
            else
            {
                Console.WriteLine("Invalid Choice : Please select 1 - 5");
                AdminMenu(pin);
            }
        }
        static void AddWord(int pin)
        {
            Console.WriteLine("---------------------");
            string addMore = "";
            do
            {
                Console.Write("Enter The Arranged Word : ");
                string newArrangedWord = Console.ReadLine().ToUpper();
                Console.Write("Enter the shuffled word  : ");
                string newShuffledWord = Console.ReadLine().ToUpper();
                GameBL.AddShuffledWords(newArrangedWord, newShuffledWord);
                Console.WriteLine("New shuffled and arranged word added successfully!");
                Console.Write("Would you like to add another word? (type 'YES' to continue, any other key to exit) : ");
                addMore = Console.ReadLine().ToUpper();
            } while (addMore == "YES");
            AdminMenu(pin);
        }
        static void ShowWords(int pin)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Shuffled \t Arranged");
            for (int i = 0; i <= GameBL.questionsList.Count() - 1; i++)
            {
                Console.WriteLine(GameBL.ShowQuestionAndAnwers(i));

            }
            Console.WriteLine("Enter any key to go back.");
            Console.ReadKey();
            AdminMenu(pin);
        }
        static void AdminChangePin()
        {
            Console.Write("Enter your new pin : ");
            int pin = Convert.ToInt16(Console.ReadLine());
            GameBL.ChangePIN(pin);
            AdminMenu(pin);
        }
        static void Player(string ign)
        {

            Console.WriteLine("---------------------");
            Console.WriteLine("Welcome to Mekus Mekus Game " + ign);
            Console.WriteLine("\n[1]Start\n[2]Rules & Mechanics\n[3]Change Username\n[4]Exit");
            Console.Write("\nI will select no. ");
            int playerChoice = Convert.ToInt16(Console.ReadLine());

            if (playerChoice == 1)
            {
                Start(ign);
            }
            else if (playerChoice == 2)
            {
                GameMechanics();
            }
            else if (playerChoice == 3)
            {
                Username(ign);
            }
            else if (playerChoice == 4)
            {
                WelcomePage();
            }
            else
            {
                Console.WriteLine("\n\nInvalid Choice, Please Select again.\n\n");
                Player(ign);
            }
        }
        static void GameMechanics()
        {
            Console.WriteLine("---------------------");
            Console.Write("Rules & Mechanics\n1 - In this game, you'll be given shuffled words to arrange." +
                "\n2 - Answer shouldn't contains spaces." +
                "\n3 - You only have 3 lives.\n");

            Console.WriteLine("\nPress any key to go back");
            Console.ReadKey();
            Player(ign);
        }
        static void Username(string ign)
        {
            Console.WriteLine("---------------------");
            Console.Write("Enter your Username : ");
            ign = Console.ReadLine();
            Player(ign);
        }
        static void Start(string ign)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"{ign}, you have {GameBL.Lives()} tries.");

            for (int i = 0; i < GameBL.questionsList.Count() && GameBL.Lives() > 0; i++)
            {
                Game(i);
            }

            DisplayFinalScore(ign);
        }
        static void Game(int i)
        {
            Console.WriteLine($"\nShuffled Word no. {i + 1}");
            Console.WriteLine($"\nArrange the letters\n{GameBL.QuestionsList(i)}\n");

            string answer = Console.ReadLine().ToUpper();
            if (answer == GameBL.AnswersList(i))
            {
                Console.WriteLine("\nCORRECT! : GUESS");
                Console.WriteLine("---------------------");
                GameBL.Correct();
            }
            else
            {
                GameBL.Incorrect();
                Console.WriteLine("\nINCORRECT! : GUESS");
                Console.WriteLine($"\nYour current lives is {GameBL.Lives()}");
                Console.WriteLine("---------------------");

                if (GameBL.Lives() == 0)
                {
                    Console.WriteLine("GAME OVER");
                }
            }
        }
        static void DisplayFinalScore(string ign)
        {
            Console.WriteLine($"Your Score is: {GameBL.ShowScore()}");
            Console.Write("\n\nDo you want to try again? (type YES to Continue):");
            string playAgain = Console.ReadLine().ToUpper();
            if (playAgain == "YES")
            {
                GameBL.Reset();
                Start(ign);
            }
            else
            {
                Console.WriteLine("Until next time, word wizard!");
                Console.ReadKey();
                GameBL.Leaderboards(ign, GameBL.ShowScore());
                GameBL.Reset();
                WelcomePage();
            }
        }
        static void Leaderboards(string scores)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("LEADERBOARDS");
            foreach (var displayScores in GameBL.scoreList)
            {
                Console.WriteLine(displayScores);
            }
            Console.ReadKey();
            WelcomePage();
        }
    }
}
