﻿using ShuffledWordGameBL;
using ShuffledWordGameDL;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Xml.Linq;
namespace Project_1
{
    internal class Program
    {
        static GameBL BusinessLogic = new GameBL();
        static string password = string.Empty;

        static void Main(string[] args)
        {
            File.Create("accounts.json");
            Console.WriteLine("Welcome to Mekus Mekus Game");
            WelcomePage();
            BusinessLogic.GetAccounts();
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
                string? input = Console.ReadLine();
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
            Console.WriteLine("Username must be greater than or equal to 4 characters.\nPassword must be greater than or equal to 8 characters.");
            Console.WriteLine("---------------------");
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Username: ");
            string username = Console.ReadLine().ToUpper();
            Console.Write("Create Password: ");
            string password = Console.ReadLine();

            if (BusinessLogic.CreateAccount(name, username, password))
            {
                Console.WriteLine("Account created successfully!");
            }
            else
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Account creation failed. \nUername already exist or your username and password doesn't meet the requirements");
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

                Account = BusinessLogic.AccountVerifier(username, password);
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
                string pin = BusinessLogic.GetAdminPassword();
                AdminMenu(pin);
            }
            else if (Account == "Player")
            {
                string playerName = BusinessLogic.PlayerName(username);
                Player(playerName);
            }
        }
        static void AdminMenu(string pin)
        {
            while (true)
            {
                Console.WriteLine("---------------------");
                Console.Write("Correct Pin!\n" +
                    "[1] Clear Leaderboards\n" +
                    "[2] Add Word\n" +
                    "[3] Show Words\n" +
                    "[4] Remove Word\n" +
                    "[5] Change Admin Password\n" +
                    "[6] Exit\nEnter Action : ");
                int adminAction = Convert.ToInt16(Console.ReadLine());
                if (GameBL.MenuValidator(Actions.Admin, adminAction))
                {
                    switch (adminAction)
                    {
                        case 1:
                            Console.WriteLine("---------------------");
                            Console.WriteLine("Leaderboards Cleared!");
                            BusinessLogic.ClearLeaderboard();
                            Console.ReadKey();
                            AdminMenu(pin);
                            break;
                        case 2:
                            AddWord(pin);
                            break;
                        case 3:
                            ShowWords(pin);
                            break;
                        case 4:
                            RemoveWords(pin);
                            break;
                        case 5:
                            ChangeAdminPassword(pin);
                            break;
                        case 6:
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
        public static void ChangeAdminPassword(string pin)
        {
            Console.WriteLine("---------------------");
            Console.Write("Enter your old password : ");
            string oldPass = Console.ReadLine();
            Console.Write("Enter your new password : ");
            string newPass = Console.ReadLine();
            if (BusinessLogic.ChangeAdminPassword(pin, newPass))
            {
                Console.WriteLine("Change password success.");
            }
            else
            {
                Console.WriteLine("Change password failed.");
            }
        }
        public static void RemoveWords(string pin)
        {
            Console.WriteLine("---------------------");

            Console.WriteLine("Words");
            for (int i = 0; i <= GameBL.TotalWords() - 1; i++)
            {
                Console.WriteLine(GameBL.ShowWord(i));
            }
            Console.Write("Enter the number you want to remove : ");
            int wordToRemove = Convert.ToInt16(Console.ReadLine());
            wordToRemove--;
            if (BusinessLogic.RemoveWords(wordToRemove))
            {
                Console.WriteLine("Word removed successfully!");
            }
            else
            {
                Console.WriteLine("Index out of Bounds.");
            }
            AdminMenu(pin);
        }
        static void AddWord(string pin)
        {
            Console.WriteLine("---------------------");

            string newArrangedWord = "";
            do
            {
                Console.Write("Enter a word (or type 'exit' to quit) : ");
                newArrangedWord = Console.ReadLine().ToUpper();
                if (newArrangedWord != "EXIT")
                {
                    if (GameBL.AddShuffledWords(newArrangedWord))
                    {
                        Console.WriteLine("New word added successfully!");
                        Console.WriteLine("---------------------");
                    }
                    else
                    {
                        Console.WriteLine("Word already Exist.");
                        Console.WriteLine("---------------------");
                    }
                }

            } while (newArrangedWord != "EXIT");
            AdminMenu(pin);
        }
        static void ShowWords(string pin)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("Words");
            for (int i = 0; i <= GameBL.TotalWords() - 1; i++)
            {
                Console.WriteLine(GameBL.ShowWord(i));

            }
            Console.Write("Enter any key to go back.");
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
                    else if (playerChoice == 4)
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

            string username = BusinessLogic.GetPlayerUsername(name);

            if (BusinessLogic.ChangePassword(username, oldPass, newPass))
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
            string user = BusinessLogic.GetPlayerUsername(name);
            Console.WriteLine(BusinessLogic.ShowPlayerHistory(user));
            Console.WriteLine("\nPress any key to go back");
            Console.ReadKey();
        }
        static void Start(string name)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"{name}, you have {GameBL.Lives()} tries.");

            for (int i = 0; i <= GameBL.TotalWords() - 1 && GameBL.Lives() > 0; i++)
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
                BusinessLogic.UpdatePlayerHistory(name);
                GameBL.Reset();
            }
        }
        static void Leaderboards()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("LEADERBOARDS");
            Console.WriteLine(BusinessLogic.DisplayLeaderboard());
            Console.ReadKey();
            WelcomePage();
        }
    }
}
