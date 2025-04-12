using ShuffledWordGameBL;
using ShuffledWordGameDL;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Xml.Linq;
namespace Project_1
{
    internal class Program
    {
        static int playersScore = 0;
        static string password = string.Empty;
        
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
                Console.WriteLine("[1] Register\n" +
                    "[2] Login\n" +
                    "[3] Leaderboards\n" +
                    "[4] Exit");
                Console.Write("Enter Action : ");
                string? input  = Console.ReadLine();
                if (int.TryParse(input, out action) && GameBL.WelcomeMenuValidator(action))
                {
                    switch (action)
                    {
                        case 1:
                            CreateAccount();
                            break;
                        case 2:
                            Login();
                            break;
                        case 3:
                            Leaderboards();
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
        public static void CreateAccount()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Username must be greater than 4 characters.\nPassword must be greater than or equal to 8 characters.");
            Console.WriteLine("---------------------");
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Username: ");
            string username = Console.ReadLine().ToUpper();
            Console.Write("Create Password: ");
            string password = Console.ReadLine();

            if (GameBL.CreateAccount(name, username, password))
            {
                Console.WriteLine("Account created successfully!");
            }
            else
            {
                Console.WriteLine("Account creation failed. \nPlease ensure your username and password meet the requirements\nUername already exist.");
            }
        }
        static void Login()
        {
            string Account = string.Empty;
            string username = string.Empty;
            string password = string.Empty;
            do
            {
                Console.WriteLine("---------------------");
                Console.Write("Username : ");
                 username = Console.ReadLine().ToUpper();
                Console.Write("Password : ");
                 password = Console.ReadLine();

                Account = GameBL.AccountVerifier(username, password);
                if (Account == "Invalid")
                {
                    Console.WriteLine("Invalid Account");
                }
                else if (Account == "Admin" || Account == "Player")
                {
                    Console.WriteLine("Login Success");
                }
            } while (Account == "Invalid");
            if (Account == "Admin")
            {
                int pin = 0000;
                AdminMenu(pin);
            }
            else if (Account == "Player")
            {
                string playerName = GameBL.PlayerName(username);
                Player(playerName);
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
                if (GameBL.MenuValidator(Actions.Admin, adminAction))
                {
                    switch (adminAction)
                    {
                        case 1:
                            //temporary
                            Console.WriteLine("---------------------");
                            Console.WriteLine("Leaderboards Cleared!");
                            GameBL.ClearLeaderboard();
                            Console.ReadKey();
                            AdminMenu(pin);
                            break;
                        case 2:
                            AdminChangePin(pin);
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
        static void AdminChangePin(int pin)
        {
            Console.WriteLine("Coming soon");
            Console.ReadKey();
            AdminMenu(pin);
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
                    string ShuffledWord = GameBL.Shuffle(newArrangedWord);
                    GameBL.AddShuffledWords(newArrangedWord, ShuffledWord);
                    Console.WriteLine("New word added successfully!");
                    Console.WriteLine("---------------------");
                }
                
            } while (newArrangedWord != "EXIT");
            AdminMenu(pin);
        }
        static void ShowWords(int pin)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Words");
            for (int i = 0; i <= GameBL.TotalWords() - 1; i++)
            {
                Console.WriteLine(GameBL.ShowWord(i));

            }
            Console.WriteLine("Enter any key to go back.");
            Console.ReadKey();
            AdminMenu(pin);
        }
        static void Player(string name)
        {
            while (true)
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Welcome to Mekus Mekus Game " + name);
                Console.WriteLine("\n[1]Start\n[2]Rules & Mechanics\n[3]Change Password\n[4]History\n[5]Exit");
                Console.Write("\nEnter Action : ");
                int playerChoice = Convert.ToInt16(Console.ReadLine());
                if (GameBL.MenuValidator(Actions.Player, playerChoice))
                    {

                    if (playerChoice == 1)
                    {
                        Start(name);
                    }
                    else if (playerChoice == 2)
                    {
                        GameMechanics(name);
                    }
                    else if (playerChoice == 3)
                    {
                        ChangePassword(name);
                    }
                    else if(playerChoice == 4)
                    {
                        GameHistory(name);
                    }
                    else if (playerChoice == 5)
                    {
                        WelcomePage();
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid Choice, Please Select between 1 - 5.");
                    Player(name);
                }

            }
        }
        static void GameMechanics(string name)
        {
            Console.WriteLine("---------------------");
            Console.Write("Rules & Mechanics\n1 - In this game, you'll be given shuffled words to arrange." +
                "\n2 - Answer shouldn't contains spaces." +
                "\n3 - You only have 3 lives.\n");

            Console.WriteLine("\nPress any key to go back");
            Console.ReadKey();
            Player(name);
        }
        static void ChangePassword(string name)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("You are changing your password.");
            Console.Write("Enter your old password : ");
            string oldPass = Console.ReadLine();
            Console.Write("Enter your new password : ");
            string newPass = Console.ReadLine();

            string username = GameBL.GetUsername(name);
            
            if (ShuffledWordDataLogic.ChangePassword(username, oldPass, newPass))
            {
                Console.WriteLine("Change password success.");
            }
            else
            {
                Console.WriteLine("Change password failed.");
            }
        }
        static void GameHistory(string name)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("GAME HISTORY");
            string user = GameBL.GetUsername(name);
            Console.WriteLine(GameBL.ShowPlayerHistory(user));
            Console.WriteLine("\nPress any key to go back");
            Console.ReadKey();
        }
        static void Start(string name)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"{name}, you have {GameBL.Lives()} tries.");

            for (int i = 0; i <= GameBL.TotalWords() - 1&& GameBL.Lives() > 0; i++)
            {
                Game(i);
            }

            DisplayFinalScore(name);
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
        static void DisplayFinalScore(string name)
        {
            Console.WriteLine($"Your Score is: {GameBL.ShowScore()} out of {GameBL.TotalWords()}");
            Console.Write("\n\nDo you want to try again? (type Y to Continue):");
            string playAgain = Console.ReadLine().ToUpper();
            if (playAgain == "Y")
            {
                GameBL.Reset();
                Start(name);
            }
            else
            {
                Console.WriteLine("Until next time, word wizard!");
                Console.ReadKey();
                GameBL.UpdatePlayerHistory(name, GameBL.ShowScore());
                GameBL.Reset();
            }
        }
        static void Leaderboards()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("LEADERBOARDS");
            Console.WriteLine(GameBL.DisplayLeaderboard());
            Console.ReadKey();
            WelcomePage();
        }
    }
}
