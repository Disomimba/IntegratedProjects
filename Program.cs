using GameBusinessLogic;
namespace Project_1
{
    internal class Program
    {
        static string ign = "";
        static string playersScore = "";
        static int adminPin = 0000;
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
                    Admin();
                    break;
                case 2:
                    Username(ign);
                    break;
                case 3:
                    Leaderboards(playersScore);
                    break;
                default:
                    Console.WriteLine("Please select 1-4 only.");
                    WelcomePage();
                    break;
            }
        }
        static void Admin()
        {

            Console.Write("Enter Pin : ");
            int pin = Convert.ToInt16(Console.ReadLine());
            if (pin == adminPin)
            {
                //Console.Write("Success Pin! \n Features Coming Soon : \n[1] Delete a user\n[2] Add Words");
                Console.Write("Success Pin! \n\n [1] Clear Leaderboards\n [2] Change Pin\n [3] Exit\nEnter Action : ");
                int adminAction = Convert.ToInt16(Console.ReadLine());
                if (adminAction == 1)
                {
                    GameBL.scoreList.Clear();
                    Console.WriteLine("Leaderboards Cleared!");
                    Console.ReadKey();
                    Admin();
                }
                else if (adminAction == 3)
                {
                    AdminChangePin();

                }
                else if (adminAction == 2)
                {
                    WelcomePage();

                }
                else
                {
                    Console.WriteLine("Invalid Choice : Please select 1 or 2");
                    Admin();
                }
            }
            else
            {
                Console.Write("Incorrect Pin! \n Features Coming Soon : \n[1] Delete a user\n[2] Add Words");
                Console.ReadKey();
                WelcomePage();
            }
        }
        static void AdminChangePin()
        {
            Console.Write("Enter your new pin : ");
            adminPin = Convert.ToInt16(Console.ReadLine());
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
                Console.WriteLine("---------------------");
                ActualGame(ign);
            }
            else if (playerChoice == 2)
            {
                Console.WriteLine("---------------------");
                Console.Write("Rules & Mechanics\n1 - In this game, you'll be given shuffled words to arrange." +
                    "\n2 - Answer must be Capitalize." +
                    "\n3 - Answer shouldn't contains spaces." +
                    "\n4 - You only have 3 lives.\n");

                Console.WriteLine("\nPress any key to go back");
                Console.ReadKey();
                Player(ign);
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
        static void Username(string ign)
        {
            Console.WriteLine("---------------------");
            Console.Write("Enter your Username : ");
            ign = Console.ReadLine();
            Player(ign);
        }
        static void ActualGame(string ign)
        {
            Console.WriteLine(ign + " you have " + GameBL.Lives() + " tries.");
            int i = 0;
            while (i < GameBL.TotalQuestions() && GameBL.Lives() > 0)
            {
                int shuffleNumber = i + 1;
                Console.WriteLine("\nShuffled Word no. " + shuffleNumber);
                Console.WriteLine("\nArrange the letters\n" + GameBL.Questions(i) + "\n");
                string ans = Console.ReadLine();
                if (ans == GameBL.Answers(i))
                {
                    Console.WriteLine("\nCORRECT! : GUESS");
                    Console.WriteLine("---------------------");
                    GameBL.Correct();
                }
                else
                {
                    GameBL.Incorrect();
                    Console.WriteLine("\nINCORRECT! : GUESS");
                    Console.WriteLine("\nYour current lives is " + GameBL.Lives());
                    Console.WriteLine("---------------------");

                    if (GameBL.Lives() == 0)
                    {
                        Console.WriteLine("GAME OVER");
                    }
                }
                i++;
            }
            Console.WriteLine("Your Score is : " + GameBL.ShowScore());
            Console.WriteLine("\n\nDo you want to try again?\n\nPress 1 if 'Yes', Any number if No");
            Console.Write("\nI will select no. ");
            int playAgain = Convert.ToInt16(Console.ReadLine());

            if (playAgain != 1)
            {
                Console.Write("Thank You for playing");
                Console.ReadKey();
                GameBL.Leaderboards(ign, GameBL.ShowScore());
                GameBL.Reset();
                WelcomePage();
            }
            else
            {
                GameBL.Reset();
                Console.WriteLine("---------------------");
                ActualGame(ign);
            }
        }
        
        static void Leaderboards(String scores)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("LEADERBOARDS");
            foreach(var displayScores in GameBL.scoreList)
            {
                Console.WriteLine(displayScores);
            }
            Console.ReadKey();
            WelcomePage();
        }
    }
}
