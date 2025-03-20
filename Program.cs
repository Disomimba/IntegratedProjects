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
                    Console.Write("Coming soon.");
                    break;
                case 2:
                    Console.WriteLine("---------------------");
                    Console.Write("Enter your Username : ");
                    string ign = Console.ReadLine();
                    player(ign);
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
        static void player(string ign)
        {

            Console.WriteLine("---------------------");
            Console.WriteLine("Welcome to Mekus Mekus Game " + ign);
            Console.WriteLine("\n[1]Start\n[2]Rules & Mechanics");
            Console.Write("\nI will select no. ");
            int playerChoice = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("---------------------");
            if (playerChoice == 1)
            {
                ActualGame(ign);
            }
            else if (playerChoice == 2)
            {
                Console.Write("Rules & Mechanics\n1 - In this game, you'll be given shuffled words to arrange." +
                    "\n2 - Answer must be Capitalize." +
                    "\n3 - Answer shouldn't contains spaces." +
                    "\n4 - You only have 3 lives.\n");

                Console.WriteLine("\nPress any key to go back");
                Console.ReadKey();
                player(ign);
            }
            else
            {
                Console.WriteLine("\n\nInvalid Choice, Please Select again.\n\n");
                player(ign);
            }
        }
        static void ActualGame(string ign)
        {
            int lives = 3;
            int score = 0;
            

            Console.WriteLine(ign + " you have " + lives + " tries.");

            string[] wordsEasy = { "Y E E S", "N S P I", "S A C H", "C E H S S", "W E R I S", "H A L K C" };
            string[] answersOfEasy = { "EYES", "SPIN", "CASH", "CHESS", "WIRES", "CHALK" };
            int i = 0;

            while (i < wordsEasy.Length && lives > 0)
            {
                int shuffleNumber = i + 1;
                Console.WriteLine("\nShuffled Word no. " + shuffleNumber);
                Console.WriteLine("\nArrange the letters\n" + wordsEasy[i] + "\n");
                string ans = Console.ReadLine();
                if (ans == answersOfEasy[i])
                {
                    Console.WriteLine("\nCORRECT! : GUESS");
                    Console.WriteLine("---------------------");
                    score++;
                }
                else
                {
                    lives--;
                    Console.WriteLine("\nINCORRECT! : GUESS");
                    Console.WriteLine("\nYour current lives is " + lives + "\n");
                    Console.WriteLine("---------------------");

                    if (lives == 0)
                    {
                        Console.WriteLine("GAME OVER");
                    }
                }
                i++;
            }
            Console.WriteLine("Your Score is : " + score);
            Console.WriteLine("\n\nDo you want to try again?\n\nPress 1 if 'Yes', Any number if No");
            Console.Write("\nI will select no. ");
            int playAgain = Convert.ToInt16(Console.ReadLine());

            if (playAgain != 1)
            {
                Console.Write("Thank You for playing");
                Console.ReadKey();
                playersScore += ign + "\t\t" + score +"\n";
                WelcomePage();
            }
            else
            {
                Console.WriteLine("---------------------");
                ActualGame(ign);

            }

        }
        static void Leaderboards(String scores)
        {
            Console.WriteLine("LEADERBOARDS");

            Console.WriteLine(scores);
            Console.ReadKey();
            WelcomePage();
        }
    }
}
