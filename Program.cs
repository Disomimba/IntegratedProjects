using GameBusinessLogic;
using System.Net.NetworkInformation;
namespace Project_1
{
    internal class Program
    {
        static string playersScore = "";
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mekus Mekus Game");
            WelcomePage();
        }
        static void WelcomePage()
        {
            int action;
            do
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("[1] Admin\n" +
                    "[2] Player\n" +
                    "[3] Leaderboards\n" +
                    "[4] Exit");
                Console.Write("Enter Action : ");
                action = Convert.ToInt16(Console.ReadLine());
                if (GameBL.WelcomeMenuValidator(action))
                {
                    switch (action)
                    {
                        case 1:
                            AdminLogin();
                            break;
                        case 2:
                            Username(GameBL.username);
                            break;
                        case 3:
                            Leaderboards(playersScore);
                            break;
                        case 4:
                            Console.WriteLine("Until next time, word wizard!");
                          
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            } while (action != 4);
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
            while (true)
            {
                Console.WriteLine("---------------------");
                Console.Write("Correct Pin!\n" +
                    "[1] Clear Leaderboards\n" +
                    "[2] Change Pin\n" +
                    "[3] Add Word\n" +
                    "[4] Show Arranged and Shuffled Words\n" +
                    "[5] Exit\nEnter Action : ");
                int adminAction = Convert.ToInt16(Console.ReadLine());
                if (GameBL.AdminMenuValidator(adminAction))
                {
                    switch (adminAction)
                    {
                        case 1:
                            GameBL.LeaderboardClear();
                            Console.WriteLine("---------------------");
                            Console.WriteLine("Leaderboards Cleared!");
                            Console.ReadKey();
                            AdminMenu(pin);
                            break;
                        case 2:
                            AdminChangePin();
                            break;
                        case 3:
                            AddWord(pin);
                            break;
                        case 4:
                            ShowWords(pin);
                            break;
                        case 5:
                            WelcomePage();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }

        }
        static void AddWord(int pin)
        {
            Console.WriteLine("---------------------");
            
            string newArrangedWord = "";
            do
            {
                Console.Write("Enter a word (or type 'exit' to quit) : ");
                 newArrangedWord = Console.ReadLine().ToUpper();
                if (newArrangedWord != "EXIT")
                {
                    string newWord = GameBL.Shuffle(newArrangedWord);
                    GameBL.AddShuffledWords(newArrangedWord, newWord);
                    Console.WriteLine("New word added successfully!");
                    Console.WriteLine("---------------------");
                }
                
            } while (newArrangedWord != "EXIT");
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
        static void Player(string username)
        {

            Console.WriteLine("---------------------");
            Console.WriteLine("Welcome to Mekus Mekus Game " + username);
            Console.WriteLine("\n[1]Start\n[2]Rules & Mechanics\n[3]Change Username\n[4]Exit");
            Console.Write("\nI will select no. ");
            int playerChoice = Convert.ToInt16(Console.ReadLine());

            if (playerChoice == 1)
            {
                Start(username);
            }
            else if (playerChoice == 2)
            {
                GameMechanics(username);
            }
            else if (playerChoice == 3)
            {
                Username(username);
            }
            else if (playerChoice == 4)
            {
                WelcomePage();
            }
            else
            {
                Console.WriteLine("\n\nInvalid Choice, Please Select again.\n\n");
                Player(username);
            }
        }
        static void GameMechanics(string ign)
        {
            Console.WriteLine("---------------------");
            Console.Write("Rules & Mechanics\n1 - In this game, you'll be given shuffled words to arrange." +
                "\n2 - Answer shouldn't contains spaces." +
                "\n3 - You only have 3 lives.\n");

            Console.WriteLine("\nPress any key to go back");
            Console.ReadKey();
            Player(ign);
        }
        static void Username(string username)
        {
            Console.WriteLine("---------------------");
            Console.Write("Enter your Username : ");
            string newName = Console.ReadLine();
            if(newName == "" || newName == username) 
            {
                Console.WriteLine("Username unchanged.");
                Player(username);
            }
            else
            {
                GameBL.ChangeUsername(newName);
                Player(GameBL.PlayerUsername());
            }
            
        }
        static void Start(string username)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"{username}, you have {GameBL.Lives()} tries.");

            for (int i = 0; i <= GameBL.TotalWords() - 1&& GameBL.Lives() > 0; i++)
            {
                Game(i);
            }

            DisplayFinalScore(username);
        }
        static void Game(int i)
        {
            GameBL.RandomizerQuestion();
            Console.WriteLine($"\nShuffled Word no. {i + 1}");
            Console.WriteLine($"\nArrange the letters\n{GameBL.QuestionsList()}\n");
            string answer = Console.ReadLine().ToUpper();
            if (answer == GameBL.AnswersList())
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
            Console.WriteLine($"Your Score is: {GameBL.ShowScore()} out of {GameBL.TotalWords()}");
            Console.Write("\n\nDo you want to try again? (type Y to Continue):");
            string playAgain = Console.ReadLine().ToUpper();
            if (playAgain == "Y")
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
